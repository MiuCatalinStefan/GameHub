using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameHub.Models
{
    public class ShoppingCartProduct
    {
        public int Id { get; set; }

        [Required]
        [ValidateNever]
        [ForeignKey("ShoppingCartId")]
        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

        [Required]
        [ValidateNever]
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public Product Product { get; set; } 
        public int Quantity { get; set; } = 1;
    }
}
