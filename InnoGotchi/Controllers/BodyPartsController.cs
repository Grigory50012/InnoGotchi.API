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

    [HttpGet]
    public async Task<IActionResult> GetBodyParts()
    {
        return Ok(await _serviceManager.BodyPartService.GetBodyPartsAsync());
    }
}
