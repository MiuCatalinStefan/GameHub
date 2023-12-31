﻿using GameHub.Models;
using GameHub.Utils;

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
        public List<string> Categories { get; set; } = [];
        public string Platform { get; set; }
        public int Stock { get; set; }
        public string? MinOperatingSystem { get; set; }
        public string? RecomandedOperatingSystem { get; set; }
        public string ReleaseDate { get; set; }
        public string Producer { get; set; }
        public List<string> AvailableLanguages { get; set; } = ["english"];
        public int? RecomandedAge { get; set; }
        public string MultiplayerInfo { get; set; }
        public string? MinProcessor { get; set; }
        public string? RecomandedProcessor { get; set; }
        public string? MinGraphic { get; set; }
        public string? RecomandedGraphic { get; set; }
        public string? MinRam { get; set; }
        public string? RecomandedRam { get; set; }
        public int? StorageMemory { get; set; } // GB

        public static ProductDto MapProductToDto(Product p)
        {
            return new ProductDto
            {
                Id = p.Id,
                Description = p.Description,
                Title = p.Title,
                Price = p.Price,
                Image = p.Image ?? new Uri("https://gallery.yopriceville.com/var/albums/Free-Clipart-Pictures/Money.PNG/Treasure_Chest_PNG_Transparent_Clipart.png?m=1612789715"),
                Video = p.Video,
                Categories = GetCategoriesNames(p.Categories),
                Platform = p.Platform.Name,
                Stock = p.Stock,
                // TODO remove enums and refactor below
                MinOperatingSystem = (p.PlatformId == 5 && p.MinOperatingSystem != null) ? OperatingSystemsValue.getOsValue((Utils.OperatingSystem)p.MinOperatingSystem) : null,
                RecomandedOperatingSystem = (p.PlatformId == 5 && p.RecommendedOperatingSystem != null) ? OperatingSystemsValue.getOsValue((Utils.OperatingSystem)p.RecommendedOperatingSystem) : null,
                ReleaseDate = p.ReleaseDate,
                Producer = p.Producer,
                AvailableLanguages = p.AvailableLanguages.Count > 0 ? p.AvailableLanguages : ["english"],
                RecomandedAge = p.RecommendedAge != null ? p.RecommendedAge : 0,
                MultiplayerInfo = p.MultiplayerInfo,
                MinProcessor = (p.PlatformId == 5 && p.MinProcessor != null) ? ProcessorValue.GetProcessorValue((Processor)p.MinProcessor) : null,
                RecomandedProcessor = (p.PlatformId == 5 && p.RecommendedProcessor != null) ? ProcessorValue.GetProcessorValue((Processor)p.RecommendedProcessor) : null,
                MinGraphic = (p.PlatformId == 5 && p.MinGraphic != null) ? GraphicValue.GetGraphicValue((Graphic)p.MinGraphic) : null,
                RecomandedGraphic = (p.PlatformId == 5 && p.RecommendedGraphic != null) ? GraphicValue.GetGraphicValue((Graphic)p.RecommendedGraphic) : null,
                MinRam = (p.PlatformId == 5 && p.MinRam != null) ? RamMemoryValue.GetRamemoryValue((RamMemory)p.MinRam) : null,
                RecomandedRam = (p.PlatformId == 5 && p.RecommendedRam != null) ? RamMemoryValue.GetRamemoryValue((RamMemory)p.RecommendedRam) : null,
                StorageMemory = p.StorageMemory ?? null
            };
        }

        public static ProductDto GetPartialProductDto(Product p)
        {
            return new ProductDto
            {
                Id = p.Id,
                Title = p.Title,
                Price = p.Price,
                Image = p.Image ?? new Uri("https://gallery.yopriceville.com/var/albums/Free-Clipart-Pictures/Money.PNG/Treasure_Chest_PNG_Transparent_Clipart.png?m=1612789715"),
                Platform = p.Platform.Name,
            };
        }

        public static List<string> GetCategoriesNames(List<Category> categories)
        {
            List<string> categoriesNames = [];
            if (categories.Count > 0)
            {
                foreach (Category category in categories)
                {
                    categoriesNames.Add(category.Name);
                }
                return categoriesNames;
            }
            return [];
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
