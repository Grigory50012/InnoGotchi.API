using InnoGotchi.API.Core.Contracts.Repositories;
using InnoGotchi.API.Core.Entities.Models;

namespace InnoGotchi.API.Infrastructure.Repository.UserRepositories
{
    public class BodyPartRepository : RepositoryBase<BodyPart>, IBodyPartRepository
    {
        public BodyPartRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
