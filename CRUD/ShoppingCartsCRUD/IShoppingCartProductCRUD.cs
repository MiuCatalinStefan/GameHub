using GameHub.Models;

namespace GameHub.CRUD.ShoppingCartsCRUD
{
    public interface IShoppingCartProductCRUD:IRepoCRUD<ShoppingCartProduct>
    {
        void Update(ShoppingCartProduct shoppingCartProduct);
        void Save();
    }
}
