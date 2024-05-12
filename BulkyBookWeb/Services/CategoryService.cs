using BulkyBookWeb.Interfaces;
using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BulkyBookWeb.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IBulky<Category, int, Category> CateRepository;
        public CategoryService(IBulky<Category, int, Category> CateRepository) 
        {
            this.CateRepository = CateRepository;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            var objCatagoryList =await CateRepository.GetAll();
            return objCatagoryList;
        }
       

        public Task<Category> CreatCategoryAsync(Category category)
        {
            var data = CateRepository.Create(category);
            return data;
        }

        public Task<Category> getCategory(int id)
        {
            var data = CateRepository.Get(id);
            return data;
        }
        public Task<Category> UpdateCategory(Category category) 
        {
            var data = CateRepository.Update(category);
            return data;
        }

        public Task<Category> deleteCategory(int id)
        {
            var data = CateRepository.Delete(id);
            return data;
        }
    }
}
