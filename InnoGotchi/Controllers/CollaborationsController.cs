using InnoGotchi.API.Core.Services.Abstractions;
using InnoGotchi.Core.Entities.ActionFilter;
using InnoGotchi.Core.Entities.DataTransferObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnoGotchi.Controllers;

[Route("api/collaborations")]
[ApiController]
[Authorize]
public class CollaborationsController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public CollaborationsController(IServiceManager serviceManager) => _serviceManager = serviceManager;

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateCollaboration([FromBody] CollaborationForCreationDto collaboration)
    {
        await _serviceManager.CollaborationService.CreateCollaboration(collaboration);

        return NoContent();
    }
}
