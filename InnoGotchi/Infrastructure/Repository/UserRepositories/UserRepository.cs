using InnoGotchi.API.Core.Contracts.Repositories;
using InnoGotchi.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace InnoGotchi.API.Infrastructure.Repository.UserRepositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public async Task<User> GetUserByNameAsync(string name, bool trackChanges) =>
         await FindByCondition(user => user.UserName.Equals(name), trackChanges)
        .SingleOrDefaultAsync();
}
