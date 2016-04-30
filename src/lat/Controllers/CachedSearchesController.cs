using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using lat.Models;

namespace lat.Controllers
{
    public class CachedSearchesController : Controller
    {
        private ApplicationDbContext _context;

        public CachedSearchesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: CachedSearches
        public IActionResult Index()
        {
            return View(_context.CachedSearch.ToList());
        }

        // GET: CachedSearches/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            CachedSearch cachedSearch = _context.CachedSearch.Single(m => m.ID == id);
            if (cachedSearch == null)
            {
                return HttpNotFound();
            }

            return View(cachedSearch);
        }

        // GET: CachedSearches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CachedSearches/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CachedSearch cachedSearch)
        {
            if (ModelState.IsValid)
            {
                _context.CachedSearch.Add(cachedSearch);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cachedSearch);
        }

        // GET: CachedSearches/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            CachedSearch cachedSearch = _context.CachedSearch.Single(m => m.ID == id);
            if (cachedSearch == null)
            {
                return HttpNotFound();
            }
            return View(cachedSearch);
        }

        // POST: CachedSearches/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CachedSearch cachedSearch)
        {
            if (ModelState.IsValid)
            {
                _context.Update(cachedSearch);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cachedSearch);
        }

        // GET: CachedSearches/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            CachedSearch cachedSearch = _context.CachedSearch.Single(m => m.ID == id);
            if (cachedSearch == null)
            {
                return HttpNotFound();
            }

            return View(cachedSearch);
        }

        // POST: CachedSearches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            CachedSearch cachedSearch = _context.CachedSearch.Single(m => m.ID == id);
            _context.CachedSearch.Remove(cachedSearch);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
