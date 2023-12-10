using GameHub.Models;

namespace GameHub.CRUD.CategoriesCRUD
{
    public interface ICategoryCRUD :IRepoCRUD<Category>
    {
        void Update(Category category);
        void Save();
    }
}
