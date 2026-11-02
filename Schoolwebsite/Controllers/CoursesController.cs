using Microsoft.AspNetCore.Mvc;
using Schoolwebsite.Services;

namespace Schoolwebsite.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseService _courses;
        public CoursesController(ICourseService courses)=> _courses = courses;

        // GET: /Courses
        public async Task<IActionResult> Index()
        {
            return View( await _courses.GetAllAsync());
        }

        // GET: /Courses/Details/1
        public async Task<IActionResult> Details(int id)
        {
          var course = await _courses.GetByIdAsync(id);
            if(course == null) return NotFound ();

            var all = await _courses.GetAllAsync();
            ViewBag.otherCourses = all.Where(c => c.CourseId != id).Take(3).ToList();

            return View(course);
        }
    }
}
