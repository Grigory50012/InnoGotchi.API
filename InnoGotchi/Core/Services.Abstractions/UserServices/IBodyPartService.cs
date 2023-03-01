using InnoGotchi.Core.Entities.DataTransferObject;

namespace InnoGotchi.API.Core.Services.Abstractions.UserServices
{
    public interface IBodyPartService
    {
        Task<IEnumerable<BodyPartDto>> GetBodyPartsAsync();
    }
}
