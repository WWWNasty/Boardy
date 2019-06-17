using System.Collections.Generic;

namespace BusinessLogicLayer.Objects.Dtos.Adverts.Search
{
    public class SearchAnswer
    {
        public ICollection<AdvertDto> Adverts { get; set; }
        public int AdvertsAmount { get; set; }
    }
}
