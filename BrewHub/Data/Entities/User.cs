using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BrewHub.Data.Entities
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        [StringLength(100)]
        public string UserName { get; set; }
        [Required]
        [StringLength(30)]
        public string Password { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }



    }
}
