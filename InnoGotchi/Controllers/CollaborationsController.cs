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

    /// <summary>
    /// Creates a new collaboration
    /// </summary>
    /// <param name="collaboration">The collaboration to create</param>
    /// <returns>No content</returns>
    /// <response code="201">Returns when the collaboration is created successfully</response>
    /// <response code="404">If the farm is not found</response>
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateCollaboration([FromBody] CollaborationForCreationDto collaboration)
    {
        await _serviceManager.CollaborationService.CreateCollaboration(collaboration);

        return StatusCode(201);
    }
}
