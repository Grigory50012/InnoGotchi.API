using AutoMapper;
using InnoGotchi.API.Core.Contracts;
using InnoGotchi.API.Core.Services.Abstractions.UserServices;
using InnoGotchi.Core.Entities.DataTransferObject;

namespace InnoGotchi.API.Core.Services.UserServices
{
    internal sealed class PetService : IPetService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public PetService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PetDto>> GetAllPetsAsync()
        {
            var pets = await _repository.Pet.GetAllPetsAsync(trackChanges: false);

            var petsDto = _mapper.Map<IEnumerable<PetDto>>(pets);

            return petsDto;
        }
    }
}
