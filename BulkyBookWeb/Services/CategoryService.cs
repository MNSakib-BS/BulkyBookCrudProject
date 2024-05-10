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

        
    }
}
