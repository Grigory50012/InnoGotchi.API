using AutoMapper;
using InnoGotchi.API.Core.Contracts;
using InnoGotchi.API.Core.Entities.Models;
using InnoGotchi.API.Core.Services.Abstractions.UserServices;
using InnoGotchi.Core.Entities.DataTransferObject;
using InnoGotchi.Core.Entities.Exceptions.NotFoundExcrption;

namespace InnoGotchi.API.Core.Services.UserServices;

internal sealed class CollaborationService : ICollaborationService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public CollaborationService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CollaborationDto>> GetCollaborationAsync(Guid userId)
    {
        var collaborations = await _repository.Collaboration.GetCollaborationAsync(userId, trackChanges: false);

        return _mapper.Map<IEnumerable<CollaborationDto>>(collaborations);
    }

    //public async Task CreateCollaboration(string name, CollaborationForCreationDto collaboration)
    //{
    //    var user = await _repository.UserProfile.GetUserByNameAsync(name, trackChanges: false);
    //    if (user is null)
    //        throw new UserNotFoundException(name);

    //    collaboration.UserId = user.Id;

    //    var collaborationEntity = _mapper.Map<Collaboration>(collaboration);

    //    _repository.Collaboration.CreateCollaboration(collaborationEntity);
    //    await _repository.SaveAsync();
    //}
}
