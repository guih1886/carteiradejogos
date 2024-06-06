using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarteiraDeJogosForms.Classes;

public static class DeserizalizeJwt
{
    public static ClaimsPrincipal? JwtClaims(string token, string key)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        };
        try
        {
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            return principal;
        }
        catch (Exception)
        {
            return null;
        }
    }
}
