using GameHub.CRUD;
using GameHub.CRUD.CategoriesCRUD;
using GameHub.CRUD.ProductsCRUD;
using GameHub.Dto;
using GameHub.Models;
using GameHub.Utils;
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
            "No Order",
            "Title A-Z",
            "Title Z-A",
            "Price Ascending",
            "Price Descending"
        ];

        public IActionResult Index(string title, string selectedCategoryName, string selectedRegionName, string selectedPlatformName, string selectedOrdering = "No Order", double minPrice = 0, double maxPrice = 999)
        {
            List<ProductListMemberDto> products = _unitOfWork.Product.GetFiltered(title, selectedCategoryName, selectedRegionName, selectedPlatformName, (SortingOrder)orderLabels.IndexOf(selectedOrdering), minPrice, maxPrice)
                .Select(ProductListMemberDto.MapProductToDto)
                .ToList();

            List<CategoryDto> allCategories = _unitOfWork.Category.GetAll()
                .Select(CategoryDto.MapCategoryToDto)
                .ToList();

            List<RegionDto> allRegions = _unitOfWork.Region.GetAll()
                .Select(RegionDto.MapRegionToDto)
                .ToList();

            List<PlatformDto> allPlatforms = _unitOfWork.Platform.GetAll()
                .Select(PlatformDto.MapPlatformToDto)
                .ToList();

            return View((products, allCategories, allRegions, allPlatforms, orderLabels, title, selectedCategoryName, selectedRegionName, selectedPlatformName, selectedOrdering, minPrice, maxPrice));
        }

        public IActionResult DetailProduct(int id)
        {
            Debug.Print(id.ToString());
            List<Product> products = _unitOfWork.Product.GetAll(includeProperties: "Categories,Platform").ToList();
            if (id != 0)
            {
                Product product = products.Where(p => p.Id == id).First();                
                if (product != null)
                {
                    Debug.Print("product displayed!");
                    ProductDto productDto = ProductDto.MapProductToDto(product);
                    List<ProductDto> relatedProducts = RelatedProductsBasedOnCategory(product.Categories, products);
                    relatedProducts = relatedProducts.Where(prod => prod.Id != id).ToList();
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
