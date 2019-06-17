using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstraction;
using DataAccessLayer.Abstraction.RepositoryInterfaces;
using DataAccessLayer.Data.Mock.Repositories;

namespace DataAccessLayer.Data.Mock
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAddressRepository AddressRepository { get; }
        public IAdvertCommentRepository AdvertCommentRepository { get; }
        public IAdvertRepository AdvertRepository { get; } = new AdvertRepository();
        public IImageRepository ImageRepository { get; }
        public ILikeRepository LikeRepository { get; }
        public ISubCategoryRepository SubCategoryRepository { get; set; }

        public void SaveChanges()
        {
            //Ничего не делает т.к данные меняются сразу
        }

        public Task SaveChangesAsync()
        {
            return Task.CompletedTask;
        }
    }
}
