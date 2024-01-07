namespace GameHub.Models
{
    public class Region
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<Product> Products { get; set; } = [];
    }
}
