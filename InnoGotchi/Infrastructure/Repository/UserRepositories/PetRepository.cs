using InnoGotchi.API.Core.Contracts.Repositories;
using InnoGotchi.API.Core.Entities.Models;
using InnoGotchi.Core.Entities.RequestFeatures;
using InnoGotchi.Infrastructure.Repository.Extensions;
using Microsoft.EntityFrameworkCore;

namespace InnoGotchi.API.Infrastructure.Repository.UserRepositories;

public class PetRepository : RepositoryBase<Pet>, IPetRepository
{
    public PetRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public async Task<PagedList<Pet>> GetAllPetsAsync(PetParameters petParameters, bool trackChanges)
    {
        var pets = await FindByCondition(
            (pet => pet.DateOfBirth <= petParameters.MinDateOfBirth
                    && pet.DateOfBirth >= petParameters.MaxDateOfBirth
                    && pet.FeedingDate <= petParameters.MinFeedingDate
                    && pet.FeedingDate >= petParameters.MaxFeedingDate
                    && pet.DrinkingDate <= petParameters.MinDrinkingDate
                    && pet.DrinkingDate >= petParameters.MaxDrinkingDate), trackChanges)
            .Sort(petParameters.OrderBy)
            .Include(pet => pet.BodyParts)
            .ToListAsync();

        return PagedList<Pet>
            .ToPageList(pets, petParameters.PageNumber, petParameters.PageSize);
    }

    public async Task<Pet> GetPetAsync(Guid petId, bool trackChanges) =>
        await FindByCondition(pet => pet.PetId.Equals(petId), trackChanges)
        .Include(pet => pet.BodyParts)
        .SingleOrDefaultAsync();

    public void CreatePet(Pet pet)
    {
        RepositoryContext.Set<BodyPart>().AttachRange(pet.BodyParts);
        Create(pet);
    }
}
