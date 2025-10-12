using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebLap05.Models;

namespace WebLap05.Controllers
{
    public class LoginController : Controller
    {
        // Danh sách nhân viên mẫu (sau này có thể lấy từ DB)
        private List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, FullName = "Peter", Email="peter@gmail.com", Password="pass@123" },
            new Employee { Id = 2, FullName = "Tony", Email="tony@gmail.com", Password="ironman" },
            new Employee { Id = 3, FullName = "Natasha", Email="natasha@gmail.com", Password="blackwidow" }
        };

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string email, string password)
        {
            // Kiểm tra tài khoản
            var user = employees.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                HttpContext.Session.SetString("UserFullName", user.FullName);
                return RedirectToAction("Index", "Employee");
            }

            ViewBag.Error = "Sai tài khoản hoặc mật khẩu!";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
