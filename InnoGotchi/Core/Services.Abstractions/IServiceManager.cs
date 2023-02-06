using InnoGotchi.API.Core.Services.Abstractions.UserServices;

namespace InnoGotchi.API.Core.Services.Abstractions
{
    public interface IServiceManager
    {
        ICollaborationService CollaborationService { get; }
        IBodyPartService BodyPartService { get; }
        IUserService UserService { get; }
        IFarmService FarmService { get; }
        IPetService PetService { get; }
    }
}
