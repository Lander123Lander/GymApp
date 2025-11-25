using GymApp_shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp_shared.DTOs
{
    public class PostDTO
    {
        public int PostID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public PostType PostType { get; set; }
        public bool IsPrivate { get; set; }
        public DateTime CreatedAt { get; set; }
        public PostDTOUser User { get; set; } = null!;

        public class PostDTOUser
        {
            public Guid UserID { get; set; }
            public string Username { get; set; }
        }
    }   
}
