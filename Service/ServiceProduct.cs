using Entite;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceProduct : IServiceProduct
    {
        IRepositoryProduct repository;
        public ServiceProduct(IRepositoryProduct _repositoryProduct)
        {
            repository = _repositoryProduct;
        }

        public async Task<List<Product>> GetProducts(string? desc ,int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            return await repository.GetProducts(desc,minPrice,maxPrice,categoryIds);

        }
        //public async Task<Product> GetProductById(int id)
        //{
        //    return await repository.GetProductById(id);

        //}
        //public async Task<Product> AddProduct(Product product)
        //{
        //    return await repository.AddProduct(product);

        //}
        //public async Task UpdateProduct(int id, Product product)
        //{
        //    await repository.UpdateProduct(id, product);

        //}

    }
}
