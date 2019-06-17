using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BusinessLogicLayer.Objects.Dtos.Base;
using BusinessLogicLayer.Objects.Dtos.Comments;
using BusinessLogicLayer.Objects.Dtos.Likes;

namespace BusinessLogicLayer.Objects.Dtos.Adverts
{
    public class AdvertDto: EntityDto<int>
    {
        public const int MaxImagesCount = 5;

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

       
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Список комментариев к объявлению
        /// </summary>
        public ICollection<AdvertCommentDto> AdvertComments { get; set; } = new List<AdvertCommentDto>();

        
        [Required]
        public uint Price { get; set; }

        [Required]
        public AddressDto Address { get; set; }

        public string UserId { get; set; }

        [Required]
        public SubCategoryDto SubCategory { get; set; }

        public ICollection<LikeDto> Likes{ get; set; } = new List<LikeDto>();

        [MaxLength(MaxImagesCount)]
        public ImageDto[] AdvertImages { get; set; } = new ImageDto[MaxImagesCount];
    }
}