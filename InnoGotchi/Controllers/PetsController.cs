using InnoGotchi.API.Core.Services.Abstractions;
using InnoGotchi.Core.Entities.ActionFilter;
using InnoGotchi.Core.Entities.DataTransferObject;
using InnoGotchi.Core.Entities.Exceptions.BadRequestException;
using InnoGotchi.Core.Entities.RequestFeatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace InnoGotchi.Controllers;

[Route("api/pets")]
[ApiController]
public class PetsController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public PetsController(IServiceManager serviceManager) => _serviceManager = serviceManager;

    [HttpGet]
    public async Task<IActionResult> GetAllPets([FromQuery] PetParameters petParameters)
    {
        var pagedResult = await _serviceManager.PetService.GetAllPetsAsync(petParameters);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

        return Ok(pagedResult.pets);
    }

    [HttpGet("{petId:guid}")]
    public async Task<IActionResult> GetPet(Guid petId)
    {
        var petDto = await _serviceManager.PetService.GetPetAsync(petId);

        return Ok(petDto);
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreatePet([FromBody] PetForCreationDto pet)
    {
        var petDto = await _serviceManager.PetService.CreatePetAsync(pet);

        return CreatedAtAction(nameof(GetPet), new { petId = petDto.PetId }, petDto);
    }

    [HttpPatch("{petId:guid}")]
    public async Task<IActionResult> UpdatePet(Guid petId, [FromBody] JsonPatchDocument<PetForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            throw new PatchDocObjectIsNullBadRequestException();

        var (petToPatch, pet) = await _serviceManager.PetService.GetPetForPatchAsync(petId);

        patchDoc.ApplyTo(petToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        await _serviceManager.PetService.SaveChangesForPatchAsync(petToPatch, pet);

        return await GetPet(petId);
    }
}
