using InnoGotchi.API.Core.Contracts.Repositories;
using InnoGotchi.API.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace InnoGotchi.API.Infrastructure.Repository.UserRepositories;

public class CollaborationRepository : RepositoryBase<Collaboration>, ICollaborationRepository
{
    public CollaborationRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Collaboration>> GetCollaborationAsync(Guid userId, bool trackChanges) =>
        await FindByCondition(collaboration => collaboration.UserId.Equals(userId), trackChanges)
        .ToListAsync();

    public void CreateCollaboration(Collaboration collaboration) => Create(collaboration);
}
