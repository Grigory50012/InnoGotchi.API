using InnoGotchi.API.Core.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnoGotchi.Controllers;

[Route("api/bodyParts")]
[ApiController]
public class BodyPartsController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public BodyPartsController(IServiceManager serviceManager) => _serviceManager = serviceManager;

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetBodyParts()
    {
        var bodyPartsDto = await _serviceManager.BodyPartService.GetBodyPartsAsync();

        return Ok(bodyPartsDto);
    }
}
