using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using lat.Models;
using System.Collections.Generic;

namespace lat.Controllers
{
    public class DesksController : Controller
    {
        private ApplicationDbContext _context;

        public DesksController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Desks
        public IActionResult Index()
        {
            return View(_context.Desk.ToList());
        }

        // GET: Desks/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Desk desk = _context.Desk.Single(m => m.ID == id);
            if (desk == null)
            {
                return HttpNotFound();
            }

            return View(desk);
        }

        public string pls()
        {
            Desk desk = _context.Desk.FirstOrDefault(m => m.named.Equals("weeedd"));
            string result = desk.named;
            var caddys = _context.Cardd.Where(m => m.DeskID == desk.ID).ToArray();

            foreach(Cardd d in caddys)
            {
                result += " " + d.name;
            }

            return result;
        }

        // GET: Desks/Create
        public IActionResult Create()
        {
            Desk deck = new Desk();
            deck.named = "weeedd";
            _context.Desk.Update(deck);
            _context.SaveChanges();

            var cads = new List<Cardd>()
            {
                new Cardd("c111",deck.ID),
                new Cardd("c121",deck.ID),
                new Cardd("c311",deck.ID)
            };

            

            foreach (Cardd c in cads)
            {
                var cardIn = _context.Cardd.Where(s => s.ID == c.ID).FirstOrDefault();
                if (cardIn == null)
                {
                    _context.Cardd.Add(c);
                }
                
            }
            _context.SaveChanges();

            return View();
        }

        // POST: Desks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Desk desk)
        {
            if (ModelState.IsValid)
            {
                _context.Desk.Add(desk);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(desk);
        }

        // GET: Desks/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Desk desk = _context.Desk.Single(m => m.ID == id);
            if (desk == null)
            {
                return HttpNotFound();
            }
            return View(desk);
        }

        // POST: Desks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Desk desk)
        {
            if (ModelState.IsValid)
            {
                _context.Update(desk);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(desk);
        }

        // GET: Desks/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Desk desk = _context.Desk.Single(m => m.ID == id);
            if (desk == null)
            {
                return HttpNotFound();
            }

            return View(desk);
        }

        // POST: Desks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Desk desk = _context.Desk.Single(m => m.ID == id);
            _context.Desk.Remove(desk);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
