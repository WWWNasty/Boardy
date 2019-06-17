using BusinessLogicLayer.Abstraction.Interfaces;
using BusinessLogicLayer.Objects.Dtos.Prompt;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PresentationLayer.WebApplication.Controllers
{
    public class PromptController : Controller
    {
        private readonly IPromptService _promptService;

        public PromptController(IPromptService promptService)
        {
            _promptService = promptService;
        }

        public async Task<JsonResult> GetRegion(PromptQuery qry)
        {
            var result = await _promptService.GetRegion(qry);
            return Json(result);
        }

        public async Task<JsonResult> GetCity(PromptQuery qry)
        {
            var result = await _promptService.GetCity(qry);
            return Json(result);
        }

        public async Task<JsonResult> GetStreet(PromptQuery qry)
        {
            var result = await _promptService.GetStreet(qry);
            return Json(result);
        }

        public async Task<JsonResult> GetHouse(PromptQuery qry)
        {
            var result = await _promptService.GetHouse(qry);
            return Json(result);
        }
    }
}