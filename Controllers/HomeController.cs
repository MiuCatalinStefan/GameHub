using GameHub.CRUD;
using GameHub.Dto;
using GameHub.Models;
using GameHub.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GameHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;


        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;

        }

        public IActionResult Index()
        {
            List<ProductListMemberDto> products = _unitOfWork.Product.GetAll()
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

            return View((products, allCategories, allRegions, allPlatforms));

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
