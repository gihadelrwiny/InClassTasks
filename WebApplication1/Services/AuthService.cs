using Microsoft.AspNetCore.Identity;
using WebApplication1.DTO;
using WebApplication1.interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;

        public AuthService(UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<AuthResponseDto?> LoginAsync(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user == null)
                return null;

            var validPassword = await _userManager.CheckPasswordAsync(user, dto.Password);

            if (!validPassword)
                return null;

            var roles = await _userManager.GetRolesAsync(user);

            var token = _tokenService.GenerateAccessToken(user, roles);

            return new AuthResponseDto
            {
                AccessToken = token,
                UserName = user.UserName!,
                Roles = roles.ToList(),
                ExpiresAt = DateTime.UtcNow.AddMinutes(30)
            };
        }

        public async Task<bool> RegisterAsync(RegisterDto dto)
        {
            if (await _userManager.FindByEmailAsync(dto.Email) != null)
                return false;

            var user = new AppUser
            {
                UserName = dto.UserName,
                Email = dto.Email
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(" | ", result.Errors.Select(e => e.Description)));
            }
             

            await _userManager.AddToRoleAsync(user, "User");

            return true;
        }
    }
}