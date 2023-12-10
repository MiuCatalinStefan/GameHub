using GameHub.CRUD.CategoriesCRUD;
using GameHub.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace GameHub.Tests
{
    public class CategoryTests
    {
        private readonly ICategoryCRUD? _categoryCRUD;

        public CategoryTests() 
        {
            var builder = WebApplication.CreateBuilder();

            var serviceProvider = new ServiceCollection()
                .AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")))
                .AddTransient<ICategoryCRUD, CategoryCRUD>()
                .BuildServiceProvider();

            _categoryCRUD = serviceProvider.GetService<ICategoryCRUD>();
        }

        [Fact]
        public void TestGetAll()
        {
            if (_categoryCRUD == null)
                Assert.Fail("Service injection failed");

            var result = _categoryCRUD.GetAll();
            Assert.NotNull(result);
        }
    }
}
