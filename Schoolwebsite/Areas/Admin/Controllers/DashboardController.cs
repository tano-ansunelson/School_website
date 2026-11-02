using Microsoft.AspNetCore.Mvc;
using Schoolwebsite.Services;

namespace Schoolwebsite.Areas.Admin.Controllers
{
    public class DashboardController : AdminBaseController
    {
        private readonly ITeacherService _teachers;
        private readonly ICourseService _courses;
        private readonly IEventService _events;
        private readonly IBlogService _blogs;
        private readonly IStudentService _student;

        public DashboardController(ITeacherService teachers, ICourseService courses, IEventService events, IBlogService blogs, IStudentService student)
        {
            _teachers = teachers;
            _courses = courses;
            _events = events;
            _blogs = blogs;
            _student = student;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.TeacherCount = (await _teachers.GetAllAsync()).Count;
            ViewBag.CourseCount = (await _courses.GetAllAsync()).Count;
            ViewBag.EventCount = (await _events.GetAllAsync()).Count;
            ViewBag.BlogCount = (await _blogs.GetAllAsync()).Count;
            ViewBag.StudentCount= (await _student.GetAllAsync()).Count;

            return View();
        }
    }
}
