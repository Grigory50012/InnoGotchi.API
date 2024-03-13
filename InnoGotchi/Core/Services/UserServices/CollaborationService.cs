using AutoMapper;
using InnoGotchi.API.Core.Contracts;
using InnoGotchi.API.Core.Entities.Models;
using InnoGotchi.API.Core.Services.Abstractions.UserServices;
using InnoGotchi.Core.Entities.DataTransferObject;
using InnoGotchi.Core.Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace InnoGotchi.API.Core.Services.UserServices;

internal sealed class CollaborationService : ICollaborationService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CollaborationService(IRepositoryManager repository, IMapper mapper, 
        UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
    {
        _repository = repository;
        _mapper = mapper;
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task CreateCollaboration(CollaborationForCreationDto collaboration)
    {
        collaboration.UserId = new Guid(_userManager.GetUserId(_httpContextAccessor.HttpContext.User));

        var collaborationEntity = _mapper.Map<Collaboration>(collaboration);

        _repository.Collaboration.CreateCollaboration(collaborationEntity);

        await _repository.SaveAsync();
    }
}
