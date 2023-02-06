using AutoMapper;
using InnoGotchi.API.Core.Entities.Models;
using InnoGotchi.Core.Entities.DataTransferObject;

namespace InnoGotchi.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Pet, PetDto>();

            CreateMap<BodyPart, BodyPartDto>();
        }
    }
}
