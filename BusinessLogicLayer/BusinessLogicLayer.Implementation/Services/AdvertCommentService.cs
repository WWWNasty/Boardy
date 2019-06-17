using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.Abstraction.Interfaces;
using BusinessLogicLayer.Implementation.Exceptions;
using BusinessLogicLayer.Objects.Dtos.Comments;
using DataAccessLayer.Abstraction;
using DataAccessLayer.Models.Entities;

namespace BusinessLogicLayer.Implementation.Services
{
    public class AdvertCommentService: IAdvertCommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
       
        public AdvertCommentService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddAsync(CreateCommentDto dto)
        {
            Advert advert = await _unitOfWork.AdvertRepository.GetAsync(dto.AdvertId);

            ThrowIfNotFound(advert);

            var comment = _mapper.Map<AdvertComment>(dto);
            comment.Advert = advert;
            _unitOfWork.AdvertCommentRepository.Create(comment);

            await _unitOfWork.SaveChangesAsync();
        }
        
        public async Task DeleteAsync(DeleteCommentDto dto, bool isAdmin = false)
        {
            AdvertComment comment = await _unitOfWork.AdvertCommentRepository.GetAsync(dto.Id);

            ThrowIfNotFound(comment);

            if (!isAdmin && comment.UserId != dto.UserId)
            {
                throw new NotPermittedException("Нельзя удалять чужие комментарии");
            }

            _unitOfWork.AdvertCommentRepository.Delete(comment);

            _unitOfWork.SaveChanges();
        }


        private static void ThrowIfNotFound(AdvertComment comment)
        {
            if (comment == null)
            {
                throw new CommentNotFoundException("Комментарий не найден");
            }
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
