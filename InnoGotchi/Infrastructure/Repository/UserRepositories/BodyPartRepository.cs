using InnoGotchi.API.Core.Contracts.Repositories;
using InnoGotchi.API.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace InnoGotchi.API.Infrastructure.Repository.UserRepositories;

public class BodyPartRepository : RepositoryBase<BodyPart>, IBodyPartRepository
{
    public BodyPartRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<BodyPart>> GetBodyPartsAsync(bool trackChanges) 
        => await FindAll(trackChanges)
        .ToListAsync();
}
