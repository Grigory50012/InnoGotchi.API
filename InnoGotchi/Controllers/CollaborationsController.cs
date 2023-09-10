using InnoGotchi.API.Core.Services.Abstractions;
using InnoGotchi.Core.Entities.ActionFilter;
using InnoGotchi.Core.Entities.DataTransferObject;
using Microsoft.AspNetCore.Mvc;

namespace InnoGotchi.Controllers;

[Route("api/collaborations")]
[ApiController]
public class CollaborationsController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public CollaborationsController(IServiceManager serviceManager) => _serviceManager = serviceManager;

    [HttpPost("{email}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateCollaboration(string email, [FromBody] CollaborationForCreationDto collaboration)
    {
        await _serviceManager.CollaborationService.CreateCollaboration(email, collaboration);

        return NoContent();
    }
}
