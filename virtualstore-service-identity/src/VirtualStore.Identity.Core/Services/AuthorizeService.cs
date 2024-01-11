using VirtualStore.Identity.Core.Configurations.Enums;
using VirtualStore.Identity.Core.Exceptions;
using VirtualStore.Identity.Core.Managers.Interfaces;
using VirtualStore.Identity.Core.Models;
using VirtualStore.Identity.Core.Services.Interfaces;
using VirtualStore.Identity.Domain.Requests;
using VirtualStore.Identity.Domain.Responses;

namespace VirtualStore.Identity.Core.Services;

public class AuthorizeService : IAuthorizeService
{
    private readonly ITokenService _tokenService;
    private readonly IRoleManager _roleManager;

    public AuthorizeService(
        ITokenService jwtTokenService, 
        IRoleManager roleManager)
    {
        _tokenService = jwtTokenService;
        _roleManager = roleManager;

    }

    public async Task DisableUserTokens(string username)
    {
        await _tokenService.DisableUserTokens(username);
    }

    public async Task<TokenResponse> GetTokensAuthentication(TokenRequest request)
    {
        RoleType role = (RoleType)Enum.Parse(typeof(RoleType), request.Role);
        IEnumerable<ClaimType> claims = request.Claims.Select(claim => (ClaimType)Enum.Parse(typeof(ClaimType), claim));

        if (!await _roleManager.ContainsRole(role, request.Username))
            throw new AuthorizationTokenException(
                string.Format("User {0} canot contains role {1} in your profile.", request.Username, role.GetDescription()),
                ExceptionType.Error,
                System.Net.HttpStatusCode.Unauthorized);


        request.Claims.ToList().ForEach(async claim =>
        {
            ClaimType claimType = (ClaimType)Enum.Parse(typeof(ClaimType), claim);

            if (!await _roleManager.ContainsClaim(claimType, request.Username))
                throw new AuthorizationTokenException(
                    string.Format("User {0} canot contains claim {1} in your profile.", request.Username, claimType.GetDescription()),
                    ExceptionType.Error,
                    System.Net.HttpStatusCode.Unauthorized);
        });

        Models.TokenModel accessToken = await _tokenService.GetUserToken(TokenType.AccessToken, request.Username);
        Models.TokenModel refreshToken = await _tokenService.GetUserToken(TokenType.AccessToken, request.Username);

        if(accessToken == null || accessToken.Expires <= DateTime.Now || refreshToken == null)
        {
            accessToken = await _tokenService.SaveUserToken(request.Username, role, claims, TokenType.AccessToken);
            refreshToken = await _tokenService.SaveUserToken(request.Username, role, claims, TokenType.RefreshToken);
        }

        return new TokenResponse
        {
            AccessToken = new()
            {
                Token = accessToken.TokenValue,
                Expires = accessToken.Expires,
                Message = accessToken.Message
            },
            RefreshToken = new()
            {
                Token = refreshToken.TokenValue,
                Expires = refreshToken.Expires,
                Message = refreshToken.Message
            }
        };
    }

    public async Task<TokenResponse> RefreshTokensAuthentication(ValidateTokenRequest request)
    {
        (TokenModel accessToken, TokenModel refreshToken) = await _tokenService.RefreshToken(request);

        return new TokenResponse
        {
            AccessToken = new()
            {
                Token = accessToken.TokenValue,
                Expires = accessToken.Expires,
                Message = accessToken.Message
            },
            RefreshToken = new()
            {
                Token = refreshToken.TokenValue,
                Expires = refreshToken.Expires,
                Message = refreshToken.Message
            }
        };
    }

    public async Task<bool> ValidateRefreshToken(string refreshToken, string username)
    {
        return await _tokenService.GetUserToken(TokenType.RefreshToken, username) != null;
    }
}