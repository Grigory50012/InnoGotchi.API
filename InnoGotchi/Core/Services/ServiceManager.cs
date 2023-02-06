using AutoMapper;
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

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _bodyPartService = new Lazy<IBodyPartService>(() => new BodyPartService(repositoryManager, mapper));
            _collaborationService = new Lazy<ICollaborationService>(() => new CollaborationService(repositoryManager, mapper));
            _userService = new Lazy<IUserService>(() => new UserService(repositoryManager, mapper));
            _farmService = new Lazy<IFarmService>(() => new FarmService(repositoryManager, mapper));
            _petService = new Lazy<IPetService>(() => new PetService(repositoryManager, mapper));
        }

        public ICollaborationService CollaborationService => _collaborationService.Value;
        public IBodyPartService BodyPartService => _bodyPartService.Value;
        public IUserService UserService => _userService.Value;
        public IFarmService FarmService => _farmService.Value;
        public IPetService PetService => _petService.Value;
    }
}
