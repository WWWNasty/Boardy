using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models.Entities.Base;


namespace DataAccessLayer.Abstraction.RepositoryInterfaces.Base
{
    public interface IRepositoryBase<TEntity, TId> where TEntity : Entity<TId>
    {
        TEntity Get(TId id);
        Task<TEntity> GetAsync(TId id);

        ICollection<TEntity> GetAll();
        Task<ICollection<TEntity>> GetAllAsync();

        void Delete(TId id);
        void Delete(TEntity entity);

        int Create(TEntity entity);
        int Update(TEntity entity);
    }
}