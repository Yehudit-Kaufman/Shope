using Entite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryProduct : IRepositoryProduct
    {
        ShopApiContext _context;
        public RepositoryProduct(ShopApiContext shopApiContext)
        {
            _context = shopApiContext;
        }

        public async Task<List<Product>> GetProducts()
        {

            return await _context.Products.Include(p=>p.Category).ToListAsync();


        }
        //public async Task<Product> GetProductById(int id)
        //{
        //    return await _context.Products.FirstOrDefaultAsync(product => product.ProductId == id);



        //}

        //public async Task<Product> AddProduct(Product product)
        //{
        //    //int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
        //    //user.UserId = numberOfUsers + 1;
        //    _context.Products.AddAsync(product);
        //    await _context.SaveChangesAsync();
        //    return product;

        //}

        //public async Task UpdateProduct(int id, Product value)
        //{
        //    _context.Products.Update(value);
        //    await _context.SaveChangesAsync();
        //}



    }
}
