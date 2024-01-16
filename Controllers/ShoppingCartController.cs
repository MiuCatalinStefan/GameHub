using GameHub.CRUD;
using GameHub.Dto;
using GameHub.DtoServices.IDtoServices;
using GameHub.Models;
using GameHub.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GameHub.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IServiceShoppingCart _shoppingCart;
        private readonly IUnitOfWork _unitOfWork;
		[BindProperty]
		public ShoppingCartDto shoppingCart { get; set; }

		public ShoppingCartController(IServiceShoppingCart shoppingCart, IUnitOfWork unitOfWork)
        {
            _shoppingCart = shoppingCart;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            try
            {
                ClaimsIdentity claimsIdentity = (ClaimsIdentity)User.Identity;
                if (claimsIdentity.IsAuthenticated == false)
                {
                    ViewBag.UserNotLoggedIn = false;
                    return View();
                }
                var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

                 shoppingCart = _shoppingCart.Get(userId);

                return View(shoppingCart);
            } catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
		public IActionResult Checkout()
		{
			var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			if (string.IsNullOrEmpty(userId))
			{
				ViewBag.IsUserAuthenticated = false;
				return View();
			}

			var shoppingCart = _shoppingCart.PrepareCheckout(userId);
			return View(shoppingCart);
		}

		[HttpPost]
		[ActionName("Checkout")]
		public IActionResult CheckoutPOST()
		{
			var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			if (string.IsNullOrEmpty(userId))
			{
				ViewBag.UserNotLoggedIn = false;
				return View();
			}

			Stripe.Checkout.Session session = _shoppingCart.CompleteCheckout(shoppingCart, userId);

			Response.Headers.Add("Location", session.Url);
			return new StatusCodeResult(303);
		}
	

	public IActionResult OrderConfirmation(int id)
        {
            _shoppingCart.PostProcessOrder(id);
			return View(id);
        }
		public IActionResult AddProduct(int productId)
        {
            ClaimsIdentity claimsIdentity = (ClaimsIdentity)User.Identity;
            if (claimsIdentity.IsAuthenticated == false)
            {
                ViewBag.UserNotLoggedIn = false;
                return RedirectToAction(nameof(Index));
            }
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

             shoppingCart = _shoppingCart.AddProduct(productId, userId);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteProduct(int productId)
        {
            ClaimsIdentity claimsIdentity = (ClaimsIdentity)User.Identity;
            if (claimsIdentity.IsAuthenticated == false)
            {
                ViewBag.UserNotLoggedIn = false;
                return RedirectToAction(nameof(Index));
            }
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

             shoppingCart = _shoppingCart.DeleteProduct(productId, userId);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult IncreaseQuantity(int productId)
        {
            ClaimsIdentity claimsIdentity = (ClaimsIdentity)User.Identity;
            if (claimsIdentity.IsAuthenticated == false)
            {
                ViewBag.UserNotLoggedIn = false;
                return RedirectToAction(nameof(Index));
            }
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

             shoppingCart = _shoppingCart.IncreaseQuantity(productId, userId);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult DecreaseQuantity(int productId)
        {
            ClaimsIdentity claimsIdentity = (ClaimsIdentity)User.Identity;
            if (claimsIdentity.IsAuthenticated == false)
            {
                ViewBag.UserNotLoggedIn = false;
                return RedirectToAction(nameof(Index));
            }
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

             shoppingCart = _shoppingCart.DecreaseQuantity(productId, userId);

            return RedirectToAction(nameof(Index));
        }
    }

}
