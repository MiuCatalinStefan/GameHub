using GameHub.Models;
using GameHub.Utils;

namespace GameHub.CRUD.ProductsCRUD
{
    public interface IProductCRUD:IRepoCRUD<Product>
    {
        List<Product> GetFiltered(string title, string selectedCategory, string selectedRegion, string selectedPlatform, SortingOrder order, double minPrice, double maxPrice);
        void Update(Product product);
    }
}
