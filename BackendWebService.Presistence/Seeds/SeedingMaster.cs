using Application.Manager;
using BackendWebService.Persistence.Seeds;
using Persistence.Data;

namespace Presistence.Data.Seeds;

public static class SeedingMaster
{
    public static async Task SeedAsync(AppRoleManager roleManager,
                                       AppUserManager userManager,
                                       ApplicationDbContext dbContext)
    {
        await SeedDataBase.SeedAsync(userManager, roleManager, dbContext);
    }
}
