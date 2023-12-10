using GameHub.Data;
using GameHub.Models;
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

        public List<Product> GetFiltered(string title, string selectedCategory)
        {
            Category? category = _db.Categories.FirstOrDefault(x => x.Name == selectedCategory);

            List<Product> products = [.. _db.Products
                .Where(t => (title.IsNullOrEmpty() || t.Title.Contains(title)) && (category == null || t.Categories.Contains(category)))
                ];

            return products;
        }

        public void Save()
        {
            _db.SaveChanges();

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
