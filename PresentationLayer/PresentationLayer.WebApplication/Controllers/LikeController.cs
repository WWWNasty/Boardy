using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstraction.Interfaces;
using BusinessLogicLayer.Objects.Dtos;
using BusinessLogicLayer.Objects.Dtos.Likes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.WebApplication.Models;

namespace PresentationLayer.WebApplication.Controllers
{
    public class LikeController : Controller
    {
        private readonly ILikeService _likeService;

        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(CreateLikeDto like, [FromQuery]string returnUrl)
        {
            if (ModelState.IsValid)
            {
                await _likeService.AddAsync(like);
            }

            return Redirect(returnUrl);
        }

        public async Task<IActionResult> Delete(DeleteLikeDto like, [FromQuery]string returnUrl)
        {

            if (ModelState.IsValid)
            {
                await _likeService.DeleteAsync(like);
            }

            return Redirect(returnUrl);
        }
    }
}