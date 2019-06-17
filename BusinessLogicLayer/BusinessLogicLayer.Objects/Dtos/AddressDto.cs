using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using BusinessLogicLayer.Objects.Dtos.Base;

namespace BusinessLogicLayer.Objects.Dtos
{
    public class AddressDto : EntityDto<int>
    {

        [Required(ErrorMessage = "Поле \"Региорн\" является обязательным!")]
        public string Region { get; set; }

        [Required(ErrorMessage = "Поле \"Город\" является обязательным!")]
        public string City { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

    }
}
