using GameHub.Data;
using GameHub.Dto;
using GameHub.Models;
using static Azure.Core.HttpHeader;

namespace GameHub.CRUD.ShoppingCartsCRUD
{
    public class ShoppingCartCRUD(ApplicationDbContext db) : IShoppingCartCRUD
    {
        private readonly ApplicationDbContext _db = db;



        public ShoppingCartDto Get(string userId)
        {
            ShoppingCartDto shoppingCart = new ShoppingCartDto();

            var dbItem = _db.ShoppingCarts.Where(t => t.ApplicationUserId == userId && t.IsDeleted == false).FirstOrDefault();

            if (dbItem != null)
            {
                shoppingCart.UserId = dbItem.ApplicationUserId;
                double totalPrice = 0;
                foreach (var item in dbItem.Products)
                {
                    ShoppingCartProductDto product = new ShoppingCartProductDto();
                    product.ProductName = item.Product.Title;
                    product.Price = item.Product.Price;
                    product.Quantity = item.Quantity;

                    totalPrice += (item.Product.Price * item.Quantity);
                    shoppingCart.Products.Add(product);
                }
                shoppingCart.TotalPrice = totalPrice;
            }

            return shoppingCart;
        }

        public ShoppingCartDto AddProduct(int productId, string userId)
        {
            try
            {
                var cart = _db.ShoppingCarts.Where(t => t.ApplicationUserId == userId && t.IsDeleted == false).FirstOrDefault();
                if (cart == null)
                {
                    cart = new ShoppingCart()
                    {
                        ApplicationUserId = userId,
                        IsDeleted = false,
                    };
                }

                cart.LastModified = DateTime.Now;

                if (cart.Id == 0)
                {
                    _db.ShoppingCarts.Add(cart);
                }
                else
                {
                    _db.ShoppingCarts.Update(cart);
                }
                _db.SaveChanges();

                var cartId = _db.ShoppingCarts.Where(t => t.ApplicationUserId == userId && t.IsDeleted == false).Select(t => t.Id).FirstOrDefault();

                if (cart.Products.Where(t => t.ProductId == productId).Any())
                {
                    var product = cart.Products.Where(t => t.ProductId == productId).FirstOrDefault();
                    product.Quantity += 1;
                    _db.ShoppingCartProducts.Update(product);
                }
                else
                {
                    var product = _db.Products.Where(t => t.Id == productId).FirstOrDefault();
                    var cartItem = new ShoppingCartProduct()
                    {
                        ProductId = productId,
                        ShoppingCartId = cartId,
                        Quantity = 1
                    };
                    _db.ShoppingCartProducts.Add(cartItem);
                }
                _db.SaveChanges();

                var dbItem = _db.ShoppingCarts.Where(t => t.Id == cartId).FirstOrDefault();

                ShoppingCartDto shoppingCart = new ShoppingCartDto();

                if (dbItem != null)
                {
                    shoppingCart.UserId = dbItem.ApplicationUserId;
                    double totalPrice = 0;
                    foreach (var item in dbItem.Products)
                    {
                        ShoppingCartProductDto product = new ShoppingCartProductDto();
                        product.ProductName = item.Product.Title;
                        product.Price = item.Product.Price;
                        product.Quantity = item.Quantity;

                        totalPrice += (item.Product.Price * item.Quantity);
                        shoppingCart.Products.Add(product);
                    }
                    shoppingCart.TotalPrice = totalPrice;
                }

                return shoppingCart;

            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
           
        }

        public ShoppingCartDto DeleteProduct(int productId, string userId)
        {
            try
            {
                var cart = _db.ShoppingCarts.Where(t => t.ApplicationUserId == userId && t.IsDeleted == false).FirstOrDefault();
                var obj = cart.Products.Where(t => t.ProductId == productId).FirstOrDefault();
                _db.ShoppingCartProducts.Remove(obj);
                _db.SaveChanges();

                cart.Products.Remove(cart.Products.Where(note => note.Id == productId).First());
                if (cart.Products.Count == 0)
                {
                    _db.ShoppingCarts.Remove(cart);
                    _db.SaveChanges();
                }

                var dbItem = _db.ShoppingCarts.Where(t => t.Id == cart.Id).FirstOrDefault();

                ShoppingCartDto shoppingCart = new ShoppingCartDto();

                if (dbItem != null)
                {
                    shoppingCart.UserId = dbItem.ApplicationUserId;
                    double totalPrice = 0;
                    foreach (var item in dbItem.Products)
                    {
                        ShoppingCartProductDto product = new ShoppingCartProductDto();
                        product.ProductName = item.Product.Title;
                        product.Price = item.Product.Price;
                        product.Quantity = item.Quantity;

                        totalPrice += (item.Product.Price * item.Quantity);
                        shoppingCart.Products.Add(product);
                    }
                    shoppingCart.TotalPrice = totalPrice;
                }

                return shoppingCart;

            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public ShoppingCartDto IncreaseQuantity(int productId, string userId)
        {
            try
            {
                var cart = _db.ShoppingCarts.Where(t => t.ApplicationUserId == userId && t.IsDeleted == false).FirstOrDefault();
                var obj = cart.Products.Where(t => t.ProductId == productId).FirstOrDefault();
                obj.Quantity += 1;
                _db.ShoppingCartProducts.Update(obj);
                _db.SaveChanges();

                var dbItem = _db.ShoppingCarts.Where(t => t.Id == cart.Id).FirstOrDefault();

                ShoppingCartDto shoppingCart = new ShoppingCartDto();

                if (dbItem != null)
                {
                    shoppingCart.UserId = dbItem.ApplicationUserId;
                    double totalPrice = 0;
                    foreach (var item in dbItem.Products)
                    {
                        ShoppingCartProductDto product = new ShoppingCartProductDto();
                        product.ProductName = item.Product.Title;
                        product.Price = item.Product.Price;
                        product.Quantity = item.Quantity;

                        totalPrice += (item.Product.Price * item.Quantity);
                        shoppingCart.Products.Add(product);
                    }
                    shoppingCart.TotalPrice = totalPrice;
                }

                return shoppingCart;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public ShoppingCartDto DecreaseQuantity(int productId, string userId)
        {
            try
            {
                var cart = _db.ShoppingCarts.Where(t => t.ApplicationUserId == userId && t.IsDeleted == false).FirstOrDefault();
                var obj = cart.Products.Where(t => t.ProductId == productId).FirstOrDefault();
                obj.Quantity += -1;
                _db.ShoppingCartProducts.Update(obj);
                _db.SaveChanges();

                var dbItem = _db.ShoppingCarts.Where(t => t.Id == cart.Id).FirstOrDefault();

                ShoppingCartDto shoppingCart = new ShoppingCartDto();

                if (dbItem != null)
                {
                    shoppingCart.UserId = dbItem.ApplicationUserId;
                    double totalPrice = 0;
                    foreach (var item in dbItem.Products)
                    {
                        ShoppingCartProductDto product = new ShoppingCartProductDto();
                        product.ProductName = item.Product.Title;
                        product.Price = item.Product.Price;
                        product.Quantity = item.Quantity;

                        totalPrice += (item.Product.Price * item.Quantity);
                        shoppingCart.Products.Add(product);
                    }
                    shoppingCart.TotalPrice = totalPrice;
                }

                return shoppingCart;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

    }
}
