using CategoryServices.Data;
using CategoryServices.Models;

namespace CategoryServices.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _db;
        public CategoryRepository(AppDbContext db) { 
        
            _db = db;
        }
        public async Task<Category> AddCategory(Category category)
        {
            _db.categories.Add(category);
            await _db.SaveChangesAsync();
            return category;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var category = await GetCategoryById(id);
            if (category != null)
            {
                _db.categories.Remove(category);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return  _db.categories.ToList();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _db.categories.FindAsync(id);
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            var category1 = await GetCategoryById(category.CategoryId);
            if (category1 == null)
            {
                return null;
            }
            category1.CategoryName = category.CategoryName;

            await _db.SaveChangesAsync();
            return category1;
        }
    }
}
