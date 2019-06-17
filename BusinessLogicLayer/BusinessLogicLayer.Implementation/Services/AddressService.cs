using System;
using System.Collections.Generic;
using AutoMapper;
using BusinessLogicLayer.Abstraction.Interfaces;
using BusinessLogicLayer.Implementation.Services.Base;
using BusinessLogicLayer.Objects.Dtos;
using DataAccessLayer.Abstraction;
using DataAccessLayer.Abstraction.RepositoryInterfaces;
using DataAccessLayer.Models.Entities;

namespace BusinessLogicLayer.Implementation.Services
{
    public class AddressService : BaseService, IAddressService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AddressService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        
        // валидация данных которые пришли от клиента
        //(опциональный) маппинг этих данных 
        //логика 


    }
}
