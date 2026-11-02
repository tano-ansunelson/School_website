using Schoolwebsite.Data;
using Schoolwebsite.Models;

namespace Schoolwebsite.Repository
{

    public interface IEventRepository: IRepository<SchoolEvent> { }
    public class EventRepository : Repository<SchoolEvent>, IEventRepository
    {

        public EventRepository(Data.ApplicationDbContext db): base(db) { }
    }
}
