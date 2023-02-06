using InnoGotchi.API.Core.Contracts;
using InnoGotchi.API.Core.Services.Abstractions.UserServices;

namespace InnoGotchi.API.Core.Services.UserServices
{
    internal sealed class BodyPartService : IBodyPartService
    {
        private readonly IRepositoryManager _repository;

        public BodyPartService(IRepositoryManager repository)
        {
            _repository = repository;
        }
    }
}
