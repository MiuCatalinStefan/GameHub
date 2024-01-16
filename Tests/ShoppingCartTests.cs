using GameHub.CRUD;
using GameHub.CRUD.CategoriesCRUD;
using GameHub.Data;
using GameHub.Dto;
using GameHub.DtoServices;
using GameHub.DtoServices.IDtoServices;
using GameHub.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace GameHub.Tests
{
    public class ShoppingCartTests
    {
        private readonly IServiceShoppingCart? _shoppingCartCRUD;
        private readonly IUnitOfWork? _unitOfWork;

        public ShoppingCartTests()
        {
            var builder = WebApplication.CreateBuilder();

            var serviceProvider = new ServiceCollection()
                .AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")))
                .AddScoped<IServiceShoppingCart, ServiceShoppingCart>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .BuildServiceProvider();

            _shoppingCartCRUD = serviceProvider.GetService<IServiceShoppingCart>();
            _shoppingCartCRUD = serviceProvider.GetService<IServiceShoppingCart>();
        }

        [Fact]
        public void TestGetShoppingCart()
        {
            string userId = "7874d364-a03d-4724-8680-961840b7704c";
            Dto.ShoppingCartDto expected = new Dto.ShoppingCartDto
            {
                UserId = userId,
                Products = new List<ShoppingCartProductDto>(), 
                TotalPrice = 0
            };

            Dto.ShoppingCartDto actual = _shoppingCartCRUD.Get(userId);

            var objExpected = JsonConvert.SerializeObject(expected);
            var objActual = JsonConvert.SerializeObject(actual);

            Assert.Equal(objExpected, objActual);
        }


        [Fact]
        public void TestAddProduct()
        {
            string userId = "7874d364-a03d-4724-8680-961840b7704c";
            int productId = 6;
            Dto.ShoppingCartDto expected = new Dto.ShoppingCartDto()
            {
                UserId = userId,
                TotalPrice = 25
            };
            ShoppingCartProductDto expectedProduct = new ShoppingCartProductDto()
            {
                ProductId = productId,
                ProductName = "Minecraft",
                Price = 25,
                Quantity = 1
            };
            expected.Products.Add(expectedProduct);

            Dto.ShoppingCartDto actual = _shoppingCartCRUD.AddProduct(productId, userId);

            var objExpected = JsonConvert.SerializeObject(expected);
            var objActual = JsonConvert.SerializeObject(actual);

            Assert.Equal(objExpected, objActual);
        }

        [Fact]
        public void TestAddProductWithNoStockProducts()
        {
            string userId = "7874d364-a03d-4724-8680-961840b7704c";
            int productId = 1;

            var exception = Record.Exception(() => _shoppingCartCRUD.AddProduct(productId, userId));

            Assert.NotNull(exception);
            Assert.IsType<InvalidOperationException>(exception);
            Assert.Equal("Product is out of stock", exception.Message);
        }

        [Fact]
        public void TestDeleteProduct()
        {
            string userId = "7874d364-a03d-4724-8680-961840b7704c";
            int productId = 6;
            Dto.ShoppingCartDto expected = new Dto.ShoppingCartDto
            {
                UserId = userId,
                Products = new List<ShoppingCartProductDto>(),
                TotalPrice = 0
            };
            Dto.ShoppingCartDto actual = _shoppingCartCRUD.DeleteProduct(productId, userId);

            var objExpected = JsonConvert.SerializeObject(expected);
            var objActual = JsonConvert.SerializeObject(actual);

            Assert.Equal(objExpected, objActual);
        }

        [Fact]
        public void TestIncreaseQuantity()
        {
            string userId = "7874d364-a03d-4724-8680-961840b7704c";
            int productId = 6;

            var expectedProducts = new List<ShoppingCartProductDto>
            {
                new ShoppingCartProductDto
                {
                    ProductId = productId,
                    ProductName = "Minecraft",
                    Price = 25,
                    Quantity = 2
                }
            };

            Dto.ShoppingCartDto expected = new Dto.ShoppingCartDto
            {
                UserId = userId,
                Products = expectedProducts,
                TotalPrice = 50 
            };

            Dto.ShoppingCartDto actual = _shoppingCartCRUD.AddProduct(productId, userId);
            actual = _shoppingCartCRUD.IncreaseQuantity(productId, userId);

            var objExpected = JsonConvert.SerializeObject(expected);
            var objActual = JsonConvert.SerializeObject(actual);

            Assert.Equal(objExpected, objActual);
        }

        [Fact]
        public void TestDecreaseQuantity()
        {
            string userId = "7874d364-a03d-4724-8680-961840b7704c";
            int productId = 6;
            Dto.ShoppingCartDto expected = new Dto.ShoppingCartDto()
            {
                UserId = userId,
                TotalPrice = 25
            };
            ShoppingCartProductDto expectedProduct = new ShoppingCartProductDto()
            {
                ProductId = productId,
                ProductName = "Minecraft",
                Price = 25,
                Quantity = 1
            };

            Dto.ShoppingCartDto actual = _shoppingCartCRUD.DecreaseQuantity(productId, userId);

            var objExpected = JsonConvert.SerializeObject(expected);
            var objActual = JsonConvert.SerializeObject(actual);

            Assert.Equal(objExpected, objActual);
        }
    }
}
