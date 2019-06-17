using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstraction.Interfaces;
using BusinessLogicLayer.Objects.Dtos;
using BusinessLogicLayer.Objects.Dtos.Comments;
using Flurl.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using PresentationLayer.WebApplication.Common.Options;

namespace PresentationLayer.WebApplication.ApiClients
{
    public class AdvertCommentServiceProxy : ServiceProxy, IAdvertCommentService
    {
        private ApiOptions _apiOptions;

        public AdvertCommentServiceProxy(IHttpContextAccessor httpContextAccessor, IOptions<ApiOptions> apiOptions) : base(httpContextAccessor)
        {
            _apiOptions = apiOptions.Value;
        }

        public async Task AddAsync(CreateCommentDto dto)
        {
            var token = await GetAccessTokenAsync();

            await ($"{_apiOptions.Url}/api/AdvertComment").WithOAuthBearerToken(token).PostJsonAsync(dto);
        }

        public async Task DeleteAsync(DeleteCommentDto dto, bool isAdmin = false)
        {
            var token = await GetAccessTokenAsync();
            await ($"{_apiOptions.Url}/api/AdvertComment").WithOAuthBearerToken(token)
                
                .SetQueryParams(dto).DeleteAsync();
        }
    }
}
