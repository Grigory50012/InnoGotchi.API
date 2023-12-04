using InnoGotchi.Core.Entities.DataTransferObject;
using InnoGotchi.Core.Entities.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace InnoGotchi.Core.Services.Abstractions.UserServices;

public interface IUserService
{
    Task<(UserForUpdateDto userToPatch, User user)> GetUserForPatchAsync(Guid userId,
        JsonPatchDocument<UserForUpdateDto> patchDoc);

    Task SaveChangesForPatchAsync(UserForUpdateDto userToPatch, User user);

    Task ChangePasswordAsync(UserPasswordForUpdateDto passwordForUpdate);
}
