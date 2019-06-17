using System.Net.Http;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstraction.Interfaces;
using BusinessLogicLayer.Objects.Dtos;
using BusinessLogicLayer.Objects.Dtos.Adverts;
using BusinessLogicLayer.Objects.Dtos.Adverts.Search;
using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using PresentationLayer.WebApplication.Common.Options;

namespace PresentationLayer.WebApplication.ApiClients
{
    public class AdvertServiceProxy : ServiceProxy, IAdvertService
    {
       private readonly ApiOptions _apiOptions;

        public AdvertServiceProxy(
            IOptions<ApiOptions> apiOptions,
            IHttpContextAccessor httpContextAccessor):base(httpContextAccessor)
        {
           _apiOptions = apiOptions.Value;
        }

        public async Task<SearchAnswer> GetAllAsync(SearchQuery searchQuery)
        {
            return await $"{_apiOptions.Url}/api/adverts"
                .SetQueryParams(searchQuery)
                .GetJsonAsync<SearchAnswer>();
        }

        public Task<AdvertDto> GetAsync(int id)
        {
            return $"{_apiOptions.Url}/api/adverts/{id}".GetJsonAsync<AdvertDto>();
        }

        public async Task<int> AddAsync(CreateAdvertDto dto)
        {
            var postResponse = await $"{_apiOptions.Url}/api/adverts"
                .WithOAuthBearerToken(await GetAccessTokenAsync())
                .PostJsonAsync(dto);

            return  await postResponse.Content.ReadAsAsync<int>();
        }

        public async Task DeleteAsync(DeleteAdvertDto dto, bool isAdmin = false)
        {
            var accessToken = await GetAccessTokenAsync();

            await $"{_apiOptions.Url}/api/adverts"
                .SetQueryParams(dto)
                .WithOAuthBearerToken(accessToken)
                .DeleteAsync();
        }

        public async Task UpdateAsync(UpdateAdvertDto dto, bool isAdmin = false)
        {
            await $"{_apiOptions.Url}/api/adverts/"
                .WithOAuthBearerToken(await GetAccessTokenAsync())
                .PutJsonAsync(dto);
        }
    }
}