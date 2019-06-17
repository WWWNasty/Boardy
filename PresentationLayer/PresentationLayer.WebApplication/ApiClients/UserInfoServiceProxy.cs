using BusinessLogicLayer.Abstraction.Interfaces;
using BusinessLogicLayer.Objects.Dtos;
using Flurl.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using PresentationLayer.WebApplication.Common.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.Objects.Dtos.Adverts.Search;

namespace PresentationLayer.WebApplication.ApiClients
{
    public class UserInfoServiceProxy: ServiceProxy, IUserInfoService
    {
        private readonly ApiOptions _apiOptions;

        public UserInfoServiceProxy(
            IOptions<ApiOptions> apiOptions,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _apiOptions = apiOptions.Value;
        }

        public async Task<SearchAnswer> GetByUserAsync(SearchQuery searchQuery)
        {
            return await $"{_apiOptions.Url}/api/userinfo/user"
                .WithOAuthBearerToken(await GetAccessTokenAsync())
                .SetQueryParams(searchQuery)
                .GetJsonAsync<SearchAnswer>();
        }

        public async Task<SearchAnswer> GetByUserLikedAsync(SearchQuery searchQuery)
        {
            return await $"{_apiOptions.Url}/api/userinfo/liked"
                .WithOAuthBearerToken(await GetAccessTokenAsync())
                .SetQueryParams(searchQuery)
                .GetJsonAsync<SearchAnswer>();
        }
    }
}
