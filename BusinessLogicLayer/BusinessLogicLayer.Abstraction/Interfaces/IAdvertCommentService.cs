using System.Threading.Tasks;
using BusinessLogicLayer.Objects.Dtos.Comments;

namespace BusinessLogicLayer.Abstraction.Interfaces
{
    public interface IAdvertCommentService
    {
        /// <summary>
        /// Асинхронно добавляет комментарий объявлению.
        /// </summary>
        /// <param name="dto">DTO, содержащее в том числе текст комментария, Id объявления, Id пользователя.</param>
        /// <returns>Объект Task, который представляет собой асинхронную операцию добавления комментария в БД.</returns>
        Task AddAsync(CreateCommentDto dto);
        
        /// <summary>
        /// Асинхронно удаляет комментарий объявления.
        /// </summary>
        /// <param name="dto">DTO, содержащее Id пользователя и Id объявления.</param>
        /// <param name="isAdmin">Признак того, что объявление удаляется пользователем с ролью "Администратор".</param>
        /// <returns>Объект Task, который представляет собой асинхронную операцию удаления комментария из БД.</returns>
        Task DeleteAsync(DeleteCommentDto dto, bool isAdmin = false);
    }
}