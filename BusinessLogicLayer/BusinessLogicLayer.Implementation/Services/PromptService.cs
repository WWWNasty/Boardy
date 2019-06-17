using BusinessLogicLayer.Abstraction.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Newtonsoft.Json.Linq;
using System.Linq;
using BusinessLogicLayer.Objects.Dtos.Prompt;

namespace BusinessLogicLayer.Implementation.Services
{
    class PromptService : IPromptService
    {
        private const string _token = "378c8f7d3fb7b7a83b043259cf3373443cbc723d";
        private const string _promptServiceHost = "https://suggestions.dadata.ru/suggestions/api/4_1/rs/suggest/address";

        public async Task<IEnumerable<PromptAnswer>> GetCity(PromptQuery qry)
        {
            var message = _promptServiceHost
                .WithHeader("Authorization", $"Token {_token}");
            string response = await message
                .PostJsonAsync(new
                {
                    query = qry.Query,
                    from_bound = new { value = "city" },
                    to_bound = new { value = "city" },
                    locations = new object[] {
                        new { region_fias_id =  qry.Constraint }
                    }
                }).ReceiveString();

            JObject jsonResponse = JObject.Parse(response);
            IEnumerable<PromptAnswer> result = (from item in jsonResponse["suggestions"]
                                               select new PromptAnswer
                                               {
                                                   Address = item["data"]["city_with_type"].ToString(),
                                                   AddressId = item["data"]["city_fias_id"].ToString()
                                               }).ToList();
            return result;
        }

        public async Task<IEnumerable<PromptAnswer>> GetHouse(PromptQuery qry)
        {
            var message = _promptServiceHost
               .WithHeader("Authorization", $"Token {_token}");
            string response = await message
                .PostJsonAsync(new
                {
                    query = qry.Query,
                    from_bound = new { value = "house" },
                    to_bound = new { value = "house" },
                    locations = new object[] {
                        new { street_fias_id =  qry.Constraint }
                    }
                }).ReceiveString();

            JObject jsonResponse = JObject.Parse(response);
            IEnumerable<PromptAnswer> result = (from item in jsonResponse["suggestions"]
                                               select new PromptAnswer
                                               {
                                                   Address = item["data"]["house_type"].ToString() + " " + item["data"]["house"].ToString(),
                                                   AddressId = item["data"]["house_fias_id"].ToString()
                                               }).ToList();
            return result;
        }

        public async Task<IEnumerable<PromptAnswer>> GetRegion(PromptQuery qry)
        {
            var message = _promptServiceHost
                .WithHeader("Authorization", $"Token {_token}");
            string response = await message
                .PostJsonAsync(new
                {
                    query = qry.Query,
                    from_bound = new { value = "region" },
                    to_bound = new { value = "region" }
                }).ReceiveString();

            JObject jsonResponse = JObject.Parse(response);
            IEnumerable<PromptAnswer> result = (from item in jsonResponse["suggestions"]
                                                select new PromptAnswer
                                                {
                                                    Address = item["data"]["region_with_type"].ToString(),
                                                    AddressId = item["data"]["region_fias_id"].ToString()
                                                }).ToList();
            return result;
        }

        public async Task<IEnumerable<PromptAnswer>> GetStreet(PromptQuery qry)
        {
            var message = _promptServiceHost
              .WithHeader("Authorization", $"Token {_token}");
            string response = await message
                .PostJsonAsync(new
                {
                    query = qry.Query,
                    from_bound = new { value = "street" },
                    to_bound = new { value = "street" },
                    locations = new object[] {
                        new { city_fias_id =  qry.Constraint}
                    }
                }).ReceiveString();

            JObject jsonResponse = JObject.Parse(response);
            IEnumerable<PromptAnswer> result = (from item in jsonResponse["suggestions"]
                                               select new PromptAnswer
                                               {
                                                   Address = item["data"]["street_with_type"].ToString(),
                                                   AddressId = item["data"]["street_fias_id"].ToString()
                                               }).ToList();
            return result;
        }
    }
}
