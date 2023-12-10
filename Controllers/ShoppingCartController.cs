using GameHub.Data;
using GameHub.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GameHub.Controllers
{
    public class ShoppingCartController(ApplicationDbContext db) : Controller
    {
        private readonly ApplicationDbContext _db = db;
        public IActionResult Index(int userId = 0)
        {
            Debug.Print(userId.ToString());
            ShoppingCartDto shoppingCart = new ShoppingCartDto();

            ShoppingCart dbItem = _db.ShoppingCarts.Where(t => t.UserId == userId).FirstOrDefault();

            if (dbItem != null)
            {
                shoppingCart.UserId = dbItem.UserId;
                double totalPrice = 0;
                foreach (var item in dbItem.Products)
                {
                    ProductDto product = new ProductDto();
                    product.ProductId = item.Id;
                    product.ProductName = item.Title;
                    product.ProductPrice = item.Price;

                    totalPrice += item.Price;
                    shoppingCart.Products.Add(product);
                }
                shoppingCart.TotalPrice = totalPrice;
            }

            return View(shoppingCart);
        }
    }

    public class ShoppingCartDto
    {
        public int UserId { get; set; }
        public List<ProductDto> Products { get; set; } = [];
        public double TotalPrice { get; set; }
    }

    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = "";
        public double ProductPrice { get; set; }
    }
}
