using GameHub.Data;
using GameHub.Models;

namespace GameHub.CRUD
{
    public class CategoryCRUD(ApplicationDbContext db) : ICategoryCRUD
    {
        private readonly ApplicationDbContext _db = db;

        public List<Category> GetAll()
        {
            return [.. _db.Categories];
        }
    }
}
