using InnoGotchi.API.Core.Services.Abstractions;
using InnoGotchi.Core.Entities.DataTransferObject;
using InnoGotchi.Core.Entities.Exceptions.BadRequestException;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace InnoGotchi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public UsersController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpPatch("{email}")]
        [Authorize]
        public async Task<IActionResult> UpdateUser(string email, [FromBody] JsonPatchDocument<UserForUpdateDto> userPatchDoc)
        {
            if (userPatchDoc is null)
                throw new PatchDocObjectIsNullBadRequestException();

            var (userToPatch, user) = await _serviceManager.UserService.GetUserForPatchAsync(email);

            userPatchDoc.ApplyTo(userToPatch);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _serviceManager.UserService.SaveChangesForPatchAsync(userToPatch, user);

            return Ok(userToPatch);
        }
    }
}
