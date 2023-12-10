using GameHub.Dto;

namespace GameHub.CRUD.ShoppingCartsCRUD
{
    public interface IShoppingCartCRUD
    {
        public ShoppingCartDto Get(int userId = 0);
    }
}
