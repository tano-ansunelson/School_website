using Microsoft.AspNetCore.Mvc;
using Schoolwebsite.Services;

namespace Schoolwebsite.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogs;
        public BlogController(IBlogService blogs)=> _blogs = blogs;
        // GET: /Blog
        public async Task<IActionResult> Index(int page =1)
        {
            const int PageSize = 3;
           var post = await _blogs.GetAllAsync();

            var ordered = post.OrderByDescending(p => p.Date).ToList();

            int totalCount = ordered.Count;
            int totalPages = (int)Math.Ceiling(totalCount / (double) PageSize);

            var pagedPosts = ordered
                .Skip((page -1) * PageSize)
                .Take(PageSize)
                .ToList();
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.AllCategories = ordered.Select(p => p.Category).Distinct().ToList();
            ViewBag.RecentPosts = ordered.Take(2).ToList();
            return View(pagedPosts);
        }

        // GET: /Blog/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var post = await _blogs.GetByIdAsync(id);
            if(post == null)return NotFound();

            var all = await _blogs.GetAllAsync();
            ViewBag.RecentPosts = all.Where(p => p.BlogPostId != id).OrderByDescending(p=>p.Date).Take(3).ToList();
           

            return View(post);
        }
    }
}
