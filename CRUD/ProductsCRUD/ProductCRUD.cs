using GameHub.Data;
using GameHub.Models;
using GameHub.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace GameHub.CRUD.ProductsCRUD
{
    public enum ProductSorting : int
    {
        None = 0,
        PriceAscending = 1,
        PriceDescending = 2
    }

    public class ProductCRUD : RepoCRUD<Product>, IProductCRUD
    {
        private readonly ApplicationDbContext _db;
        public ProductCRUD(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public List<Product> GetFiltered(string title, string selectedCategory, string selectedRegion, string selectedPlatform, SortingOrder order, double minPrice, double maxPrice)
        {
            Category? category = _db.Categories.FirstOrDefault(x => x.Name == selectedCategory);
            Region? region = _db.Regions.FirstOrDefault(x => x.Name == selectedRegion);
            Platform? platform = _db.Platforms.FirstOrDefault(x => x.Name == selectedPlatform);

            List<Product> products = [];
            IEnumerable<Product> query = _db.Products
                .Where(t => (title.IsNullOrEmpty() || t.Title.Contains(title)) &&
                (category == null || t.Categories.Contains(category)) &&
                (region == null || t.Region == region) &&
                (platform == null || t.Platform == platform) &&
                t.Price >= minPrice &&
                t.Price <= maxPrice
                );


            switch (order)
            {
                case SortingOrder.None:
                    products = [.. query];
                    break;
                case SortingOrder.TitleAscending: 
                    products = [.. query.OrderBy(t => t.Title)]; 
                    break;
                case SortingOrder.TitleDescending:
                    products = [.. query.OrderByDescending(t => t.Title)];
                    break;
                case SortingOrder.PriceAscending:
                    products = [.. query.OrderBy(t => t.Price)]; 
                    break;
                case SortingOrder.PriceDescending:
                    products = [.. query.OrderByDescending(t => t.Price)];
                    break;
            }

            return products;
        }


        public void Update(Product product)
        {
            _db.Products.Update(product);
        }

        public List<Product> GetAllProductsWithCategories()
        {
            return [.. _db.Products.Include(p => p.Categories)];
        }
    }
}
