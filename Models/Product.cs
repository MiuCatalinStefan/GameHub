using GameHub.Utils;
using System.ComponentModel.DataAnnotations;

using OperatingSystem = GameHub.Utils.OperatingSystem;

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
        public Uri? Image { get; set; }
        public Uri? Video { get; set; }
        public List<Category> Categories { get; set; } = [];
        [Required]
        public required Platform Platform { get; set; }
        [Required]
        public required int Stock { get; set; }
        public OperatingSystem? MinOperatingSystem { get; set; }
        public OperatingSystem? RecomandedOperatingSystem { get; set; }
        public List<ShoppingCartProduct> ShoppingCartProducts { get; set; } = [];
    }
}
