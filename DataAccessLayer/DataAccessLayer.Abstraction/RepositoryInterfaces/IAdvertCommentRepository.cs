using DataAccessLayer.Abstraction.RepositoryInterfaces.Base;
using DataAccessLayer.Models.Entities;
using System.Collections.Generic;

namespace DataAccessLayer.Abstraction.RepositoryInterfaces
{
    public interface IAdvertCommentRepository : IRepositoryBase<AdvertComment, int>
    {
    }
}