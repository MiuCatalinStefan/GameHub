using GameHub.Dto;
using GameHub.Dto.DtoServices.IDtoServices;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GameHub.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IServiceShoppingCart _shoppingCart;

        public ShoppingCartController(IServiceShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
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

                ShoppingCartDto shoppingCart = _shoppingCart.Get(userId);

                return View(shoppingCart);
            } catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
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

            ShoppingCartDto shoppingCart = _shoppingCart.AddProduct(productId, userId);

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

            ShoppingCartDto shoppingCart = _shoppingCart.DeleteProduct(productId, userId);

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

            ShoppingCartDto shoppingCart = _shoppingCart.IncreaseQuantity(productId, userId);

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

            ShoppingCartDto shoppingCart = _shoppingCart.DecreaseQuantity(productId, userId);

            return RedirectToAction(nameof(Index));
        }
    }

}
