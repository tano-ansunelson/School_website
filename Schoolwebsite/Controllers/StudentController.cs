using Microsoft.AspNetCore.Mvc;
using Schoolwebsite.Services;

namespace Schoolwebsite.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _student;

        public StudentController(IStudentService student)=> _student = student;
        public async Task<IActionResult> Index()
        {
            return View( await _student.GetAllAsync());
        }
    }
}
