using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Implementation.Services;
using BusinessLogicLayer.Objects.Dtos;
using Flurl.Http;
using Microsoft.Extensions.Options;
using PresentationLayer.WebApplication.Common.Options;

namespace PresentationLayer.WebApplication.ApiClients
{
    public class SubCategoryServiceProxy: ISubCategoryService
    {
        private readonly ApiOptions _apiOptions;

        public SubCategoryServiceProxy(IOptions<ApiOptions> apiOptions)
        {
            _apiOptions = apiOptions.Value;
        }

        public async Task<ICollection<SubCategoryDto>> GetSubCategoriesAsync() => 
            await $"{_apiOptions.Url}/api/SubCategory".GetJsonAsync<ICollection<SubCategoryDto>>();
    }
}
