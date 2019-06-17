using System.ComponentModel.DataAnnotations;
using BusinessLogicLayer.Objects.Dtos.Base;

namespace BusinessLogicLayer.Objects.Dtos.Likes
{
   public class CreateLikeDto
    {
        [Required]
        public string UserId { get; set; }
        
        [Required]
        public int AdvertId { get; set; }
    }
}
