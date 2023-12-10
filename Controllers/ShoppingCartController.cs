﻿using GameHub.CRUD.ShoppingCartsCRUD;
using GameHub.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GameHub.Controllers
{
    public class ShoppingCartController(IShoppingCartCRUD shoppingCartCRUD) : Controller
    {
        private readonly IShoppingCartCRUD _shoppingCartCRUD = shoppingCartCRUD;
        public IActionResult Index(string userId)
        {
            ShoppingCartDto shoppingCart = _shoppingCartCRUD.Get(userId);

            return View(shoppingCart);
        }
    }

}
