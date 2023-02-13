using InnoGotchi.API.Core.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace InnoGotchi.Controllers
{
    [Route("api/farms")]
    [ApiController]
    public class FarmsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public FarmsController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet("{farmId:guid}")]
        public async Task<IActionResult> GetFarm(Guid farmId)
        {
            var farmDto = await _serviceManager.FarmService.GetFarmAsync(farmId);

            return Ok(farmDto);
        }
    }
}
