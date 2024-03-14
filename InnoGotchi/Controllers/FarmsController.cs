using InnoGotchi.API.Core.Services.Abstractions;
using InnoGotchi.Core.Entities.ActionFilter;
using InnoGotchi.Core.Entities.DataTransferObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnoGotchi.Controllers;

[Route("api/farms")]
[ApiController]
[Authorize]
public class FarmsController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public FarmsController(IServiceManager serviceManager) => _serviceManager = serviceManager;

    /// <summary>
    /// Retrieves all farms.
    /// </summary>
    /// <param name="farmId">The ID of the farm.</param>
    /// <returns>A list of farms.</returns>
    /// <response code="200">Returns when the farms are retrieved successfully</response>
    /// <response code="404">If the farms are not found</response>
    [HttpGet("{farmId:guid}")]
    public async Task<IActionResult> GetFarm(Guid farmId)
    {
        var farmDto = await _serviceManager.FarmService.GetFarmAsync(farmId);

        return Ok(farmDto);
    }

    /// <summary>
    /// Retrieves all collaboration farms based on the provided user ID.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <returns>A list of farms.</returns>
    /// <response code="200">Returns when the farms are retrieved successfully</response>
    /// <response code="404">If the farms are not found</response>
    [HttpGet("{userId:guid}/collaborations")]
    public async Task<IActionResult> GetCollaborationFarms(Guid userId)
    {
        var farmsDto = await _serviceManager.FarmService.GetCollaborationFarmsAsync(userId);

        return Ok(farmsDto);
    }

    /// <summary>
    /// Creates a new farm.
    /// </summary>
    /// <param name="farm">The farm to create.</param>
    /// <returns>The created farm.</returns>
    /// <response code="201">Returns when the farm is created successfully</response>
    /// <response code="400">If the farm is null or invalid</response>
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateFarm([FromBody] FarmForCreationDto farm)
    {
        var farmDto = await _serviceManager.FarmService.CreateFarmAsync(farm);

        return CreatedAtAction(nameof(GetFarm), new { farmId = farmDto.FarmId }, farmDto);
    }
}
