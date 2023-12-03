using AutoMapper;
using InnoGotchi.API.Core.Contracts;
using InnoGotchi.Core.Entities.DataTransferObject;
using InnoGotchi.Core.Entities.Exceptions.BadRequestException;
using InnoGotchi.Core.Entities.Exceptions.NotFoundExcrption;
using InnoGotchi.Core.Entities.Models;
using InnoGotchi.Core.Services.Abstractions.UserServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;

namespace InnoGotchi.Core.Services.UserServices;

public class UserService : IUserService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    private User? _user;

    public UserService(IRepositoryManager repository, IMapper mapper, UserManager<User> userManager)
    {
        _repositoryManager = repository;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<(UserForUpdateDto userToPatch, User user)> GetUserForPatchAsync(Guid userId,
        JsonPatchDocument<UserForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            throw new PatchDocumentObjectIsNullBadRequestException();

        _user = await _userManager.FindByIdAsync(userId.ToString());

        if (_user is null)
            throw new UserNotFoundByIdException(userId);

        var userToPatch = _mapper.Map<UserForUpdateDto>(_user);

        return (userToPatch, _user);
    }

    public async Task SaveChangesForPatchAsync(UserForUpdateDto userToPatch, User user)
    {
        _mapper.Map(userToPatch, user);

        await _repositoryManager.SaveAsync();
    }
}
