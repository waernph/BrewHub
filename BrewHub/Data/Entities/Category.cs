using System.ComponentModel.DataAnnotations;

namespace BrewHub.Data.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        [StringLength(100)]
        public string CategoryName { get; set; } = null!;

        public int PostId { get; set; }
        public List<Post> ? Posts { get; set; }
    }
}
