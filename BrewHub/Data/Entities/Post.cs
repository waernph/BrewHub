using System.ComponentModel.DataAnnotations;

namespace BrewHub.Data.Entities
{
    public class Post
    {
        public int PostId { get; set; }

        [StringLength(100)]
        public string PostTitle { get; set; } = null!;

        [StringLength(5000)]
        public string PostBody { get; set; } = null!;
        public DateTime PostCreatedDate { get; set; } = DateTime.Now;

        public List<Comment> ? Comments { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
