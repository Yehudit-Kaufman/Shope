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
        //public async Task<Category> GetCategoryById(int id)
        //{
        //    return await _context.Categories.FirstOrDefaultAsync(category => category.CategoryId == id);



        //}

        //public async Task<Category> AddCategory(Category category)
        //{
        //    //int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
        //    //user.UserId = numberOfUsers + 1;
        //    _context.Categories.AddAsync(category);
        //    await _context.SaveChangesAsync();
        //    return category;

        //}

        //public async Task UpdateCategory(int id, Category value)
        //{
        //    _context.Categories.Update(value);
        //    await _context.SaveChangesAsync();
        //}



    }

}
