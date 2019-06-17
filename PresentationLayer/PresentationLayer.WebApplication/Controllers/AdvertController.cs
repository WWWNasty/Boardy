using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.Abstraction.Interfaces;
using BusinessLogicLayer.Objects.Dtos;
using BusinessLogicLayer.Objects.Dtos.Adverts;
using BusinessLogicLayer.Objects.Dtos.Adverts.Search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PresentationLayer.WebApplication.Controllers.Base;
using PresentationLayer.WebApplication.Models;

namespace PresentationLayer.WebApplication.Controllers
{
    public class AdvertController : CaptchaController
    {
        private readonly IAdvertService _advertService;
        private readonly IMapper _mapper;

        public AdvertController(IAdvertService advertService, IMapper mapper, IConfiguration configuration) : base(
            configuration)
        {
            _advertService = advertService;
            _mapper = mapper;
        }

        /// <summary>
        /// Функция возвращает объект с объявлениями, параметры выборки которых указаны в параметре <paramref name="query"/>.
        /// </summary>
        /// <param name="query">Объект, в котором находятся параметры фильтрации, сортировки и данные для пагинации.</param>
        /// <param name="id">Номер страницы с объявлениями. Извлекается из URI.</param>
        /// <returns>AdvertListViewModel - модель с непросредственно объявлениями, запросом и количеством объявлений.</returns>
        public async Task<IActionResult> Index(SearchQuery query, [FromRoute] int? id)
        {
            if (id != null)
            {
                query.CurrentPage = id.Value;
            }

            SearchAnswer result = await _advertService.GetAllAsync(query);

            return View(new AdvertListViewModel
            {
                Adverts = result.Adverts,
                Query = query,
                AllAdvertsAmount = result.AdvertsAmount
            });
        }

        [Authorize]
        public IActionResult Create()
        {
            // get reCAPTHCA key from appsettings.json
            ViewBag.ReCaptchaKey = GetCaptchaKey();

            return View(new CreateAdvertDto());
        }

        [Authorize]
        [HttpPost]
        //защита от многоразового вызова метода
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAdvertDto advert)
        {
            ViewBag.ReCaptchaKey = GetCaptchaKey();

            if (ModelState.IsValid)
            {
                if (!ReCaptchaPassed(
                    Request.Form["g-recaptcha-response"], // that's how you get it from the Request object
                    _configuration.GetSection("GoogleReCaptcha:secret").Value
                ))
                {
                    ModelState.AddModelError(string.Empty, "You failed the CAPTCHA, stupid robot. Go play some 1x1 on SFs instead.");
                    return View(advert);
                }
                RemoveEmptyImages(advert);
                int createdAdvertId = await _advertService.AddAsync(advert);

                return RedirectToAction("Get", new {id = createdAdvertId});
            }

            return View(advert);
        }

        private static void RemoveEmptyImages(CreateAdvertDto advert)
        {
            advert.AdvertImages = advert.AdvertImages
                .Where(image => !string.IsNullOrEmpty(image.Base64))
                .ToArray();
        }


        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            // get reCAPTHCA key from appsettings.json
            ViewBag.ReCaptchaKey = GetCaptchaKey();

            var advertDto = await _advertService.GetAsync(id);

            return View(_mapper.Map<UpdateAdvertDto>(advertDto));
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateAdvertDto advert)
        {
            ViewBag.ReCaptchaKey = GetCaptchaKey();

            if (ModelState.IsValid)
            {
                if (!ReCaptchaPassed(
                    Request.Form["g-recaptcha-response"], // that's how you get it from the Request object
                    _configuration.GetSection("GoogleReCaptcha:secret").Value
                ))
                {
                    ModelState.AddModelError(string.Empty, "You failed the CAPTCHA, stupid robot. Go play some 1x1 on SFs instead.");
                    return View(advert);
                }

                RemoveEmptyImages(advert);
                await _advertService.UpdateAsync(advert);

                return RedirectToAction("Get", new {id = advert.Id});
            }

            return View(advert);
        }

        [Authorize]
        public async Task<IActionResult> Delete(DeleteAdvertDto dto)
        {
            await _advertService.DeleteAsync(dto);

            string redirect = Request.Headers["Referer"].ToString();
            return Redirect(redirect);
        }

        public async Task<ActionResult<AdvertDto>> Get(int id)
        {
            var advertDto = await _advertService.GetAsync(id);

            return View(advertDto);
        }
    }
}