namespace BrewHub.Data.Entities
{
    public class Comment
    {

        public int CommentId { get; set; }
        [StringLength(5000)]
        public string CommentText { get; set; } = null!;
        public DateTime CommentCreatedDate { get; set; } = DateTime.Now;

        public int PostId { get; set; }
        public Post Post { get; set; } = null!;
        public int UserId { get; set; }
        public User User { get; set; } = null!;


    }
}
