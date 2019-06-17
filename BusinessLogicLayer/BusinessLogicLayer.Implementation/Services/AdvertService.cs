using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.Abstraction.Interfaces;
using BusinessLogicLayer.Implementation.Exceptions;
using BusinessLogicLayer.Implementation.Services.Base;
using BusinessLogicLayer.Objects.Dtos.Adverts;
using BusinessLogicLayer.Objects.Dtos.Adverts.Search;
using DataAccessLayer.Abstraction;
using DataAccessLayer.Models.Entities;

namespace BusinessLogicLayer.Implementation.Services
{
    public class AdvertService : BaseService, IAdvertService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AdvertService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AdvertDto> GetAsync(int id)
        {
            Advert advert = await _unitOfWork.AdvertRepository.GetAsync(id);

            ThrowIfNotFound(advert);

            return _mapper.Map<AdvertDto>(advert);
        }

        public async Task<int> AddAsync(CreateAdvertDto dto)
        {
            Validate(dto);

            var advert = _mapper.Map<Advert>(dto);

            _unitOfWork.AdvertRepository.Create(advert);

            await _unitOfWork.SaveChangesAsync();

            return advert.Id;
        }

        public async Task DeleteAsync(DeleteAdvertDto dto, bool isAdmin = false)
        {
            var advert = await _unitOfWork.AdvertRepository.GetAsync(dto.Id);

            ThrowIfNotFound(advert);

            if (!isAdmin && advert.UserId != dto.UserId)
            {
                throw new NotPermittedException("Нельзя удалять чужие обьявления");
            }

            _unitOfWork.AdvertRepository.Delete(advert);

            _unitOfWork.SaveChanges();
        }

        public async Task UpdateAsync(UpdateAdvertDto dto, bool isAdmin = false)
        {
            Validate(dto);
            
            var advert = await _unitOfWork.AdvertRepository.GetAsync(dto.Id);

            ThrowIfNotFound(advert);

            if (!isAdmin && advert.UserId != dto.UserId)
            {
                throw new NotPermittedException("Нельзя редактировать чужие обьявления");
            }

            _mapper.Map(dto, advert);
            
            _unitOfWork.AdvertRepository.Update(advert);

            await _unitOfWork.SaveChangesAsync();
        }


        public async Task<SearchAnswer> GetAllAsync(SearchQuery searchQuery)
        {
            ICollection<Advert> adverts = await _unitOfWork.AdvertRepository.GetAllAsync(searchQuery);
            int advertsAmount = await _unitOfWork.AdvertRepository.GetAdvertsAmountAsync(searchQuery);
            var mappedAdverts = _mapper.Map<List<AdvertDto>>(adverts);
            SearchAnswer result = new SearchAnswer
            {
                Adverts = mappedAdverts,
                AdvertsAmount = advertsAmount
            };
            return result;
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