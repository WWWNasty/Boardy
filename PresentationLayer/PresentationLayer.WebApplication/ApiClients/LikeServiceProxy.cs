using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstraction.Interfaces;
using BusinessLogicLayer.Objects.Dtos;
using BusinessLogicLayer.Objects.Dtos.Likes;
using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using PresentationLayer.WebApplication.Common.Options;

namespace PresentationLayer.WebApplication.ApiClients
{
    public class LikeServiceProxy : ServiceProxy, ILikeService
    {
        private readonly ApiOptions _apiOptions;

        public LikeServiceProxy(IOptions<ApiOptions> apiOptions,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _apiOptions = apiOptions.Value;
        }


        public async Task AddAsync(CreateLikeDto dto)
        {
            await $"{_apiOptions.Url}/api/like"
                .WithOAuthBearerToken(await GetAccessTokenAsync())
                .PostJsonAsync(dto);
        }

        public async Task DeleteAsync(DeleteLikeDto dto)
        {
            await $"{_apiOptions.Url}/api/like"
                .WithOAuthBearerToken(await GetAccessTokenAsync())
                .SetQueryParams(dto)
                .DeleteAsync();
        }
    }
}