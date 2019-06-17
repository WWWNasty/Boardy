using BusinessLogicLayer.Objects.Dtos.Base;

namespace BusinessLogicLayer.Objects.Dtos.Adverts
{
    public class DeleteAdvertDto : EntityDto<int>
    {
        public string UserId { get; set; }
    }
}