using BusinessLogicLayer.Objects.Dtos.Prompt;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstraction.Interfaces
{
    public interface IPromptService
    {
        Task<IEnumerable<PromptAnswer>> GetRegion(PromptQuery query);
        Task<IEnumerable<PromptAnswer>> GetCity(PromptQuery query);
        Task<IEnumerable<PromptAnswer>> GetStreet(PromptQuery query);
        Task<IEnumerable<PromptAnswer>> GetHouse(PromptQuery query);
    }
}
