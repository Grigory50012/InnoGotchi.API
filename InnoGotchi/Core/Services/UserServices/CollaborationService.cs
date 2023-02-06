using AutoMapper;
using InnoGotchi.API.Core.Contracts;
using InnoGotchi.API.Core.Services.Abstractions.UserServices;

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
    }
}
