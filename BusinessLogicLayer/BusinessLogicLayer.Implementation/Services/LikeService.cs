using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.Abstraction.Interfaces;
using BusinessLogicLayer.Objects.Dtos.Likes;
using DataAccessLayer.Abstraction;
using DataAccessLayer.Models.Entities;
using BusinessLogicLayer.Implementation.Exceptions;

namespace BusinessLogicLayer.Implementation.Services
{
    public class LikeService : ILikeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
      
        public LikeService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(CreateLikeDto dto)
        {
            Advert advert = await _unitOfWork.AdvertRepository.GetAsync(dto.AdvertId);

            ThrowIfNotFound(advert);
            Like like = advert.Likes.FirstOrDefault(advertLike => advertLike.UserId == dto.UserId);

            if (like != null)
               return;

            var newLike = _mapper.Map<Like>(dto);
            newLike.Advert = advert;
            _unitOfWork.LikeRepository.Create(newLike);
            await _unitOfWork.SaveChangesAsync();
            
        }

        public async Task DeleteAsync(DeleteLikeDto dto)
        {
            Like like = await _unitOfWork.LikeRepository.GetAsync(dto.Id);

            if (like == null)
            {
                return;
            }
            _unitOfWork.LikeRepository.Delete(like);
            await _unitOfWork.SaveChangesAsync();
        }

        private static void ThrowIfNotFound(Advert advert)
        {
            if (advert == null)
            {
                throw new AdvertNotFoundException("Объявление не найдено");
            }
        }
    }
}
