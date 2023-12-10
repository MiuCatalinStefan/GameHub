using GameHub.Models;
using Microsoft.Identity.Client;

namespace GameHub.Dto
{
    public class CategoryDto
    {
        public required string Name { get; set; }
        public static CategoryDto MapCategoryToDto(Category c)
        {
            return new CategoryDto { Name = c.Name };
        }
    }
}
