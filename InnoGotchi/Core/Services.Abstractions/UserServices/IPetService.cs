using InnoGotchi.API.Core.Entities.Models;
using InnoGotchi.Core.Entities.DataTransferObject;
using InnoGotchi.Core.Entities.RequestFeatures;
using Microsoft.AspNetCore.JsonPatch;

namespace InnoGotchi.API.Core.Services.Abstractions.UserServices;

public interface IPetService
{
    Task<(IEnumerable<PetDto> pets, MetaData metaData)> GetAllPetsAsync(PetParameters petParameters);

    Task<PetDto> GetPetAsync(Guid petId);

    Task<PetDto> CreatePetAsync(PetForCreationDto pet);

    Task<(PetForUpdateDto petToPatch, Pet pet)> GetPetForPatchAsync(Guid petId,
        JsonPatchDocument<PetForUpdateDto> patchDoc);

    Task SaveChangesForPatchAsync(PetForUpdateDto petToPatch, Pet pet);
}
