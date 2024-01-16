using GameHub.Data;
using GameHub.Models;
using System.Linq.Expressions;

namespace GameHub.CRUD.OrdersCRUD
{
    public class OrderProductsCRUD : RepoCRUD<OrderProducts>, IOrderProductsCRUD
	{
        private readonly ApplicationDbContext _db;
        public OrderProductsCRUD(ApplicationDbContext db):base(db) {
            _db = db;
        }
        
        public void Update(OrderProducts orderProducts)
        {
            _db.OrderProducts.Update(orderProducts);
        }

    }
}
