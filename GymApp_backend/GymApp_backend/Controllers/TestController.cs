using GymApp_backend.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymApp_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TestController : Controller
    {
        private readonly AppDbContext _db;

        public TestController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _db.Users
                .Include(u => u.Posts)
                    .ThenInclude(p => p.Workout)
                        .ThenInclude(w => w.WorkoutExercises)
                            .ThenInclude(we => we.WorkoutSets)
                .Include(u => u.Posts)
                    .ThenInclude(p => p.Workout)
                        .ThenInclude(w => w.WorkoutExercises)
                            .ThenInclude(we => we.Exercise)
                                .ThenInclude(e => e.MuscleGroups)
                .ToListAsync();

            return Ok(users);
        }
    }
}
