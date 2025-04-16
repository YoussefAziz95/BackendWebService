using Application.Contracts.Manager;
using Application.DTOs;
using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Application.Manager;

public class AppUserManager : UserManager<User>, IAppUserManager
{
    public AppUserManager(IUserStore<User> store,
        IOptions<IdentityOptions> optionsAccessor,
        IPasswordHasher<User> passwordHasher,
        IEnumerable<IUserValidator<User>> userValidators,
        IEnumerable<IPasswordValidator<User>> passwordValidators,
        ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors,
        IServiceProvider services, ILogger<UserManager<User>> logger) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
    {
    }

    public Task<IdentityResult> CreateAsync(CreateUserWithPasswordRequest request)
    {
        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            UserName = request.Email.Split('@')[0].ToLower(),
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            Department = request.Department,
            Title = request.Title,
            MainRole = Enum.Parse<RoleEnum>(request.MainRole, true)
        };
        return CreateAsync(user, request.Password);
    }

}
