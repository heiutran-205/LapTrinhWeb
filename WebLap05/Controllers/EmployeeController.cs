using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebLap05.Models;

namespace WebLap05.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserFullName")))
                return RedirectToAction("Index", "Login");

            var employees = new List<Employee>
            {
                new Employee { Id = 1, FullName = "Peter", Gender="Nam", Phone="0123456789", Email="peter@gmail.com", Password="pass@123", Salary=5000, Status="Độc thân" },
                new Employee { Id = 2, FullName = "Tony", Gender="Nam", Phone="0987654321", Email="tony@gmail.com", Password="ironman", Salary=10000, Status="Đã kết hôn" },
                new Employee { Id = 3, FullName = "Natasha", Gender="Nữ", Phone="0911222333", Email="natasha@gmail.com", Password="blackwidow", Salary=7000, Status="Độc thân" }
            };

            return View(employees);
        }
    }
}
