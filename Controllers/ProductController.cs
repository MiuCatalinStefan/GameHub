using GameHub.Data;
using GameHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;

namespace GameHub.Controllers
{
    public class ProductController(ApplicationDbContext db) : Controller
    {
        private readonly ApplicationDbContext _db = db;

        public IActionResult Index(string title)
        {
            Debug.Print(title);
            List<Product> products = [];

            if (title.IsNullOrEmpty())
            {
                Debug.Print("it failed");
                products = [.. _db.Products];
            }
            else
            {
                Debug.Print("it worked");
                products = [.. _db.Products.Where(t => t.Title.Contains(title))];
            }

            return View((products, title));
        }

        public IActionResult DetailProduct(int id) {
            Debug.Print(id.ToString());
            List<Product> products = [.. _db.Products];
            Product product = products.Where(p => p.Id == id).First();
            if (product != null) {
                Debug.Print("product displayed!");
                return View((id, product));
            } else {
                Debug.Print("exception");
                throw new Exception("No product with this id");
            }
        }
    }

}
