using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymApp_backend.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    ExerciseID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    EquipmentType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.ExerciseID);
                });

            migrationBuilder.CreateTable(
                name: "MuscleGroups",
                columns: table => new
                {
                    MuscleGroupID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuscleGroups", x => x.MuscleGroupID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseMuscleGroup",
                columns: table => new
                {
                    ExercisesExerciseID = table.Column<int>(type: "integer", nullable: false),
                    MuscleGroupsMuscleGroupID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseMuscleGroup", x => new { x.ExercisesExerciseID, x.MuscleGroupsMuscleGroupID });
                    table.ForeignKey(
                        name: "FK_ExerciseMuscleGroup_Exercises_ExercisesExerciseID",
                        column: x => x.ExercisesExerciseID,
                        principalTable: "Exercises",
                        principalColumn: "ExerciseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseMuscleGroup_MuscleGroups_MuscleGroupsMuscleGroupID",
                        column: x => x.MuscleGroupsMuscleGroupID,
                        principalTable: "MuscleGroups",
                        principalColumn: "MuscleGroupID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserID = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    PostType = table.Column<int>(type: "integer", nullable: false),
                    IsPrivate = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostID);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    WorkoutID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PostID = table.Column<int>(type: "integer", nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.WorkoutID);
                    table.ForeignKey(
                        name: "FK_Workouts_Posts_PostID",
                        column: x => x.PostID,
                        principalTable: "Posts",
                        principalColumn: "PostID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutExercises",
                columns: table => new
                {
                    WorkoutExerciseID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkoutID = table.Column<int>(type: "integer", nullable: false),
                    ExerciseID = table.Column<int>(type: "integer", nullable: false),
                    SupersetID = table.Column<int>(type: "integer", nullable: true),
                    ExerciseOrder = table.Column<int>(type: "integer", nullable: false),
                    ExerciseNotes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutExercises", x => x.WorkoutExerciseID);
                    table.ForeignKey(
                        name: "FK_WorkoutExercises_Exercises_ExerciseID",
                        column: x => x.ExerciseID,
                        principalTable: "Exercises",
                        principalColumn: "ExerciseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutExercises_Workouts_WorkoutID",
                        column: x => x.WorkoutID,
                        principalTable: "Workouts",
                        principalColumn: "WorkoutID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workoutSets",
                columns: table => new
                {
                    WorkoutSetID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkoutExerciseID = table.Column<int>(type: "integer", nullable: false),
                    SetOrder = table.Column<int>(type: "integer", nullable: false),
                    WeightKG = table.Column<decimal>(type: "numeric", nullable: false),
                    Reps = table.Column<int>(type: "integer", nullable: false),
                    SetType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workoutSets", x => x.WorkoutSetID);
                    table.ForeignKey(
                        name: "FK_workoutSets_WorkoutExercises_WorkoutExerciseID",
                        column: x => x.WorkoutExerciseID,
                        principalTable: "WorkoutExercises",
                        principalColumn: "WorkoutExerciseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "ExerciseID", "EquipmentType", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Bench press" },
                    { 2, 2, "Dumbbell curl" },
                    { 3, 4, "Preacher curl machine" },
                    { 4, 3, "Kettlebell swings" },
                    { 5, 0, "Push-ups" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "CreatedAt", "DeletedAt", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 11, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, "aaa", 2, "lander" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 11, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, "aaa", 1, "admin" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 11, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, "aaa", 0, "user1" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2025, 11, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, "aaa", 0, "user2" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2025, 11, 15, 0, 0, 0, 0, DateTimeKind.Utc), null, "aaa", 0, "user3" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostID", "CreatedAt", "Description", "IsPrivate", "PostType", "Title", "UserID" },
                values: new object[] { 1, new DateTime(2025, 11, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Test description", false, 0, "My first workout", new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.InsertData(
                table: "Workouts",
                columns: new[] { "WorkoutID", "EndTime", "PostID", "StartTime" },
                values: new object[] { 1, new DateTime(2025, 11, 15, 2, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2025, 11, 15, 1, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "WorkoutExercises",
                columns: new[] { "WorkoutExerciseID", "ExerciseID", "ExerciseNotes", "ExerciseOrder", "SupersetID", "WorkoutID" },
                values: new object[,]
                {
                    { 1, 1, null, 0, null, 1 },
                    { 2, 2, null, 1, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "workoutSets",
                columns: new[] { "WorkoutSetID", "Reps", "SetOrder", "SetType", "WeightKG", "WorkoutExerciseID" },
                values: new object[,]
                {
                    { 1, 15, 0, 0, 20m, 1 },
                    { 2, 12, 1, 0, 40m, 1 },
                    { 3, 10, 2, 0, 60m, 1 },
                    { 4, 15, 0, 0, 15m, 2 },
                    { 5, 12, 1, 0, 20m, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseMuscleGroup_MuscleGroupsMuscleGroupID",
                table: "ExerciseMuscleGroup",
                column: "MuscleGroupsMuscleGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserID",
                table: "Posts",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutExercises_ExerciseID",
                table: "WorkoutExercises",
                column: "ExerciseID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutExercises_WorkoutID",
                table: "WorkoutExercises",
                column: "WorkoutID");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_PostID",
                table: "Workouts",
                column: "PostID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_workoutSets_WorkoutExerciseID",
                table: "workoutSets",
                column: "WorkoutExerciseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseMuscleGroup");

            migrationBuilder.DropTable(
                name: "workoutSets");

            migrationBuilder.DropTable(
                name: "MuscleGroups");

            migrationBuilder.DropTable(
                name: "WorkoutExercises");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Workouts");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
