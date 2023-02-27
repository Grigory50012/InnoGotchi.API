using AutoMapper;
using InnoGotchi.API.Core.Contracts;
using InnoGotchi.API.Core.Entities.Models;
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

        public async Task<PetDto> GetPetAsync(Guid petId)
        {
            var pet = await _repository.Pet.GetPetAsync(petId, trackChanges: false);

            var petDto = _mapper.Map<PetDto>(pet);
            return petDto;
        }

        public async Task<PetDto> CreatePet(PetForCreationDto pet)
        {
            var petEntity = _mapper.Map<Pet>(pet);

            _repository.Pet.CreatePet(petEntity);
            await _repository.SaveAsync();

            var petDto = _mapper.Map<PetDto>(petEntity);
            return petDto;
        }
    }
}
