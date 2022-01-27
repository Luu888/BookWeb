using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _context;
        public CategoryController(ICategoryRepository context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _context.GetAll();
            return View(objCategoryList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.Displayorder.ToString())
            {
                ModelState.AddModelError("name", "DisplayOrder cant be the same like Category Name");
            }
            if (ModelState.IsValid)
            {
                _context.Add(obj);
                _context.Save();
                TempData["success"] = "Category created success";
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }
        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            //var category = _context.Categories.Find(id);
            var category = _context.GetFirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                return View(category);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.Displayorder.ToString())
            {
                ModelState.AddModelError("name", "DisplayOrder cant be the same like Category Name");
            }
            if (ModelState.IsValid)
            {
                _context.Update(obj);
                _context.Save();
                TempData["success"] = "Category edited success";
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _context.GetFirstOrDefault(u=>u.Id==id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                return View(category);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _context.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                _context.Remove(obj);
                _context.Save();
                TempData["success"] = "Category deleted success";
                return RedirectToAction("Index");
            }
        }
    }
}
