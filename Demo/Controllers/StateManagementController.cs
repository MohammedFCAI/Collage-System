using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class StateManagementController : Controller
    {
        public IActionResult SetTempData()
        {

            TempData["msg"] = "Temp Data :)";

            return Content("Data Saved");
        }


        public IActionResult GetTempData1()
        {
            // Read From TempData

            //var message = TempData["msg"]?.ToString() ?? "Expired"; // Normal Read
            var message = TempData.Peek("msg")?.ToString();


            if (TempData.ContainsKey("msg"))
            {
                //return Content($"Get1: {message}");
                message = TempData.Peek("msg")?.ToString(); // Don't Destroy
            }


            var err = TempData["Error"]?.ToString() ?? "Temp Expired";

            var result = message ?? err;
            return Content($"{result}");

        }

        public IActionResult GetTempData2()
        {
            // Read From TempData

            var message = TempData["msg"]?.ToString() ?? "TempData Expired"; // Mormal read
            TempData.Keep(); // don't remove any key
            return Content($"Get2: {message}");
        }


        public IActionResult SetSession()
        {
            HttpContext.Session.SetString("Name", "Ahmed");
            HttpContext.Session.SetInt32("Age", 21);

            return Content("Session Data Saved.");
        }


        public IActionResult GetSession()
        {
            var str = HttpContext.Session?.GetString("Name");

            var age = HttpContext.Session?.GetInt32("Age");

            return Content($"Data: {str}:::{age}");
        }


        public IActionResult SetCookie()
        {
            CookieOptions options = new CookieOptions();

            options.Expires = DateTimeOffset.Now.AddHours(1);

            Response.Cookies.Append("Name", "Mohamed", options); // Presestent Cookie
            Response.Cookies.Append("Gender", "Male"); // Session Cookie 20 Minutes
            Response.Cookies.Append("Age", "12");

            return Content("Cookie Saved");
        }

        public IActionResult GetCookie()
        {
            var name = Request.Cookies["Name"];
            var age = int.Parse(Request.Cookies["Age"]);

            return Content($"{name}:::{age}");

        }

    }
}
