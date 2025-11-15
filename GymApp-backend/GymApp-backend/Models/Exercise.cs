namespace GymApp_backend.Models
{
    public enum EquipmentType
    {
        None,
        Barbell,
        Dumbbell,
        Kettlebell,
        Machine
    }

    public class Exercise
    {
        public int ExerciseID { get; set; }

        public string Name { get; set; } = string.Empty;
        public EquipmentType EquipmentType { get; set; }

        public ICollection<WorkoutExercise> WorkoutExercises { get; set; }
        public ICollection<MuscleGroup> MuscleGroups { get; set; }
    }
}
