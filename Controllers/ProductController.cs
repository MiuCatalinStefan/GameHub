using GameHub.CRUD;
using GameHub.Data;
using GameHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;

namespace GameHub.Controllers
{
    public class ProductController(IProductCRUD productCRUD, ICategoryCRUD categoryCRUD) : Controller
    {
        private readonly IProductCRUD _productCRUD = productCRUD;
        private readonly ICategoryCRUD _categoryCRUD = categoryCRUD;

        // this one should match ProductSorting enum
        private static readonly List<string> orderLabels = [
            "None",
            "Price Ascending",
            "Price Descending"
        ];

        public IActionResult Index(string title, string selectedCategoryName)
        {
            Debug.Print(selectedCategoryName);
            List<Product> products = _productCRUD.Get(title, selectedCategoryName);
            List<Category> allCategories = _categoryCRUD.GetAll();
            return View((products, allCategories, title, selectedCategoryName, orderLabels));
        }
    }
}
