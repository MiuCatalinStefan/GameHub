using GameHub.Models;
using GameHub.Utils;
using PlatformEnum = GameHub.Utils.Platform;

namespace GameHub.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public Uri? Image { get; set; }
        public Uri? Video { get; set; }
        public string Platform { get; set; }
        public int Stock { get; set; }
        public string? MinOperatingSystem { get; set; }
        public string? RecomandedOperatingSystem { get; set; }

        public static ProductDto MapProductToDto(Product p)
        {
            return new ProductDto
            {
                Id = p.Id,
                Description = p.Description,
                Title = p.Title,
                Price = p.Price,
                Image = p.Image,
                Video = p.Video,
                Platform = PlatformValue.getPlatformName(p.Platform),
                Stock = p.Stock,
                MinOperatingSystem = (p.Platform == PlatformEnum.PC && p.MinOperatingSystem != null) ? OperatingSystemsValue.getOsValue((Utils.OperatingSystem)p.MinOperatingSystem) : null,
                RecomandedOperatingSystem = (p.Platform == PlatformEnum.PC && p.RecomandedOperatingSystem != null) ? OperatingSystemsValue.getOsValue((Utils.OperatingSystem)p.RecomandedOperatingSystem) : null
            };
        }
    }

    public class ProductListMemberDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public double Price { get; set; }
        public Uri? Image { get; set; }
        public static ProductListMemberDto MapProductToDto(Product p)
        {
            return new ProductListMemberDto
            {
                Id = p.Id,
                Title = p.Title,
                Price = p.Price,
                Image = p.Image
            };
        }
    }
}
