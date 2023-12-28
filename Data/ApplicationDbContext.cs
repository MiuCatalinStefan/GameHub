using GameHub.Models;
using GameHub.Utils;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OperatingSystem = GameHub.Utils.OperatingSystem;

namespace GameHub.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
      
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartProduct> ShoppingCartProducts { get; set; }

      
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ShoppingCart>()
               .HasMany(t => t.Products)
               .WithOne(t => t.ShoppingCart)
               .HasForeignKey(t => t.ProductId)
               .IsRequired();

            modelBuilder.Entity<Product>()
                .HasMany(t => t.Categories)
                .WithMany(t => t.Products)
                .UsingEntity(t => t.ToTable("ProductCategoryContract"));

            modelBuilder.Entity<Product>()
                .HasMany(t => t.ShoppingCartProducts)
                .WithOne(t => t.Product)
                .HasForeignKey(t => t.ProductId)
                .IsRequired();
            
            modelBuilder.Entity<Product>().HasData(
                new
                {
                    Id = 1,
                    Title = "GTA 6",
                    Description = "Gotcha! Coming in 2025 only for Ps5",
                    Price = 90.0,
                    Image = new Uri("https://cdn.images.express.co.uk/img/dynamic/143/590x/secondary/GTA-6-trailer-Grand-Theft-Auto-6-gameplay-reveal-5098949.jpg?r=1701793274244"),
                    Video = new Uri("https://www.youtube.com/watch?v=QdBZY2fkU-0&t=5s"),
                    Platform = Platform.PS5,
                    Stock = 0,
                    ReleaseDate = "12 october 2025",
                    Producer = "Rockstar",
                    AvailableLanguages = new List<string> {"English", "French", "German", "Japanese"},
                    RecomandedAge = 17,
                    MultiplayerInfo = "Co-op: 1-30 players",
                    StorageMemory = 100
                },
                new
                {
                    Id = 2,
                    Title = "Metro Exodus",
                    Description = "This game is not a metro simulator",
                    Price = 30.0,
                    Video = new Uri("https://www.youtube.com/watch?v=fbbqlvuovQ0"),
                    Platform = Platform.XBOX,
                    Stock = 23,
                    ReleaseDate = "30 june 2019",
                    Producer = "Deep Silver",
                    AvailableLanguages = new List<string> { "English", "French", "German"},
                    RecomandedAge = 15,
                    MultiplayerInfo = "only single player",
                    StorageMemory = 60
                },
                new
                {
                    Id = 3,
                    Title = "Assassin's Creed Unity",
                    Description = "The goat",
                    Price = 20.0,
                    Image = new Uri("https://upload.wikimedia.org/wikipedia/en/thumb/4/41/Assassin%27s_Creed_Unity_cover.jpg/220px-Assassin%27s_Creed_Unity_cover.jpg"),
                    Video = new Uri("https://www.youtube.com/watch?v=fbbqlvuovQ0"),
                    Platform = Platform.PS4,
                    Stock = 13,
                    ReleaseDate = "2 may 2014",
                    Producer = "Ubisoft Connect",
                    AvailableLanguages = new List<string> { "English", "French", "German" },
                    RecomandedAge = 12,
                    MultiplayerInfo = "Co-op: 2-4 players",
                    StorageMemory = 50

                },
                new
                {
                    Id = 4,
                    Title = "Assassin's Creed Origin",
                    Description = "The second best assassin's creed game",
                    Price = 40.0,
                    Image = new Uri("https://upload.wikimedia.org/wikipedia/en/4/4a/Assassin%27s_Creed_Origins_Cover_Art.png"),
                    Video = new Uri("https://www.youtube.com/watch?v=cK4iAjzAoas"),
                    Platform = Platform.NINTENDO,
                    Stock = 10,
                    ReleaseDate = "18 december 2017",
                    Producer = "Ubisoft Connect",
                    AvailableLanguages = new List<string> { "English", "French", "German" , "Japanese", "Turkish" },
                    RecomandedAge = 12,
                    MultiplayerInfo = "only single player",
                    StorageMemory = 89
                },
                new
                {
                    Id = 5,
                    Title = "The Crew",
                    Description = "Racing game",
                    Price = 15.0,
                    Image = new Uri("https://image.api.playstation.com/cdn/EP0001/CUSA00161_00/f0kLJbch2vDawClFcF6k9LzZ7Ohi9a7n.png"),
                    Video = new Uri("https://www.youtube.com/watch?v=LVDUbfdfBPk"),
                    Platform = Platform.PC,
                    Stock = 23,
                    MinOperatingSystem = OperatingSystem.Windows10_64Bit,
                    RecomandedOperatingSystem = OperatingSystem.Windows11_32Bit,
                    ReleaseDate = "22 july 2020",
                    Producer = "Ubisoft",
                    AvailableLanguages = new List<string> { "English", "French", "German", "Japanese", "Turkish" },
                    MultiplayerInfo = "Co-op: up to 32 players",
                    MinProcessor = Processor.IntelCore2,
                    RecomandedProcessor = Processor.IntelCoreI5,
                    MinGraphic = Graphic.GTX780,
                    RecomandedGraphic = Graphic.RTX2080,
                    MinRam = RamMemory.RAM16,
                    RecomandedRam = RamMemory.RAM32,
                    StorageMemory = 88
                },
                new
                {
                    Id = 6,
                    Title = "Minecraft",
                    Description = "This doesn't need a description",
                    Price = 25.0,
                    Platform = Platform.PC,
                    Stock = 6,
                    MinOperatingSystem = OperatingSystem.Windows10_64Bit,
                    RecomandedOperatingSystem = OperatingSystem.Windows11_32Bit,
                    ReleaseDate = "8 january 2010",
                    Producer = "Sandbox",
                    AvailableLanguages = new List<string> { "English"},
                    RecomandedAge = 4,
                    MultiplayerInfo = "Public server",
                    MinProcessor = Processor.AmdRyzen5,
                    RecomandedProcessor = Processor.AmdRyzen7,
                    MinGraphic = Graphic.DX10,
                    RecomandedGraphic = Graphic.RadeonRx470,
                    MinRam = RamMemory.RAM8,
                    RecomandedRam = RamMemory.RAM16,
                    StorageMemory = 7
                }
            );

            modelBuilder.Entity<Category>().HasData(
                new { Id = 1, Name = "RPG" },
                new { Id = 2, Name = "Adventure" },
                new { Id = 3, Name = "Action" },
                new { Id = 4, Name = "Strategy" },
                new { Id = 5, Name = "Third Person Shooter" },
                new { Id = 6, Name = "First Person Shooter" },
                new { Id = 7, Name = "Racing" }
                );

            modelBuilder.Entity<Product>()
                .HasMany(t => t.Categories)
                .WithMany(t => t.Products)
                .UsingEntity(t =>
                {
                    t.ToTable("ProductCategoryContract");
                    t.HasData(
                        new { ProductsId = 1, CategoriesId = 1 },
                        new { ProductsId = 1, CategoriesId = 5 },
                        new { ProductsId = 2, CategoriesId = 3 },
                        new { ProductsId = 2, CategoriesId = 6 },
                        new { ProductsId = 3, CategoriesId = 3 },
                        new { ProductsId = 4, CategoriesId = 3 },
                        new { ProductsId = 5, CategoriesId = 7 },
                        new { ProductsId = 6, CategoriesId = 2 }
                        );
                });
        }
    }
}
