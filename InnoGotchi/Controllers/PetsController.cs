using InnoGotchi.API.Core.Services.Abstractions;
using InnoGotchi.Core.Entities.DataTransferObject;
using Microsoft.AspNetCore.JsonPatch;
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
        public async Task<IActionResult> GetAllPets()
        {
            var petsDto = await _serviceManager.PetService.GetAllPetsAsync();

            return Ok(petsDto);
        }

        [HttpGet("{petId:guid}")]
        public async Task<IActionResult> GetPet(Guid petId)
        {
            var petDto = await _serviceManager.PetService.GetPetAsync(petId);

            return Ok(petDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePet([FromBody] PetForCreationDto pet)
        {
            var petDto = await _serviceManager.PetService.CreatePet(pet);

            return CreatedAtAction(nameof(GetPet), new { petId = petDto.PetId }, petDto);
        }

        [HttpPatch("{petId:guid}")]
        public async Task<IActionResult> UpdatePet(Guid petId, [FromBody] JsonPatchDocument<PetForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object sent from client is null.");

            var result = await _serviceManager.PetService.GetPetForPatchAsync(petId);

            patchDoc.ApplyTo(result.petToPatch);

            await _serviceManager.PetService.SaveChangesForPatchAsync(result.petToPatch, result.pet);

            return await GetPet(petId);
        }
    }
}
