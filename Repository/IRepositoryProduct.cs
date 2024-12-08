using Entite;

namespace Repository
{
    public interface IRepositoryProduct
    {
        //Task<Product> AddProduct(Product product);
        //Task<Product> GetProductById(int id);
        Task<List<Product>> GetProducts();
        //Task UpdateProduct(int id, Product value);
    }
}