using AutoMapper;
using InnoGotchi.API.Core.Contracts;
using InnoGotchi.API.Core.Services.Abstractions.UserServices;
using InnoGotchi.Core.Entities.DataTransferObject;

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

        public async Task<FarmDto> GetFarmAsync(Guid farmId)
        {
            var farm = await _repository.Farm.GetFarmAsync(farmId, trackChanges: false);

            var farmDto = _mapper.Map<FarmDto>(farm);
            return farmDto;
        }
    }
}
