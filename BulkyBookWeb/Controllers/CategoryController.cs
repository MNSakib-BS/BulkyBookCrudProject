using BulkyBookWeb.Data;
using BulkyBookWeb.Interfaces;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;


namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
            
        }
    
        public async Task<IActionResult> Index()
        {
            return View(await categoryService.GetAllCategories());
        }
        //Get
       public IActionResult Create()
        {
           
            return View();
        }
        /* //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "Name and Order cannot be Same!");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
         *//*   var categoryFromDBFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            var categoryFromDBSingle = _db.Categories.SingleOrDefault(u => u.Id == id);*//*
            if(categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "Name and Order cannot be Same!");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }



        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            *//*   var categoryFromDBFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
               var categoryFromDBSingle = _db.Categories.SingleOrDefault(u => u.Id == id);*//*
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj=_db.Categories.Find(id);
            if(obj == null)
            {
                return NotFound();  
            }
            
                _db.Categories.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
           

        }*/
    }
}
