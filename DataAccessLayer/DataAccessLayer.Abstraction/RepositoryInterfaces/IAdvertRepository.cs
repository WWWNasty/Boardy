using DataAccessLayer.Abstraction.RepositoryInterfaces.Base;
using DataAccessLayer.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.Objects.Dtos;
using BusinessLogicLayer.Objects.Dtos.Adverts.Search;

namespace DataAccessLayer.Abstraction.RepositoryInterfaces
{
    public interface IAdvertRepository : IRepositoryBase<Advert, int>
    {
        Task<ICollection<Advert>> GetAllAsync(SearchQuery query);

        Task<int> GetAdvertsAmountAsync(SearchQuery query);
    }
}