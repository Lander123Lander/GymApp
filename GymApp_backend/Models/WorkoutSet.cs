using System.Text.Json.Serialization;

namespace GymApp_shared.Models
{
    public enum SetType
    {
        Normal,
        Warmup,
        Dropset,
        Failure
    }

    public class WorkoutSet
    {
        public int WorkoutSetID { get; set; }
        public int WorkoutExerciseID { get; set; }

        public int SetOrder { get; set; }
        public decimal WeightKG { get; set; }
        public int Reps { get; set; }
        public SetType SetType { get; set; } = SetType.Normal;

        [JsonIgnore]
        public WorkoutExercise WorkoutExercise { get; set; }
    }
}
