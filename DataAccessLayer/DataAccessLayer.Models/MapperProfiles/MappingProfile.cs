using AutoMapper;
using BusinessLogicLayer.Objects.Dtos;
using BusinessLogicLayer.Objects.Dtos.Adverts;
using BusinessLogicLayer.Objects.Dtos.Comments;
using BusinessLogicLayer.Objects.Dtos.Likes;
using DataAccessLayer.Models.Entities;

namespace DataAccessLayer.Models.MapperProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {//когда данные приходят от пользователя
         //   CreateMap<AdvertDto, Advert>()
         //       .ForMember(advert => advert.SubCategory, opt => opt.Ignore())
         //       .ForMember(advert => advert.SubCategoryId, opt => opt.MapFrom(dto => dto.SubCategory.Id))
         //       .ForMember(advert => advert.Id, opt => opt.Ignore())
         //       .ForMember(advert => advert.AdvertComments, opt => opt.Ignore())
         //       .ForMember(advert => advert.CreatedDate, opt => opt.Ignore())
         //       .ForMember(advert => advert.Likes, opt => opt.Ignore());
         ////когда отправляются данные пользователю
        
            CreateMap<Advert, AdvertDto>();

            CreateMap<ImageDto, Image>().ReverseMap();

            CreateMap<CreateAdvertDto, Advert>();

            CreateMap<UpdateAdvertDto, Advert>();

            CreateMap<AdvertComment, AdvertCommentDto>()
                .ReverseMap();

            CreateMap<CreateCommentDto, AdvertComment>().ReverseMap();

            CreateMap<DeleteCommentDto, AdvertComment>().ReverseMap();
            
            CreateMap<Address, AddressDto>()
                .ReverseMap()
                .ForMember(address => address.Id, opt => opt.Ignore());


            CreateMap<Image, ImageDto>().ReverseMap();

            CreateMap<SubCategory, SubCategoryDto>().ReverseMap();

            CreateMap<Like, LikeDto>().ReverseMap();

            CreateMap<CreateLikeDto, Like>().ReverseMap();

            CreateMap<DeleteLikeDto, Like>().ReverseMap();

        }
    }
}