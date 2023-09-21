using InnoGotchi.API.Core.Services.Abstractions;
using InnoGotchi.Core.Entities.ActionFilter;
using InnoGotchi.Core.Entities.DataTransferObject;
using Microsoft.AspNetCore.Mvc;

namespace InnoGotchi.Controllers;

[Route("api/token")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public TokenController(IServiceManager service) => _serviceManager = service;

    [HttpPost("refresh")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
    {
        var tokenDtoToReturn = await _serviceManager.AuthenticationService.RefreshToken(tokenDto);

        return Ok(tokenDtoToReturn);
    }
}
