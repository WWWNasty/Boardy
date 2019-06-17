using System.Threading.Tasks;
using BusinessLogicLayer.Objects.Dtos.Adverts;
using BusinessLogicLayer.Objects.Dtos.Adverts.Search;

namespace BusinessLogicLayer.Abstraction.Interfaces
{
    public interface IAdvertService
    {
        /// <summary>
        /// Асинхронно получает объявления из БД.
        /// </summary>
        ///<remarks>Список объявлений возвращается постранично. Параметры страницы указаны в параметре <paramref name="searchQuery"/></remarks>
        /// <param name="searchQuery">Объект с полями, содержащими параметры фильтрации, сортировки, характеристики пользователя и параметры пагинации.</param>
        /// <returns>Объект с полями, в которых содержатся выбранные объявления и количество всех доступных объявлений в БД.</returns>
        Task<SearchAnswer> GetAllAsync(SearchQuery searchQuery);

       /// <summary>
       /// Асинхронно получает определённое объявление из БД по его Id.
       /// </summary>
       /// <param name="id">Id объявления.</param>
       /// <returns>DTO с полученным объявлением.</returns>
        Task<AdvertDto> GetAsync(int id);

        /// <summary>
        /// Асинхронно добавляет объявление в БД.
        /// </summary>
        /// <param name="dto">DTO с добавляемым объявлением.</param>
        /// <returns>Id добавленного объявления.</returns>
        Task<int> AddAsync(CreateAdvertDto dto);

        /// <summary>
        /// Асинхронно удаляет объявление из БД.
        /// </summary>
        /// <param name="dto">DTO с параметрами удаляемого объявления.</param>
        /// <param name="isAdmin">Признак того, что действие производится пользователем с ролью "Администратор"</param>
        /// <returns>Объект Task, который представляет собой операцию асинхронного удаления объявления из БД.</returns>
        Task DeleteAsync(DeleteAdvertDto dto, bool isAdmin = false);

        /// <summary>
        /// Асинхронно обновляет объявление в БД.
        /// </summary>
        /// <param name="dto">DTO с параметрами обновляемого объявления.</param>
        /// <param name="isAdmin">Признак того, что действие производится пользователем с ролью "Администратор".</param>
        /// <returns>Объект Task, который представляет собой операцию асинхронного обновления объявления в БД.</returns>
        Task UpdateAsync(UpdateAdvertDto dto, bool isAdmin = false);
    }
}
 