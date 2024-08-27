using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

using LIhaApiA5.Model;
namespace LihaApiA5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {
        private readonly string secretKey;

        public AutenticacionController(IConfiguration config)
        {
            secretKey = config.GetSection("settings").GetSection("secretkey").ToString();
        }
        [HttpPost]
        [Route("Validar")]
        public IActionResult Validar([FromBody] LoginUser request)
        {
            if (request.usuario == "carmen" && request.clave =="123456") {
            var keyBytes = Encoding.ASCII.GetBytes(secretKey);
                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.usuario));
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenconfig = tokenHandler.CreateToken(tokenDescriptor);
                string tokencreado = tokenHandler.WriteToken(tokenconfig);
                return StatusCode(StatusCodes.Status200OK, new { token =  tokencreado});
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { token = "no Autorizado"});
            }
        }
    }
}
