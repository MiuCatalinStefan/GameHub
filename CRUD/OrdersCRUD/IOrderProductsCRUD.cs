using GameHub.Models;

namespace GameHub.CRUD.OrdersCRUD
{
    public interface IOrderProductsCRUD : IRepoCRUD<OrderProducts>
    {
        void Update(OrderProducts orderProducts);
    }
}
