using Entite;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class serviceCategory : IserviceCategory
    {
        IRepositoryCategory repository;
        public serviceCategory(IRepositoryCategory _repositoryProduct)
        {
            repository = _repositoryProduct;
        }

        public async Task<List<Category>> GetCategories()
        {
            return await repository.GetCategories();

        }
        //public async Task<Category> GetCategoryById(int id)
        //{
        //    return await repository.GetCategoryById(id);

        //}
        //public async Task<Category> AddCategory(Category category)
        //{
        //    return await repository.AddCategory(category);

        //}
        //public async Task UpdateCategory(int id, Category category)
        //{
        //    await repository.UpdateCategory(id, category);

        //}

    }

}
