using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataAccessLayer.Models.Entities.Base;

namespace DataAccessLayer.Models.Entities
{
    public class Address : Entity<int>
    {
        [Required]
        public string Region { get; set; }

        [Required]
        public string City { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public ICollection<Advert> Advert { get; set; }

    }
}