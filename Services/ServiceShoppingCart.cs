using GameHub.CRUD;
using GameHub.Data;
using GameHub.Dto;
using GameHub.DtoServices.IDtoServices;
using GameHub.Models;
using GameHub.Utils;
using Microsoft.AspNetCore.Mvc;
using Stripe.BillingPortal;
using Stripe.Checkout;
using static Azure.Core.HttpHeader;

namespace GameHub.DtoServices
{
    public class ServiceShoppingCart : IServiceShoppingCart
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

            var cartProducts = _unitOfWork.ShoppingCartProduct.GetAll(t => t.ShoppingCartId == dbItem.Id);

            if (dbItem != null)
            {
                shoppingCart.UserId = dbItem.ApplicationUserId;
                shoppingCart.Id = dbItem.Id;
                double totalPrice = 0;
                foreach (var item in cartProducts)
                {
                    ShoppingCartProductDto product = new ShoppingCartProductDto();
                    var dbProduct = _unitOfWork.Product.Get(t => t.Id == item.ProductId);
                    product.ProductName = dbProduct.Title;
                    product.Price = dbProduct.Price;
                    product.Quantity = item.Quantity;
                    product.ProductId = item.ProductId;
                    product.Description = dbProduct.Description;
                    product.Image = dbProduct.Image;
                    product.Id = item.Id;

                    totalPrice += dbProduct.Price * item.Quantity;
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
                var cart = _unitOfWork.ShoppingCart.Get(t => t.ApplicationUserId == userId && t.IsDeleted == false)
                           ?? new ShoppingCart { ApplicationUserId = userId, IsDeleted = false, LastModified = DateTime.UtcNow };

                if (cart.Id == 0)
                {
                    _unitOfWork.ShoppingCart.Add(cart);
                    _unitOfWork.Save();
                    cart = _unitOfWork.ShoppingCart.Get(t => t.ApplicationUserId == userId && t.IsDeleted == false); // Reload the cart with ID
                }
                else
                {
                    cart.LastModified = DateTime.UtcNow;
                    _unitOfWork.ShoppingCart.Update(cart);
                }

                cart.Products = _unitOfWork.ShoppingCartProduct.GetAll(p => p.ShoppingCartId == cart.Id).ToList(); // Ensure products are loaded

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
                    _unitOfWork.ShoppingCartProduct.Update(cartProduct);
                }
                else
                {
                    var newShoppingCartProduct = new ShoppingCartProduct
                    {
                        ProductId = productId,
                        ShoppingCartId = cart.Id,
                        Quantity = 1,
                        Description = product.Description,
                        Image = product.Image,

                    };

                    _unitOfWork.ShoppingCartProduct.Add(newShoppingCartProduct);
                    cart.Products.Add(newShoppingCartProduct);
                }
                _unitOfWork.Save();
                cart.Products = LoadCartProducts(cart.Id);

                return MapToShoppingCartDto(cart);
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
                if (cart == null)
                {
                    throw new InvalidOperationException("Shopping cart not found");
                }

                cart.Products = LoadCartProducts(cart.Id);


                var productToRemove = cart.Products.FirstOrDefault(p => p.ProductId == productId);
                if (productToRemove == null)
                {
                    throw new InvalidOperationException("Product not found");
                }
                else
                {
                    _unitOfWork.ShoppingCartProduct.Remove(productToRemove);
                }

                _unitOfWork.Save();

                return MapToShoppingCartDto(cart);
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
                if (cart == null)
                {
                    throw new InvalidOperationException("Shopping cart not found");
                }

                cart.Products = _unitOfWork.ShoppingCartProduct.GetAll(p => p.ShoppingCartId == cart.Id).ToList();

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
                cart.Products = LoadCartProducts(cart.Id);

                if (cartProduct.Quantity + 1 > product.Stock)
                {
                    throw new InvalidOperationException("Insufficient stock to increase quantity");
                }
                cartProduct.Quantity += 1;
                _unitOfWork.ShoppingCartProduct.Update(cartProduct);
                _unitOfWork.Save();

                return MapToShoppingCartDto(cart);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        private ShoppingCartDto MapToShoppingCartDto(ShoppingCart cart)
        {
            var shoppingCartDto = new ShoppingCartDto
            {
                UserId = cart.ApplicationUserId,
                Id = cart.Id,
                TotalPrice = cart.Products.Sum(p => p.Product.Price * p.Quantity),
                Products = cart.Products.Select(p => new ShoppingCartProductDto
                {
                    Id = p.Id,
                    ProductId = p.ProductId,
                    ProductName = p.Product.Title,
                    Price = p.Product.Price * p.Quantity,
                    Quantity = p.Quantity,
                    Description = p.Product.Description,
                    Image = p.Product.Image
                }).ToList()
            };

            return shoppingCartDto;
        }
        private List<ShoppingCartProduct> LoadCartProducts(int cartId)
        {
            return _unitOfWork.ShoppingCartProduct.GetAll(p => p.ShoppingCartId == cartId, "Product").ToList();
        }
        public ShoppingCartDto DecreaseQuantity(int productId, string userId)
        {
            try
            {
                var cart = _unitOfWork.ShoppingCart.Get(t => t.ApplicationUserId == userId && t.IsDeleted == false);
                if (cart == null)
                {
                    throw new InvalidOperationException("Shopping cart not found");
                }

                cart.Products = _unitOfWork.ShoppingCartProduct.GetAll(p => p.ShoppingCartId == cart.Id).ToList();

                var cartProduct = cart.Products.FirstOrDefault(p => p.ProductId == productId);
                if (cartProduct == null)
                {
                    throw new InvalidOperationException("Product not found in cart");
                }
                cart.Products = LoadCartProducts(cart.Id);

                if (cartProduct.Quantity <= 1)
                {
                    _unitOfWork.ShoppingCartProduct.Remove(cartProduct);
                }
                else
                {
                    cartProduct.Quantity -= 1;
                    _unitOfWork.ShoppingCartProduct.Update(cartProduct);
                }

                _unitOfWork.Save();
                return MapToShoppingCartDto(cart);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public ShoppingCartDto PrepareCheckout(string userId)
        {
			var cart = this.Get(userId);

			if (cart == null) return null;

            var applicationUser = _unitOfWork.ApplicationUser.Get(u => u.Id == userId);
            if (applicationUser != null)
            {
				cart.Order = new Order
                    {
                        PhoneNumber = applicationUser.PhoneNumber,
                        FullName = $"{applicationUser.FirstName ?? ""} {applicationUser.LastName ?? ""}".Trim(),
                        StreetAddress = applicationUser.StreetAddress,
                        City = applicationUser.City,
                        State = applicationUser.State,
                        PostalCode= applicationUser.ZipCode,
                        Email=applicationUser.Email
                };
            }

            return cart;
        }

        public Stripe.Checkout.Session CompleteCheckout(ShoppingCartDto shoppingCart, string userId)
        {
			var cart = this.Get(userId);
            shoppingCart.Products=cart.Products;
			shoppingCart.Order.OrderDate = DateTime.Now;
            shoppingCart.Order.ApplicationUserId = userId;
            shoppingCart.Order.OrderStatus = Statuses.StatusPending;
            shoppingCart.Order.PaymentStatus = Statuses.PaymentStatusPending;

            _unitOfWork.Order.Add(shoppingCart.Order);
            _unitOfWork.Save();

            foreach (var product in shoppingCart.Products)
            {
                var orderProduct = new OrderProducts
                {
                    ProductId = product.ProductId,
                    OrderHeaderId = shoppingCart.Order.Id,
                    Price = product.Price,
                    Count = product.Quantity
                };

                _unitOfWork.OrderProducts.Add(orderProduct);
                _unitOfWork.Save();
            }
            var domain = "https://localhost:7253/";
			var options = new Stripe.Checkout.SessionCreateOptions
			{
				SuccessUrl = domain+$"ShoppingCart/OrderConfirmation?id={shoppingCart.Order.Id}",
                CancelUrl = domain+"ShoppingCart/Index",
				LineItems = new List<Stripe.Checkout.SessionLineItemOptions>(),
				Mode = "payment",
			};

            foreach(var item in shoppingCart.Products)
            {
                var sessionLineItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(item.Price * 100),
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.ProductName
                        }
                    },
                    Quantity = item.Quantity,
                };
                options.LineItems.Add(sessionLineItem);
            }
			var service = new Stripe.Checkout.SessionService();
            Stripe.Checkout.Session session =service.Create(options);
            _unitOfWork.Order.UpdateStripePaymentId(shoppingCart.Order.Id, session.Id, session.PaymentIntentId);
            _unitOfWork.Save();
            return session;
		}

        public void PostProcessOrder(int id)
        {
            Order order = _unitOfWork.Order.Get(u=>u.Id == id, includeProperties:"ApplicationUser");
			var service = new Stripe.Checkout.SessionService();
			Stripe.Checkout.Session session = service.Get(order.SessionId);

			if (session.PaymentStatus.ToLower() == "paid")
			{
				_unitOfWork.Order.UpdateStripePaymentId(id, session.Id, session.PaymentIntentId);
				_unitOfWork.Order.UpdateStatus(id, Statuses.StatusApproved, Statuses.PaymentStatusApproved);
				_unitOfWork.Save();
			}

            List<ShoppingCart> shoppingCarts = _unitOfWork.ShoppingCart.GetAll(u=>u.ApplicationUserId==order.ApplicationUserId).ToList();
            _unitOfWork.ShoppingCart.RemoveRange(shoppingCarts);
            _unitOfWork.Save();
		}
    }
}
