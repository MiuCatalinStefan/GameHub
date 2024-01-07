using GameHub.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OperatingSystem = GameHub.Utils.OperatingSystem;

namespace GameHub.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Description { get; set; }
        [Required]
        public required string Title { get; set; }
        public double Price { get; set; }
        public Uri? Image { get; set; }
        public Uri? Video { get; set; }
        public List<Category> Categories { get; set; } = [];

        [ForeignKey(nameof(Platform))]
        public int PlatformId { get; set; }
        public Platform Platform { get; set; } = null!;

        [ForeignKey(nameof(Region))]
        public int RegionId { get; set; }
        public Region Region { get; set; } = null!;

        [Required]
        public required int Stock { get; set; }
        public OperatingSystem? MinOperatingSystem { get; set; }
        public OperatingSystem? RecommendedOperatingSystem { get; set; }
        public List<ShoppingCartProduct> ShoppingCartProducts { get; set; } = [];
        [Required]
        public required string ReleaseDate { get; set; }
        [Required]
        public required string Producer {  get; set; }
        [Required]
        public required List<string> AvailableLanguages { get; set; } = ["english"];
        public int? RecommendedAge {  get; set; }
        [Required]
        public required string MultiplayerInfo {  get; set; }
        public Processor? MinProcessor {  get; set; }
        public Processor? RecommendedProcessor { get; set; }
        public Graphic? MinGraphic { get; set; }
        public Graphic? RecommendedGraphic { get; set; }
        public RamMemory? MinRam { get; set; }
        public RamMemory? RecommendedRam { get; set; }
        public int? StorageMemory { get; set; } // GB

    }
}
