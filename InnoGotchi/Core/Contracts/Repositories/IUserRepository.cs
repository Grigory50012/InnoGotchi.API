using InnoGotchi.Core.Entities.Models;

namespace InnoGotchi.API.Core.Contracts.Repositories;

public interface IUserRepository
{
    Task<User> GetUserByNameAsync(string name, bool trackChanges);
}
