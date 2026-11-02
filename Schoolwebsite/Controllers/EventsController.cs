using Microsoft.AspNetCore.Mvc;
using Schoolwebsite.Services;

namespace Schoolwebsite.Controllers
{
    public class EventsController : Controller

    {

        private readonly IEventService _events;

        public EventsController(IEventService events)=> _events= events;
        public async Task<IActionResult> Index(int page =1)
        {
            const int pageSize = 6;
            var events = await _events.GetAllAsync();
         
            var orderd = events.OrderBy(e=>e.Date).ToList();
            int totalCount = orderd.Count;
            int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            var pagedEvents = orderd
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();


            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;


            return View(pagedEvents);
        }

        // GET: /Events/Details/1
        public async Task<IActionResult> Details(int id)
        {
          var ev= await _events.GetByIdAsync(id);
            if(ev==null)  return NotFound();

            var all = await _events.GetAllAsync(); 
            ViewBag.otherEvents = all.Where(e=> e.SchoolEventId != id ).OrderBy(e=>e.Date).Take(2).ToList();

            return View(ev);
        }
    }
}
