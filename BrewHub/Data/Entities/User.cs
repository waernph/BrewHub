namespace BrewHub.Data.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Role { get; set; } = "User";

        [StringLength(100)]
        public string UserName { get; set; } = null!;

        [StringLength(30)]
        public string Password { get; set; } = null!;

        [StringLength(100)]
        public string Email { get; set; } = null!;

        public int postId { get; set; }
        public List<Post> ? Posts { get; set; }

        public int CommentId { get; set; } 
        public List<Comment> ? Comments { get; set; }




    }
}
