using InnoGotchi.API.Core.Contracts.Repositories;
using InnoGotchi.API.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace InnoGotchi.API.Infrastructure.Repository.UserRepositories
{
    public class FarmRepository : RepositoryBase<Farm>, IFarmRepository
    {
        public FarmRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public async Task<Farm> GetFarmAsync(Guid farmId, bool trackChanges) =>
            await FindByCondition(farm => farm.FarmId.Equals(farmId), trackChanges)
            .Include(farm => farm.Pets)
            .SingleOrDefaultAsync();
    }
}
