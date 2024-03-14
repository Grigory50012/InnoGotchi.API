using InnoGotchi.API.Core.Services.Abstractions;
using InnoGotchi.Core.Entities.ActionFilter;
using InnoGotchi.Core.Entities.DataTransferObject;
using InnoGotchi.Core.Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace InnoGotchi.Controllers;

[Route("api/pets")]
[ApiController]
[Authorize]
public class PetsController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public PetsController(IServiceManager serviceManager) => _serviceManager = serviceManager;

    /// <summary>
    /// Retrieves a list of pets based on the provided parameters.
    /// </summary>
    /// <param name="petParameters">Parameters for filtering and pagination.</param>
    /// <returns>The list of pets based on the provided parameters.</returns>
    /// <response code="200">Returns when the pets are retrieved successfully</response>
    /// <response code="400">If the pet parameters is invalid</response>
    [HttpGet]
    public async Task<IActionResult> GetAllPets([FromQuery] PetParameters petParameters)
    {
        var pagedResult = await _serviceManager.PetService.GetAllPetsAsync(petParameters);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

        return Ok(pagedResult.pets);
    }

    /// <summary>
    /// Retrieves a specific pet based on the provided ID.
    /// </summary>
    /// <param name="petId">The ID of the pet to retrieve.</param>
    /// <returns>The specific pet based on the provided ID.</returns>
    /// <response code="200">Returns when the pet is retrieved successfully</response>
    /// <response code="404">If the pet is not found</response>
    [HttpGet("{petId:guid}")]
    public async Task<IActionResult> GetPet(Guid petId)
    {
        var petDto = await _serviceManager.PetService.GetPetAsync(petId);

        return Ok(petDto);
    }

    /// <summary>
    /// Creates a new pet.
    /// </summary>
    /// <param name="pet">The pet to create.</param>
    /// <returns>The created pet.</returns>
    /// <remarks>
    /// Sample request:
    ///     {
    ///         "name": "kiril",
    ///         "farmId": "ab473c20-c8ab-4400-957b-08dbe8fc66b2",
    ///         "bodyParts": [
    ///             {
    ///                 "bodyPartId": "f6bda2d8-d5dd-47a0-a77c-0dbaff44b18a",
    ///                 "name": "Eyes",
    ///                 "imageUrl": "eyes5.svg"
    ///             },
    ///             {
    ///                 "bodyPartId": "df44186a-08cb-454a-95ac-09e98800ef2d",
    ///                 "name": "Body",
    ///                 "imageUrl": "body4.svg"
    ///             },
    ///             {
    ///         "bodyPartId": "7544cbc5-8277-49e4-87db-71f836fdf2e3",
    ///                 "name": "Mouth",
    ///                 "imageUrl": "mouth5.svg"
    ///             },
    ///             {
    ///         "bodyPartId": "b552a88f-8c93-4ab1-bde0-d40e25323d86",
    ///                 "name": "Nose",
    ///                 "imageUrl": "nose2.svg"
    ///             }
    ///         ]
    ///     }
    /// </remarks>
    /// <response code="201">Returns when the pet is created successfully</response>
    /// <response code="400">If the pet parameters is null or invalid</response>
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreatePet([FromBody] PetForCreationDto pet)
    {
        var petDto = await _serviceManager.PetService.CreatePetAsync(pet);

        return CreatedAtAction(nameof(GetPet), new { petId = petDto.PetId }, petDto);
    }

    /// <summary>
    /// Updates a specific pet based on the provided ID.
    /// </summary>
    /// <param name="petId">The ID of the pet to update.</param>
    /// <param name="patchDoc">The JSON patch document containing updates for the pet.</param>
    /// <returns>The updated pet.</returns>
    /// <remarks>
    /// Sample request:
    ///     [
    ///          {
    ///              "op": "replace",
    ///              "path": "/Name",
    ///              "value": "New Name"
    ///          }
    ///     ]
    /// </remarks>
    /// <response code="200">Returns when the pet is updated successfully</response>
    /// <response code="404">If the pet is not found</response>
    /// <response code="400">If the patch document is null or invalid</response>
    [HttpPatch("{petId:guid}")]
    public async Task<IActionResult> UpdatePet(Guid petId, [FromBody] JsonPatchDocument<PetForUpdateDto> patchDoc)
    {
        var (petToPatch, pet) = await _serviceManager.PetService.GetPetForPatchAsync(petId, patchDoc);

        patchDoc.ApplyTo(petToPatch);

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        await _serviceManager.PetService.SaveChangesForPatchAsync(petToPatch, pet);

        return await GetPet(petId);
    }
}
