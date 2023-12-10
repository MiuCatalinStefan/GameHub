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
            List<ProductListMemberDto> products = _unitOfWork.Product.GetFiltered(title, selectedCategoryName)
                .Select(ProductListMemberDto.MapProductToDto)
                .ToList();

            List<CategoryDto> allCategories = _unitOfWork.Category.GetAll()
                .Select(CategoryDto.MapCategoryToDto)
                .ToList();

            return View((products, allCategories, title, selectedCategoryName, orderLabels));
        }

        public IActionResult DetailProduct(int id)
        {
            Debug.Print(id.ToString());
            List<Product> products = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
            if (id != 0)
            {
                Product product = products.Where(p => p.Id == id).First();                
                if (product != null)
                {
                    Debug.Print("product displayed!");
                    ProductDto productDto = ProductDto.MapProductToDto(product);
                    List<ProductDto> relatedProducts = RelatedProductsBasedOnCategory(product.Categories, products);
                    return View((id, productDto, relatedProducts));
                }
                else
                {
                    Debug.Print("exception");
                    throw new Exception("No product with this id");
                }
            }
            return null;
        }

        public List<ProductDto> RelatedProductsBasedOnCategory(List<Category> categories, List<Product> allProducts)
        {
            List<Product> products = allProducts.Where(p => p.Categories.Any(c => categories.Contains(c))).ToList();
            List<ProductDto> productDtos = products.Select(p => ProductDto.GetPartialProductDto(p)).ToList();
            if (productDtos.Count > 0)
            {
                return productDtos;
            }
            return [];
        }
    }

}
