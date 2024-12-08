using Entite;

namespace Repository
{
    public interface IRepositoryCategory
    {
        //Task<Category> AddCategory(Category category);
        Task<List<Category>> GetCategories();
        //Task<Category> GetCategoryById(int id);
        //Task UpdateCategory(int id, Category value);
    }
}