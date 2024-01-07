using GameHub.Models;

namespace GameHub.Dto
{
    public class RegionDto
    {
        public required string Name { get; set; }
        public static RegionDto MapRegionToDto(Region c)
        {
            return new RegionDto { Name = c.Name };
        }
    }
}
