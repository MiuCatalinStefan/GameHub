using GameHub.Models;
using GameHub.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using OperatingSystem = GameHub.Utils.OperatingSystem;

namespace GameHub.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoppingCart>()
               .HasMany(t => t.Products)
               .WithMany(t => t.ShoppingCarts)
               .UsingEntity(t => t.ToTable("ShoppingCartProductContract"));

            modelBuilder.Entity<Product>()
                .HasMany(t => t.Categories)
                .WithMany(t => t.Products)
                .UsingEntity(t => t.ToTable("ProductCategoryContract"));

            modelBuilder.Entity<Product>().HasData(
                new
                {
                    Id = 1,
                    Title = "GTA 6",
                    Description = "Gotcha! Coming in 2025 only for Ps5",
                    Price = 90.0,
                    Image = new Uri("https://cdn.images.express.co.uk/img/dynamic/143/590x/secondary/GTA-6-trailer-Grand-Theft-Auto-6-gameplay-reveal-5098949.jpg?r=1701793274244"),
                    Platform=Platform.PS5,
                    Stock=0,
                },
                new { 
                    Id = 2, 
                    Title = "Metro Exodus", 
                    Description = "This game is not a metro simulator", 
                    Price = 30.0, 
                    Platform = Platform.XBOX,
                    Stock = 23
                },
                new { 
                    Id = 3, 
                    Title = "Assassin's Creed Unity", 
                    Description = "The goat", 
                    Price = 20.0,
                    Image = new Uri("https://upload.wikimedia.org/wikipedia/en/thumb/4/41/Assassin%27s_Creed_Unity_cover.jpg/220px-Assassin%27s_Creed_Unity_cover.jpg"), 
                    Platform = Platform.PS4,
                    Stock = 13,
                },
                new { 
                    Id = 4, 
                    Title = "Assassin's Creed Origin", 
                    Description = "The second best assassin's creed game", 
                    Price = 40.0, 
                    Image = new Uri("https://upload.wikimedia.org/wikipedia/en/4/4a/Assassin%27s_Creed_Origins_Cover_Art.png"), 
                    Platform = Platform.NINTENDO,
                    Stock = 10,

                },
                new { 
                    Id = 5, 
                    Title = "The Crew", 
                    Description = "Racing game", 
                    Price = 15.0, 
                    Image = new Uri("https://image.api.playstation.com/cdn/EP0001/CUSA00161_00/f0kLJbch2vDawClFcF6k9LzZ7Ohi9a7n.png"),
                    Platform = Platform.PC,
                    Stock = 23,
                    MinOperatingSystem = OperatingSystem.Windows10_64Bit,
                    RecomandedOperatingSystem = OperatingSystem.Windows11_32Bit
                },
                new { 
                    Id = 6, 
                    Title = "Minecraft", 
                    Description = "This doesn't need a description", 
                    Price = 25.0, 
                    Platform = Platform.PC,
                    Stock = 6,
                    MinOperatingSystem = OperatingSystem.Windows10_64Bit,
                    RecomandedOperatingSystem = OperatingSystem.Windows11_32Bit
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
