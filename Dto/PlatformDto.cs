using GameHub.Models;

namespace GameHub.Dto
{
    public class PlatformDto
    {
        public required string Name { get; set; }
        public static PlatformDto MapPlatformToDto(Platform c)
        {
            return new PlatformDto { Name = c.Name };
        }
    }
}
