using InnoGotchi.API.Core.Entities.Models;

namespace InnoGotchi.API.Core.Contracts.Repositories
{
    public interface IFarmRepository
    {
        Task<Farm> GetFarmAsync(Guid farmId, bool trackChanges);
        void CreateFarm(Farm farm);
    }
}
