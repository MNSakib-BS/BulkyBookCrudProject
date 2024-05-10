using BulkyBookWeb.Models;

namespace BulkyBookWeb.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();
        
    }
}
