using DataAccessLayer.Abstraction;
using DataAccessLayer.Abstraction.RepositoryInterfaces;
using DataAccessLayer.Data.EntityFramework;
using DataAccessLayer.Implementation.Repositories.Base;
using DataAccessLayer.Models.Entities;

namespace DataAccessLayer.Implementation.Repositories
{
    public class ImageRepository : RepositoryBase<Image>, IImageRepository
    {
        public ImageRepository(BoardyDbContext dbContext) : base(dbContext)
        {
        }
    }
}
