using InnoGotchi.API.Core.Contracts;
using InnoGotchi.API.Core.Services.Abstractions.UserServices;

namespace InnoGotchi.API.Core.Services.UserServices
{
    internal sealed class FarmService : IFarmService
    {
        private readonly IRepositoryManager _repository;

        public FarmService(IRepositoryManager repository)
        {
            _repository = repository;
        }
    }
}
