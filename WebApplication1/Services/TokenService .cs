using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WebApplication1.interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtOptions _opt;

        public TokenService(IOptions<JwtOptions> opts)
        {
            _opt = opts.Value;
        }
        public string GenerateAccessToken(AppUser user, IList<string> roles)
        {
           var claims = new List<Claim>()
           {
               new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
               new Claim(ClaimTypes.Name,user.UserName),
               new Claim(ClaimTypes.Email,user.Email)
           };
            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_opt.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _opt.Issuer,
                audience: _opt.Audience,
                claims: claims,
                expires:DateTime.UtcNow.AddMinutes(_opt.ExpiresInMinutes),
                signingCredentials:creds

                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
