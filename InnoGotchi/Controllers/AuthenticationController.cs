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
    /// User registration.
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     POST api/authentication
    ///     {        
    ///       "firstName": "Mike",
    ///       "lastName": "Andrew",
    ///       "emailId": "Mike.Andrew@gmail.com"
    ///       "password": "9135058150611563"
    ///     }
    /// </remarks>
    /// <param name="user"></param>
    /// <response code="201">The user has been created</response>
    /// <response code="400">If the element has a null value or the properties are incorrect</response>
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto user)
    {
        await _serviceManager.AuthenticationService.RegisterUser(user);

        return StatusCode(201);
    }

    [HttpPost("login")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
    {
        await _serviceManager.AuthenticationService.ValidateUser(user);
            
        return Ok(await _serviceManager.AuthenticationService.CreateToken(populateExp: true));
    }
}
