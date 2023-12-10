using GameHub.Data;
using GameHub.Models;

namespace GameHub.CRUD.ShoppingCartsCRUD
{
    public class ShoppingCartCRUD : RepoCRUD<ShoppingCart>, IShoppingCartCRUD
    {
        private readonly ApplicationDbContext _db;
        public ShoppingCartCRUD(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();

        }

        public void Update(ShoppingCart shoppingCart)
        {
            _db.ShoppingCarts.Update(shoppingCart);
        }
    }
}
