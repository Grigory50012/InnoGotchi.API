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

    public async Task<FarmDto> GetFarmAsync(Guid farmId)
    {
        var farm = await GetFarmAndCheckIfItExistssAsync(farmId);

        return _mapper.Map<FarmDto>(farm);
    }

    private async Task<Farm> GetFarmAndCheckIfItExistssAsync(Guid id)
    {
        var farm = await _repository.Farm.GetFarmAsync(id, trackChanges: true);

        if (farm is null)
            throw new FarmNotFoundException(id);

        return farm;
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

        return _mapper.Map<IEnumerable<FarmDto>>(farms); 
    }

    public async Task<FarmDto> CreateFarmAsync(FarmForCreationDto farm)
    {
        var farmEntity = _mapper.Map<Farm>(farm);
        
        _repository.Farm.CreateFarm(farmEntity);

        await _repository.SaveAsync();

        return _mapper.Map<FarmDto>(farmEntity);
    }
}
