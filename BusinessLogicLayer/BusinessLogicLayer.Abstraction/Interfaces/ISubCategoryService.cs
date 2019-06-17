using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.Objects.Dtos;

namespace BusinessLogicLayer.Implementation.Services
{
    public interface ISubCategoryService
    {
        Task<ICollection<SubCategoryDto>> GetSubCategoriesAsync();
    }
}