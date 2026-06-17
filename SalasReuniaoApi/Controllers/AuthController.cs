using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SalasReuniaoApi.Auth;

namespace SalasReuniaoApi.Controllers
{
    [ApiController]
    [Route("login")]
    public class AuthController : ControllerBase
    {
        private const string chaveJwt = "MINHA_CHAVE_SUPER_SECRETA_123456_SALAS";

        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (login.Email == "admin@email.com" && login.Senha == "123456")
            {
                var tokenHandler = new JwtSecurityTokenHandler();

                var key = Encoding.UTF8.GetBytes(chaveJwt);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, login.Email)
                    }),

                    Expires = DateTime.UtcNow.AddHours(1),

                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature
                    )
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                var tokenString = tokenHandler.WriteToken(token);

                return Ok(new
                {
                    token = tokenString
                });
            }

            return Unauthorized("Email ou senha inválidos");
        }
    }
}