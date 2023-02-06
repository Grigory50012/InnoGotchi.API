using InnoGotchi.API.Core.Contracts.Repositories;
using InnoGotchi.API.Core.Entities.Models;

namespace InnoGotchi.API.Infrastructure.Repository.UserRepositories
{
    public class FarmRepository : RepositoryBase<Farm>, IFarmRepository
    {
        public FarmRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
