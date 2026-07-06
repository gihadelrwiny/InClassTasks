using BCrypt.Net;
using System.Data;
using WebApplication1.DTO;
using WebApplication1.interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService _tokenService;

        // Fake Database
        private static readonly List<AppUser> _users = new();

        public AuthService(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public Task<AuthResponseDto?> LoginAsync(LoginDto dto)
        {
            var user = _users.FirstOrDefault(x => x.Email == dto.Email);

            if (user == null)
                return Task.FromResult<AuthResponseDto?>(null);

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return Task.FromResult<AuthResponseDto?>(null);

            var roles = new List<string> { user.Role };

            var token = _tokenService.GenerateAccessToken(user, roles);

            var response = new AuthResponseDto
            {
                AccessToken = token,
                UserName = user.UserName,
                Roles = roles,
                ExpiresAt = DateTime.UtcNow.AddMinutes(30)
            };

            return Task.FromResult<AuthResponseDto?>(response);
        }

        public Task<bool> RegisterAsync(RegisterDto dto)
        {
            if (_users.Any(x => x.Email == dto.Email))
                return Task.FromResult(false);

            var user = new AppUser
            {
                Id = _users.Count + 1,
                UserName = dto.UserName,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = "User"
            };

            _users.Add(user);

            return Task.FromResult(true);
        }
    }
}