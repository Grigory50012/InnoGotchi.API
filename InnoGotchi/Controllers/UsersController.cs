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

        /// <summary>
        /// Update a user based on the provided patch document
        /// </summary>
        /// <param name="userId">The unique identifier of the user</param>
        /// <param name="patchDoc">The JSON patch document containing updates for the user</param>
        /// <returns>Returns an IActionResult representing the outcome of the update operation</returns>
        /// <remarks>
        /// Sample request:
        ///     [
        ///          {
        ///              "op": "replace",
        ///              "path": "/FirstName",
        ///              "value": "Kirill"
        ///          }
        ///     ]
        /// </remarks>
        /// <response code="200">Returns when the user is updated</response>
        /// <response code="404">If the user is not found</response>
        /// <response code="400">If the patch document is null or invalid</response>
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

        /// <summary>
        /// Change the password of a user
        /// </summary>
        /// <param name="user">The DTO containing user id, old and new passwords for the user</param>
        /// <returns>Returns an IActionResult representing the outcome of the password change operation (200 if successful)</returns>
        /// <response code="200">Returns when the password is updated</response>
        /// <response code="404">If the user is not found</response>
        /// <response code="400">If the new or old password is null or invalid</response>
        [HttpPost]
        public async Task<IActionResult> ChangePassword([FromBody] UserPasswordForUpdateDto user)
        {
            await _serviceManager.UserService.ChangePasswordAsync(user);

            return StatusCode(200);
        }
    }
}
