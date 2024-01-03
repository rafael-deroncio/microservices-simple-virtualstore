using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using VirtualStore.Identity.Core.Arguments;
using VirtualStore.Identity.Core.Configurations.Enums;
using VirtualStore.Identity.Core.Configurations.Mappers;
using VirtualStore.Identity.Core.Exceptions;
using VirtualStore.Identity.Core.Models;
using VirtualStore.Identity.Core.Repositories.Interfaces;
using VirtualStore.Identity.Domain.Requests;
using YamlDotNet.Core.Tokens;

namespace VirtualStore.Identity.Core.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly ITokenRepository _tokenRepository;
    private readonly IObjectConverter _objectConverter;
    private readonly ILogger<AuthorizeService> _logger;

    public TokenService(
        IConfiguration configuration, 
        ITokenRepository tokenRepository, 
        IObjectConverter objectConverter,
        ILogger<AuthorizeService> logger)
    {
        _configuration = configuration;
        _tokenRepository = tokenRepository;
        _objectConverter = objectConverter;
        _logger = logger;
    }

    public async Task<TokenModel> GenerateBearerAccessToken(RoleType role, IEnumerable<ClaimType> claims, string username)
    {

        _logger.LogInformation(string.Format("Starting access token generation for the user {0} with role {1}", username, role.ToString()));

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenExpires = GenerateTokenExpires();
        var tokenClaims = GenerateClaims(role, claims, username);
        var tokenCredentials = GenerateTokenCredentials();
        var tokenDescriptor = GenerateTokenDescriptor(tokenExpires, tokenCredentials, tokenClaims);

        var token = tokenHandler.CreateToken(tokenDescriptor);

        _logger.LogInformation(string.Format("Finishing access token generation for the user {0} with role {1}", username, role.ToString()));

        return await Task.FromResult<TokenModel>(
            new()
            {
                Message = "access-token-jwt-ok",
                TokenValue = "Bearer " + tokenHandler.WriteToken(token),
                Expires = tokenExpires
            });
    }

    public Task<TokenModel> GenerateBearerRefreshToken(RoleType role, string username)
    {
        _logger.LogInformation(string.Format("Starting refresh token generation for the user {0} with role {1}", username, role.ToString()));

        string combinedHash;
        string secretHash = _configuration["SecretHashRefreshToken"];
        string randomSequence = GetRandomSequence(length: 32);
        string combinedString = $"{randomSequence}.{username}.{role.GetDescription()}.{secretHash}";
        
        using (var sha256 = SHA256.Create())
        {
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(combinedString));
            combinedHash =  BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }

        _logger.LogInformation(string.Format("Finishing refresh token generation for the user {0} with role {1}", username, role.ToString()));

        return Task.FromResult(new TokenModel()
        {
            TokenValue = combinedHash,
            Expires = GerarRefreshTokenExpires(),
            Message = "refresh-token-jwt-ok"
        });
    }

    public async Task<(TokenModel, TokenModel)> RefreshToken(ValidateTokenRequest tokenRequest)
    {
        _logger.LogInformation(string.Format("Starting refresh token validation. RefreshToken: {0}", tokenRequest.RefreshToken));

        ClaimsPrincipal claimsPrincipal = GetClaimsPrincipal(tokenRequest);

        string username = GetClaimValue(claimsPrincipal, ClaimTypes.Name);
        RoleType role = (RoleType)Enum.Parse(typeof(RoleType), GetClaimValue(claimsPrincipal, ClaimTypes.Role));
        IEnumerable<ClaimType> claims = GetClaimsList(claimsPrincipal);

        var tokenSaved = await _tokenRepository.GetUserToken(TokenType.RefreshToken, username);

        if (tokenSaved == null || tokenSaved.TokenValue != tokenRequest.RefreshToken)
            throw new SecurityTokenException("invalid refresh token.");

        TokenModel newAccessToken = await SaveUserToken(username, role, claims, TokenType.AccessToken);
        TokenModel newRefreshToken = await SaveUserToken(username, role, claims, TokenType.RefreshToken);

        _logger.LogInformation(string.Format("Finishing refresh token validation. NewRefreshToken: {0}", newRefreshToken.TokenValue));

        return (
            newAccessToken,
            newRefreshToken
        );
    }

    public async Task<TokenModel> SaveUserToken(string username, RoleType role, IEnumerable<ClaimType> claims, TokenType tokenType)
    {
        TokenModel newToken = default;

        switch (tokenType)
        {
            case TokenType.AccessToken:
                newToken = await GenerateBearerAccessToken(role, claims, username);
                break;
            case TokenType.RefreshToken:
                newToken = await GenerateBearerRefreshToken(role, username);
                break;
        }

        if (newToken == default)
            throw new TokenException(string.Format("token type '{0}' not found", tokenType));

        _logger.LogInformation(string.Format("Disabling {0} user {1} tokens", username, tokenType.GetDescription()));
        await _tokenRepository.DisableTokens(username, tokenType);

        TokenArgument argument = _objectConverter.Map<TokenArgument>(newToken);
        argument.TokenType = tokenType.GetDescription();

        _logger.LogInformation(string.Format("Saving new {0} from user {1}", username, tokenType.GetDescription()));
        return await _tokenRepository.SaveUserToken(username, argument) ;
    }

    public async Task<TokenModel> GetUserToken(TokenType type, string username)
    {
        _logger.LogInformation(string.Format("Recovering {0} from user {1}", type.GetDescription(), username));
        return await _tokenRepository.GetUserToken(type, username);
    }

    public async Task DisableUserTokens(string username)
    {
        _logger.LogInformation(string.Format("Disabling {0} and {1} from user {2}", TokenType.AccessToken.GetDescription(), TokenType.RefreshToken.GetDescription(), username));
        await _tokenRepository.DisableTokens(username, TokenType.RefreshToken);
        await _tokenRepository.DisableTokens(username, TokenType.AccessToken);
    }

    #region privates
    private ClaimsPrincipal GetClaimsPrincipal(ValidateTokenRequest tokenRequest)
    {
        TokenValidationParameters tokenValidationParameters = new()
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSymmetricSecurityKey"])),
            ValidateLifetime = false,
        };

        tokenRequest.AccessToken = tokenRequest.AccessToken.Replace("Bearer ", "");

        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        var accessToken = tokenHandler.ValidateToken(tokenRequest.AccessToken, tokenValidationParameters, out var securityToken);

        if (securityToken is not JwtSecurityToken jwtSecurityToken ||
            !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("invalid access token");
        return accessToken;
    }

    private DateTime GenerateTokenExpires()
    {
        var expireHours = double.Parse(_configuration["JwtTokenSettings:ExpireHours"]);
        return DateTime.UtcNow.AddHours(expireHours);
    }

    private DateTime GerarRefreshTokenExpires()
    {
        var expireHours = double.Parse(_configuration["JwtTokenSettings:RefreshTokenExpireHours"]);
        return DateTime.UtcNow.AddHours(expireHours);
    }

    private static ClaimsIdentity GenerateClaims(RoleType role, IEnumerable<ClaimType> claims, string username)
    {
        ClaimsIdentity claimsIdentity = new ClaimsIdentity();
        claimsIdentity.AddClaim(new Claim(type: ClaimTypes.Role, value: role.ToString()));
        claimsIdentity.AddClaim(new Claim(type: ClaimTypes.Name, value: username));


        claimsIdentity.AddClaims(
            claims.Select(claim =>
            {
                return new Claim(type: claim.ToString(), value: claim.GetDescription());
            }));


        return claimsIdentity;
    }

    private SigningCredentials GenerateTokenCredentials()
    {
        string key = _configuration["JwtSymmetricSecurityKey"];
        SymmetricSecurityKey symmetricKey = new(Encoding.UTF8.GetBytes(key));
        return new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);
    }

    private static SecurityTokenDescriptor GenerateTokenDescriptor(DateTime tokenExpires, SigningCredentials tokenCredentials, ClaimsIdentity tokenClaims)
    {
        return new SecurityTokenDescriptor()
        {
            Subject = tokenClaims,
            Expires = tokenExpires,
            SigningCredentials = tokenCredentials
        };
    }

    private static string GetRandomSequence(int length)
    {
        var randomNumber = new byte[length];
        using var randomGenerator = RandomNumberGenerator.Create();
        randomGenerator.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    private static string GetClaimValue(ClaimsPrincipal claimsPrincipal, string claimType)
    {
        var claim = claimsPrincipal.FindFirst(claimType);
        return claim?.Value;
    }

    private static IEnumerable<ClaimType> GetClaimsList(ClaimsPrincipal claimsPrincipal)
    {
        List<ClaimType> claimsList = new List<ClaimType>();

        foreach (var claim in claimsPrincipal.Claims)
        {
            if (claim.Type == ClaimTypes.Role || claim.Type == ClaimTypes.Name)
                continue;

            if (Enum.TryParse(typeof(ClaimType), claim.Type, out var parsedClaim))
            {
                claimsList.Add((ClaimType)parsedClaim);
            }
        }

        return claimsList;
    }
    #endregion
}