using GameHub.Models;
using Microsoft.EntityFrameworkCore;

namespace GameHub.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :  DbContext(options)
    {
        public DbSet<Product> Products { get; set; }
    }
}
