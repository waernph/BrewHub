namespace BrewHub.Data.DTO
{
    public class CommentDTO
    {
        public string Comments { get; set; }
        public DateTime Date { get; set; }
        public UserDTO User { get; set; }
    }
}
