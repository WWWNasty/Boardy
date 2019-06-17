using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Abstraction.RepositoryInterfaces.Base;
using DataAccessLayer.Data.EntityFramework;
using DataAccessLayer.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Implementation.Repositories.Base
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T, int> where T : Entity<int>
    {
        protected readonly BoardyDbContext DbContext;

        public RepositoryBase(BoardyDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual T Get(int id)
        {
            var result = GetData().FirstOrDefault(entity => entity.Id == id);
            return result;
        }

        public virtual Task<T> GetAsync(int id)
        {
            var result = GetData().FirstOrDefaultAsync(entity => entity.Id == id);
            return result;
        }

        public virtual ICollection<T> GetAll()
        {
            var result = GetData().ToList();
            return result;
        }

        public virtual async Task<ICollection<T>> GetAllAsync()
        {
            List<T> result = await GetData().ToListAsync();

            return result;
        }
        
        public virtual void Delete(T entity)
        {
            GetData().Remove(entity);
        }
        

        public void Delete(int id)
        {
            var entity = Get(id);
            Delete(entity);
        }

        public int Create(T entity)
        {
            DbContext.Set<T>().Add(entity);

            return entity.Id;
        }
        

        public int Update(T entity)
        {
            DbContext.Set<T>().Update(entity);

            return entity.Id;
        }
        
        private DbSet<T> GetData()
        {
            return DbContext.Set<T>();
        }
    }
}