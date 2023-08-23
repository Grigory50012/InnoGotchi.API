using InnoGotchi.API.Core.Entities.Models;

namespace InnoGotchi.API.Core.Contracts.Repositories;

public interface IBodyPartRepository
{
    Task<IEnumerable<BodyPart>> GetBodyPartsAsync(bool trackChanges);
}
