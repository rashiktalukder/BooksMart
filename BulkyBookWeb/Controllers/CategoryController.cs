using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db=db;
        }
        public IActionResult Index()
        {
            IEnumerable<CategoryModel> objCategoryList = _db.categoryTable;
            return View(objCategoryList);
        }

        //Get
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryModel categoryObj)
        {
            /*if (categoryObj.Name == null && categoryObj.DisplayOrder.ToString()==null)
            {
                ModelState.AddModelError("CustomError", "Name and Display Order is required!!");
            }*/

            if (categoryObj.Name == categoryObj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "Name & Display order can not be same");
                // Or, ModelState.AddModelError("Name", "Name & Display order can not be same");
            }
            if (ModelState.IsValid)
            {
                _db.categoryTable.Add(categoryObj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            return View(categoryObj);

        }

        //Get
        public IActionResult Edit(int id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var categoryFromDb = _db.categoryTable.Find(id);
            //var categoryFromDbFirst = _db.categoryTable.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.categoryTable.SingleOrDefault(u => u.Id==id);
            if(categoryFromDb==null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryModel categoryObj)
        {
            if (categoryObj.Name == categoryObj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "Name & Display order can not be same");
                // Or, ModelState.AddModelError("Name", "Name & Display order can not be same");
            }
            if (ModelState.IsValid)
            {
                _db.categoryTable.Update(categoryObj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View(categoryObj);

        }
        //Get-> DeleteCategory
        public IActionResult Delete(int id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var categoryFromDb = _db.categoryTable.Find(id);
            //var categoryFromDbFirst = _db.categoryTable.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.categoryTable.SingleOrDefault(u => u.Id==id);
            if (categoryFromDb==null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            var DeleteObj=_db.categoryTable.Find(id);
            if(id==null)
            {
                return NotFound();
            }
            _db.categoryTable.Remove(DeleteObj);
            _db.SaveChanges();
            return RedirectToAction("Index");

            return View(DeleteObj);

        }
    }
}
