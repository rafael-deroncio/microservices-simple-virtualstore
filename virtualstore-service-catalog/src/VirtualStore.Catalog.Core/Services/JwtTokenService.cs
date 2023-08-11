using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VirtualStore.Catalog.Core.Configurations.Enums;
using VirtualStore.Catalog.Core.Models;
using VirtualStore.Catalog.Core.Services.Interfaces;

namespace VirtualStore.Catalog.Core.Services;

public class JwtTokenService : IJwtTokenService
{
    private readonly IConfiguration _configuration;

    public JwtTokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<TokenModel> GenerateBearerToken()
    {
        (string token, DateTime expires) = GerarTokenJwt();

        return await Task.FromResult<TokenModel>(
            new()
            {
                Message = "Jwt Token - OK",
                Token = "Bearer " + token,
                Expires = expires
            });
    }

    private (string, DateTime) GerarTokenJwt()
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenExpires = GerarTokenExpires();
        var tokenClaims = GerarClaims();
        var tokenCredentials = GerarTokenCredentials();
        var tokenDescriptor = GerarTokenDescriptor(tokenExpires, tokenCredentials, tokenClaims);

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return (tokenHandler.WriteToken(token), tokenExpires);
    }

    private DateTime GerarTokenExpires()
    {
        var expireHours = double.Parse(_configuration["JwtTokenSettings:ExpireHours"]);
        return DateTime.UtcNow.AddHours(expireHours);
    }

    private static ClaimsIdentity GerarClaims()
    {
        return new(new[]
        {
                new Claim(type: ClaimTypes.Name, value: "microservice-request-client"),
                new Claim(type: ClaimTypes.Role, value: nameof(RoleEnum.MicroserviceRequestClient))
        });
    }

    private SigningCredentials GerarTokenCredentials()
    {
        string key = _configuration["JwtSymmetricSecurityKey"];
        SymmetricSecurityKey symmetricKey = new(Encoding.UTF8.GetBytes(key));
        return new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);
    }

    private static SecurityTokenDescriptor GerarTokenDescriptor(DateTime tokenExpires, SigningCredentials tokenCredentials, ClaimsIdentity tokenClaims)
    {
        return new SecurityTokenDescriptor()
        {
            Subject = tokenClaims,
            Expires = tokenExpires,
            SigningCredentials = tokenCredentials
        };
    }
}