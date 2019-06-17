using BusinessLogicLayer.Objects.Dtos.Base;

namespace BusinessLogicLayer.Objects.Dtos.Likes
{
   public class DeleteLikeDto : EntityDto<int>
    {
       public string UserId { get; set; }
    }
}
