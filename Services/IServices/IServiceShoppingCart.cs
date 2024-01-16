using GameHub.Dto;

namespace GameHub.DtoServices.IDtoServices
{
    public interface IServiceShoppingCart
    {
        public ShoppingCartDto Get(string userId);

        public ShoppingCartDto AddProduct(int productId, string userId);

        public ShoppingCartDto DeleteProduct(int productId, string userId);
        public ShoppingCartDto IncreaseQuantity(int productId, string userId);
        public ShoppingCartDto DecreaseQuantity(int productId, string userId);
        public ShoppingCartDto PrepareCheckout(string userId);
        public Stripe.Checkout.Session CompleteCheckout(ShoppingCartDto shoppingCart, string userId);
        public void PostProcessOrder(int id);

	}
}
