using CategoryServices.Models;

namespace CategoryServices.Repository
{
    public interface ICategoryRepository
    {
        Task<Category> AddCategory(Category category);
        Task<Category> UpdateCategory(Category category);
        Task<bool> DeleteCategory(int id);
        Task<Category> GetCategoryById(int id);
        Task<IEnumerable<Category>> GetAllCategories();
    }
}
