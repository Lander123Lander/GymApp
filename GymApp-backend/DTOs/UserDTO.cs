using GymApp_backend.Models;
using System.ComponentModel.DataAnnotations;

namespace GymApp_backend.DTOs
{
    public class RegisterRequest
    {
        [Required]
        [MinLength(3, ErrorMessage = "Username must be at least 3 characters.")]
        [MaxLength(20, ErrorMessage = "Username cannot be longer than 20 characters.")]
        public string Username { get; set; } = string.Empty;

        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
        public string Password { get; set; } = string.Empty;
    }

    public class LoginRequest
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }

    public class LoginResponse
    {
        public String AccessToken { get; set; }
        public String RefreshToken { get; set; }
    }
}
