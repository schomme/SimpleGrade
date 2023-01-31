using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleGrade.Data;
using SimpleGrade.Models;

namespace SimpleGrade.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationDbContext _context { get; }
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateEdit(int id)
        {
            if(id == 0) { return View(); }
            var student = _context.Students.Find(id);
            if(student == null) { return NotFound(); }

            return View(student);
        }

        [HttpPost]
        public IActionResult CreateEdit(Student student)
        {
            if (student == null) return NotFound();
            var existing = _context.Students.FirstOrDefault(i => i.Firstname == student.Firstname && i.Lastname == student.Lastname && i.Birthday == student.Birthday);

            if (student.Id == 0)
            {
                if (existing is not null) return Conflict();

                _context.Students.Add(student);
            }
            else
            {
                if (existing is not null && existing.Id == student.Id) return RedirectToAction(nameof(Index));
                if (existing is not null) return Conflict();

                _context.Students.Update(student);
            }
            if (_context.ChangeTracker.HasChanges()) _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
