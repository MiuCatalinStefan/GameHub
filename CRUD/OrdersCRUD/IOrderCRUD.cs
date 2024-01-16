using GameHub.Models;

namespace GameHub.CRUD.OrdersCRUD
{
    public interface IOrderCRUD : IRepoCRUD<Order>
    {
        void Update(Order order);
        void UpdateStatus(int id, string orderStatus, string? paymentStatus=null);
        void UpdateStripePaymentId(int id, string sessionId, string paymentIntentId);
    }
}
