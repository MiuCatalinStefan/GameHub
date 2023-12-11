using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameHub.Models
{
    public class ShoppingCartProduct
    {
        public int Id { get; set; }
        [Required]
        public int ShoppingCartId { get; set; }
        [ForeignKey("ShoppingCartId")]
        [ValidateNever]
        public ShoppingCart ShoppingCart { get; set; }
        [Required]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        [ValidateNever]
        public Product Product { get; set; } 
        public int Quantity { get; set; } = 1;
    }
}
