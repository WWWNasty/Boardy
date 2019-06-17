using System.Threading.Tasks;
using BusinessLogicLayer.Objects.Dtos.Likes;

namespace BusinessLogicLayer.Abstraction.Interfaces
{
    public interface ILikeService
    {
        /// <summary>
        /// Асинхронно добавляет лайк к объявлению от лица определённого пользователя.
        /// </summary>
        /// <param name="dto">DTO с полями Id пользователя и Id объявления.</param>
        /// <returns>Объект Task, который представляет собой асинхронную операцию добавления лайка в БД.</returns>
        Task AddAsync(CreateLikeDto dto);

        /// <summary>
        /// Асинхронно удаляет лайк объявления.
        /// </summary>
        /// <param name="dto">DTO с полями Id пользователя.</param>
        /// <returns>Объект Task, который представляет собой асинхронную операцию удаления лайка из БД.</returns>
        Task DeleteAsync(DeleteLikeDto dto);
    }
}