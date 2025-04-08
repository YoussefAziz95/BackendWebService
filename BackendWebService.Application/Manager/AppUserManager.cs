using Application.DTOs.Users;
using AutoMapper;
using BackendWebService.Application.Contracts.Manager;
using Contracts.Services;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace Application.Manager;

public class AppUserManager : UserManager<User>, IAppUserManager
{
    private readonly IMapper _mapper;
    public AppUserManager(IUserStore<User> store, 
        IOptions<IdentityOptions> optionsAccessor, 
        IPasswordHasher<User> passwordHasher, 
        IEnumerable<IUserValidator<User>> userValidators, 
        IEnumerable<IPasswordValidator<User>> passwordValidators, 
        ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, 
        IServiceProvider services, ILogger<UserManager<User>> logger,
        IMapper mapper) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
    {
        _mapper = mapper;
    }

    public  Task<IdentityResult> CreateAsync(CreateUserWithPasswordRequest request)
    {
        var user = _mapper.Map<User>(request);
        return CreateAsync(user, request.Password);
    }

}
