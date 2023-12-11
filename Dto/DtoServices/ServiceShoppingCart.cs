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
            var cart = _unitOfWork.ShoppingCart.Get(t => t.ApplicationUserId == userId && t.IsDeleted == false)
                       ?? new ShoppingCart { ApplicationUserId = userId, IsDeleted = false };

            if (cart.Id == 0)
            {
                _unitOfWork.ShoppingCart.Add(cart);
            }

            var product = _unitOfWork.Product.Get(t => t.Id == productId);
            if (product == null)
            {
                throw new ArgumentException("Product not found");
            }

            if (product.Stock <= 0)
            {
                throw new InvalidOperationException("Product is out of stock");
            }

            var cartProduct = cart.Products.FirstOrDefault(t => t.ProductId == productId);
            if (cartProduct != null)
            {
                if (cartProduct.Quantity + 1 > product.Stock)
                {
                    throw new InvalidOperationException("Insufficient stock for the product");
                }
                cartProduct.Quantity += 1;
            }
            else
            {
                cart.Products.Add(new ShoppingCartProduct
                {
                    ProductId = productId,
                    Quantity = 1,
                    Product = product
                });
            }

            _unitOfWork.Save();

            double totalPrice = cart.Products.Sum(p => p.Product.Price * p.Quantity);

            return new ShoppingCartDto
            {
                UserId = cart.ApplicationUserId,
                TotalPrice = totalPrice,
                Products = cart.Products.Select(p => new ShoppingCartProductDto
                {
                    ProductId = p.ProductId,
                    ProductName = p.Product.Title,
                    Price = p.Product.Price,
                    Quantity = p.Quantity
                }).ToList()
            };
        }

        public ShoppingCartDto DeleteProduct(int productId, string userId)
        {
            try
            {
                var cart = _unitOfWork.ShoppingCart.Get(t => t.ApplicationUserId == userId && t.IsDeleted == false);
                if (cart == null)
                {
                    throw new InvalidOperationException("Shopping cart not found");
                }

                var productToRemove = cart.Products.FirstOrDefault(p => p.ProductId == productId);
                if (productToRemove != null)
                {
                    cart.Products.Remove(productToRemove);
                    _unitOfWork.ShoppingCartProduct.Remove(productToRemove);
                }

                _unitOfWork.Save();

                return new ShoppingCartDto
                {
                    UserId = cart.ApplicationUserId,
                    TotalPrice = cart.Products.Sum(p => p.Product.Price * p.Quantity),
                    Products = cart.Products.Select(p => new ShoppingCartProductDto
                    {
                        ProductId = p.ProductId,
                        ProductName = p.Product.Title,
                        Price = p.Product.Price,
                        Quantity = p.Quantity
                    }).ToList()
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null; 
            }
        }

        public ShoppingCartDto IncreaseQuantity(int productId, string userId)
        {
            var cart = _unitOfWork.ShoppingCart.Get(t => t.ApplicationUserId == userId && t.IsDeleted == false);
            if (cart == null)
            {
                throw new InvalidOperationException("Shopping cart not found");
            }

            var cartProduct = cart.Products.FirstOrDefault(p => p.ProductId == productId);
            if (cartProduct == null)
            {
                throw new InvalidOperationException("Product not found in cart");
            }

            var product = _unitOfWork.Product.Get(t => t.Id == productId);
            if (product == null)
            {
                throw new InvalidOperationException("Product details not found");
            }

            if (cartProduct.Quantity + 1 > product.Stock)
            {
                throw new InvalidOperationException("Insufficient stock to increase quantity");
            }

            cartProduct.Quantity += 1;

            _unitOfWork.ShoppingCartProduct.Update(cartProduct);
            _unitOfWork.Save();

            double totalPrice = cart.Products.Sum(p => p.Product.Price * p.Quantity);

            return new ShoppingCartDto
            {
                UserId = cart.ApplicationUserId,
                TotalPrice = totalPrice,
                Products = cart.Products.Select(p => new ShoppingCartProductDto
                {
                    ProductId = p.ProductId,
                    ProductName = p.Product.Title,
                    Price = p.Product.Price,
                    Quantity = p.Quantity
                }).ToList()
            };
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
