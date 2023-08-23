using InnoGotchi.API.Core.Services.Abstractions;
using InnoGotchi.Core.Entities.ActionFilter;
using InnoGotchi.Core.Entities.DataTransferObject;
using Microsoft.AspNetCore.Mvc;

namespace InnoGotchi.Controllers;

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

        return Ok(await _serviceManager.FarmService.GetFarmAsync(farmId));
    }

    //[HttpGet("{ownerId:guid}/collaborations")]
    //public async Task<IActionResult> GetCollaborationFarms(Guid ownerId)
    //{
    //    var farmsDto = await _serviceManager.FarmService.GetCollaborationFarmsAsync(ownerId);

    //    return Ok(farmsDto);
    //}

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateFarm([FromBody] FarmForCreationDto farm)
    {
        var farmDto = await _serviceManager.FarmService.CreateFarmAsync(farm);

        return CreatedAtAction(nameof(GetFarm), new { farmId = farmDto.FarmId }, farmDto);
    }
}
