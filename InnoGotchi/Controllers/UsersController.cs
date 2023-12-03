using InnoGotchi.API.Core.Services.Abstractions;
using InnoGotchi.Core.Entities.DataTransferObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace InnoGotchi.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public UsersController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpPatch("{userId:guid}")]
        public async Task<IActionResult> UpdateUser(Guid userId, [FromBody] JsonPatchDocument<UserForUpdateDto> patchDoc)
        {
            var (userToPatch, user) = await _serviceManager.UserService.GetUserForPatchAsync(userId, patchDoc);

            patchDoc.ApplyTo(userToPatch);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _serviceManager.UserService.SaveChangesForPatchAsync(userToPatch, user);

            return Ok(userToPatch);
        }
    }
}
