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
        IRepositoryProduct repository2;
        public ServiceOrder(IRepositoryOrder _repository, IRepositoryProduct repository22)
        {
            repository = _repository;
            repository2 = repository22;
        
        }
        public async Task<Order> AddOrder(Order order)
        {

            if (await getCurrentSumProducts(order) != order.OrderSum)
            {
                order.OrderSum = await getCurrentSumProducts(order);
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
