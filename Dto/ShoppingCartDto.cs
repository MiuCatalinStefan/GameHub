using GameHub.Models;

namespace GameHub.Dto
{
    public class ShoppingCartDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<ShoppingCartProductDto> Products { get; set; } = [];
        public Order Order { get; set; }
        public double TotalPrice { get; set; }
    }

    public class ShoppingCartProductDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public Uri? Image { get; set; }
    }
}
