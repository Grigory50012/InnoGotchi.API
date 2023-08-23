using InnoGotchi.API.Core.Entities.Models;
using InnoGotchi.Infrastructure.Repository.Extensions.Utility;
using System.Linq.Dynamic.Core;

namespace InnoGotchi.Infrastructure.Repository.Extensions;

public static class RepositoryPetExtensions
{
    public static IQueryable<Pet> Sort(this IQueryable<Pet> pets, string orderByQueryString)
    {
        if (string.IsNullOrWhiteSpace(orderByQueryString))
            return pets.OrderBy(pet => pet.DaysOfHappiness);

        var orderQuery = OrderQueryBuilder.CreateOrderQuery<Pet>(orderByQueryString);

        if (string.IsNullOrWhiteSpace(orderQuery))
            return pets.OrderBy(e => e.DaysOfHappiness);

        return pets.OrderBy(orderQuery);
    }
}
