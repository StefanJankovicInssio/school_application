using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using Presentation.UserDemo;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public AuthController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public static User user = new User();
        private readonly IConfiguration configuration;

        [HttpPost("registration")]
        public void Registration([FromBody]UserDto data)
        {
            user.Email = data.Email;
            user.PasswordSalt = RandomNumberGenerator.GetBytes(128 / 8);
            user.PasswordHash = CreatePasswordHash(data.Password, user.PasswordSalt);
        }

        [HttpPost("login")]
        public string Login([FromBody] LoginDto data)
        {
            if (user.Email != data.Email)
            {
                throw new Exception("Email is not valid");
            }

            if (user.PasswordHash != CreatePasswordHash(data.Password, user.PasswordSalt))
            {
                throw new Exception("Password is not valid");
            }

            string token = GenerateJSONWebToken(user);
         
            return token;
        }
       
        private static string CreatePasswordHash(string password, byte[] salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password!,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));
        }

        private string GenerateJSONWebToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration.GetSection("AppSettings:Token").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim("email", user.Email),
                    new Claim("role", user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
