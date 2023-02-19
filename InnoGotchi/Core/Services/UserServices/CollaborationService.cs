using AutoMapper;
using InnoGotchi.API.Core.Contracts;
using InnoGotchi.API.Core.Services.Abstractions.UserServices;
using InnoGotchi.Core.Entities.DataTransferObject;

namespace InnoGotchi.API.Core.Services.UserServices
{
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

            var collaborationsDto = _mapper.Map<IEnumerable<CollaborationDto>>(collaborations);
            return collaborationsDto;
        }
    }
}
