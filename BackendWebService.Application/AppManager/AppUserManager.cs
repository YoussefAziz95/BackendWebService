using Application.Contracts.AppManager;
using Application.Contracts.Persistence;
using Application.Features;
using Dapper;
using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Data;
namespace Application.AppManager;

public class AppUserManager : UserManager<User>, IAppUserManager
{
    private readonly ISP_Call _sp_call;
    public AppUserManager(IUserStore<User> store,
        IOptions<IdentityOptions> optionsAccessor,
        IPasswordHasher<User> passwordHasher,
        IEnumerable<IUserValidator<User>> userValidators,
        IEnumerable<IPasswordValidator<User>> passwordValidators,
        ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors,
        IServiceProvider services, ILogger<UserManager<User>> logger,
        ISP_Call sP_Call) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
    {
        _sp_call = sP_Call;
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

    public Task<User?> FindByPhoneNumberAsync(string phoneNumber)
    {
        return Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
    }

    public async Task<IdentityResult> ConfirmPhoneNumberAsync(User user)
    {
        user.EmailConfirmed = true;
        user.PhoneNumberConfirmed = true;
        return await UpdateAsync(user);
    }
    public async Task<IEnumerable<UserPagesResponse>> GetUserPages(int id)
    {
        var dbParams = new DynamicParameters();
        dbParams.Add("@UserId ", id, DbType.Int32);
        var responses = _sp_call.List<UserPagesResponse>("dbo.sp_GetUserPages", dbParams);
        return responses.AsEnumerable();
    }


}
