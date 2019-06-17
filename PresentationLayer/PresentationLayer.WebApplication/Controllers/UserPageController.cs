using System.Threading.Tasks;
using BusinessLogicLayer.Abstraction.Interfaces;
using BusinessLogicLayer.Objects.Dtos;
using BusinessLogicLayer.Objects.Dtos.Adverts.Search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.WebApplication.Models;

namespace PresentationLayer.WebApplication.Controllers
{
    //[Route("[controller]")]
    public class UserPageController : Controller
    {
        private readonly IUserInfoService _userInfoService;

        public UserPageController(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUserAdverts([FromQuery]SearchQuery query, [FromRoute] int? id)
        {
            if (id != null)
            {
                query.CurrentPage = id.Value;
            }
            SearchAnswer result = await _userInfoService.GetByUserAsync(query);
            AdvertListViewModel data = new AdvertListViewModel
            {
                Adverts = result.Adverts,
                Query = query,
                AllAdvertsAmount = result.AdvertsAmount
            };
            return View("Adverts", data);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUserLikedAdverts([FromQuery]SearchQuery query, [FromRoute] int? id)
        {
            if (id != null)
            {
                query.CurrentPage = id.Value;
            }
            SearchAnswer result = await _userInfoService.GetByUserLikedAsync(query);
            AdvertListViewModel data = new AdvertListViewModel
            {
                Adverts = result.Adverts,
                Query = query,
                AllAdvertsAmount = result.AdvertsAmount
            };
            return View("Adverts", data);
        }
    }
}