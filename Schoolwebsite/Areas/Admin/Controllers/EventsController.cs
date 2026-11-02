using Microsoft.AspNetCore.Mvc;
using Schoolwebsite.Services;
using Schoolwebsite.ViewModels.Admin;

namespace Schoolwebsite.Areas.Admin.Controllers
{
    public class EventsController : AdminBaseController
    {
        private readonly IEventService _events;

        public EventsController(IEventService events)
        {
            _events = events;
        }

        // GET: /Admin/Events
        public async Task<IActionResult> Index()
        {
            return View(await _events.GetAllAsync());
        }

        // GET: /Admin/Events/Create
        public IActionResult Create()
        {
            return View(new EventViewModel());
        }

        // POST: /Admin/Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventViewModel model)
        {
            if (model.Image == null)
            {
                ModelState.AddModelError(nameof(model.Image), "Please choose an image.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await _events.CreateAsync(model);
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(nameof(model.Image), ex.Message);
                return View(model);
            }

            TempData["Success"] = $"{model.Title} was added.";
            return RedirectToAction(nameof(Index));
        }

        // GET: /Admin/Events/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _events.GetForEditAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: /Admin/Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EventViewModel model)
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
                var updated = await _events.UpdateAsync(model);
                if (!updated)
                {
                    return NotFound();
                }
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(nameof(model.Image), ex.Message);
                return View(model);
            }

            TempData["Success"] = $"{model.Title} was updated.";
            return RedirectToAction(nameof(Index));
        }

        // GET: /Admin/Events/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var ev = await _events.GetByIdAsync(id);
            if (ev == null)
            {
                return NotFound();
            }

            return View(ev);
        }

        // POST: /Admin/Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleted = await _events.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            TempData["Success"] = "Event was deleted.";
            return RedirectToAction(nameof(Index));
        }


        //get:/admin/events/details
        public  async Task<IActionResult> Details(int id)
        {
            var ev = await _events.GetByIdAsync(id);
            if(ev == null) return NotFound();
            return View(ev);

        }

    }
}
