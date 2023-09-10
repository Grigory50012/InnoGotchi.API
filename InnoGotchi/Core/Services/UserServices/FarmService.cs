using AutoMapper;
using InnoGotchi.API.Core.Contracts;
using InnoGotchi.API.Core.Entities.Models;
using InnoGotchi.API.Core.Services.Abstractions.UserServices;
using InnoGotchi.Core.Entities.DataTransferObject;
using InnoGotchi.Core.Entities.Exceptions.NotFoundExcrption;

namespace InnoGotchi.API.Core.Services.UserServices;

internal sealed class FarmService : IFarmService
{
    private readonly IRepositoryManager _repository;
    private readonly IMapper _mapper;

    public FarmService(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    private async Task<Farm> GetFarmAndCheckIfItExistssAsync(Guid id, bool trackChanges)
    {
        var farm = await _repository.Farm.GetFarmAsync(id, trackChanges: true);
        if (farm is null)
            throw new FarmNotFoundException(id);
        return farm;
    }

    public async Task<FarmDto> GetFarmAsync(Guid farmId)
    {
        var farm = await GetFarmAndCheckIfItExistssAsync(farmId, trackChanges: false);

        var farmDto = _mapper.Map<FarmDto>(farm);
        return farmDto;
    }

    public async Task<IEnumerable<FarmDto>> GetCollaborationFarmsAsync(Guid userId)
    {
        var collaborations = await _repository.Collaboration.GetCollaborationAsync(userId, trackChanges: false);

        var farms = new List<Farm>();

        foreach (var collaboration in collaborations)
        {
            var farm = await _repository.Farm.GetFarmAsync(collaboration.FarmId, trackChanges: false);
            farms.Add(farm);
        }

        var farmsDto = _mapper.Map<IEnumerable<FarmDto>>(farms);
        return farmsDto;
    }

    public async Task<FarmDto> CreateFarmAsync(FarmForCreationDto farm)
    {
        var farmEntity = _mapper.Map<Farm>(farm);
        
        _repository.Farm.CreateFarm(farmEntity);
        await _repository.SaveAsync();

        var farmDto = _mapper.Map<FarmDto>(farmEntity);
        return farmDto;
    }
}
