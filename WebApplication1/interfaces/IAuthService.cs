using Microsoft.AspNetCore.Identity;
using WebApplication1.DTO;

namespace WebApplication1.interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto?> LoginAsync(LoginDto dto);
        public Task<bool> RegisterAsync(RegisterDto dto);
    }
}
