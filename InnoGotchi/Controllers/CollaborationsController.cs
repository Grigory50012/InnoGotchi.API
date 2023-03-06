using InnoGotchi.API.Core.Services.Abstractions;
using InnoGotchi.Core.Entities.DataTransferObject;
using Microsoft.AspNetCore.Mvc;

namespace InnoGotchi.Controllers
{
    [Route("api/collaborations")]
    [ApiController]
    public class CollaborationsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public CollaborationsController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpPost("{email}")]
        public async Task<IActionResult> CreateCollaboration(string userEmail, [FromBody] CollaborationForCreationDto collaboration)
        {
            await _serviceManager.CollaborationService.CreateCollaboration(userEmail, collaboration);

            return Ok();
        }
    }
}
