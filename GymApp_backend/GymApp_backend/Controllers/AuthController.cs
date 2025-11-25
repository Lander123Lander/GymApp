using GymApp_backend.Data;
using GymApp_shared.DTOs;
using GymApp_shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace GymApp_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly JwtService _jwtService;

        public AuthController(AppDbContext db, JwtService jwtService)
        {
            _db = db;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<LoginResponse>> Register([FromBody] RegisterRequest dto)
        {
            if (await _db.Users.AnyAsync(u => u.Email == dto.Email))
                return BadRequest("This e-mail is already in use.");

            if (await _db.Users.AnyAsync(u => u.Username.ToLower() == dto.Username.ToLower()))
                return BadRequest("This username already exists.");

            if (!Regex.IsMatch(dto.Username, @"^[a-zA-Z0-9_-]+$"))
                return BadRequest("Username cannot contain special characters.");

            var user = new User
            {
                Username = dto.Username.Trim(),
                Email = dto.Email.ToLower().Trim(),
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            return Ok(await CreateLoginResponseAsync(user));
        }


        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest dto)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => 
                u.Username.ToLower() == dto.EmailOrUsername.ToLower() || 
                u.Email.ToLower() == dto.EmailOrUsername.ToLower());

            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
                return Unauthorized("The entered email/username or password is incorrect.");

            return Ok(await CreateLoginResponseAsync(user));
        }


        [HttpPost("refresh")]
        public async Task<ActionResult<LoginResponse>> RefreshToken([FromBody] string refreshToken)
        {
            var tokenEntry = await _db.RefreshTokens
                .Include(t => t.User)
                .FirstOrDefaultAsync(t => t.Token == refreshToken && t.ExpiresAt > DateTime.UtcNow && t.RevokedAt == null);

            if (tokenEntry == null)
                return Unauthorized("No valid token found");

            var user = tokenEntry.User;

            tokenEntry.RevokedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();

            return Ok(await CreateLoginResponseAsync(user));
        }


        private async Task<LoginResponse> CreateLoginResponseAsync(User user)
        {
            var accessToken = _jwtService.GenerateAccessToken(user);
            var refreshToken = _jwtService.GenerateRefreshToken(user);

            _db.RefreshTokens.Add(refreshToken);

            await _db.SaveChangesAsync();

            return new LoginResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token
            };
        }
    }
}
