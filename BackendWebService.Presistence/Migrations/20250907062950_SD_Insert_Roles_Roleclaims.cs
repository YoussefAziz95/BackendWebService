using Domain.Constants;
using Domain.Enums;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SD_Insert_Roles_Roleclaims : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            // ===== 2. Insert Roles =====
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Role] ON");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "OrganizationId", "Name", "DisplayName", "NormalizedName", "ConcurrencyStamp", "ParentId", "IsSystem", "CreatedBy", "CreatedDate", "IsActive", "IsDeleted" },
                values: new object[,]
                {
                { (int)RoleEnum.SuperAdmin, (int)OrganizationEnum.Organization, "SuperAdmin", "SuperAdmin", "SUPERADMIN", Guid.NewGuid().ToString(), null, true, "System", DateTime.UtcNow, true, false },
                { (int)RoleEnum.Admin, (int)OrganizationEnum.Company, "Admin", "Admin", "ADMIN", Guid.NewGuid().ToString(), null, true, "System", DateTime.UtcNow, true, false },
                { (int)RoleEnum.Employee, (int)OrganizationEnum.Company, "Employee", "Employee", "EMPLOYEE", Guid.NewGuid().ToString(), null, true, "System", DateTime.UtcNow, true, false },
                { (int)RoleEnum.Customer, (int)OrganizationEnum.Company, "Customer", "Customer", "CUSTOMER", Guid.NewGuid().ToString(), null, true, "System", DateTime.UtcNow, true, false }
                }
            );

            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Role] OFF");

            // ===== 3. Insert Permissions =====
            InsertRoleClaims(migrationBuilder, RoleEnum.SuperAdmin, OrganizationEnum.Organization, PermissionConstants.GetAllPermissions());
            InsertRoleClaims(migrationBuilder, RoleEnum.Admin, OrganizationEnum.Company, PermissionConstants.GetCompanyPermissions());
            InsertRoleClaims(migrationBuilder, RoleEnum.Employee, OrganizationEnum.Company, PermissionConstants.GetEmployeePermissions());
            InsertRoleClaims(migrationBuilder, RoleEnum.Customer, OrganizationEnum.Company, PermissionConstants.GetCustomerPermissions());



        }
        private void InsertRoleClaims(MigrationBuilder migrationBuilder, RoleEnum role, OrganizationEnum org, string[] claims)
        {
            foreach (var claim in claims)
            {
                migrationBuilder.Sql($@"
                INSERT INTO [RoleClaim] 
                    ([RoleId], [ClaimType], [ClaimValue], [OrganizationId], [CreatedDate], [CreatedBy], [IsActive], [IsDeleted], [IsSystem]) 
                VALUES 
                    ({(int)role}, '{claim}', '{claim}', {(int)org}, '{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}', 'System', 1, 0, 1)
            ");
            }
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Clean UserRole and Users first
            migrationBuilder.Sql("DELETE FROM [UserRole] WHERE UserId IN (1,2,3,4,5)");
            migrationBuilder.Sql("DELETE FROM [Users] WHERE Id IN (1,2,3,4,5)");

            // Clean RoleClaims
            foreach (var claim in PermissionConstants.GetAllPermissions())
            {
                migrationBuilder.Sql($@"DELETE FROM [RoleClaim] WHERE [ClaimType] = '{claim}'");
            }

            // Clean Roles
            migrationBuilder.Sql($"DELETE FROM [Role] WHERE Id IN ({(int)RoleEnum.SuperAdmin},{(int)RoleEnum.Admin},{(int)RoleEnum.Employee},{(int)RoleEnum.Customer})");
        }

    }
}
