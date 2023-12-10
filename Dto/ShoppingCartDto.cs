namespace GameHub.Dto
{
    public class ShoppingCartDto
    {
        public int UserId { get; set; }
        public List<ShoppingCartProductDto> Products { get; set; } = [];
        public double TotalPrice { get; set; }
    }

    public class ShoppingCartProductDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
