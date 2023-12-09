using GameHub.Data;
using GameHub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace GameHub.CRUD
{
    public enum ProductSorting : int
    {
        None = 0, 
        PriceAscending = 1, 
        PriceDescending = 2
    }

    public class ProductCRUD(ApplicationDbContext db) : IProductCRUD
    {
        private readonly ApplicationDbContext _db = db;

        public List<Product> Get(string title, string selectedCategory)
        {
            Category? category = _db.Categories.FirstOrDefault(x => x.Name == selectedCategory);

            List<Product> products = [.. _db.Products
                .Where(t => (title.IsNullOrEmpty() || t.Title.Contains(title)) && (category == null || t.Categories.Contains(category)))
                ];

            return products;
        }
    }
}
