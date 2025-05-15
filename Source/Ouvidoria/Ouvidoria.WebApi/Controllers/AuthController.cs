using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Ouvidoria.Domain.Interfaces;
using Ouvidoria.WebApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ouvidoria.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly IUsuarioService _usuarioDomain;

        public AuthController(IConfiguration configuration, IUsuarioService usuarioDomain)
        {
            _configuration = configuration;            
            _usuarioDomain = usuarioDomain;
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUsuario item)
        {
          
            var usuario = _usuarioDomain.Autenticar(item.Login, item.Senha);

            if (usuario == null)
                return Unauthorized();

            // Geração do token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.NameIdentifier, usuario.CodUsuario.ToString()),
                new Claim(ClaimTypes.Name, usuario.Login),
                new Claim(ClaimTypes.Role, usuario.CodPerfil.ToString()) // Ajuste conforme necessário
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { Token = tokenString });
            
        }
    }
}
