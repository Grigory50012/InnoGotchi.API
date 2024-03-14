using InnoGotchi.API.Core.Services.Abstractions;
using InnoGotchi.Core.Entities.ActionFilter;
using InnoGotchi.Core.Entities.DataTransferObject;
using Microsoft.AspNetCore.Mvc;

namespace InnoGotchi.Controllers;

[Route("api/authentication")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public AuthenticationController(IServiceManager serviceManager) => _serviceManager = serviceManager;

    /// <summary>
    /// Registers a new user
    /// </summary>
    /// <param name="user">The user to register</param>
    /// <returns>Returns an IActionResult representing the outcome of the registration operation</returns>
    /// <response code="201">Returns when the user is registered</response>
    /// <response code="400">If the user is null or invalid</response>
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto user)
    {
        await _serviceManager.AuthenticationService.RegisterUser(user);

        return StatusCode(201);
    }

    /// <summary>
    /// Authenticates a user
    /// </summary>
    /// <param name="user">The user to authenticate</param>
    /// <returns>Returns an IActionResult representing the outcome of the authentication operation</returns>
    /// <response code="200">Returns when the user is authenticated</response>
    /// <response code="401">If the user is not authorized</response>
    /// <response code="404">If the user is not found</response>
    [HttpPost("login")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
    {
        await _serviceManager.AuthenticationService.ValidateUser(user);
            
        return Ok(await _serviceManager.AuthenticationService.CreateToken(populateExp: true));
    }
}
