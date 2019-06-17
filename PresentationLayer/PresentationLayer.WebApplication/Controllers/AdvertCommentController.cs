using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstraction.Interfaces;
using BusinessLogicLayer.Objects.Dtos;
using BusinessLogicLayer.Objects.Dtos.Comments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.WebApplication.Controllers
{
    public class AdvertCommentController : Controller
    {
        private readonly IAdvertCommentService _commentService;

        public AdvertCommentController(IAdvertCommentService commentService)
        {
            _commentService = commentService;
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddComment([FromForm] CreateCommentDto comment)
        {
            //логика добавления комментария
            await _commentService.AddAsync(comment);

            return RedirectToAction("Get", "Advert", new {id = comment.AdvertId});
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeleteComment([FromForm] DeleteCommentDto comment)
        {
            await _commentService.DeleteAsync(comment);
            return RedirectToAction("Get", "Advert", new { id = comment.AdvertId });

        }
    }
}