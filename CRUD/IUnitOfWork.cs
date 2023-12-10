using GameHub.CRUD.CategoriesCRUD;
using GameHub.CRUD.ProductsCRUD;
using GameHub.CRUD.ShoppingCartsCRUD;

namespace GameHub.CRUD
{
    public interface IUnitOfWork
    {
        ICategoryCRUD Category { get; }
        IProductCRUD Product { get; }
        IShoppingCartCRUD ShoppingCart { get; }
        IShoppingCartProductCRUD ShoppingCartProduct { get; }   
        void Save();
    }
}
