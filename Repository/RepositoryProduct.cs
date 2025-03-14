﻿using Entite;
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

        public async Task<List<Product>> GetProducts(string? desc ,int? minPrice,int? maxPrice, int?[]categoryIds)
        {

            var query = _context.Products.Where(Product =>
            (desc==null?(true):(Product.Description.Contains(desc)))
        &&((minPrice == null) ? (true) : (Product.Price >= minPrice))
        && ((maxPrice == null) ? (true) : (Product.Price <= maxPrice))
        && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(Product.CategoryId))))
        .OrderBy(Product => Product.Price).Include(p => p.Category);
            Console.WriteLine(query.ToQueryString());
            List<Product> products = await query.ToListAsync();
            return products;

        }
        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(product => product.ProductId == id);



        }




    }
}
