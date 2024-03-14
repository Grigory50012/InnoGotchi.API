using InnoGotchi.API.Core.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnoGotchi.Controllers;

[Route("api/bodyParts")]
[ApiController]
[Authorize]
public class BodyPartsController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public BodyPartsController(IServiceManager serviceManager) => _serviceManager = serviceManager;

    /// <summary>
    /// Get all body parts
    /// </summary>
    /// <returns>A list of body parts.</returns>
    /// <response code="200">Returns when the body parts are retrieved successfully</response>
    [HttpGet]
    public async Task<IActionResult> GetBodyParts()
    {
        return Ok(await _serviceManager.BodyPartService.GetBodyPartsAsync());
    }
}
