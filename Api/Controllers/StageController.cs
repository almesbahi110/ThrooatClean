using Application;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StageController : ControllerBase
    {
        private readonly IStage _brandService;

        public StageController(IStage brandService)
        {
            _brandService = brandService;
        }
        [HttpPost]
        public async Task<ActionResult<Stage>> PostStage( Stage brand)
        {
            var result = await _brandService.AddAsync(brand);
            return Ok(result);
        }
    }
}
