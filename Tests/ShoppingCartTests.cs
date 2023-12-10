using GameHub.CRUD.ShoppingCartsCRUD;
using GameHub.Data;
using GameHub.Dto;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Xunit;

namespace GameHub.Tests
{
    public class ShoppingCartTests
    {
        private readonly IShoppingCartCRUD? _shoppingCartCRUD;

        public ShoppingCartTests()
        {
            var builder = WebApplication.CreateBuilder();

            var serviceProvider = new ServiceCollection()
                .AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")))
                .AddTransient<IShoppingCartCRUD, ShoppingCartCRUD>()
                .BuildServiceProvider();

            _shoppingCartCRUD = serviceProvider.GetService<IShoppingCartCRUD>();
        }

        [Fact]
        public void TestGetShoppingCart()
        {
            string userId = "823e8260-efb3-44a9-8467-780993d1dc7c";
            ShoppingCartDto expected = new ShoppingCartDto();

            ShoppingCartDto actual = _shoppingCartCRUD.Get(userId);

            var objExpected = JsonConvert.SerializeObject(expected);
            var objActual = JsonConvert.SerializeObject(actual);

            Assert.Equal(objExpected, objActual);
        }

        [Fact]
        public void TestAddProduct()
        {
            string userId = "823e8260-efb3-44a9-8467-780993d1dc7c";
            int productId = 6;
            ShoppingCartDto expected = new ShoppingCartDto() 
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

            ShoppingCartDto actual = _shoppingCartCRUD.AddProduct(productId, userId);

            var objExpected = JsonConvert.SerializeObject(expected);
            var objActual = JsonConvert.SerializeObject(actual);

            Assert.Equal(objExpected, objActual);
        }

        [Fact]
        public void TestDeleteProduct()
        {
            string userId = "823e8260-efb3-44a9-8467-780993d1dc7c";
            int productId = 6;
            ShoppingCartDto expected = new ShoppingCartDto();

            ShoppingCartDto actual = _shoppingCartCRUD.DeleteProduct(productId, userId);

            var objExpected = JsonConvert.SerializeObject(expected);
            var objActual = JsonConvert.SerializeObject(actual);

            Assert.Equal(objExpected, objActual);
        }


        [Fact]
        public void TestAddTwoOfTheSameProducts()
        {
            string userId = "823e8260-efb3-44a9-8467-780993d1dc7c";
            int productId = 6;
            ShoppingCartDto expected = new ShoppingCartDto()
            {
                UserId = userId,
                TotalPrice = 50
            };
            ShoppingCartProductDto expectedProduct = new ShoppingCartProductDto()
            {
                ProductId = productId,
                ProductName = "Minecraft",
                Price = 25,
                Quantity = 2
            };

            expected.Products.Add(expectedProduct);

            ShoppingCartDto actual = _shoppingCartCRUD.AddProduct(productId, userId);

            var objExpected = JsonConvert.SerializeObject(expected);
            var objActual = JsonConvert.SerializeObject(actual);

            Assert.Equal(objExpected, objActual);
            _shoppingCartCRUD.DeleteProduct(productId, userId);
        }

        [Fact]
        public void TestAddTwoOfDifferentProducts()
        {
            string userId = "823e8260-efb3-44a9-8467-780993d1dc7c";
            int productId1 = 6;
            int productId2 = 5;
            ShoppingCartDto expected = new ShoppingCartDto()
            {
                UserId = userId,
                TotalPrice = 40
            };
            ShoppingCartProductDto expectedProduct1 = new ShoppingCartProductDto()
            {
                ProductId = productId1,
                ProductName = "Minecraft",
                Price = 25,
                Quantity = 1
            };
            ShoppingCartProductDto expectedProduct2 = new ShoppingCartProductDto()
            {
                ProductId = productId2,
                ProductName = "The Crew",
                Price = 15,
                Quantity = 1
            };

            expected.Products.Add(expectedProduct1);
            expected.Products.Add(expectedProduct2);

            ShoppingCartDto actual = _shoppingCartCRUD.AddProduct(productId1, userId);
            actual = _shoppingCartCRUD.AddProduct(productId2, userId);

            var objExpected = JsonConvert.SerializeObject(expected);
            var objActual = JsonConvert.SerializeObject(actual);

            Assert.Equal(objExpected, objActual);
            _shoppingCartCRUD.DeleteProduct(productId1, userId);
            _shoppingCartCRUD.DeleteProduct(productId2, userId);
        }

        [Fact]
        public void TestAddProductWithNoStockProducts()
        {
            string userId = "823e8260-efb3-44a9-8467-780993d1dc7c";
            int productId = 1;
            ShoppingCartDto expected = new ShoppingCartDto() { };

            ShoppingCartDto actual = _shoppingCartCRUD.AddProduct(productId, userId);

            var objExpected = JsonConvert.SerializeObject(expected);
            var objActual = JsonConvert.SerializeObject(actual);

            Assert.Equal(objExpected, objActual);
        }


        [Fact]
        public void TestIncreaseQuantity()
        {
            string userId = "823e8260-efb3-44a9-8467-780993d1dc7c";
            int productId = 6;
            ShoppingCartDto expected = new ShoppingCartDto()
            {
                UserId = userId,
                TotalPrice = 50
            };
            ShoppingCartProductDto expectedProduct = new ShoppingCartProductDto()
            {
                ProductId = productId,
                ProductName = "Minecraft",
                Price = 25,
                Quantity = 2
            };

            ShoppingCartDto actual = _shoppingCartCRUD.AddProduct(productId, userId);
            actual = _shoppingCartCRUD.IncreaseQuantity(productId, userId);

            var objExpected = JsonConvert.SerializeObject(expected);
            var objActual = JsonConvert.SerializeObject(actual);

            Assert.Equal(objExpected, objActual);
        }

        [Fact]
        public void TestDecreaseQuantity()
        {
            string userId = "823e8260-efb3-44a9-8467-780993d1dc7c";
            int productId = 6;
            ShoppingCartDto expected = new ShoppingCartDto()
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

            ShoppingCartDto actual = _shoppingCartCRUD.DecreaseQuantity(productId, userId);

            var objExpected = JsonConvert.SerializeObject(expected);
            var objActual = JsonConvert.SerializeObject(actual);

            Assert.Equal(objExpected, objActual);
        }
    }
}
