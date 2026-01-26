namespace BrewHub.Data.DTO
{
    public class PostDTO
    {
        public CategoryDTO Category { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public UserDTO User { get; set; }
        public List<CommentDTO> Comments { get; set; }

    }
}
