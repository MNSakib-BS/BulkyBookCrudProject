using BulkyBookWeb.Data;
using BulkyBookWeb.Interfaces;
using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Repositories
{
    public class CategoryReopsitory : IBulky<Category, int, Category>
    {
        private readonly ApplicationDbContext _context;
        public CategoryReopsitory(ApplicationDbContext db)
        {
            _context = db;              
        }        

        public async Task<List<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
