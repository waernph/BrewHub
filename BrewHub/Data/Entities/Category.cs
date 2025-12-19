using System.ComponentModel.DataAnnotations;

namespace BrewHub.Data.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        [StringLength(100)]
        public string CategoryName { get; set; }


    }
}
