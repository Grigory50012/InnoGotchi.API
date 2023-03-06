using InnoGotchi.API.Core.Contracts.Repositories;
using InnoGotchi.API.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace InnoGotchi.API.Infrastructure.Repository.UserRepositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<User> GetUserByEmailAsync(string email, bool trackChanges) =>
             await FindByCondition(user => user.Email.Equals(email), trackChanges)
            .SingleOrDefaultAsync();
    }
}
