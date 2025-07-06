using Application.Contracts.AppManager;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Application.AppManager;
public class AppRoleManager : RoleManager<Role>, IAppRoleManager
{
    public AppRoleManager(IRoleStore<Role> store, IEnumerable<IRoleValidator<Role>> roleValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<RoleManager<Role>> logger) : base(store, roleValidators, keyNormalizer, errors, logger)
    {
    }
}