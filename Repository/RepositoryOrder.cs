using Entite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryOrder : IRepositoryOrder
    {
        ShopApiContext _context;
        public RepositoryOrder(ShopApiContext shopApiContext)
        {
            _context = shopApiContext;
        }

  
        public async Task<Order> GetOrderById(int id)
        {
            return await _context.Orders.Include(u => u.User).Include(o => o.OrderItems).FirstOrDefaultAsync(order => order.OrderId == id);



        }

        public async Task<Order> AddOrder(Order order)
        {
 

            _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;

        }




    }
}
