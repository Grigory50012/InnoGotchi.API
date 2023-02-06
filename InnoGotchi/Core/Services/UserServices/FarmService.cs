using AutoMapper;
using InnoGotchi.API.Core.Contracts;
using InnoGotchi.API.Core.Services.Abstractions.UserServices;

namespace InnoGotchi.API.Core.Services.UserServices
{
    internal sealed class FarmService : IFarmService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public FarmService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
