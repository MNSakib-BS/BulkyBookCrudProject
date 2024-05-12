using BulkyBookWeb.Models;

namespace BulkyBookWeb.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();
        Task<Category>CreatCategoryAsync(Category category);
        Task<Category> getCategory(int id);
        Task<Category> UpdateCategory(Category category);
        Task<Category> deleteCategory(int id);
        
    }
}
