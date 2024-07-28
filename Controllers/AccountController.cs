using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskSystem.Models;

namespace TaskSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel login)
        {
            if (login.Login == "admin" && login.Password == "admin")
            {
                var token = GenerateTokenJWT();
                return Ok(new {token} );
            }
            return BadRequest(new {message = "Invalid credentials. Please check your login and password." });
        }

        private string GenerateTokenJWT()
        {
            string secretKey = "f64feb14-60a0-43d4-8592-58d97f16d4d8";

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim("login", "admin"),
            new Claim("admin", "System Admin")
        };

            var token = new JwtSecurityToken
            (
                issuer: "sua_empresa",
                audience: "sua_aplicacao",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credential

            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
