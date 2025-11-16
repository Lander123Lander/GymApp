using System.Text.Json.Serialization;

namespace GymApp_backend.Models
{
    public enum Role
    {
        User,
        Admin,
        Owner
    }

    public class User
    {
        public Guid UserID { get; set; } = Guid.NewGuid();

        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Role Role { get; set; } = Role.User;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; set; } = null;

        public ICollection<Post> Posts { get; set; }

        [JsonIgnore]
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    }
}
