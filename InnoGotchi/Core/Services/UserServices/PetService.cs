using AutoMapper;
using InnoGotchi.API.Core.Contracts;
using InnoGotchi.API.Core.Entities.Models;
using InnoGotchi.API.Core.Services.Abstractions.UserServices;
using InnoGotchi.Core.Entities.DataTransferObject;
using InnoGotchi.Core.Entities.Exceptions.BadRequestException;
using InnoGotchi.Core.Entities.Exceptions.NotFoundExcrption;
using InnoGotchi.Core.Entities.RequestFeatures;
using Microsoft.AspNetCore.JsonPatch;

namespace InnoGotchi.API.Core.Services.UserServices;

internal sealed class PetService : IPetService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public PetService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(IEnumerable<PetDto> pets, MetaData metaData)> GetAllPetsAsync(PetParameters petParameters)
    {
        IsValidPetParameters(petParameters);

        var pets = await _repository.Pet.GetAllPetsAsync(petParameters, trackChanges: false);

        var petsDto = _mapper.Map<IEnumerable<PetDto>>(pets);

        return (pets: petsDto, metaData: pets.MetaData);
    }

    private void IsValidPetParameters(PetParameters petParameters)
    {
        if (!petParameters.ValidAgeRange)
            throw new MaxAgeRangeBadRequestException();

        if (!petParameters.ValidHungerLevelRange)
            throw new MaxHungerLevelRangeBadRequestException();

        if (!petParameters.ValidThirstyLevelRange)
            throw new MaxThirstyLevelRangeBadRequestException();
    }

    public async Task<PetDto> GetPetAsync(Guid petId)
    {
        var pet = await GetPetAndCheckIfItExistssAsync(petId, trackChanges: false);

        return _mapper.Map<PetDto>(pet);
    }

    public async Task<(PetForUpdateDto petToPatch, Pet pet)> GetPetForPatchAsync(Guid petId,
        JsonPatchDocument<PetForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            throw new PatchDocumentObjectIsNullBadRequestException();

        var pet = await GetPetAndCheckIfItExistssAsync(petId, trackChanges: true);

        var petToPatch = _mapper.Map<PetForUpdateDto>(pet);

        return (petToPatch, pet);
    }

    private async Task<Pet> GetPetAndCheckIfItExistssAsync(Guid id, bool trackChanges)
    {
        var pet = await _repository.Pet.GetPetAsync(id, trackChanges);

        if (pet is null)
            throw new PetNotFoundException(id);

        return pet;
    }

    public async Task<PetDto> CreatePetAsync(PetForCreationDto pet)
    {
        var petEntity = _mapper.Map<Pet>(pet);

        _repository.Pet.CreatePet(petEntity);

        await _repository.SaveAsync();

        return _mapper.Map<PetDto>(petEntity);
    }

    public async Task SaveChangesForPatchAsync(PetForUpdateDto petToPatch, Pet pet)
    {
        _mapper.Map(petToPatch, pet);

        await _repository.SaveAsync();
    }
}
