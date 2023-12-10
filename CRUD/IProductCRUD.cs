using GameHub.Models;

namespace GameHub.CRUD
{
    public interface IProductCRUD
    {
        public List<Product> Get(string title, string category);
        public List<Product> GetAll();
    }
}
