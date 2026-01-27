using BrewHub.Data.DTO;

namespace BrewHub_App.Models
{
    public class CommentDTO
    {
        public string Comments { get; set; }
        public DateTime Date { get; set; }
        public UserDTO User { get; set; }
    }
}
