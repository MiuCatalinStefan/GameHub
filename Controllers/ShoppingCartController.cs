using GameHub.CRUD;
using GameHub.Dto;
using GameHub.Dto.DtoServices;
using GameHub.Dto.DtoServices.IDtoServices;
using Microsoft.AspNetCore.Mvc;

namespace GameHub.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IServiceShoppingCart _shoppingCart;

        public ShoppingCartController(IServiceShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }
        public IActionResult Index(string userId)
        {
            ShoppingCartDto shoppingCart = _shoppingCart.Get(userId);

            return View(shoppingCart);
        }
    }

}
