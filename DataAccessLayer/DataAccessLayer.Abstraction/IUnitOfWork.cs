using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstraction.RepositoryInterfaces;

namespace DataAccessLayer.Abstraction
{
    public interface IUnitOfWork
    {
        IAddressRepository AddressRepository { get;  }

        IAdvertCommentRepository AdvertCommentRepository { get; }

        IAdvertRepository AdvertRepository { get; }

        IImageRepository ImageRepository { get; }

        ILikeRepository LikeRepository { get; }

        ISubCategoryRepository SubCategoryRepository { get; set; }

        void SaveChanges();

        Task SaveChangesAsync();

    }
}
