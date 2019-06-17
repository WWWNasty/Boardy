using System.Threading.Tasks;
using DataAccessLayer.Abstraction;
using DataAccessLayer.Abstraction.RepositoryInterfaces;
using DataAccessLayer.Data.EntityFramework;
using DataAccessLayer.Implementation.Repositories;

namespace DataAccessLayer.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BoardyDbContext _dbContext;
        public IAddressRepository AddressRepository { get; }
        public IAdvertCommentRepository AdvertCommentRepository { get; }
        public IAdvertRepository AdvertRepository { get; }
        public IImageRepository ImageRepository { get; }
        public ILikeRepository LikeRepository { get; }
        public ISubCategoryRepository SubCategoryRepository { get; set; }

        public UnitOfWork(BoardyDbContext dbContext,
            IAddressRepository addressRepository,
            IAdvertCommentRepository advertCommentRepository,
            IAdvertRepository advertRepository,
            IImageRepository imageRepository,
            ILikeRepository likeRepository,
            ISubCategoryRepository subCategoryRepository)
        {
            _dbContext = dbContext;
            AddressRepository = addressRepository;
            AdvertCommentRepository = advertCommentRepository;
            AdvertRepository = advertRepository;
            ImageRepository = imageRepository;
            LikeRepository = likeRepository;
            SubCategoryRepository = subCategoryRepository;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}