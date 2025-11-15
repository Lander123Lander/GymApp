using System.Text.Json.Serialization;

namespace GymApp_backend.Models
{
    public class Workout
    {
        public int WorkoutID { get; set; }
        public int PostID { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        [JsonIgnore]
        public Post Post { get; set; }
        public ICollection<WorkoutExercise> WorkoutExercises { get; set; }
    }
}
