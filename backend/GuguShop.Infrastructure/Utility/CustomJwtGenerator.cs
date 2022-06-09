using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace GuguShop.Infrastructure.Utility;

public class CustomJwtGenerator: ICustomJwtGenerator
{
    private const string Secret = "JgqIeQULGfqiXjqVWlYS";
    private const string Issuer = "https://mysite.com";
    private const string Audience = "https://myaudience.com";
    private readonly ILogger<CustomJwtGenerator> _logger;
    public CustomJwtGenerator(ILogger<CustomJwtGenerator> logger)
    {
        _logger = logger;
    }
    public string GenerateToken(string userName)
    {
        var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, userName),
            }),
            Expires = DateTime.UtcNow.AddMinutes(2),
            Issuer = Issuer,
            Audience = Audience,
            SigningCredentials = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    
    public bool ValidateCurrentToken(string token)
    {
        var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
        var tokenHandler = new JwtSecurityTokenHandler();
        try
        {
            var claims = tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = Issuer,
                ValidAudience = Audience,
                IssuerSigningKey = mySecurityKey
            }, out var validatedToken);
        }
        catch(Exception ex)
        {
            _logger.LogError($"{ex.Message} {ex.StackTrace}");
            return false;
        }
        return true;
    }
}