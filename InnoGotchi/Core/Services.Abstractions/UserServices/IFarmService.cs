using InnoGotchi.Core.Entities.DataTransferObject;

namespace InnoGotchi.API.Core.Services.Abstractions.UserServices;

public interface IFarmService
{
    Task<IEnumerable<FarmDto>> GetCollaborationFarmsAsync(Guid userId);

    Task<FarmDto> GetFarmAsync(Guid farmId);

    Task<FarmDto> CreateFarmAsync(FarmForCreationDto farm);
}
