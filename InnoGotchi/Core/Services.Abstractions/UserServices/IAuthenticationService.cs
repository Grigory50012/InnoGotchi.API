﻿using InnoGotchi.Core.Entities.DataTransferObject;
using Microsoft.AspNetCore.Identity;

namespace InnoGotchi.Core.Services.Abstractions.UserServices;

public interface IAuthenticationService
{
    Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
}