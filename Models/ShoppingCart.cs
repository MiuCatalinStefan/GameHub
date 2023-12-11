using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameHub.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; } = null!;
        [Required]
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        public List<ShoppingCartProduct> Products { get; set; } = [];
    }
}
