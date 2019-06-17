using System;
using System.ComponentModel.DataAnnotations;
using BusinessLogicLayer.Objects.Dtos.Base;

namespace BusinessLogicLayer.Objects.Dtos.Likes
{
    public class LikeDto : EntityDto<int>
    {
        public string UserId { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public int AdvertId { get; set; }
    }
}
