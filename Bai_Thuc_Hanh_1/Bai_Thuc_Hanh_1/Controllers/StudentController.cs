using Bai_Thuc_Hanh_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bai_Thuc_Hanh_1.Controllers
{
    [Route("Admin/Student")]
    [Route("Student")]
    public class StudentController : Controller
    {
        private List<Student> listStudents = new List<Student>();
        public StudentController()
        {
            listStudents = new List<Student>()
            {
                new Student() {
                    Id = 1,
                    Name = "Đồn Lạt",
                    Email = "donlat@gmail.com",
                    Branch = Branch.IT,
                    Gender = Gender.Male,
                    IsRegular = true,
                    Address = "Hà Tây",
                    Avatar = "demo1.png",
                    DateOfBorth = new DateTime(2005,01,01)
                },
                new Student() {
                    Id = 2,
                    Name = "Phấn Đồ",
                    Email = "phando@gmail.com",
                    Branch = Branch.BE,
                    Gender = Gender.Female,
                    IsRegular = false,
                    Address = "Nam Định",
                    Avatar = "demo1.png",
                    DateOfBorth = new DateTime(2005,10,31)
                },
                new Student() {
                    Id = 3,
                    Name = "Hất Chiếu",
                    Email = "hatchieu@gmail.com",
                    Branch = Branch.CE,
                    Gender = Gender.Male,
                    IsRegular = true,
                    Address = "Hà Nội Thành",
                    Avatar = "demo1.png",
                    DateOfBorth = new DateTime(2005,03,30)
                },
            };
        }

        [Route("List")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View(listStudents);
        }

        [Route("Add")]
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "1" },
                new SelectListItem { Text = "BE", Value = "2" },
                new SelectListItem { Text = "CE", Value = "3" },
                new SelectListItem { Text = "EE", Value = "4" }
            };
            return View();
        }

        [Route("Add")]
        [HttpPost]
        public IActionResult Create(Student s, IFormFile AvatarFile)
        {
            if (AvatarFile != null && AvatarFile.Length > 0)
            {
                // Lấy tên file gốc
                var fileName = Path.GetFileName(AvatarFile.FileName);

                // Tạo đường dẫn lưu file (wwwroot/images)
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

                // Tạo thư mục nếu chưa có
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                // Đường dẫn file đích
                var filePath = Path.Combine(uploadPath, fileName);

                // Ghi file lên server
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    AvatarFile.CopyTo(stream);
                }

                // Gán tên file vào thuộc tính Avatar
                s.Avatar = fileName;
            }
            else
            {
                s.Avatar = "default.png"; // nếu không upload thì dùng ảnh mặc định
            }

            if (ModelState.IsValid)
            {
                s.Id = listStudents.Last<Student>().Id + 1;
                listStudents.Add(s);
                return View("Index", listStudents);
            }

            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "1" },
                new SelectListItem { Text = "BE", Value = "2" },
                new SelectListItem { Text = "CE", Value = "3" },
                new SelectListItem { Text = "EE", Value = "4" }
            };

            return View(s);
        }
    }
}
