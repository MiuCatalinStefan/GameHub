using GameHub.Data;
using GameHub.Models;
using System.Linq.Expressions;

namespace GameHub.CRUD.OrdersCRUD
{
    public class OrderCRUD : RepoCRUD<Order>,IOrderCRUD
    {
        private readonly ApplicationDbContext _db;
        public OrderCRUD(ApplicationDbContext db):base(db) {
            _db = db;
        }
        
        public void Update(Order order)
        {
            _db.Orders.Update(order);
        }

		public void UpdateStatus(int id, string orderStatus, string? paymentStatus = null)
		{
            var order = _db.Orders.FirstOrDefault(o => o.Id == id);
            if (order != null)
            {
               order.OrderStatus = orderStatus;
                if(!string.IsNullOrEmpty(paymentStatus)) order.PaymentStatus = paymentStatus;
            }
		}

		public void UpdateStripePaymentId(int id, string sessionId, string paymentIntentId)
		{
            var order = _db.Orders.FirstOrDefault(o => o.Id == id);
            if (!string.IsNullOrEmpty(sessionId))
            {
                order.SessionId=sessionId;
            }
            if (!string.IsNullOrEmpty(paymentIntentId))
            {
                order.PaymentIntentId=paymentIntentId;
                
            }
		}
	}
}
