using GameHub.CRUD;
using GameHub.Data;
using GameHub.Dto;
using GameHub.Dto.DtoServices.IDtoServices;
using GameHub.Models;
using static Azure.Core.HttpHeader;

namespace GameHub.Dto.DtoServices
{
    public class ServiceShoppingCart: IServiceShoppingCart
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServiceShoppingCart(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ShoppingCartDto Get(string userId)
        {
            ShoppingCartDto shoppingCart = new ShoppingCartDto();

            var dbItem = _unitOfWork.ShoppingCart.Get(t => t.ApplicationUserId == userId && t.IsDeleted == false);

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

                    totalPrice += item.Product.Price * item.Quantity;
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
                var cart = _unitOfWork.ShoppingCart.Get(t => t.ApplicationUserId == userId && t.IsDeleted == false);
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
                    _unitOfWork.ShoppingCart.Add(cart);
                }
                else
                {
                    _unitOfWork.ShoppingCart.Update(cart);
                }
                _unitOfWork.Save();

                var cartId = _unitOfWork.ShoppingCart.Get(t => t.ApplicationUserId == userId && t.IsDeleted == false).Id;

                if (cart.Products.Where(t => t.ProductId == productId).Any())
                {
                    var product = cart.Products.Where(t => t.ProductId == productId).FirstOrDefault();
                    product.Quantity += 1;
                    _unitOfWork.ShoppingCartProduct.Update(product);
                }
                else
                {
                    var product = _unitOfWork.Product.Get(t => t.Id == productId);
                    var cartItem = new ShoppingCartProduct()
                    {
                        ProductId = productId,
                        ShoppingCartId = cartId,
                        Quantity = 1
                    };
                    _unitOfWork.ShoppingCartProduct.Add(cartItem);
                }
                _unitOfWork.Save();

                var dbItem = _unitOfWork.ShoppingCart.Get(t => t.Id == cartId);

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

                        totalPrice += item.Product.Price * item.Quantity;
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

        public ShoppingCartDto DeleteProduct(int productId, string userId)
        {
            try
            {
                var cart = _unitOfWork.ShoppingCart.Get(t => t.ApplicationUserId == userId && t.IsDeleted == false);
                var obj = cart.Products.Where(t => t.ProductId == productId).FirstOrDefault();
                _unitOfWork.ShoppingCartProduct.Remove(obj);
                _unitOfWork.Save();

                cart.Products.Remove(cart.Products.Where(note => note.Id == productId).First());
                if (cart.Products.Count == 0)
                {
                    _unitOfWork.ShoppingCart.Remove(cart);
                    _unitOfWork.Save();
                }

                var dbItem = _unitOfWork.ShoppingCart.Get(t => t.Id == cart.Id);

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

                        totalPrice += item.Product.Price * item.Quantity;
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

        public ShoppingCartDto IncreaseQuantity(int productId, string userId)
        {
            try
            {
                var cart = _unitOfWork.ShoppingCart.Get(t => t.ApplicationUserId == userId && t.IsDeleted == false);
                var obj = cart.Products.Where(t => t.ProductId == productId).FirstOrDefault();
                obj.Quantity += 1;
                _unitOfWork.ShoppingCartProduct.Update(obj);
                _unitOfWork.Save();

                var dbItem = _unitOfWork.ShoppingCart.Get(t => t.Id == cart.Id);

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

                        totalPrice += item.Product.Price * item.Quantity;
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
                var cart = _unitOfWork.ShoppingCart.Get(t => t.ApplicationUserId == userId && t.IsDeleted == false);
                var obj = cart.Products.Where(t => t.ProductId == productId).FirstOrDefault();
                obj.Quantity += -1;
                _unitOfWork.ShoppingCartProduct.Update(obj);
                _unitOfWork.Save();

                var dbItem = _unitOfWork.ShoppingCart.Get(t => t.Id == cart.Id);

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

                        totalPrice += item.Product.Price * item.Quantity;
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
