using GameHub.Models;

namespace GameHub.CRUD.ShoppingCartsCRUD
{
    public interface IShoppingCartCRUD:IRepoCRUD<ShoppingCart>
    {
        void Update(ShoppingCart shoppingCart);

    }
}
