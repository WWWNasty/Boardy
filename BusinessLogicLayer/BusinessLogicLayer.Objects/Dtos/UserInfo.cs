using BusinessLogicLayer.Objects.Enums;

namespace BusinessLogicLayer.Objects.Dtos
{
    public class UserInfo
    {
        public string Id { get; set; }
        public AdvertsType AdvertsType { get; set; } = AdvertsType.Own;
    }
}