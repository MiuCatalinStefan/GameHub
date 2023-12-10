using GameHub.CRUD.CategoriesCRUD;
using GameHub.CRUD.ProductsCRUD;
using GameHub.Dto;
using GameHub.Models;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult DetailProduct(int id)
        {
            Debug.Print(id.ToString());
            List<Product> products = _productCRUD.GetAll();
            Product product = products.Where(p => p.Id == id).First();
            if (product != null)
            {
                Debug.Print("product displayed!");
                return View((id, ProductDto.MapProductToDto(product)));
            }
            else
            {
                Debug.Print("exception");
                throw new Exception("No product with this id");
            }
        }
    }

}
