using AuthService.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthService.Services
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        public const string issuer = "CodeChallengeSG";
        private readonly SymmetricSecurityKey _key;
        public JwtTokenGenerator(IConfiguration config)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]!));
        }
        public (string, DateTime) GenerarToken(int subject)
        {
            var signingCredentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, subject.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var expires = DateTime.Now.AddHours(24);

            var token = new JwtSecurityToken(
                issuer: issuer,
                expires: expires,
                claims: claims,
                signingCredentials: signingCredentials
            );

            return (new JwtSecurityTokenHandler().WriteToken(token).ToString(), expires);
        }
    }
}
