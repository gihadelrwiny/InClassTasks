using WebApplication1.Models;

namespace WebApplication1.interfaces
{
    public interface ITokenService
    {
        public string GenerateAccessToken(AppUser user, IList<string> roles);

    }
}
