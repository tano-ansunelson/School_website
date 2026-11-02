using Microsoft.AspNetCore.Mvc;
using Schoolwebsite.Models;
using Schoolwebsite.Repository;
using Schoolwebsite.Services;
using Schoolwebsite.ViewModels.Admin;

namespace Schoolwebsite.Areas.Admin.Controllers
{
    public class StudentController : AdminBaseController
    {

        private readonly IStudentService _student;
        public StudentController(IStudentService student)=> _student = student;

        //get:/admin/student/
        public async Task<IActionResult> Index()
        {
            return View(await _student.GetAllAsync());
        }

        
        //get:/admin/student/create

        public IActionResult Create()
        {
            return View( new StudentViewModel());
        }
        //post:/admin/student/create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<IActionResult> Create(StudentViewModel model)
        {
            if (model.Image == null)
            {
                ModelState.AddModelError(nameof(model.Image), "Please choose a photo");
            }

            if(!ModelState.IsValid)
            {
                return View(model);
            }


            try
            {
                await _student.CreateAsync(model);
            }catch (AggregateException ex)
            {
                ModelState.AddModelError(nameof(model.Image), ex.Message);
                return View(model);
            }
            TempData["Success"] = $"{model.Name} was added";
            return RedirectToAction(nameof(Index));
               
        }

        //get:/admin/student/edit
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _student.GetForEditAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StudentViewModel model)
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
                var updated = await _student.UpdateAsync(model);
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
            var student = await _student.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var deleted = await _student.DeleteAsync(id);
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
    }
}
