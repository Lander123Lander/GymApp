using System.Text.Json.Serialization;

namespace GymApp_shared.Models
{
    public class WorkoutExercise
    {
        public int WorkoutExerciseID { get; set; }
        public int WorkoutID { get; set; }
        public int ExerciseID { get; set; }

        public int? SupersetID { get; set; }
        public int ExerciseOrder { get; set; }
        public string? ExerciseNotes { get; set; }

        [JsonIgnore]
        public Workout Workout { get; set; }

        [JsonIgnore]
        public Exercise Exercise { get; set; }

        public ICollection<WorkoutSet> WorkoutSets { get; set; }
    }
}
