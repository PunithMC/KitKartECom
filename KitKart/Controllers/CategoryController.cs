using KitKart.Context;
using KitKart.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KitKart.Controllers
{
    public class CategoryController : Controller
    {

        private KartContext _context;

        public CategoryController()
        {
            _context = new KartContext();
        }

        public ActionResult Index()
        {
            var categories = _context.categories.ToList();
            return View(categories);
        }

        public ActionResult Create()
        {
            return View(new Category { Id =0});
        }
        [HttpPost]
        public ActionResult Create(Category _cat)
        {
            if (!ModelState.IsValid)
            {
                return View("Create",_cat);
            }

            if (_cat.Id > 0)
            {
                _context.Entry(_cat).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                _context.categories.Add(_cat);
            }
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
       
        public ActionResult Delete(int? id)
        {
           if(id == null)
            {
                return Content("Error CId is null");
            }
            var Category = _context.categories.SingleOrDefault(c => c.Id == id);

            if(Category == null) {
                return Content("Error");
            }

            _context.categories.Remove(Category);
            _context.SaveChanges();
            return View("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return Content("Error Id is null");
            }
            var Category = _context.categories.SingleOrDefault(c => c.Id == id);

            if (Category == null)
            {
                return Content("Error");
            }
            return View("Create",Category);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
