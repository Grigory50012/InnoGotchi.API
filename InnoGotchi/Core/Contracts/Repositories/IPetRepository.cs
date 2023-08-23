using InnoGotchi.API.Core.Entities.Models;
using InnoGotchi.Core.Entities.RequestFeatures;

namespace InnoGotchi.API.Core.Contracts.Repositories;

public interface IPetRepository
{
    Task<PagedList<Pet>> GetAllPetsAsync(PetParameters petParameters, bool trackChanges);
    Task<Pet> GetPetAsync(Guid petId, bool trackChanges);
    void CreatePet(Pet pet);
}
