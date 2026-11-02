using Microsoft.AspNetCore.Mvc;
using Schoolwebsite.Services;
using Schoolwebsite.ViewModels.Admin;

namespace Schoolwebsite.Areas.Admin.Controllers
{
    public class BlogPostsController : AdminBaseController
    {
        private readonly IBlogService _blog;

        public BlogPostsController(IBlogService blog)
        {
            _blog = blog;
        }

        // GET: /Admin/BlogPosts
        public async Task<IActionResult> Index()
        {
            return View(await _blog.GetAllAsync());
        }

        // GET: /Admin/BlogPosts/Create
        public IActionResult Create()
        {
            return View(new BlogPostViewModel());
        }

        // POST: /Admin/BlogPosts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogPostViewModel model)
        {
            if (model.Image == null)
            {
                ModelState.AddModelError(nameof(model.Image), "Please choose a cover image.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await _blog.CreateAsync(model);
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(nameof(model.Image), ex.Message);
                return View(model);
            }

            TempData["Success"] = $"{model.Title} was published.";
            return RedirectToAction(nameof(Index));
        }

        // GET: /Admin/BlogPosts/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _blog.GetForEditAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: /Admin/BlogPosts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BlogPostViewModel model)
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
                var updated = await _blog.UpdateAsync(model);
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

        // GET: /Admin/BlogPosts/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var post = await _blog.GetByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: /Admin/BlogPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleted = await _blog.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            TempData["Success"] = "Blog post was deleted.";
            return RedirectToAction(nameof(Index));
        }



        ///get:/admin/blogs/details
        ///
        public async Task<IActionResult> Details(int id)
        {
            var blog= await _blog.GetByIdAsync(id);
            if(blog == null) return NotFound();
            return View(blog);
        }
    }
}
