using BusinessLogicLayer.Objects.Enums;
using System.Collections.Generic;

namespace BusinessLogicLayer.Objects.Dtos.Adverts.Search
{
    public class SearchQuery
    {
        public int? AdvertCategoryId { get; set; }

        public string AdvertSearchString { get; set; } = string.Empty;

        public string AdvertRegion { get; set; } = string.Empty;

        public uint? PriceFilterMax { get; set; } 

        public uint? PriceFilterMin { get; set; }
        
        public int CurrentPage { get; set; } = 1;
        public int AdvertsPerPage { get; set; } = 15;

        public SortingType SortType { get; set; } = SortingType.NoSorting;

        public IDictionary<string, string> GetRouteData()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                { "AdvertCategoryId", AdvertCategoryId.ToString() },
                { "AdvertSearchString", AdvertSearchString },
                { "AdvertRegion", AdvertRegion },
                { "CurrentPage", CurrentPage.ToString() },
                { "AdvertsPerPage", AdvertsPerPage.ToString() },
                { "SortType", SortType.ToString() }
            };
            return dict;
        }

        public UserInfo UserInfo { get; set; }
    }
}