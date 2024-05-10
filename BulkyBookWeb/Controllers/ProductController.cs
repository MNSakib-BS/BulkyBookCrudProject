using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        #region constructor
        public ProductController(ApplicationDbContext db)
        {
            _db = db;
            
        }
        #endregion
        public IActionResult Index()
        {
            IEnumerable<Product> objProductList = _db.products;
            return View(objProductList);
        }
        public IActionResult Create()
        {
            var categories = _db.Categories.Select(c => new { Id = c.Id, Name = c.Name }).ToList();
            ViewBag.Categories = categories;
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product obj)
        {
            if (obj.Name == obj.Description.ToString())
            {
                ModelState.AddModelError("CustomError", "Name and Description cannot be Same!");
            }
            obj.CategoryId = 1;//should be implemented businessLOgic
            if (ModelState.IsValid)
            {
                _db.products.Add(obj);
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
            var productsFromDb = _db.products.Find(id);
           
            if (productsFromDb == null)
            {
                return NotFound();
            }
            return View(productsFromDb);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product obj)
        {
            if (obj.Name == obj.Description.ToString())
            {
                ModelState.AddModelError("CustomError", "Name and Description cannot be Same!");
            }
            if (ModelState.IsValid)
            {
                _db.products.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var productsFromDb = _db.products.Find(id);
            /*   var categoryFromDBFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
               var categoryFromDBSingle = _db.Categories.SingleOrDefault(u => u.Id == id);*/
            if (productsFromDb == null)
            {
                return NotFound();
            }
            return View(productsFromDb);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.products.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.products.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
