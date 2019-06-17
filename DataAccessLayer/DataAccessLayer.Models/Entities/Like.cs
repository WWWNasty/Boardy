using System;
using System.ComponentModel.DataAnnotations;
using DataAccessLayer.Models.Entities.Base;

namespace DataAccessLayer.Models.Entities
{
    public class Like : Entity<int>
    {
        [Required]
        public string UserId { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        
        [Required]
        public Advert Advert { get; set; }
    }
}