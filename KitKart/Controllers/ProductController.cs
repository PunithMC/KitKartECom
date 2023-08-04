using KitKart.Context;
using KitKart.Models;
using KitKart.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity.Validation;
using System.Data.Entity;

namespace KitKart.Controllers
{
    public class ProductController : Controller
    {
        private KartContext _context;
        public ProductController()
        {
            _context = new KartContext();
        }

        public ActionResult Create()
        {
            var _categories = _context.categories.ToList();
            var Viewmodel = new ProductFormViewModel
            {
                kartitems = new KartItems(),
                categories = _categories

            };
            return View(Viewmodel);

        }

        [HttpPost]
        public ActionResult Create(KartItems kartItems)
        {

            _context.kartItems.Add(kartItems);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var kartitemes1 = _context.kartItems.Include(c => c.category).ToList(); //tolist inner Loading
            return View(kartitemes1);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Content("Error CId is null");
            }
            var Category = _context.kartItems.SingleOrDefault(c => c.Id== id);

            if (Category == null)
            {
                return Content("Error");
            }

            _context.kartItems.Remove(Category);
            _context.SaveChanges();
            return View("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return Content("Error Id is null");
            }
            var kartintems = _context.kartItems.SingleOrDefault(c => c.Id == id);

            if (kartintems == null)
            {
                return Content("Error");
            }

            var viewdata = new ProductFormViewModel
            {
                kartitems = kartintems,
                categories = _context.categories.ToList()
            };
            return View("Create", viewdata);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
            base.Dispose(disposing);
        }
    }
    
}
