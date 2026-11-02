using Schoolwebsite.Data;
using Schoolwebsite.Models;

namespace Schoolwebsite.Repository
{

    public interface IBlogPostRepository: IRepository<BlogPost>
    {

    }



    public class BlogPostRepository :Repository<BlogPost>, IBlogPostRepository
    {

        public BlogPostRepository(Data.ApplicationDbContext db): base(db) { }
    }
}
