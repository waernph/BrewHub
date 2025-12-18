using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace BrewHub.Data.Entities
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        [StringLength(100)]
        public string UserName { get; set; }
        [Required]
        [StringLength(25)]
        public string Password { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        public List<Post> Posts { get; set; }
        public List<Comment> Comments { get; set; }

    }
}
