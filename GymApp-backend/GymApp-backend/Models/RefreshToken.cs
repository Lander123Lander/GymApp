namespace GymApp_backend.Models
{
    public class RefreshToken
    {
        public Guid RefreshTokenID { get; set; } = Guid.NewGuid();
        public Guid UserID { get; set; }

        public string Token { get; set; } = string.Empty;
        public DateTime IssuedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
