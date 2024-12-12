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

        //public async Task<List<Order>> GetOrders()
        //{
        //    return await _context.Products.ToListAsync();


        //}
        public async Task<Order> GetOrderById(int id)
        {
            return await _context.Orders.Include(u => u.User).Include(o => o.OrderItems).FirstOrDefaultAsync(order => order.OrderId == id);



        }

        public async Task<Order> AddOrder(Order order)
        {
            //int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            //user.UserId = numberOfUsers + 1;

            _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;

        }

        //public async Task UpdateProduct(int id, Product value)
        //{
        //    _context.Products.Update(value);
        //    await _context.SaveChangesAsync();
        //}



    }
}
