using GameHub.Data;
using GameHub.Models;
using System.Linq.Expressions;

namespace GameHub.CRUD.ShoppingCartsCRUD
{
    public class ShoppingCartProductCRUD : RepoCRUD<ShoppingCartProduct>, IShoppingCartProductCRUD
    {
        private readonly ApplicationDbContext _db;
        public ShoppingCartProductCRUD(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();

        }

        public void Update(ShoppingCartProduct shoppingCartProduct)
        {
            _db.ShoppingCartProducts.Update(shoppingCartProduct);
        }

    }
}
