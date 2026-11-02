using Microsoft.AspNetCore.Mvc;
using Schoolwebsite.Services;

namespace Schoolwebsite.Controllers
{
    public class TeachersController : Controller

    {

        private readonly ITeacherService _teachers;

        public TeachersController(ITeacherService teachers)
        {
            _teachers = teachers;
        }

        public async Task<IActionResult> Index(string? category)
        {
            var all = await _teachers.GetAllAsync();
            var filtered = category?.ToLower() switch
            {
                "administration" => all.Where(t => t.IsAdministration).ToList(),
                "hod" => all.Where(t => t.IsHod).ToList(),
                "housemaster" => all.Where(t => t.IsHouseMaster).ToList(),
                "teacher" => all.Where(t => t.IsTeacher).ToList(),
                _ => all

            };

            ViewBag.SelectedCategory = category;
            return View(filtered);
        }
       

        // GET: /Teachers/Details/1
        public async Task<IActionResult> Details(int id)
        {
         var teacher = await _teachers.GetByIdAsync(id);
            if(teacher == null) return NotFound();


            return View(teacher);
        }
    }
}
