using Application.Manager;
using Domain;
using Domain;
using Domain.Constants;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System.Data;


namespace Persistence.Seeds;


public static class SeedDataBase 
{
    public static async Task SeedAsync(AppUserManager userManager, AppRoleManager roleManager, ApplicationDbContext dbContext)
    {
       

        using (var transaction = dbContext.Database.BeginTransaction())
        {
            Role role = new Role
            {
                Id = (int)RoleEnum.SuperAdmin,
                OrganizationId = (int)OrganizationEnum.Organization,
                Name = Enum.GetName<RoleEnum>(RoleEnum.SuperAdmin),
                DisplayName = Enum.GetName<RoleEnum>(RoleEnum.SuperAdmin),
                CreatedBy = "System",
            };
            var roleClaim = PermissionConstants.GetBasePermissions();
            var user0 = await userManager.FindByEmailAsync("maziz@domain.com");
            var user1 = await userManager.FindByEmailAsync("Yaziz@domain.com");
            try
            {
                if (!roleManager.Roles.AsNoTracking().Any(r => r.Name.Equals(Enum.GetName<RoleEnum>(RoleEnum.SuperAdmin))))
                {
                    dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Role ON");
                    await roleManager.CreateAsync(role);
                    await dbContext.SaveChangesAsync();
                    foreach(var claim in roleClaim)
                    {
                        await roleManager.AddClaimAsync(role, claim);
                    }
                    await dbContext.SaveChangesAsync();
                    dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Role OFF");
                }

                dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Users ON");
                if (user0 is null)
                {
                    user0 = new User()
                    {
                        Id = 1,
                        UserName = "maziz",
                        Email = "maziz@domain.com",
                        FirstName = "Super",
                        LastName = "Admin",
                        OrganizationId = null,
                        Department = "Administration",
                        Title = "Super Admin",
                        MainRole = RoleEnum.SuperAdmin,
                        CreatedBy = "System",
                        PhoneNumber = "1234567890",
                    }; 
                    var result = await userManager.CreateAsync(user0, "P@ssw0rd");
                    await dbContext.SaveChangesAsync();
                }
               
                if (user1 is null)
                {
                    user1 = new User()
                    {
                        Id = 2,
                        UserName = "YAziz",
                        Email = "Yaziz@domain.com",
                        FirstName = "Organization",
                        LastName = "Admin",
                        OrganizationId = null,
                        Department = "Administration",
                        Title = "Admin",
                        MainRole = RoleEnum.SuperAdmin,
                        CreatedBy = "System",
                        PhoneNumber = "1234567890",
                    };
                    await userManager.CreateAsync(user1, "P@ssw0rd");
                    await dbContext.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                transaction.Rollback();
            }
            finally
            {
                dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Users OFF");
                dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Role OFF");
            }
            transaction.Commit();
            await userManager.AddToRoleAsync(user0, role.Name);
            await userManager.AddToRoleAsync(user1, role.Name);
        }
    }
}