using AutoMapper;
using InnoGotchi.API.Core.Contracts;
using InnoGotchi.API.Core.Services.Abstractions.UserServices;
using InnoGotchi.Core.Entities.DataTransferObject;

namespace InnoGotchi.API.Core.Services.UserServices
{
    internal sealed class BodyPartService : IBodyPartService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public BodyPartService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BodyPartDto>> GetBodyPartsAsync()
        {
            var bodyParts = await _repository.BodyPart.GetBodyPartsAsync(trackChanges: false);

            var bodyPartsDto = _mapper.Map<IEnumerable<BodyPartDto>>(bodyParts);
            return bodyPartsDto;
        }
    }
}
