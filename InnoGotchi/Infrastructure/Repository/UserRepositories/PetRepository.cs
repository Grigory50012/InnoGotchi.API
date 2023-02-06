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

    }
}
