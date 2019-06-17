using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace PresentationLayer.WebApplication.ApiClients
{
    public class ServiceProxy
    {
        private IHttpContextAccessor _httpContextAccessor;

        public ServiceProxy(
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected async Task<string> GetAccessTokenAsync()
        {
            var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");

            return accessToken;
        }
    }
}