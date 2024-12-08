using Entite;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceOrder : IServiceOrder
    {
        IRepositoryOrder repository;

        public ServiceOrder(IRepositoryOrder _repository)
        {
            repository = _repository;
        }
        public async Task<Order> AddOrder(Order order)
        {
            return await repository.AddOrder(order);

        }
        public async Task<Order> GetOrderById(int id)
        {
            return await repository.GetOrderById(id);

        }
    }
}
