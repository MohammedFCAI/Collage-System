using Demo.Contexts;
using Demo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DepartmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View(_context.Departments.ToList());
        }


        public IActionResult Add()
        {
            return View();
        }

        public IActionResult SaveAdd()
        {
            return View();
        }


        // anchor tag
        public IActionResult Edit(int id) // get by id
        {
            // open view
            var department = _context.Departments.FirstOrDefault(d => d.Id == id);

            return View(department);

        }

        // submit save in db
        [HttpPost]
        public IActionResult SaveEdit(Department department, [FromRoute] int id)
        {
            if (department.Name != null || department.ManagerName != null)
            {
                var oldDept = _context.Departments.FirstOrDefault(de => de.Id == id);
                if (oldDept != null)
                {
                    oldDept.Name = department.Name ?? "";
                    oldDept.ManagerName = department.ManagerName;

                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(nameof(Edit), department);
        }

    }
}
