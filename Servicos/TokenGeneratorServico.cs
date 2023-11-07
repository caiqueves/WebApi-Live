using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using webApi_Live.Servicos.Interface;

namespace webApi_Live.Servicos
{

    public class TokenGeneratorServico : ITokenGeneratorServico
    {
        public string GenerateFixedToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AAAAAAA1212454545484FFGFGF"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "webApi",                  // Emissor (issuer)
                audience: "webApiLive",               // Audiência (audience)
                claims: new[]
                {
                new Claim(ClaimTypes.Name, "local"),
                new Claim(ClaimTypes.Role, "admin")
                },
                expires: DateTime.UtcNow.AddHours(1), // Tempo de expiração
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}