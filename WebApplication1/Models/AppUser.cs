namespace WebApplication1.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName{ get; set; } = string.Empty;
        public string Email{ get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenExpiryTime { get; set; }
        public string Role { get; set; } = "User";

    }
}