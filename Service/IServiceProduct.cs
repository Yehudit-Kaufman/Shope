using Entite;

namespace Service
{
    public interface IServiceProduct
    {
        //Task<Product> AddProduct(Product product);
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetProducts(string? desc ,int? minPrice, int? maxPrice, int?[] categoryIds);
        //Task UpdateProduct(int id, Product product);
    }
}