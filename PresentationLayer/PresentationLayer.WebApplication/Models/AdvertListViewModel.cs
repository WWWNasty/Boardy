using System.Collections.Generic;
using BusinessLogicLayer.Objects.Dtos.Adverts;
using BusinessLogicLayer.Objects.Dtos.Adverts.Search;

namespace PresentationLayer.WebApplication.Models
{
    public class AdvertListViewModel
    {
        public ICollection<AdvertDto> Adverts;

        public SearchQuery Query { get; set; }

        public int AllAdvertsAmount { get; set; }
    }
}
