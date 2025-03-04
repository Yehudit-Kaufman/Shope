using Entite;

namespace Service
{
    public interface IserviceCategory
    {
        Task<List<Category>> GetCategories();
  
    }
}