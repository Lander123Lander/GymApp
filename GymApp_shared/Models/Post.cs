using System.Text.Json.Serialization;

namespace GymApp_shared.Models
{
    public enum PostType
    {
        Workout,
        Activity
    }
    
    public class Post
    {
        public int PostID { get; set; }
        public Guid UserID { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }
        public PostType PostType { get; set; }
        public bool IsPrivate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [JsonIgnore]
        public User User { get; set; }

        public Workout Workout { get; set; }
    }
}
