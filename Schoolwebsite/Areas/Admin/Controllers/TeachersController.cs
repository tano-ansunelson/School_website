using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Abstractions;
using Schoolwebsite.Services;
using Schoolwebsite.ViewModels.Admin;

namespace Schoolwebsite.Areas.Admin.Controllers
{
    public class TeachersController : AdminBaseController
    {
        private readonly ITeacherService _teacher;
        public TeachersController(ITeacherService teacher)
        {
            _teacher = teacher;
        }

        //get:/admin/teachers/
        public async Task<IActionResult> Index()
        {

            return View(await _teacher.GetAllAsync());
        }
        //get:/admin/teacher/create
        public IActionResult Create()
        {
            return View(new TeacherViewModel());
        }


        //post:/admin/teacher/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeacherViewModel model) 
        { 
        if(model.Image == null)
            {
                ModelState.AddModelError(nameof(model.Image), "Please choose a photo");
            }

            if (!ModelState.IsValid) { 
            return View(model);
            }
            
            try
            {
                await _teacher.CreateAsync(model);
            }
            catch (AggregateException ex) { 
            ModelState.AddModelError(nameof(model.Image), ex.Message);
                return View(model);
            }
            TempData["Success"] = $"{model.Name} was added";
            return RedirectToAction(nameof(Index));
        }


        //get:/admin/teachers/edit
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _teacher.GetForEditAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TeacherViewModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                var updated = await _teacher.UpdateAsync(model);
                if (!updated)
                {
                    return NotFound();
                }
            }
            catch (AggregateException ex)
            {
                ModelState.AddModelError(nameof(model.Image), ex.Message);
                return View(model);
            }
            TempData["Success"] = $"{model.Name} was updated.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var teacher = await _teacher.GetByIdAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }



        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var deleted = await _teacher.DeleteAsync(id);
                if (!deleted)
                {


                    return NotFound();
                }
            }
            catch (InvalidOperationException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
            TempData["Success"] = "Teacher was added";
            return RedirectToAction(nameof(Index));
        }



        //get:/admin/teachers/details
        public async Task<IActionResult> Details(int id)
        {
            var teacher = await _teacher.GetByIdAsync(id);
            if(teacher == null) return NotFound();
            return View(teacher);
        }

    }
}
