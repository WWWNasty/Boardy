using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstraction.Interfaces;
using BusinessLogicLayer.Objects.Dtos;
using BusinessLogicLayer.Objects.Dtos.Adverts.Search;
using BusinessLogicLayer.Objects.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Api.Extensions;

namespace PresentationLayer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IAdvertService _advertService;

        public UserInfoController(IAdvertService advertService)
        {
            _advertService = advertService;
        }

        [Authorize]
        [HttpGet("user")]
        public async Task<ActionResult<SearchAnswer>> GetByUser([FromQuery] SearchQuery query)
        {
            query.UserInfo = new UserInfo
            {
                Id = User.GetUserId(),
                AdvertsType = AdvertsType.Own
            };
            SearchAnswer adverts = await _advertService.GetAllAsync(query);
            return Ok(adverts);
        }

        [Authorize]
        [HttpGet("liked")]
        public async Task<ActionResult<SearchAnswer>> GetByUserLiked([FromQuery] SearchQuery query)
        {
            query.UserInfo = new UserInfo
            {
                Id = User.GetUserId(),
                AdvertsType = AdvertsType.Liked
            };
            SearchAnswer adverts = await _advertService.GetAllAsync(query);
            return Ok(adverts);
        }
    }
}