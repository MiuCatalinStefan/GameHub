using System.ComponentModel.DataAnnotations;

namespace GameHub.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        //TODO: de adaugat si user-ul aici ca sa facem o relatie frumoasa one to many
        [Required]
        public DateTime LastModified { get; set; }
        [Required]
        public List<Product> Products { get; set; } = []; // de vazut exact ce face,
    }
}
