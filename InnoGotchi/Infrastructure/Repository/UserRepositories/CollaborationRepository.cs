using InnoGotchi.API.Core.Contracts.Repositories;
using InnoGotchi.API.Core.Entities.Models;

namespace InnoGotchi.API.Infrastructure.Repository.UserRepositories
{
    public class CollaborationRepository : RepositoryBase<Collaboration>, ICollaborationRepository
    {
        public CollaborationRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
