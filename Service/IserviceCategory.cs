using Entite;

namespace Service
{
    public interface IserviceCategory
    {
        //Task<Category> AddCategory(Category category);
        Task<List<Category>> GetCategories();
        //Task<Category> GetCategoryById(int id);
        //Task UpdateCategory(int id, Category category);
    }
}