using cm_be_biu.Models;
using cm_be_biu.Responses;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace cm_be_biu.Utils
{
    public sealed class JwtUtils(IConfiguration configuration)
    {
        public AuthResponse Generate(Usuario user)
        {
            string secretLKey = configuration["Jwt:Secret"]!;
            int expirationTime = configuration.GetValue<int>("Jwt:ExpirationInMinutes");
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(secretLKey));
            var credentias = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity([
                    new("idUser", user.Id.ToString()),
                    new("email", user.Correo),
                    new(ClaimTypes.Role, user.Rol.Nombre)
                ]
                ),
                Expires = DateTime.UtcNow.AddMinutes(expirationTime),
                SigningCredentials = credentias,
                Issuer = configuration["Jwt:Issuer"]!,
                Audience = configuration["Jwt:Audience"]!
            };
            var handler = new JsonWebTokenHandler();
            string token = handler.CreateToken(tokenDescriptor);

            AuthResponse response = new()
            {
                IdUser = user.Id,
                Email = user.Correo,
                Role = user.Rol.Nombre,
                Jwt = token,
                ExpirationTime = expirationTime
            };

            return response;
        }


    }
}
