using System.ComponentModel.DataAnnotations;
using DataAccessLayer.Models.Entities.Base;

namespace DataAccessLayer.Models.Entities
{
    public class Image : Entity<int>
    {
        [Required]
        public string Base64 { get; set; } = string.Empty;

        [Required]
        public Advert Advert { get; set; }
    }
}