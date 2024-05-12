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
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "Name and Order cannot be Same!");
            }
            if (ModelState.IsValid)
            {
               var data =  await categoryService.CreatCategoryAsync(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var data = await categoryService.getCategory((int)id);
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        
       //Post
       [HttpPost]
       [ValidateAntiForgeryToken]
       public async Task<IActionResult> Edit(Category obj)
       {
           if (obj.Name == obj.DisplayOrder.ToString())
           {
               ModelState.AddModelError("CustomError", "Name and Order cannot be Same!");
           }
           if (ModelState.IsValid)
           {
                var data = await categoryService.UpdateCategory(obj);
               return RedirectToAction("Index");
           }
           return View();
       }



       public async Task<IActionResult> DeleteAsync(int? id)
       {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var data = await categoryService.getCategory((int)id);
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }
        
       //Post
       [HttpPost]
       [ValidateAntiForgeryToken]
       public async Task<IActionResult> DeletePost(int? id)
       {
          
           if(id == null || id == 0)
           {
               return NotFound();  
           }

            await categoryService.deleteCategory((int)id);
            return RedirectToAction("Index");


       }
    }
}
