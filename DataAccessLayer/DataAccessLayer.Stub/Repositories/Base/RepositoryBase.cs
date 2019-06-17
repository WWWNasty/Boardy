using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Abstraction.RepositoryInterfaces.Base;
using DataAccessLayer.Models.Entities.Base;

namespace DataAccessLayer.Data.Mock.Repositories.Base
{
#pragma warning disable 1998
    public abstract class RepositoryBase<T> : IRepositoryBase<T, int> where T : Entity<int>
    {
        protected readonly List<T> _context = new List<T>();


        public async Task<T> GetAsync(int id)

        {
            return _context.Find(x => x.Id == id);
        }

        public ICollection<T> GetAll()
        {
            return _context;
        }

        public Task<ICollection<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            return _context.Find(x => x.Id == id);
        }
        

        public int Create(T item)
        {
            _context.Add(item);
            return item.Id;
        }
        
        public void Delete(T item)
        {
            var itemToDelete = _context.Find(x => x.Id == item.Id);
            _context.Remove(itemToDelete);
        }

        public void Update(T item)
        {
            var entity = _context.Find(x => x.Id == item.Id);
            _context.Remove(entity);
            _context.Add(item);
        }
        
        public void Delete(int id)
        {
            var deletingEntity = _context.Find(entity => entity.Id == id);

            _context.Remove(deletingEntity);
        }

        int IRepositoryBase<T, int>.Update(T entity)
        {
            //Ничего не делает т.к данные обновляются сразу
            return entity.Id;
        }
    }
}

#pragma warning restore 1998