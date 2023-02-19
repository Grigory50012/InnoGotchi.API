﻿using AutoMapper;
using InnoGotchi.API.Core.Contracts;
using InnoGotchi.API.Core.Entities.Models;
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
    }
}
