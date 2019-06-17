using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataAccessLayer.Models.Entities.Base;

namespace DataAccessLayer.Models.Entities
{
    public class SubCategory : Entity<int>
    {
        [Required]
        public string Name { get; set; }

        public int? ParentId { get; set; }

        public SubCategory Parent { get; set; }

        public ICollection<SubCategory> Children { get; set; }
        
        public ICollection<Advert> Adverts { get; set; } = new List<Advert>();
    }
}