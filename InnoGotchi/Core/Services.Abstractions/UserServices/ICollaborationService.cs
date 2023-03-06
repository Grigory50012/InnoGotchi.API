using InnoGotchi.Core.Entities.DataTransferObject;

namespace InnoGotchi.API.Core.Services.Abstractions.UserServices
{
    public interface ICollaborationService
    {
        Task<IEnumerable<CollaborationDto>> GetCollaborationAsync(Guid userId);
        Task CreateCollaboration(string email, CollaborationForCreationDto collaboration);
    }
}
