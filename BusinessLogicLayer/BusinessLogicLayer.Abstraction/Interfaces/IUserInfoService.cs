using BusinessLogicLayer.Objects.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.Objects.Dtos.Adverts.Search;

namespace BusinessLogicLayer.Abstraction.Interfaces
{
    public interface IUserInfoService
    {
        Task<SearchAnswer> GetByUserAsync(SearchQuery query);
        Task<SearchAnswer> GetByUserLikedAsync(SearchQuery query);
    }
}