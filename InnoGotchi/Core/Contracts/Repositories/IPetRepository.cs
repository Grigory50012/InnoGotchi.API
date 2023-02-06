using InnoGotchi.API.Core.Entities.Models;

namespace InnoGotchi.API.Core.Contracts.Repositories
{
    public interface IPetRepository
    {
        Task<IEnumerable<Pet>> GetAllPetsAsync(bool trackChanges);
    }
}
