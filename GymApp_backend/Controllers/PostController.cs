using GymApp_backend.Data;
using GymApp_shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymApp_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PostController : Controller
    {
        private readonly AppDbContext _db;

        public PostController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet("user")]
        public async Task<ActionResult<List<PostDTO>>> GetPosts()
        {
            var userId = User.GetUserId();
            if (userId == null)
            {
                return Unauthorized();
            }

            var posts = await _db.Posts
                .Where(p => p.UserID == userId)
                .Select(p => new PostDTO
                {
                    PostID = p.PostID,
                    Title = p.Title,
                    Description = p.Description,
                    PostType = p.PostType,
                    IsPrivate = p.IsPrivate,
                    CreatedAt = p.CreatedAt,
                    User = new PostDTO.PostDTOUser
                    {
                        UserID = p.User.UserID,
                        Username = p.User.Username
                    }
                })
                .ToListAsync();

            return Ok(posts);
        }
    }
}
