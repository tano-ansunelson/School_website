using Microsoft.AspNetCore.Mvc;
using Schoolwebsite.Models;
using Schoolwebsite.Services;
using System.Diagnostics;

namespace Schoolwebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITeacherService _teacher;
        private readonly ICourseService _courses;
        private readonly IEventService _events;
        private readonly IBlogService _blog;



        public HomeController(ILogger<HomeController> logger, ITeacherService teacher, ICourseService course, IEventService events, IBlogService blog)
        {
            _logger = logger;
            _events = events;
            _courses = course;
            _blog = blog;
            _teacher = teacher;
        }

        // GET: /
        public async Task<IActionResult> Index()
        {

            var allPosts = await _blog.GetAllAsync();
            var allTeachers = await _teacher.GetAllAsync();
            var allEvents = await _events.GetAllAsync();
            var allCourses = await _courses.GetAllAsync();
            //// Show the 3 most recent posts and first 4 teachers on the homepage.
            ///

            ViewBag.LatestPosts = allPosts.OrderByDescending(p => p.Date).Take(3).ToList();
            ViewBag.FeaturedTeachers = allTeachers.Take(4).ToList();
            ViewBag.FeaturedCourses = allCourses.Take(3).ToList();
            ViewBag.UpcomingEvents = allEvents.OrderBy(e => e.Date).Take(3).ToList();
            return View();
        }

        // GET: /Home/About
        public async Task<IActionResult> About()
        {
            var allTeachers = await _teacher.GetAllAsync();
           ViewBag.FeaturedTeachers = allTeachers.Take(4).ToList();
            return View();
        }

        // GET: /Home/Contact
        public IActionResult Contact()
        {
            return View(new ContactFormModel());
        }

        // POST: /Home/Contact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(ContactFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // TODO: wire this up to a real email service (e.g. SMTP or an email API)
            // once you're ready. For now we just log it and show a success message.
            _logger.LogInformation(
                "Contact form submitted by {Name} ({Email}): {Subject}",
                model.Name, model.Email, model.Subject);

            TempData["ContactSuccess"] = "Thanks! Your message has been sent. We'll get back to you soon.";
            return RedirectToAction(nameof(Contact));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = HttpContext.TraceIdentifier });
        }
    }
}
