using GameHub.CRUD.ApplicationUsersCRUD;
using GameHub.CRUD.OrdersCRUD;
using GameHub.CRUD.CategoriesCRUD;
using GameHub.CRUD.PlatformsCRUD;
using GameHub.CRUD.ProductsCRUD;
using GameHub.CRUD.RegionsCRUD;
using GameHub.CRUD.ShoppingCartsCRUD;

namespace GameHub.CRUD
{
    public interface IUnitOfWork
    {
        ICategoryCRUD Category { get; }
        IOrderCRUD Order { get; }
		IOrderProductsCRUD OrderProducts { get; }
		IRegionCRUD Region { get; }
        IPlatformCRUD Platform { get; }
        IProductCRUD Product { get; }
        IShoppingCartCRUD ShoppingCart { get; }
        IShoppingCartProductCRUD ShoppingCartProduct { get; }   
        IApplicationUserCRUD ApplicationUser { get; }
        void Save();
    }
}
