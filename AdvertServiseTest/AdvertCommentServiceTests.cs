using System.Threading.Tasks;
using Xunit;
using Moq;
using BusinessLogicLayer.Abstraction.Interfaces;
using BusinessLogicLayer.Implementation.Services;
using DataAccessLayer.Models.Entities;
using DataAccessLayer.Abstraction;
using AutoMapper;
using BusinessLogicLayer.Objects.Dtos.Comments;
using DataAccessLayer.Models.MapperProfiles;
using BusinessLogicLayer.Implementation.Exceptions;

namespace BusinessLogicLayer.Tests
{
    public class AdvertCommentServiceTests
    {
        private readonly IMapper _mapper;

        public AdvertCommentServiceTests()
        {
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()));
        }

        [Fact]
        public async Task AddAsync_AddCommentToExistingAdvert()
        {
            //Создание Mock-объекта UnitOfWork
            Mock<IUnitOfWork> UOWMock = new Mock<IUnitOfWork>();
            //Настройка Mock объекта на вызов определённых методов
            //и возврат определённых значений из них
            UOWMock.Setup(uow => uow.AdvertRepository.GetAsync(1))
                .ReturnsAsync(new Advert { Id = 1 });
            UOWMock.Setup(uow => uow.AdvertCommentRepository.Create(It.Is<AdvertComment>(ac => ac.Advert.Id == 1)));

            IAdvertCommentService testingCommentService = new AdvertCommentService(_mapper, UOWMock.Object);

            await testingCommentService.AddAsync(new CreateCommentDto
            {
                AdvertId = 1,
                Text = "Текст",
                UserId = "user_1",
                UserName = "Neo"
            });
        }

        [Fact]
        public async Task AddAsync_AddCommentToNonexistentAdvert()
        {
            Mock<IUnitOfWork> UOWMock = new Mock<IUnitOfWork>();
            UOWMock.Setup(uow => uow.AdvertRepository.GetAsync(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            IAdvertCommentService testingCommentService = new AdvertCommentService(_mapper, UOWMock.Object);

            await Assert.ThrowsAsync<AdvertNotFoundException>(async () =>
                await testingCommentService.AddAsync(new CreateCommentDto
                {
                    AdvertId = 2,
                    Text = "Текст",
                    UserId = "user_1",
                    UserName = "Neo"
                })
            );
        }

        [Fact]
        public async Task DeleteAsync_DeleteOwnComment()
        {
            Mock<IUnitOfWork> UOWMock = new Mock<IUnitOfWork>();
            UOWMock.Setup(uow => uow.AdvertCommentRepository.GetAsync(1))
                 .ReturnsAsync(new AdvertComment
                 {
                     Id = 1,
                     UserId = "user_1"
                 });
            UOWMock.Setup(uow => uow.AdvertCommentRepository.Delete(It.IsAny<AdvertComment>()));
            IAdvertCommentService commentService = new AdvertCommentService(_mapper, UOWMock.Object);

            await commentService.DeleteAsync(new DeleteCommentDto
            {
                Id = 1,
                AdvertId = 1,
                UserId = "user_1"
            });
        }

        [Fact]
        public async Task DeleteAsync_DeleteForeignComment_NotAdmin()
        {
            Mock<IUnitOfWork> UOWMock = new Mock<IUnitOfWork>();
            UOWMock.Setup(uow => uow.AdvertCommentRepository.GetAsync(1))
                 .ReturnsAsync(new AdvertComment
                 {
                     Id = 1,
                     UserId = "user_1"
                 });
            UOWMock.Setup(uow => uow.AdvertCommentRepository.Delete(It.IsAny<int>()));
            IAdvertCommentService commentService = new AdvertCommentService(_mapper, UOWMock.Object);

            await Assert.ThrowsAsync<NotPermittedException>(async () =>
                await commentService.DeleteAsync(new DeleteCommentDto
                {
                    Id = 1,
                    AdvertId = 1,
                    UserId = "user_2"
                })
            );
        }

        [Fact]
        public async Task DeleteAsync_DeleteForeignComment_Admin()
        {
            Mock<IUnitOfWork> UOWMock = new Mock<IUnitOfWork>();
            UOWMock.Setup(uow => uow.AdvertCommentRepository.GetAsync(1))
                 .ReturnsAsync(new AdvertComment
                 {
                     Id = 1,
                     UserId = "user_1"
                 });
            UOWMock.Setup(uow => uow.AdvertCommentRepository.Delete(It.IsAny<int>()));
            IAdvertCommentService commentService = new AdvertCommentService(_mapper, UOWMock.Object);

            await commentService.DeleteAsync(new DeleteCommentDto
                {
                    Id = 1,
                    AdvertId = 1,
                    UserId = "admin"
                }, isAdmin: true);
        }

        [Fact]
        public async Task DeleteAsync_DeleteNonExistentComment()
        {
            Mock<IUnitOfWork> UOWMock = new Mock<IUnitOfWork>();
            UOWMock.Setup(uow => uow.AdvertCommentRepository.GetAsync(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            UOWMock.Setup(uow => uow.AdvertCommentRepository.Delete(It.IsAny<int>()));
            IAdvertCommentService commentService = new AdvertCommentService(_mapper, UOWMock.Object);

            await Assert.ThrowsAsync<CommentNotFoundException>(async () =>
                await commentService.DeleteAsync(new DeleteCommentDto
                {
                    Id = 1,
                    AdvertId = 1,
                    UserId = "user_1"
                })
            );
        }
    }
}
