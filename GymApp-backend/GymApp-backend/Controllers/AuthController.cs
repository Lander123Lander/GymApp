using GymApp_backend.Data;
using GymApp_backend.DTOs;
using GymApp_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace GymApp_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _db;

        public AuthController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
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

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest dto)
        {
            if (await _db.Users.AnyAsync(u => u.Username == dto.Username))
                return BadRequest("Username already exists.");

            var user = new User
            {
                Username = dto.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            return Ok(new LoginResponse
            {
                UserID = user.UserID,
                Username = user.Username,
                Role = user.Role
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest dto)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == dto.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
                return Unauthorized("Invalid username or password.");

            return Ok(new LoginResponse
            {
                UserID = user.UserID,
                Username = user.Username,
                Role = user.Role
            });
        }
    }
}
