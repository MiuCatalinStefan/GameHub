using GameHub.Dto;

namespace GameHub.CRUD.ShoppingCartsCRUD
{
    public interface IShoppingCartCRUD
    {
        public ShoppingCartDto Get(string userId);

        public ShoppingCartDto AddProduct(int productId, string userId);

        public ShoppingCartDto DeleteProduct(int productId, string userId);
        public ShoppingCartDto IncreaseQuantity(int productId, string userId);
        public ShoppingCartDto DecreaseQuantity(int productId, string userId);
    }
}
