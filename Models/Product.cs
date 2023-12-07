using System.ComponentModel.DataAnnotations;

namespace GameHub.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Description { get; set; }
        [Required]
        public required string Title { get; set; }
        public double Price { get; set; }
    }
}
