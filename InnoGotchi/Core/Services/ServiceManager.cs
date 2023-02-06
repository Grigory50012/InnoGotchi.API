using InnoGotchi.API.Core.Contracts;
using InnoGotchi.API.Core.Services.Abstractions;
using InnoGotchi.API.Core.Services.Abstractions.UserServices;
using InnoGotchi.API.Core.Services.UserServices;

namespace InnoGotchi.API.Core.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IBodyPartService> _bodyPartService;
        private readonly Lazy<ICollaborationService> _collaborationService;
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IFarmService> _farmService;
        private readonly Lazy<IPetService> _petService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _bodyPartService = new Lazy<IBodyPartService>(() => new BodyPartService(repositoryManager));
            _collaborationService = new Lazy<ICollaborationService>(() => new CollaborationService(repositoryManager));
            _userService = new Lazy<IUserService>(() => new UserService(repositoryManager));
            _farmService = new Lazy<IFarmService>(() => new FarmService(repositoryManager));
            _petService = new Lazy<IPetService>(() => new PetService(repositoryManager));
        }

        public ICollaborationService CollaborationService => _collaborationService.Value;
        public IBodyPartService BodyPartService => _bodyPartService.Value;
        public IUserService UserService => _userService.Value;
        public IFarmService FarmService => _farmService.Value;
        public IPetService IPetService => _petService.Value;
    }
}
