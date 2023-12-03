using InnoGotchi.API.Core.Contracts.Repositories;

namespace InnoGotchi.API.Core.Contracts;

public interface IRepositoryManager
{
    IUserRepository UserProfile { get; }

    IFarmRepository Farm { get; }

    IPetRepository Pet{ get; }

    IBodyPartRepository BodyPart { get; }

    ICollaborationRepository Collaboration { get; }

    Task SaveAsync();
}
