namespace GymApp_backend.Models
{
    public class MuscleGroup
    {
        public int MuscleGroupID { get; set; }

        public string Name { get; set; }

        public ICollection<Exercise> Exercises { get; set; }
    }
}
