using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleGrade.Data;
using SimpleGrade.Models;

namespace SimpleGrade.Controllers
{
    public class GroupController : Controller
    {
        private ApplicationDbContext _context;


        public GroupController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.Groups.ToList()); ;
        }


        [HttpGet]
        public IActionResult CreateEdit(int id)
        {
            if (id == 0) return View();

            var schoolClass = _context.Groups.Find(id);
            if (schoolClass == null) return NotFound();

            return View(schoolClass);
        }

        [HttpPost]
        public IActionResult CreateEdit(Group schoolClass)
        {
            if(schoolClass == null) return NotFound();

            if(schoolClass.Id == 0)
            {
                var existing = _context.Groups.FirstOrDefault(i => i.Year == schoolClass.Year && i.Name.ToLower() == schoolClass.Name.ToLower());

                if (existing is not null) return Conflict();

                _context.Groups.Add(schoolClass);
            } 
            else
            {
                var existing = _context.Groups.FirstOrDefault(i => i.Year == schoolClass.Year && i.Name.ToLower() == schoolClass.Name.ToLower());

                if(existing is not null && existing.Id == schoolClass.Id) return RedirectToAction(nameof(Index));
                if (existing is not null) return Conflict();

                _context.Groups.Update(schoolClass);
            }
            if(_context.ChangeTracker.HasChanges()) _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Delete(int id) 
        {
            var obj = _context.Groups.Find(id);
            if(obj == null) return NotFound();

            _context.Groups.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            if(id == 0) return NotFound();
            var group = _context.Groups.Include(i => i.Students).FirstOrDefault(i => i.Id == id);
            if(group == null) return NotFound();
            return View(group);
        }
    }
}
