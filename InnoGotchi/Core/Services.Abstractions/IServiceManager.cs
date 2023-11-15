using InnoGotchi.API.Core.Services.Abstractions.UserServices;
using InnoGotchi.Core.Services.Abstractions.UserServices;

namespace InnoGotchi.API.Core.Services.Abstractions;

public interface IServiceManager
{
    ICollaborationService CollaborationService { get; }
    IBodyPartService BodyPartService { get; }
    IFarmService FarmService { get; }
    IPetService PetService { get; }
    IAuthenticationService AuthenticationService { get; }
    IUserService UserService { get; }
}
