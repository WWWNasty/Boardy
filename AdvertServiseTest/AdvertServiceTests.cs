using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.Objects.Dtos.Adverts;
using BusinessLogicLayer.Objects.Dtos.Adverts.Search;
using DataAccessLayer.Models.Entities;
using DataAccessLayer.Models.MapperProfiles;
using Xunit;
using Moq;
using DataAccessLayer.Abstraction;
using BusinessLogicLayer.Tests.Comparator;
using BusinessLogicLayer.Implementation.Services;
using BusinessLogicLayer.Abstraction.Interfaces;
using BusinessLogicLayer.Objects.Dtos;
using BusinessLogicLayer.Implementation.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogicLayer.Tests
{
    public class AdvertServiceTests
    {
        private readonly IMapper _mapper;

        public AdvertServiceTests()
        {
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()));
        }

        [Fact]
        public async Task GetAll_ReturnsEveryAdvert()
        {
            //Arrange 
            Mock<IUnitOfWork> UOWMock = new Mock<IUnitOfWork>();
            UOWMock.Setup(uow => uow.AdvertRepository.GetAllAsync(It.IsAny<SearchQuery>()))
            .ReturnsAsync(new List<Advert> {
                new Advert {Id = 0, CreatedDate = default},
                new Advert {Id = 1, CreatedDate = default},
                new Advert {Id = 2, CreatedDate = default}
            });
            UOWMock.Setup(uow => uow.AdvertRepository.GetAdvertsAmountAsync(It.IsAny<SearchQuery>()))
                .ReturnsAsync(() => 3);

            IAdvertService advertService = new AdvertService(_mapper, UOWMock.Object);

            SearchAnswer expectedResult = new SearchAnswer
            {
                Adverts = new List<AdvertDto>
                {
                    new AdvertDto {Id = 0, CreatedDate = default, AdvertImages = new ImageDto[0]},
                    new AdvertDto {Id = 1, CreatedDate = default, AdvertImages = new ImageDto[0]},
                    new AdvertDto {Id = 2, CreatedDate = default, AdvertImages = new ImageDto[0]}
                },
                AdvertsAmount = 3
            };

            //Act
            SearchAnswer actualResult = await advertService.GetAllAsync(new SearchQuery());

            //Assert
            Assert.Equal(expectedResult, actualResult, new JsonSerializedComparer<SearchAnswer>());
        }
        [Fact]
        public async Task GetAsync_GetExistingAdvert()
        {
            Mock<IUnitOfWork> UOWMock = new Mock<IUnitOfWork>();
            UOWMock.Setup(uow => uow.AdvertRepository.GetAsync(1))
                .ReturnsAsync(new Advert
                {
                    Id = 1,
                    CreatedDate = default
                });

            IAdvertService advertService = new AdvertService(_mapper, UOWMock.Object);

            AdvertDto expected = new AdvertDto
            {
                Id = 1,
                AdvertImages = new ImageDto[0],
                CreatedDate = default
            };

            AdvertDto actual = await advertService.GetAsync(1);

            Assert.Equal(actual, expected, new JsonSerializedComparer<AdvertDto>());
        }

        [Fact]
        public async Task GetAsync_GetNonExistentAdvert()
        {
            Mock<IUnitOfWork> UOWMock = new Mock<IUnitOfWork>();
            UOWMock.Setup(uow => uow.AdvertRepository.GetAsync(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            IAdvertService advertService = new AdvertService(_mapper, UOWMock.Object);

            await Assert.ThrowsAsync<AdvertNotFoundException>(async () =>
                await advertService.GetAsync(1)
            );
        }

        [Fact]
        public async Task AddAsync_AddValidAdvert()
        {
            Mock<IUnitOfWork> UOWMock = new Mock<IUnitOfWork>();
            UOWMock.Setup(uow => uow.AdvertRepository.Create(It.IsAny<Advert>()));

            IAdvertService advertService = new AdvertService(_mapper, UOWMock.Object);

            await advertService.AddAsync(new CreateAdvertDto
            {
                Name = "Объявление",
                Description = "Описание",
                Phone = "+12345678912",
                Price = 999,
                Address = new AddressDto
                {
                    Region = "Регион",
                    City = "Город",
                    Street = "Улица",
                    HouseNumber = "дом 777"
                },
                AdvertImages = new ImageDto[0],
                SubCategoryId = -1,
                UserId = "user_1"
            });
        }

        [Fact]
        public async Task AddAsync_AddNotValidAdvert()
        {
            Mock<IUnitOfWork> UOWMock = new Mock<IUnitOfWork>();

            IAdvertService advertService = new AdvertService(_mapper, UOWMock.Object);

            await Assert.ThrowsAsync<ValidationException>(async () =>
                await advertService.AddAsync(new CreateAdvertDto
                {
                    Name = null, //Не валидно
                    Description = "Описание",
                    Phone = "110101",
                    Price = 999,
                    Address = new AddressDto
                    {
                        Region = "Регион",
                        City = "Город",
                        Street = "Улица",
                        HouseNumber = "дом 777"
                    },
                    AdvertImages = new ImageDto[0],
                    SubCategoryId = -1,
                    UserId = "user_1"
                })
                );
        }

        [Fact]
        public async Task DeleteAsync_DeleteOwnAdvert()
        {
            Mock<IUnitOfWork> UOWMock = new Mock<IUnitOfWork>();
            UOWMock.Setup(uow => uow.AdvertRepository.GetAsync(1))
                 .ReturnsAsync(new Advert
                 {
                     Id = 1,
                     UserId = "user_1"
                 });
            UOWMock.Setup(uow => uow.AdvertRepository.Delete(It.IsAny<Advert>()));
            IAdvertService advertService = new AdvertService(_mapper, UOWMock.Object);

            await advertService.DeleteAsync(new DeleteAdvertDto
            {
                Id = 1,
                UserId = "user_1"
            });
        }

        [Fact]
        public async Task DeleteAsync_DeleteForeignAdvert_NotAdmin()
        {
            Mock<IUnitOfWork> UOWMock = new Mock<IUnitOfWork>();
            UOWMock.Setup(uow => uow.AdvertRepository.GetAsync(1))
                 .ReturnsAsync(new Advert
                 {
                     Id = 1,
                     UserId = "user_1"
                 });
            UOWMock.Setup(uow => uow.AdvertRepository.Delete(It.IsAny<int>()));
            IAdvertService advertService = new AdvertService(_mapper, UOWMock.Object);

            await Assert.ThrowsAsync<NotPermittedException>(async () =>
                await advertService.DeleteAsync(new DeleteAdvertDto
                {
                    Id = 1,
                    UserId = "user_2"
                })
            );
        }

        [Fact]
        public async Task DeleteAsync_DeleteForeignComment_Admin()
        {
            Mock<IUnitOfWork> UOWMock = new Mock<IUnitOfWork>();
            UOWMock.Setup(uow => uow.AdvertRepository.GetAsync(1))
                 .ReturnsAsync(new Advert
                 {
                     Id = 1,
                     UserId = "user_1"
                 });
            UOWMock.Setup(uow => uow.AdvertRepository.Delete(It.IsAny<int>()));
            IAdvertService advertService = new AdvertService(_mapper, UOWMock.Object);

            await advertService.DeleteAsync(new DeleteAdvertDto
            {
                Id = 1,
                UserId = "admin" //Не совпадает с UserId = "user_1"
            }, isAdmin: true); //Но удаляется от лица администратора
        }

        [Fact]
        public async Task DeleteAsync_DeleteNonExistentAdvert()
        {
            Mock<IUnitOfWork> UOWMock = new Mock<IUnitOfWork>();
            UOWMock.Setup(uow => uow.AdvertRepository.GetAsync(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            IAdvertService advertService = new AdvertService(_mapper, UOWMock.Object);

            await Assert.ThrowsAsync<AdvertNotFoundException>(async () =>
                await advertService.DeleteAsync(new DeleteAdvertDto
                {
                    Id = 1,
                    UserId = "user_1"
                })
            );
        }

        [Fact]
        public async Task UpdateAsync_UpdateOwnValidAdvert()
        {
            Mock<IUnitOfWork> UOWMock = new Mock<IUnitOfWork>();
            UOWMock.Setup(uow => uow.AdvertRepository.GetAsync(1))
                .ReturnsAsync(new Advert
                {
                    Id = 1,
                    UserId = "user_1"
                });
            UOWMock.Setup(uow => uow.AdvertRepository.Update(It.IsAny<Advert>()));
            IAdvertService advertService = new AdvertService(_mapper, UOWMock.Object);

            await advertService.UpdateAsync(new UpdateAdvertDto
            {
                Id = 1,
                Name = "Объявление",
                Description = "Описание",
                Phone = "+12345678912",
                Price = 999,
                Address = new AddressDto
                {
                    Region = "Регион",
                    City = "Город",
                    Street = "Улица",
                    HouseNumber = "дом 777"
                },
                AdvertImages = new ImageDto[0],
                SubCategoryId = -1,
                UserId = "user_1"
            });
        }

        [Fact]
        public async Task UpdateAsync_UpdateNotValidAdvert()
        {
            Mock<IUnitOfWork> UOWMock = new Mock<IUnitOfWork>();
            UOWMock.Setup(uow => uow.AdvertRepository.GetAsync(1))
                .ReturnsAsync(new Advert
                {
                    Id = 1,
                    UserId = "user_1"
                });
            UOWMock.Setup(uow => uow.AdvertRepository.Update(It.IsAny<Advert>()));
            IAdvertService advertService = new AdvertService(_mapper, UOWMock.Object);

            await Assert.ThrowsAsync<ValidationException>(async () =>
                await advertService.UpdateAsync(new UpdateAdvertDto
                {
                    Id = 1,
                    Name = null,
                    Description = "Описание",
                    Phone = "+12345678912",
                    Price = 999,
                    Address = new AddressDto
                    {
                        Region = "Регион",
                        City = "Город",
                        Street = "Улица",
                        HouseNumber = "дом 777"
                    },
                    AdvertImages = new ImageDto[0],
                    SubCategoryId = -1,
                    UserId = "user_1"
                })
            );
        }

        [Fact]
        public async Task UpdateAsync_UpdateForeignAdvert_NotAdmin()
        {
            Mock<IUnitOfWork> UOWMock = new Mock<IUnitOfWork>();
            UOWMock.Setup(uow => uow.AdvertRepository.GetAsync(1))
                .ReturnsAsync(new Advert
                {
                    Id = 1,
                    UserId = "user_1"
                });
            UOWMock.Setup(uow => uow.AdvertRepository.Update(It.IsAny<Advert>()));
            IAdvertService advertService = new AdvertService(_mapper, UOWMock.Object);

            await Assert.ThrowsAsync<NotPermittedException>(async () =>
                await advertService.UpdateAsync(new UpdateAdvertDto
                {
                    Id = 1,
                    Name = "Название",
                    Description = "Описание",
                    Phone = "+12345678912",
                    Price = 999,
                    Address = new AddressDto
                    {
                        Region = "Регион",
                        City = "Город",
                        Street = "Улица",
                        HouseNumber = "дом 777"
                    },
                    AdvertImages = new ImageDto[0],
                    SubCategoryId = -1,
                    UserId = "user_2" //Не сходится с UserId = "user_1"
                })
            );
        }

        [Fact]
        public async Task UpdateAsync_UpdateForeignAdvert_Admin()
        {
            Mock<IUnitOfWork> UOWMock = new Mock<IUnitOfWork>();
            UOWMock.Setup(uow => uow.AdvertRepository.GetAsync(1))
                .ReturnsAsync(new Advert
                {
                    Id = 1,
                    UserId = "user_1"
                });
            UOWMock.Setup(uow => uow.AdvertRepository.Update(It.IsAny<Advert>()));
            IAdvertService advertService = new AdvertService(_mapper, UOWMock.Object);

            await advertService.UpdateAsync(new UpdateAdvertDto
            {
                Id = 1,
                Name = "Название",
                Description = "Описание",
                Phone = "+12345678912",
                Price = 999,
                Address = new AddressDto
                {
                    Region = "Регион",
                    City = "Город",
                    Street = "Улица",
                    HouseNumber = "дом 777"
                },
                AdvertImages = new ImageDto[0],
                SubCategoryId = -1,
                UserId = "admin"
            }, isAdmin: true);
        }
    }
}