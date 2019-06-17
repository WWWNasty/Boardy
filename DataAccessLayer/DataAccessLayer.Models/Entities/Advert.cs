using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataAccessLayer.Models.Entities.Base;

namespace DataAccessLayer.Models.Entities
{
    public class Advert : Entity<int>
    {
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public uint Price { get; set; }

        [Required]
        public Address Address { get; set; }

        public string UserId { get; set; }

        [Required]
        public int? SubCategoryId { get; set; }

        public SubCategory SubCategory { get; set; }

        [MaxLength(500)]
        [Required]
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public ICollection<AdvertComment> AdvertComments { get; set; } = new List<AdvertComment>();

        public ICollection<Like> Likes { get; set; } = new List<Like>();

        public ICollection<Image> AdvertImages { get; set; } = new List<Image>();
    }
}