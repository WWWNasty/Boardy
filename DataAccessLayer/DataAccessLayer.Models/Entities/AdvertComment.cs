using System;
using DataAccessLayer.Models.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models.Entities
{
    public class AdvertComment : Entity<int>
    {
        [MaxLength(200)]
        [Required]
        public string Text { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        [Required]
        public Advert Advert { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}