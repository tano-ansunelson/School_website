using Schoolwebsite.Models;
using Schoolwebsite.Repository;
using Schoolwebsite.ViewModels.Admin;

namespace Schoolwebsite.Services
{
    public interface IBlogService
    {
        Task<List<BlogPost>> GetAllAsync();
        Task<BlogPost?> GetByIdAsync(int id);

        Task<BlogPostViewModel?> GetForEditAsync(int id);
        Task CreateAsync(BlogPostViewModel model);
        Task<bool> UpdateAsync(BlogPostViewModel model);
        Task<bool> DeleteAsync(int id);
    }


    public class BlogService : IBlogService
    {


        private readonly IBlogPostRepository _post;
        private readonly IFileUploadService _fileUpload;



        public BlogService(IBlogPostRepository post, IFileUploadService fileUpload)
        {
            _post = post;
            _fileUpload = fileUpload;
        }

        public async Task CreateAsync(BlogPostViewModel model)
        {

            if (model.Image == null) {

                throw new ArgumentException("Please choose a cover image for the post");
            }
            var imagePath = await _fileUpload.SaveImageAsync(model.Image, "blog");


            var post = new BlogPost
            {
                Title = model.Title,
                Author = model.Author,
                Date = model.Date,
                Category = model.Category,
                Summary = model.Summary,
                Body = model.Body,
                ImagePath = imagePath,
            };

            await _post.AddAsync(post);
            await _post.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var post = await _post.GetByIdAsync(id);
            if (post == null) { 
            
            return false;
            }
            _fileUpload.DeleteImage(post.ImagePath);
            _post.Remove(post);
            await _post.SaveChangesAsync();
            return true;
        }

        public Task<List<BlogPost>> GetAllAsync() => _post.GetAllAsync();
      

        public Task<BlogPost?> GetByIdAsync(int id)=> _post.GetByIdAsync(id);
       

        public async Task<BlogPostViewModel?> GetForEditAsync(int id)
        {


            var post = await _post.GetByIdAsync( id);

            if (post == null)
            {
                return null;
            }

            return new BlogPostViewModel
            {
                Id = post.BlogPostId,
                Title = post.Title,
                Author = post.Author,
                Date = post.Date,
                Category = post.Category,
                Summary = post.Summary,
                Body = post.Body,
                ExistingImagePath = post.ImagePath
            };
           
        }

        public async Task<bool> UpdateAsync(BlogPostViewModel model)
        {
            var post = await _post.GetByIdAsync(model.Id);

            if(post == null)
            {
                return false;
            }
            post.Title = model.Title;
            post.Author = model.Author;
            post.Date = model.Date;
            post.Category = model.Category;
            post.Summary = model.Summary;
            post.Body = model.Body;

            if(model.Image != null)
            {
                var newPath = await _fileUpload.SaveImageAsync(model.Image, "blog");
                _fileUpload.DeleteImage(post.ImagePath);
                post.ImagePath = newPath;
            }

            _post.Update(post);
            await _post.SaveChangesAsync();
            return true;
        }
    }
}
