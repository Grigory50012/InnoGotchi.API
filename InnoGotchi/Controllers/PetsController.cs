using InnoGotchi.API.Core.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace InnoGotchi.Controllers
{
    [Route("api/pets")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public PetsController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet]
        public async Task<IActionResult> GetPets()
        {
            var petsDto = await _serviceManager.PetService.GetAllPetsAsync();

            return Ok(petsDto);
        }
    }
}
