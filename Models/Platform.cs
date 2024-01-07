using Microsoft.Identity.Client;

namespace GameHub.Models
{
    public class Platform
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<Product> Products { get; set; } = [];
    }
}
