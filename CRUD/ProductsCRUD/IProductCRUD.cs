using GameHub.Models;

namespace GameHub.CRUD.ProductsCRUD
{
    public interface IProductCRUD
    {
        public List<Product> Get(string title, string category);
        public List<Product> GetAll();
        public List<Product> GetAllProductsWithCategories();
    }
}
