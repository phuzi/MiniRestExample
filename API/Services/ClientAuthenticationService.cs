using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Configuration;
using Azure.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace API.Services;

public class ClientAuthenticationService : IClientAuthenticationService
{
    private readonly JwtConfiguration _configuration;
    private readonly ApiCredentials _apiCredentials;

    public ClientAuthenticationService(IOptions<JwtConfiguration> jwtConfiguration, IOptions<ApiCredentials> credentials)
    {
        _configuration = jwtConfiguration.Value;
        _apiCredentials = credentials.Value;
    }

    public string Authenticate(string clientId, string clientSecret)
    {
        if (clientId != _apiCredentials.ClientId || clientSecret != _apiCredentials.ClientSecret)
        {
            throw new AuthenticationFailedException("ClientId and Secret are invalid");
        }

        var claims = new[] { new Claim("sub", clientId) };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.Key ?? string.Empty));

        var token = new JwtSecurityToken(
            issuer: _configuration.Issuer ?? string.Empty,
            audience: _configuration.Audience ?? string.Empty,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_configuration.Lifetime),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

public interface IClientAuthenticationService
{
    string Authenticate(string clientId, string clientSecret);
}