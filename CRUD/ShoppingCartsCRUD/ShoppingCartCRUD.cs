using GameHub.Data;
using GameHub.Dto;
using GameHub.Models;

namespace GameHub.CRUD.ShoppingCartsCRUD
{
    public class ShoppingCartCRUD(ApplicationDbContext db) : IShoppingCartCRUD
    {
        private readonly ApplicationDbContext _db = db;

        public ShoppingCartDto Get(int userId = 0)
        {
            ShoppingCartDto shoppingCart = new ShoppingCartDto();

            ShoppingCart dbItem = _db.ShoppingCarts.Where(t => t.UserId == userId).FirstOrDefault();

            if (dbItem != null)
            {
                shoppingCart.UserId = dbItem.UserId;
                double totalPrice = 0;
                foreach (var item in dbItem.Products)
                {
                    ShoppingCartProductDto product = new ShoppingCartProductDto();
                    product.Id = item.Id;
                    product.ProductName = item.Product.Title;
                    product.Price = item.Product.Price;
                    product.Quantity = item.Quantity;

                    totalPrice += item.Product.Price;
                    shoppingCart.Products.Add(product);
                }
                shoppingCart.TotalPrice = totalPrice;
            }

            return shoppingCart;
        }
    }
}
