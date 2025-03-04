using Entite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryCategory : IRepositoryCategory
    {
        ShopApiContext _context;
        public RepositoryCategory(ShopApiContext shopApiContext)
        {
            _context = shopApiContext;
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync();


        }



    }

}
