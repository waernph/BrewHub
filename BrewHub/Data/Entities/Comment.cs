using System.ComponentModel.DataAnnotations;

namespace BrewHub.Data.Entities
{
    public class Comment
    {

        public int CommentId { get; set; }
        [Required]
        [StringLength(5000)]
        public string CommentText { get; set; }
        public DateTime CommentCreatedDate { get; set; } = DateTime.Now;

        public int PostId { get; set; }
        public Post Post { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }


    }
}
