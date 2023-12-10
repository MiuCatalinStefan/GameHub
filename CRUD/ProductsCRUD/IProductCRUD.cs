using GameHub.Models;

namespace GameHub.CRUD.ProductsCRUD
{
    public interface IProductCRUD:IRepoCRUD<Product>
    {
        List<Product> GetFiltered(string title, string selectedCategory);
        void Update(Product product);
        void Save();
    }
}
