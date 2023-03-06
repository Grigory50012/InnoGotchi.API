using InnoGotchi.API.Core.Entities.Models;

namespace InnoGotchi.API.Core.Contracts.Repositories
{
    public interface ICollaborationRepository
    {
        Task<IEnumerable<Collaboration>> GetCollaborationAsync(Guid userId, bool trackChanges);
        void CreateCollaboration(Collaboration collaboration);
    }
}
