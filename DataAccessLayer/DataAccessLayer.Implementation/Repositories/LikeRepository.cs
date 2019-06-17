using DataAccessLayer.Abstraction;
using DataAccessLayer.Abstraction.RepositoryInterfaces;
using DataAccessLayer.Data.EntityFramework;
using DataAccessLayer.Implementation.Repositories.Base;
using DataAccessLayer.Models.Entities;

namespace DataAccessLayer.Implementation.Repositories
{
    public class LikeRepository : RepositoryBase<Like>, ILikeRepository
    {
        public LikeRepository(BoardyDbContext dbContext) : base(dbContext)
        {
        }
    }
}
