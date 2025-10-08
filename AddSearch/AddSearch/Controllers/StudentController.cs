using Microsoft.AspNetCore.Mvc;
using System.Linq;
using AddSearch.Models;

namespace AddSearch.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searchString, int? searchNumber, string department, string sortOrder)
        {
            // Base query
            var students = from s in _context.StudentTable
                           select s;

            // Search by name
            if (!string.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.Name.Contains(searchString));
            }

            // Search by ID
            if (searchNumber.HasValue)
            {
                students = students.Where(s => s.Id == searchNumber.Value);
            }

            // Filter by department
            if (!string.IsNullOrEmpty(department))
            {
                students = students.Where(s => s.Department == department);
            }

            // Sorting
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.Name);
                    break;
                case "age_asc":
                    students = students.OrderBy(s => s.Age);
                    break;
                case "age_desc":
                    students = students.OrderByDescending(s => s.Age);
                    break;
                default:
                    students = students.OrderBy(s => s.Name); // default sort by name ASC
                    break;
            }

            return View(students.ToList());
        }
    }
}
