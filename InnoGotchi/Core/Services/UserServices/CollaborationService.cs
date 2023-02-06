using InnoGotchi.API.Core.Contracts;
using InnoGotchi.API.Core.Services.Abstractions.UserServices;

namespace InnoGotchi.API.Core.Services.UserServices
{
    internal sealed class CollaborationService : ICollaborationService
    {
        private readonly IRepositoryManager _repository;

        public CollaborationService(IRepositoryManager repository)
        {
            _repository = repository;
        }
    }
}
