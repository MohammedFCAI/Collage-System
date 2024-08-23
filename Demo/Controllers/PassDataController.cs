using Demo.Contexts;
using Demo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class PassDataController : Controller
    {


        private readonly ApplicationDbContext _context;

        public PassDataController(ApplicationDbContext context)
        {
            _context = context;
        }

        // PassData/TestViewData    
        public IActionResult TestViewData(int id)
        {
            var departmentModel = _context.Departments.Find(id);

            // Extra Info

            var message = "Hello";

            var branches = new List<string>();

            branches.Add("Alex");
            branches.Add("Cairo");
            branches.Add("Smart");
            branches.Add("Sohag");

            var temp = 44;
            var color = "orange";

            ViewData["msg"] = message;
            ViewData["brch"] = branches;
            ViewData["temp"] = temp;
            ViewData["color"] = color;

            ViewBag.color = "green";

            return View(departmentModel);
        }



        [HttpGet("view/{id}")]
        public IActionResult TestViewModel(int id)
        {
            var department = _context.Departments.Find(id);
            var branches = new List<string>() { "Alex", "Cairo", "Smart", "Marg" };

            var color = "orange";
            var temp = 33;


            var depViewModel = new DepartmentViewModel()
            {
                Branches = branches,
                Color = color,
                Temp = temp,
                DepartmentId = id,
                DepartmentName = department?.Name ?? "No Name"
            };

            return View(depViewModel);
        }
    }
}
