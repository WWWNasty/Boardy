using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstraction.Interfaces;
using BusinessLogicLayer.Objects.Dtos.Prompt;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromptController : ControllerBase
    {
        private IPromptService _promptService;

        public PromptController(IPromptService promptService)
        {
            _promptService = promptService;
        }

        [HttpPost("region")]
        public async Task<ActionResult<IEnumerable<PromptAnswer>>> GetRegion([FromBody] PromptQuery query)
        {
            var result = await _promptService.GetRegion(query);
            return Ok(result);
        }

        [HttpPost("city")]
        public async Task<ActionResult<IEnumerable<PromptAnswer>>> GetCity([FromBody] PromptQuery query)
        {
            var result = await _promptService.GetCity(query);
            return Ok(result);
        }
        [HttpPost("street")]
        public async Task<ActionResult<IEnumerable<PromptAnswer>>> GetStreet([FromBody] PromptQuery query)
        {
            var result = await _promptService.GetStreet(query);
            return Ok(result);
        }

        [HttpPost("house")]
        public async Task<ActionResult<IEnumerable<PromptAnswer>>> GetHouse([FromBody] PromptQuery query)
        {
            var result = await _promptService.GetHouse(query);
            return Ok(result);
        }
    }
}