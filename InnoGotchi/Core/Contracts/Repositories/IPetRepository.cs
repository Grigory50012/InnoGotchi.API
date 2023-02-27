using InnoGotchi.API.Core.Entities.Models;

namespace InnoGotchi.API.Core.Contracts.Repositories
{
    public interface IPetRepository
    {
        Task<IEnumerable<Pet>> GetAllPetsAsync(bool trackChanges);
        Task<Pet> GetPetAsync(Guid petId, bool trackChanges);
        void CreatePet(Pet pet);
    }
}
