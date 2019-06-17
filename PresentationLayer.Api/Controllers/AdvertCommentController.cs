using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstraction.Interfaces;
using BusinessLogicLayer.Implementation.Services;
using BusinessLogicLayer.Objects.Dtos;
using BusinessLogicLayer.Objects.Dtos.Comments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Api.Extensions;


namespace PresentationLayer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertCommentController : ControllerBase
    {
        private readonly IAdvertService _advertService;
        private readonly IAdvertCommentService _advertCommentService;

        public AdvertCommentController(IAdvertService advertService, IAdvertCommentService advertCommentService)
        {
            _advertService = advertService;
            _advertCommentService = advertCommentService;
        }

        [Authorize]
        [HttpPost]
        public async Task AddComment([FromBody]CreateCommentDto request)
        {
            request.UserId = User.GetUserId();
            request.UserName = User.GetUserName();

            await _advertCommentService.AddAsync(request);
        }

        [Authorize]
        [HttpDelete]
        public async Task DeleteComment([FromQuery]DeleteCommentDto dto)
        {
            dto.UserId = User.GetUserId();
            
           await _advertCommentService.DeleteAsync(dto, User.IsInRole("Admin"));
        }
    }
}