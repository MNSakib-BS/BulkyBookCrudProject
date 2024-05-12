using BulkyBookWeb.Data;
using BulkyBookWeb.Interfaces;
using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

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
        public async Task<Category> Create(Category category)
        {
            _context.Categories.Add(category);
            if (_context.SaveChanges() > 0) 
                return await Task.FromResult(category);
            return null ;
        }

        public async Task<Category> Get(int id)
        {
            var categoryFromDBSingle = _context.Categories.SingleOrDefault(u => u.Id == id);
            if (categoryFromDBSingle == null)
                return null;
            return await Task.FromResult(categoryFromDBSingle);
        }

        public async Task<Category> Update(Category category)
        {
            _context.Categories.Update(category);
            if (_context.SaveChanges() > 0)
                return await Task.FromResult(category);
            return null;
        }

        public async Task<Category> Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return null;
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return category;
        }

    }
}
