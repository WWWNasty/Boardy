using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstraction.Interfaces;
using BusinessLogicLayer.Implementation.Services;
using BusinessLogicLayer.Objects.Dtos;
using BusinessLogicLayer.Objects.Dtos.Likes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Api.Extensions;

namespace PresentationLayer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILikeService _likeService;

        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }
        // POST api/like
        [Authorize]
        [HttpPost]
        public async Task Post([FromBody] CreateLikeDto likeDto)
        {
            var userId = User.GetUserId();

            likeDto.UserId = userId;

            await _likeService.AddAsync(likeDto);
        }

        [Authorize]
        [HttpDelete]
        public async Task Delete([FromQuery] DeleteLikeDto likeDto)
        {
            await _likeService.DeleteAsync(likeDto);
        }
    }
}