using InnoGotchi.Core.Entities.DataTransferObject;

namespace InnoGotchi.API.Core.Services.Abstractions.UserServices
{
    public interface IFarmService
    {
        Task<FarmDto> GetFarmAsync(Guid farmId);
    }
}
