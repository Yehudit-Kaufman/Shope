using Entite;

namespace Service
{
    public interface IServiceProduct
    {
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetProducts(string? desc ,int? minPrice, int? maxPrice, int?[] categoryIds);
    }
}