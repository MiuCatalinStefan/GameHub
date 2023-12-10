using System.ComponentModel.DataAnnotations;

namespace GameHub.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; } = null!;
        [Required]
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        public List<ShoppingCartProduct> Products { get; set; } = [];
    }
}
