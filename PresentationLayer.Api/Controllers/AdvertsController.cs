using System.Threading.Tasks;
using BusinessLogicLayer.Abstraction.Interfaces;
using BusinessLogicLayer.Objects.Dtos.Adverts;
using BusinessLogicLayer.Objects.Dtos.Adverts.Search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Api.Extensions;


namespace PresentationLayer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertsController : ControllerBase
    {
        private readonly IAdvertService _advertService;

        public AdvertsController(IAdvertService advertService)
        {
            _advertService = advertService;
        }

        // GET api/adverts
        [HttpGet]
        public async Task<ActionResult<SearchAnswer>> Get([FromQuery]SearchQuery query)
         {
            var adverts = await _advertService.GetAllAsync(query);
            return Ok(adverts);
        }

        // GET api/adverts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdvertDto>> Get(int id)
        {
            var advert = await _advertService.GetAsync(id);
            return Ok(advert);
        }

        // POST api/adverts
        [Authorize]
        [HttpPost]
        public async Task<int> Post([FromBody] CreateAdvertDto advertDto)
        {
            var userId = User.GetUserId();

            advertDto.UserId = userId;

            return await _advertService.AddAsync(advertDto);
        }

        // PUT api/adverts
        [Authorize]
        [HttpPut]
        public async Task Update([FromBody] UpdateAdvertDto dto)
        {
            var userId = User.GetUserId();

            dto.UserId = userId;

            await _advertService.UpdateAsync(dto, User.IsInRole("Admin"));
        }


        // DELETE api/adverts/5
        [Authorize]
        [HttpDelete]
        public async Task Delete([FromQuery]DeleteAdvertDto dto)
        {
            dto.UserId = User.GetUserId();

            await _advertService.DeleteAsync(dto, User.IsInRole("Admin"));
        }

        
    }
}