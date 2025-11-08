using Day12Lab1.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection;

namespace Day12Lab1.Controllers
{
    [Route("Admin/Student")]
    public class StudentController : Controller
    {
        private static List<Student> listStudents = new List<Student>();
        public StudentController()
        {
            if (listStudents.Count == 0)
            {
                listStudents = new List<Student>()
                {
                    new Student() { Id = 101, Name = "Hải Nam", Branch = Branch.IT,
                        Gender = Gender.Male, IsRegular = true, Address = "A1-2018", Email = "nam@g.com" },
                    new Student() { Id = 102, Name = "Minh Tú", Branch = Branch.BE,
                        Gender = Gender.Female, IsRegular = true, Address = "A1-2019", Email = "tu@g.com" },
                    new Student() { Id = 103, Name = "Hoàng Phong", Branch = Branch.CE,
                        Gender = Gender.Male, IsRegular = false, Address = "A1-2020", Email = "phong@g.com" },
                    new Student() { Id = 104, Name = "Xuân Mai", Branch = Branch.EE,
                        Gender = Gender.Female, IsRegular = false, Address = "A1-2021", Email = "mai@g.com" }
                };
            }
        }

        [Route("List")]
        public IActionResult Index()
        {
            return View(listStudents);
        }

        [HttpGet("Add")]
        public IActionResult Create()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "IT" },
                new SelectListItem { Text = "BE", Value = "BE" },
                new SelectListItem { Text = "CE", Value = "CE" },
                new SelectListItem { Text = "EE", Value = "EE" }
            };
            return View();
        }

        //[HttpPost("Add")]
        //public IActionResult Create(Student s)
        //{
        //    s.Id = listStudents.Last().Id + 1;
        //    listStudents.Add(s);
        //    return View("Index", listStudents);
        //}

        [HttpPost("Add")]
        public IActionResult Create(Student s, IFormFile AvatarFile, [FromServices] IWebHostEnvironment env)
        {
            if (AvatarFile != null && AvatarFile.Length > 0)
            {
                // Tạo thư mục lưu ảnh nếu chưa có
                string uploadPath = Path.Combine(env.WebRootPath, "images", "avatars");
                if (!Directory.Exists(uploadPath))
                    Directory.CreateDirectory(uploadPath);

                // Đặt tên file duy nhất (tránh trùng)
                string fileName = $"{Guid.NewGuid()}_{AvatarFile.FileName}";
                string filePath = Path.Combine(uploadPath, fileName);

                // Lưu file ảnh vào thư mục wwwroot/images/avatars
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    AvatarFile.CopyTo(stream);
                }

                // Lưu đường dẫn tương đối vào Student
                s.Avatar = $"/images/avatars/{fileName}";
            }

            // Tăng ID và thêm vào danh sách
            s.Id = listStudents.Last().Id + 1;
            listStudents.Add(s);

            return RedirectToAction("Index");
        }
    }
}
