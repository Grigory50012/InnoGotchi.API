using InnoGotchi.API.Core.Entities.Models;

namespace InnoGotchi.API.Core.Contracts.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email, bool trackChanges);
    }
}
