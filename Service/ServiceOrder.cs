using Entite;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<ServiceOrder> _logger;
        IRepositoryOrder repository;
        IRepositoryProduct repository2;
        public ServiceOrder(IRepositoryOrder _repository, IRepositoryProduct repository22, ILogger<ServiceOrder> logger)
        {
            repository = _repository;
            repository2 = repository22;
           _logger = logger;
        
        }
        public async Task<Order> AddOrder(Order order)
        {
            double orderSum = await getCurrentSumProducts(order);
            if (orderSum != order.OrderSum)
            {
                order.OrderSum = orderSum;
                _logger.LogCritical($"the order sum is not equals!!");
            }
                return await repository.AddOrder(order);
           

        }
        private async Task<double> getCurrentSumProducts(Order order)
        {
            double sum=0;
            foreach (var item in order.OrderItems)
            {
             Product u=await repository2.GetProductById(item.ProductId);
                sum += u.Price;
            }
            return sum;
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await repository.GetOrderById(id);

        }
    }
}
