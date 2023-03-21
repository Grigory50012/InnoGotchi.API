using InnoGotchi.API.Core.Entities.Models;
using InnoGotchi.Core.Entities.DataTransferObject;
using InnoGotchi.Core.Entities.RequestFeatures;

namespace InnoGotchi.API.Core.Services.Abstractions.UserServices
{
    public interface IPetService
    {
        Task<(IEnumerable<PetDto> pets, MetaData metaData)> GetAllPetsAsync(PetParameters petParameters);
        Task<PetDto> GetPetAsync(Guid petId);
        Task<PetDto> CreatePetAsync(PetForCreationDto pet);
        Task<(PetForUpdateDto petToPatch, Pet pet)> GetPetForPatchAsync(Guid petId);
        Task SaveChangesForPatchAsync(PetForUpdateDto petToPatch, Pet pet);
    }
}
