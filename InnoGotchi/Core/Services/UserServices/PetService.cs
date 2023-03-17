using AutoMapper;
using InnoGotchi.API.Core.Contracts;
using InnoGotchi.API.Core.Entities.Models;
using InnoGotchi.API.Core.Services.Abstractions.UserServices;
using InnoGotchi.Core.Entities.DataTransferObject;
using InnoGotchi.Core.Entities.Exceptions;

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

        private async Task<Pet> GetPetAndCheckIfItExistssAsync(Guid id, bool trackChanges)
        {
            var pet = await _repository.Pet.GetPetAsync(id, trackChanges: true);
            if (pet is null)
                throw new PetNotFoundException(id);
            return pet;
        }

        public async Task<PetDto> GetPetAsync(Guid petId)
        {
            var pet = await GetPetAndCheckIfItExistssAsync(petId, trackChanges: false);

            var petDto = _mapper.Map<PetDto>(pet);
            return petDto;
        }

        public async Task<PetDto> CreatePetAsync(PetForCreationDto pet)
        {
            var petEntity = _mapper.Map<Pet>(pet);

            _repository.Pet.CreatePet(petEntity);
            await _repository.SaveAsync();

            var petDto = _mapper.Map<PetDto>(petEntity);
            return petDto;
        }

        public async Task<(PetForUpdateDto petToPatch, Pet pet)> GetPetForPatchAsync(Guid petId)
        {
            var pet = await GetPetAndCheckIfItExistssAsync(petId, trackChanges: true);

            var petToPatch = _mapper.Map<PetForUpdateDto>(pet);

            return (petToPatch, pet);
        }

        public async Task SaveChangesForPatchAsync(PetForUpdateDto petToPatch, Pet pet)
        {
            _mapper.Map(petToPatch, pet);

            await _repository.SaveAsync();
        }

    }
}
