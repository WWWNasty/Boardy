using BusinessLogicLayer.Abstraction.Interfaces;
using BusinessLogicLayer.Objects.Dtos.Prompt;
using Flurl.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using PresentationLayer.WebApplication.Common.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PresentationLayer.WebApplication.ApiClients
{
    public class PromptServiceProxy : ServiceProxy, IPromptService
    {
        private readonly ApiOptions _apiOptions;

        public PromptServiceProxy(
            IOptions<ApiOptions> apiOptions,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _apiOptions = apiOptions.Value;
        }

        public async Task<IEnumerable<PromptAnswer>> GetCity(PromptQuery query)
        {
            var result = await $"{_apiOptions.Url}/api/prompt/city"
                .PostJsonAsync(query)
                .ReceiveJson<IEnumerable<PromptAnswer>>();
            return result;
        }

        public async Task<IEnumerable<PromptAnswer>> GetHouse(PromptQuery query)
        {
            var result = await $"{_apiOptions.Url}/api/prompt/house"
                .PostJsonAsync(query)
                .ReceiveJson<IEnumerable<PromptAnswer>>();
            return result;
        }

        public async Task<IEnumerable<PromptAnswer>> GetRegion(PromptQuery query)
        {
            var result = await $"{_apiOptions.Url}/api/prompt/region"
                .PostJsonAsync(query)
                .ReceiveJson<IEnumerable<PromptAnswer>>();
            return result;
        }

        public async Task<IEnumerable<PromptAnswer>> GetStreet(PromptQuery query)
        {
            var result = await $"{_apiOptions.Url}/api/prompt/street"
                .PostJsonAsync(query)
                .ReceiveJson<IEnumerable<PromptAnswer>>();
            return result;
        }
    }
}
