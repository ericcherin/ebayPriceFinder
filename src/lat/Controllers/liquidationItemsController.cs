using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using lat.Models;

namespace lat.Controllers
{
    public class liquidationItemsController : Controller
    {
        private ApplicationDbContext _context;

        public liquidationItemsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: liquidationItems
        public IActionResult Index()
        {
            return View(_context.liquidationItem.ToList());
        }

        // GET: liquidationItems/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            liquidationItem liquidationItem = _context.liquidationItem.Single(m => m.ID == id);
            if (liquidationItem == null)
            {
                return HttpNotFound();
            }

            return View(liquidationItem);
        }

        // GET: liquidationItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: liquidationItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(liquidationItem liquidationItem)
        {
            if (ModelState.IsValid)
            {
                _context.liquidationItem.Add(liquidationItem);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(liquidationItem);
        }

        // GET: liquidationItems/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            liquidationItem liquidationItem = _context.liquidationItem.Single(m => m.ID == id);
            if (liquidationItem == null)
            {
                return HttpNotFound();
            }
            return View(liquidationItem);
        }

        // POST: liquidationItems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(liquidationItem liquidationItem)
        {
            if (ModelState.IsValid)
            {
                _context.Update(liquidationItem);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(liquidationItem);
        }

        // GET: liquidationItems/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            liquidationItem liquidationItem = _context.liquidationItem.Single(m => m.ID == id);
            if (liquidationItem == null)
            {
                return HttpNotFound();
            }

            return View(liquidationItem);
        }

        // POST: liquidationItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            liquidationItem liquidationItem = _context.liquidationItem.Single(m => m.ID == id);
            _context.liquidationItem.Remove(liquidationItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
