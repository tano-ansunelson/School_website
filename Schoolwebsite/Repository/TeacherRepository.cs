using Schoolwebsite.Data;
using Schoolwebsite.Models;

namespace Schoolwebsite.Repository
{

    public interface ITeacherRepository : IRepository<Teacher>
    {

    }
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(Data.ApplicationDbContext db): base(db) { }
    }
}
