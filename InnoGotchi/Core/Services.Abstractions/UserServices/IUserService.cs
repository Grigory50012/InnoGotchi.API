using InnoGotchi.API.Core.Entities.Models;
using InnoGotchi.Core.Entities.DataTransferObject;
using InnoGotchi.Core.Entities.Models;

namespace InnoGotchi.Core.Services.Abstractions.UserServices;

public interface IUserService
{
    Task<(UserForUpdateDto userToPatch, User user)> GetUserForPatchAsync(string user);
    Task SaveChangesForPatchAsync(UserForUpdateDto petToPatch, User pet);
}
