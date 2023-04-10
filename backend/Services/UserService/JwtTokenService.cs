using System.Text;
using Luxelane.DTOs;
using Luxelane.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Luxelane.Services.UserService
{

    public class JwtTokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;

        public JwtTokenService(IConfiguration config, UserManager<User> userManager)
        {
            _config = config;
            _userManager = userManager;
        }

        public async Task<UserSignInReadDto> GenerateTokenAsync(User user)
        {
            //Payload
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim(ClaimTypes.Name, user.UserName!),
            };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var secret = _config.GetValue<string>("Jwt:Secret");
            var signingKey = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret!)),
                SecurityAlgorithms.HmacSha256
            );
            
            //Long expiration date just for testing purpose. Usually it's shorter for security reason
            var expiration = DateTime.Now.AddMonths(1);

            // Token description
            var tokenDescriptor = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: expiration,
                signingCredentials: signingKey
            );

            var token = new JwtSecurityTokenHandler();

            var result = new UserSignInReadDto
            {
                Token = token.WriteToken(tokenDescriptor),
                Expiration = expiration,
            };

            return result;
        }
    }
}