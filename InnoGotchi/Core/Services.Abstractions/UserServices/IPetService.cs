﻿using InnoGotchi.Core.Entities.DataTransferObject;

namespace InnoGotchi.API.Core.Services.Abstractions.UserServices
{
    public interface IPetService
    {
        Task<IEnumerable<PetDto>> GetAllPetsAsync();
    }
}