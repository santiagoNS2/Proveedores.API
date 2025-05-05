using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Proveedores.API.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Proveedores.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;

        public AuthController(IOptions<JwtSettings> jwtOptions)
        {
            _jwtSettings = jwtOptions.Value;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Validación simulada (usuario fijo)
            if (request.Username != "admin" || request.Password != "1234")
                return Unauthorized(new { message = "Credenciales inválidas" });

            // Crear claims del usuario
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, request.Username),
                new Claim(ClaimTypes.Role, "Administrador")
            };

            // Generar token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationMinutes),
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { token = tokenString });
        }
    }

    // DTO para login
    /// <summary>
    /// Modelo para solicitar el inicio de sesión y obtener un token JWT.
    /// </summary>
    public class LoginRequest
    {
        /// <summary> Nombre de usuario del sistema. </summary>
        public string Username { get; set; } = null!;

        /// <summary> Contraseña del usuario. </summary>
        public string Password { get; set; } = null!;
    }
}
