using Demo.Contexts;
using Demo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Controllers
{
    public class TraineeController : Controller
    {

        private readonly ApplicationDbContext _context;

        public TraineeController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Details(int id)
        {
            // Eager Loading
            var trainee = _context.Trainees.Include(t => t.Department).FirstOrDefault(i => i.Id == id);

            if (trainee == null)
                return Content("Invalid Id!!");

            var departmentName = trainee?.Department?.Name ?? "NA";

            var traineeViewModel = new TraineeViewModel()
            {
                TraineeId = id,
                DepartmentName = departmentName,
                Name = trainee?.Name ?? "No Name",
                Grade = trainee?.Grade ?? 0
            };
            string color;
            if (trainee.Grade < 50)
                color = "red";

            if (trainee.Grade == 50)
                color = "blue";
            else
                color = "green";


            ViewData["color"] = color;

            return View(traineeViewModel);
        }
    }
}
