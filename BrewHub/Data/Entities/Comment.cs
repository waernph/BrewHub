using System.ComponentModel.DataAnnotations;

namespace BrewHub.Data.Entities
{
    public class Comment
    {
        public int CommentID { get; set; }
        [Required]
        [StringLength(500)]
        public string CommentText { get; set; }
        public DateTime CommentCreatedDate { get; } = DateTime.Now;
    }
}
