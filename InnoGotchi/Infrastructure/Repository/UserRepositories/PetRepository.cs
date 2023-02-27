using InnoGotchi.API.Core.Contracts.Repositories;
using InnoGotchi.API.Core.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace InnoGotchi.API.Infrastructure.Repository.UserRepositories
{
    public class PetRepository : RepositoryBase<Pet>, IPetRepository
    {
        public PetRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public async Task<IEnumerable<Pet>> GetAllPetsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(pet => pet.DaysOfHappiness)
            .Include(pet => pet.BodyParts)
            .ToListAsync();

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
}
