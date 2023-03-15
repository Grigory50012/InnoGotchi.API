using InnoGotchi.API.Core.Entities.Models;
using InnoGotchi.Core.Entities.DataTransferObject;

namespace InnoGotchi.API.Core.Services.Abstractions.UserServices
{
    public interface IPetService
    {
        Task<IEnumerable<PetDto>> GetAllPetsAsync();
        Task<PetDto> GetPetAsync(Guid petId);
        Task<PetDto> CreatePet(PetForCreationDto pet);
        Task<(PetForUpdateDto petToPatch, Pet pet)> GetPetForPatchAsync(Guid petId);
        Task SaveChangesForPatchAsync(PetForUpdateDto petToPatch, Pet pet);
    }
}
