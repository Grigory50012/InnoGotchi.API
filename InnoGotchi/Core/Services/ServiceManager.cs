using AutoMapper;
using InnoGotchi.API.Core.Contracts;
using InnoGotchi.API.Core.Services.Abstractions;
using InnoGotchi.API.Core.Services.Abstractions.UserServices;
using InnoGotchi.API.Core.Services.UserServices;
using InnoGotchi.Core.Entities.Models;
using InnoGotchi.Core.Services.Abstractions.UserServices;
using InnoGotchi.Core.Services.UserServices;
using Microsoft.AspNetCore.Identity;

namespace InnoGotchi.API.Core.Services;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IBodyPartService> _bodyPartService;
    private readonly Lazy<ICollaborationService> _collaborationService;
    private readonly Lazy<IFarmService> _farmService;
    private readonly Lazy<IPetService> _petService;
    private readonly Lazy<IAuthenticationService> _authenticationService;

    public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper, 
        UserManager<User> userManager, IConfiguration configuration)
    {
        _bodyPartService = new Lazy<IBodyPartService>(() => new BodyPartService(repositoryManager, mapper));
        _collaborationService = new Lazy<ICollaborationService>(() => new CollaborationService(repositoryManager, mapper));
        _farmService = new Lazy<IFarmService>(() => new FarmService(repositoryManager, mapper));
        _petService = new Lazy<IPetService>(() => new PetService(repositoryManager, mapper));
        _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(mapper, userManager, configuration));
    }

    public ICollaborationService CollaborationService => _collaborationService.Value;
    public IBodyPartService BodyPartService => _bodyPartService.Value;
    public IFarmService FarmService => _farmService.Value;
    public IPetService PetService => _petService.Value;
    public IAuthenticationService AuthenticationService => _authenticationService.Value;
}
