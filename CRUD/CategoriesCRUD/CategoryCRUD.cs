using GameHub.Data;
using GameHub.Models;
using System.Linq.Expressions;

namespace GameHub.CRUD.CategoriesCRUD
{
    public class CategoryCRUD : RepoCRUD<Category>,ICategoryCRUD
    {
        private readonly ApplicationDbContext _db;
        public CategoryCRUD(ApplicationDbContext db):base(db) {
            _db = db;
        }
        
        public void Update(Category category)
        {
            _db.Categories.Update(category);
        }

    }
}
