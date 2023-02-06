using InnoGotchi.API.Core.Contracts;
using InnoGotchi.API.Core.Services.Abstractions.UserServices;

namespace InnoGotchi.API.Core.Services.UserServices
{
    internal sealed class PetService : IPetService
    {
        private readonly IRepositoryManager _repository;

        public PetService(IRepositoryManager repository)
        {
            _repository = repository;
        }
    }
}
