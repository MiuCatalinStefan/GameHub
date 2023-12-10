using GameHub.CRUD;
using GameHub.CRUD.CategoriesCRUD;
using GameHub.CRUD.ProductsCRUD;
using GameHub.Dto;
using GameHub.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GameHub.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // this one should match ProductSorting enum
        private static readonly List<string> orderLabels = [
            "None",
            "Price Ascending",
            "Price Descending"
        ];

        public IActionResult Index(string title, string selectedCategoryName)
        {
            Debug.Print(selectedCategoryName);
            List<Product> products = _unitOfWork.Product.GetFiltered(title, selectedCategoryName);
            List<Category> allCategories = _unitOfWork.Category.GetAll().ToList();
            return View((products, allCategories, title, selectedCategoryName, orderLabels));
        }

        public IActionResult DetailProduct(int id)
        {
            Debug.Print(id.ToString());
            List<Product> products = _unitOfWork.Product.GetAll().ToList();
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
