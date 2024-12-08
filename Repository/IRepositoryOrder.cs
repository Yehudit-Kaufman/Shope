using Entite;

namespace Repository
{
    public interface IRepositoryOrder
    {
        Task<Order> AddOrder(Order order);
        Task<Order> GetOrderById(int id);
    }
}