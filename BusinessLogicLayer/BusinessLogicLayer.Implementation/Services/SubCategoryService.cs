using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.Implementation.Services.Base;
using BusinessLogicLayer.Objects.Dtos;
using DataAccessLayer.Abstraction;
using DataAccessLayer.Models.Entities;

namespace BusinessLogicLayer.Implementation.Services
{
    public class SubCategoryService : BaseService, ISubCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ICollection<SubCategoryDto>> GetSubCategoriesAsync()
        {
            ICollection<SubCategory> subCategories = await _unitOfWork.SubCategoryRepository.GetAllAsync();

            var subCategoriesDto = _mapper.Map<ICollection<SubCategoryDto>>(subCategories);

            return subCategoriesDto;
        }
    }
}
