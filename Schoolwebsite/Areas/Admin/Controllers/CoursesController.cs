using Microsoft.AspNetCore.Mvc;
using Schoolwebsite.Services;
using Schoolwebsite.ViewModels.Admin;

namespace Schoolwebsite.Areas.Admin.Controllers
{
    public class CoursesController : AdminBaseController
    {
        private readonly ICourseService _courses;

        public CoursesController(ICourseService courses)
        {
            _courses = courses;
        }

        // GET: /Admin/Courses
        public async Task<IActionResult> Index()
        {
            return View(await _courses.GetAllAsync());
        }

        // GET: /Admin/Courses/Create
        public async Task<IActionResult> Create()
        {
            return View(await _courses.GetForCreateAsync());
        }

        // POST: /Admin/Courses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseViewModel model)
        {
            if (model.Image == null)
            {
                ModelState.AddModelError(nameof(model.Image), "Please choose an image.");
            }

            if (!ModelState.IsValid)
            {
                var refreshed = await _courses.GetForCreateAsync();
                model.AvailableTeachers = refreshed.AvailableTeachers;
                return View(model);
            }

            try
            {
                await _courses.CreateAsync(model);
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(nameof(model.Image), ex.Message);
                var refreshed = await _courses.GetForCreateAsync();
                model.AvailableTeachers = refreshed.AvailableTeachers;
                return View(model);
            }

            TempData["Success"] = $"{model.Title} was added.";
            return RedirectToAction(nameof(Index));
        }

        // GET: /Admin/Courses/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _courses.GetForEditAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: /Admin/Courses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CourseViewModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                //var refreshed = await _courses.GetForCreateAsync();
                //model.AvailableTeachers = refreshed.AvailableTeachers;
                return View(model);
            }

            try
            {
                var updated = await _courses.UpdateAsync(model);
                if (!updated)
                {
                    return NotFound();
                }
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(nameof(model.Image), ex.Message);
                var refreshed = await _courses.GetForCreateAsync();
                model.AvailableTeachers = refreshed.AvailableTeachers;
                return View(model);
            }

            TempData["Success"] = $"{model.Title} was updated.";
            return RedirectToAction(nameof(Index));
        }

        // GET: /Admin/Courses/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _courses.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: /Admin/Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleted = await _courses.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            TempData["Success"] = "Programme was deleted.";
            return RedirectToAction(nameof(Index));
        }

        ///get:/admin/courses/details
        ///
        public async Task<IActionResult> Details(int id)
        {
            var course = await _courses.GetByIdAsync(id);
            if(course == null) return NotFound();
            return View(course);
        }




    }
}
