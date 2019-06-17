using AutoMapper;
using BusinessLogicLayer.Objects.Dtos.Adverts;

namespace PresentationLayer.WebApplication
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<AdvertDto, UpdateAdvertDto>();
        }
    }
}