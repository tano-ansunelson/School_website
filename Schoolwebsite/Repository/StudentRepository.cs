using Schoolwebsite.Models;

namespace Schoolwebsite.Repository
{

    public interface IStudentRepositoty : IRepository<Student>
    {

    }
    public class StudentRepository: Repository<Student>, IStudentRepositoty
    {

        public StudentRepository(Data.ApplicationDbContext db) : base(db) { }
    }
}
