using Xunit;
using Moq;
using DataAccessLayer.Abstraction;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Models.MapperProfiles;
using DataAccessLayer.Models.Entities;
using System.Collections.Generic;
using BusinessLogicLayer.Implementation.Services;
using BusinessLogicLayer.Abstraction.Interfaces;
using BusinessLogicLayer.Objects.Dtos.Likes;
using BusinessLogicLayer.Implementation.Exceptions;

namespace BusinessLogicLayer.Tests
{
    public class LikeServiceTests
    {
        private readonly IMapper _mapper;

        public LikeServiceTests()
        {
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()));
        }

        [Fact]
        public async Task AddAsync_AddLikeToExistingAdvert()
        {
            Mock<IUnitOfWork> UOWMock = new Mock<IUnitOfWork>();
            UOWMock.Setup(uow => uow.AdvertRepository.GetAsync(1))
                .ReturnsAsync(new Advert
                {
                    Likes = new List<Like>()
                });
            UOWMock.Setup(uow => uow.LikeRepository.Create(It.IsAny<Like>()));

            ILikeService likeService = new LikeService(_mapper, UOWMock.Object);

            await likeService.AddAsync(new CreateLikeDto
            {
                AdvertId = 1,
                UserId = "user_1"
            });
        }

        [Fact]
        public async Task AddAsync_AddLikeToNonExistentAdvert()
        {
            Mock<IUnitOfWork> UOWMock = new Mock<IUnitOfWork>();
            UOWMock.Setup(uow => uow.AdvertRepository.GetAsync(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            ILikeService likeService = new LikeService(_mapper, UOWMock.Object);

            await Assert.ThrowsAsync<AdvertNotFoundException>(async () =>
            await likeService.AddAsync(new CreateLikeDto
            {
                AdvertId = 1,
                UserId = "user_1"
            }
            ));
        }

        [Fact]
        public async Task AddAsync_AddLikeToAlreadyLikedAdvert()
        {
            Mock<IUnitOfWork> UOWMock = new Mock<IUnitOfWork>();
            UOWMock.Setup(uow => uow.AdvertRepository.GetAsync(It.IsAny<int>()))
                .ReturnsAsync(new Advert
                {
                    Likes = new List<Like>
                    {
                        new Like
                        {
                            UserId = "user_1",
                        }
                    }
                });
            UOWMock.Setup(uow => uow.LikeRepository.Create(It.IsAny<Like>()));

            ILikeService likeService = new LikeService(_mapper, UOWMock.Object);
            await likeService.AddAsync(new CreateLikeDto
            {
                AdvertId = 1,
                UserId = "user_1"
            });

            UOWMock.Verify(uow => uow.LikeRepository.Create(It.IsAny<Like>()), Times.Never);
        }

        [Fact]
        public async Task DeleteAsync_DeleteExistingLike()
        {
            Mock<IUnitOfWork> UOWMock = new Mock<IUnitOfWork>();
            UOWMock.Setup(uow => uow.LikeRepository.GetAsync(It.IsAny<int>()))
                .ReturnsAsync(new Like { });
            UOWMock.Setup(uow => uow.LikeRepository.Delete(It.IsAny<Like>()));

            ILikeService likeService = new LikeService(_mapper, UOWMock.Object);

            await likeService.DeleteAsync(new DeleteLikeDto { });
        }

        [Fact]
        public async Task DeleteAsync_DeleteNonExistentLike()
        {
            Mock<IUnitOfWork> UOWMock = new Mock<IUnitOfWork>();
            UOWMock.Setup(uow => uow.LikeRepository.GetAsync(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            UOWMock.Setup(uow => uow.LikeRepository.Delete(It.IsAny<Like>()));

            ILikeService likeService = new LikeService(_mapper, UOWMock.Object);

            await likeService.DeleteAsync(new DeleteLikeDto { });

            UOWMock.Verify(uow => uow.LikeRepository.Delete(It.IsAny<int>()), Times.Never);
        }
    }
}