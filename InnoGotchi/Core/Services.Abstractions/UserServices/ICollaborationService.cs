using InnoGotchi.Core.Entities.DataTransferObject;

namespace InnoGotchi.API.Core.Services.Abstractions.UserServices;

public interface ICollaborationService
{
    Task CreateCollaboration(CollaborationForCreationDto collaboration);
}
