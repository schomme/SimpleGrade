using Microsoft.AspNetCore.Mvc;
using SimpleGrade.Data;
using SimpleGrade.Models;

namespace SimpleGrade.Controllers
{
    public class ClassController : Controller
    {
        private ApplicationDbContext _context;


        public ClassController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.Classes.ToList()); ;
        }


        [HttpGet]
        public IActionResult CreateEdit(int id)
        {
            if (id == 0) return View();

            var schoolClass = _context.Classes.Find(id);
            if (schoolClass == null) return NotFound();

            return View(schoolClass);
        }

        [HttpPost]
        public IActionResult CreateEdit(SchoolClass schoolClass)
        {
            if(schoolClass == null) return NotFound();

            if(schoolClass.Id == 0)
            {
                var existing = _context.Classes.FirstOrDefault(i => i.Year == schoolClass.Year && i.Name.ToLower() == schoolClass.Name.ToLower());

                if (existing is not null) return Conflict();

                _context.Classes.Add(schoolClass);
            } 
            else
            {
                var existing = _context.Classes.FirstOrDefault(i => i.Year == schoolClass.Year && i.Name.ToLower() == schoolClass.Name.ToLower());

                if(existing is not null && existing.Id == schoolClass.Id) return RedirectToAction(nameof(Index));
                if (existing is not null) return Conflict();

                _context.Classes.Update(schoolClass);
            }
            if(_context.ChangeTracker.HasChanges()) _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id) 
        {
            var obj = _context.Classes.Find(id);
            if(obj == null) return NotFound();

            _context.Classes.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
