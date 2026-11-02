using System.Linq.Expressions;

namespace Schoolwebsite.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
         
        void Remove(T entity);

        Task<bool> ExistAsync(int id);
        Task SaveChangesAsync();

        Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);


    }
}
