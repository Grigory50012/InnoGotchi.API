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
            CreateMap<PetForCreationDto, Pet>();

            CreateMap<BodyPart, BodyPartDto>();

            CreateMap<Farm, FarmDto>();
            CreateMap<FarmForCreationDto, Farm>();

            CreateMap<Collaboration, CollaborationDto>();
            CreateMap<CollaborationForCreationDto, Collaboration>();
        }
    }
}
