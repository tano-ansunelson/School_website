using Schoolwebsite.Data;
using Schoolwebsite.Models;

namespace Schoolwebsite.Repository
{
    public interface ICourseRepository : IRepository<Course>
    {
        // Courses always need their Coordinator teacher for display, so these
        // two overloads eager-load it via Include() — plain GetAllAsync/GetByIdAsync
        // from IRepository<T> would leave Coordinator null.
    }


    public class CourseRepository :Repository<Course>, ICourseRepository
    {

        public CourseRepository(Data.ApplicationDbContext db):base(db) { }
    }
}
