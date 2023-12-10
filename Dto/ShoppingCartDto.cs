namespace GameHub.Dto
{
    public class ShoppingCartDto
    {
        public string UserId { get; set; }
        public List<ShoppingCartProductDto> Products { get; set; } = [];
        public double TotalPrice { get; set; }
    }

    public class ShoppingCartProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
