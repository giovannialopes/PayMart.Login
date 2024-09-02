using Azure.Core;
using Microsoft.IdentityModel.Tokens;
using PayMart.Domain.Login.Entities;
using PayMart.Domain.Login.Security.Token;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PayMart.Infrastructure.Login.Security.Token;

public class JwtAcessToken(uint expirationTimeToken, string signingKey) : IJwtTokenGenerator
{
    public string Generator(LoginUser user, string request)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Expires = DateTime.UtcNow.AddMinutes(expirationTimeToken),
            SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature),
            Subject = new ClaimsIdentity(claims)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(securityToken);  
    }

    private SymmetricSecurityKey SecurityKey()
    {
        var key = Encoding.UTF8.GetBytes(signingKey);

        return new SymmetricSecurityKey(key);
    }

}
