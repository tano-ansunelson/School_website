using Microsoft.EntityFrameworkCore;
using Schoolwebsite.Data;
using System.Linq.Expressions;

namespace Schoolwebsite.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext Db;
        protected readonly DbSet<T> DbSet;

        public Repository(ApplicationDbContext db)
        { 
            Db = db;
            DbSet = Db.Set<T>();
        }

        public  virtual async Task AddAsync(T entity) => await DbSet.AddAsync(entity);
      

        public virtual async Task<bool> ExistAsync(int id)
        {
            var entity = await DbSet.FindAsync(id);
            return entity != null;
        }

        public virtual async Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate)=> await DbSet.Where(predicate).ToListAsync();
        

        public  virtual async Task<List<T>> GetAllAsync() => await DbSet.ToListAsync();


        public virtual  async Task<T?> GetByIdAsync(int id)=> await DbSet.FindAsync(id);
       

        public virtual void Remove(T entity) => DbSet.Remove(entity);
       

        public async Task SaveChangesAsync() => await Db.SaveChangesAsync();
        

        public  virtual void Update(T entity)=> DbSet.Update(entity);
       
    }
}
