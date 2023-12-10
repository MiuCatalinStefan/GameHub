using GameHub.CRUD.ProductsCRUD;
using GameHub.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using Xunit;

namespace GameHub.Tests
{
    public class ProductTests
    {
        private readonly IProductCRUD? _productCRUD;

        public ProductTests()
        {
            var builder = WebApplication.CreateBuilder();

            var serviceProvider = new ServiceCollection()
                .AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")))
                .AddTransient<IProductCRUD, ProductCRUD>()
                .BuildServiceProvider();

            _productCRUD = serviceProvider.GetService<IProductCRUD>();
        }

        [Fact]
        public void TestGet()
        {
            if( _productCRUD == null )
                Assert.Fail("Service injection failed");

            string title = "GTA";

            var result = _productCRUD.Get(title, "");
            Assert.NotNull(result);

            foreach (var item in result)
                Assert.Contains(title, item.Title);
        }
    }
}
