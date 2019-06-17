using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Objects.Dtos;
using BusinessLogicLayer.Objects.Dtos.Adverts.Search;
using DataAccessLayer.Abstraction.RepositoryInterfaces;
using DataAccessLayer.Data.Mock.Repositories.Base;
using DataAccessLayer.Models.Entities;

namespace DataAccessLayer.Data.Mock.Repositories
{
    public class AdvertRepository : RepositoryBase<Advert>, IAdvertRepository
    {
        public Task<int> GetAdvertsAmountAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<int> GetAdvertsAmountAsync(SearchQuery query)
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<Advert>> GetAllAsync(SearchQuery query)
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<Advert>> GetByUserAsync(string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<Advert>> GetByUserLikedAsync(string userId)
        {
            throw new System.NotImplementedException();
        }
    }
}