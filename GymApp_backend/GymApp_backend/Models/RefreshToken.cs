using System.Text.Json.Serialization;

namespace GymApp_shared.Models
{
    public class RefreshToken
    {
        public Guid RefreshTokenID { get; set; } = Guid.NewGuid();
        public Guid UserID { get; set; }

        public string Token { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public DateTime? RevokedAt { get; set; }

        [JsonIgnore]
        public User User { get; set; }
    }
}
