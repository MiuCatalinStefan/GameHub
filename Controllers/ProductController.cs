using GameHub.Data;
using GameHub.Models;
using Microsoft.AspNetCore.Mvc;
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
    }
}
