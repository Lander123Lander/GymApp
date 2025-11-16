using GymApp_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace GymApp_backend.Data
{
    public class AppDbContext : DbContext
    {
        // dotnet ef migrations add init
        // dotnet ef database update

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<MuscleGroup> MuscleGroups { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
        public DbSet<WorkoutSet> workoutSets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            DateTime dateTime = new DateTime(2025, 11, 15, 00, 00, 00, DateTimeKind.Utc);

            modelBuilder.Entity<User>()
        .HasMany(p => p.RefreshTokens)
        .WithOne(w => w.User)
        .HasForeignKey(w => w.UserID);

            modelBuilder.Entity<User>()
        .HasMany(p => p.Posts)
        .WithOne(w => w.User)
        .HasForeignKey(w => w.UserID);

            modelBuilder.Entity<Post>()
    .HasOne(p => p.Workout)
    .WithOne(w => w.Post)
    .HasForeignKey<Workout>(w => w.PostID);

            modelBuilder.Entity<Workout>()
        .HasMany(w => w.WorkoutExercises)
        .WithOne(we => we.Workout)
        .HasForeignKey(we => we.WorkoutID);

            modelBuilder.Entity<Exercise>()
        .HasMany(e => e.WorkoutExercises)
        .WithOne(we => we.Exercise)
        .HasForeignKey(we => we.ExerciseID);

            modelBuilder.Entity<WorkoutExercise>()
        .HasMany(we => we.WorkoutSets)
        .WithOne(ws => ws.WorkoutExercise)
        .HasForeignKey(ws => ws.WorkoutExerciseID);

            modelBuilder.Entity<Exercise>()
        .HasMany(e => e.MuscleGroups)
        .WithMany(m => m.Exercises);

            modelBuilder.Entity<Exercise>().HasData(
                new Exercise
                {
                    ExerciseID = 1,
                    Name = "Bench press",
                    EquipmentType = EquipmentType.Barbell,
                },
                new Exercise
                {
                    ExerciseID = 2,
                    Name = "Dumbbell curl",
                    EquipmentType = EquipmentType.Dumbbell,
                },
                new Exercise
                {
                    ExerciseID = 3,
                    Name = "Preacher curl machine",
                    EquipmentType = EquipmentType.Machine,
                },
                new Exercise
                {
                    ExerciseID = 4,
                    Name = "Kettlebell swings",
                    EquipmentType = EquipmentType.Kettlebell,
                },
                new Exercise
                {
                    ExerciseID = 5,
                    Name = "Push-ups",
                    EquipmentType = EquipmentType.None,
                });

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserID = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Username = "lander",
                    Password = "aaa",
                    Role = Role.Owner,
                    CreatedAt = dateTime,
                },
                new User
                {
                    UserID = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Username = "admin",
                    Password = "aaa",
                    Role = Role.Admin,
                    CreatedAt = dateTime,
                }, new User
                {
                    UserID = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Username = "user1",
                    Password = "aaa",
                    Role = Role.User,
                    CreatedAt = dateTime,
                },
                new User
                {
                    UserID = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    Username = "user2",
                    Password = "aaa",
                    Role = Role.User,
                    CreatedAt = dateTime,
                },
                new User
                {
                    UserID = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                    Username = "user3",
                    Password = "aaa",
                    Role = Role.User,
                    CreatedAt = dateTime,
                });

            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    PostID = 1,
                    UserID = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Title = "My first workout",
                    Description = "Test description",
                    PostType = PostType.Workout,
                    IsPrivate = false,
                    CreatedAt = dateTime,
                });

            modelBuilder.Entity<Workout>().HasData(
                new Workout
                {
                    WorkoutID = 1,
                    PostID = 1,
                    StartTime = dateTime.AddHours(1),
                    EndTime = dateTime.AddHours(2)
                });

            modelBuilder.Entity<WorkoutExercise>().HasData(
                new WorkoutExercise
                {
                    WorkoutExerciseID = 1,
                    WorkoutID = 1,
                    ExerciseID = 1,
                    ExerciseOrder = 0
                },
                new WorkoutExercise
                {
                    WorkoutExerciseID = 2,
                    WorkoutID = 1,
                    ExerciseID = 2,
                    ExerciseOrder = 1
                });

            modelBuilder.Entity<WorkoutSet>().HasData(
                new WorkoutSet
                {
                    WorkoutSetID = 1,
                    WorkoutExerciseID = 1,
                    SetOrder = 0,
                    WeightKG = 20,
                    Reps = 15
                },
                new WorkoutSet
                {
                    WorkoutSetID = 2,
                    WorkoutExerciseID = 1,
                    SetOrder = 1,
                    WeightKG = 40,
                    Reps = 12
                },
                new WorkoutSet
                {
                    WorkoutSetID = 3,
                    WorkoutExerciseID = 1,
                    SetOrder = 2,
                    WeightKG = 60,
                    Reps = 10
                },
                new WorkoutSet
                {
                    WorkoutSetID = 4,
                    WorkoutExerciseID = 2,
                    SetOrder = 0,
                    WeightKG = 15,
                    Reps = 15
                },
                new WorkoutSet
                {
                    WorkoutSetID = 5,
                    WorkoutExerciseID = 2,
                    SetOrder = 1,
                    WeightKG = 20,
                    Reps = 12
                });
        }
    }
}
