using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SD_InsertUsers_UserClaims : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            // ===== 3. Insert Users =====
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Users] ON");

            var hasher = new PasswordHasher<object>();
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[]
                {
                "Id", "GeneratedCode", "FirstName", "LastName", "UserName", "NormalizedUserName",
                "Email", "NormalizedEmail", "PhoneNumber", "IsActive", "IsDeleted", "IsSystem",
                "CreatedDate", "OrganizationId", "Department", "Title", "MainRole", "CreatedBy",
                "UpdateDate", "UpdatedBy", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp",
                "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount"
                },
                values: new object[,]
                {
                {
                    1, "SYS0001", "System", "Admin", "sysadmin", "SYSADMIN", "sysadmin@domain.com", "SYSADMIN@DOMAIN.COM", "0100000000",
                    true, false, true, DateTime.UtcNow, 1, "IT", "Root Access", (int)RoleEnum.SuperAdmin, "System", null, null, true,
                    hasher.HashPassword(null, "P@ssw0rd"), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), true, false, null, false, 0
                },
                {
                    2, "SYS0002", "Youssef", "Samy", "youssefsamy", "YOUSSEFSAMY", "youssef@domain.com", "YOUSSEF@DOMAIN.COM", "0111111111",
                    true, false, true, DateTime.UtcNow, 1, "IT", "Owner", (int)RoleEnum.SuperAdmin, "System", null, null, true,
                    hasher.HashPassword(null, "P@ssw0rd"), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), true, false, null, false, 0
                },
                {
                    3, "USR0003", "Ethan", "Carter", "suppadmin", "SUPPADMIN", "suppadmin@dom.com", "SUPPADMIN@DOM.COM", "1234567891",
                    true, false, true, DateTime.UtcNow, 2, "Suppliers", "Supplier Admin", (int)RoleEnum.Admin, "System", null, null, true,
                    hasher.HashPassword(null, "P@ssw0rd"), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), true, false, null, false, 0
                },
                {
                    4, "USR0004", "Ava", "Smith", "supprep", "SUPPREP", "supprep@dom.com", "SUPPREP@DOM.COM", "1234567892",
                    true, false, true, DateTime.UtcNow, 2, "Sales", "Supplier Rep", (int)RoleEnum.Admin, "System", null, null, true,
                    hasher.HashPassword(null, "P@ssw0rd"), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), true, false, null, false, 0
                },
                {
                    5, "USR0005", "Noah", "Miller", "techlead", "TECHLEAD", "techlead@dom.com", "TECHLEAD@DOM.COM", "1234567893",
                    true, false, true, DateTime.UtcNow, 3, "Tech", "Lead Employee", (int)RoleEnum.Employee, "System", null, null, true,
                    hasher.HashPassword(null, "P@ssw0rd"), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), true, false, null, false, 0
                }
                }
            );

            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Users] OFF");

            // ===== 4. Insert UserRoles =====
            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                { 1, (int)RoleEnum.SuperAdmin },
                { 2, (int)RoleEnum.SuperAdmin },
                { 3, (int)RoleEnum.Admin },
                { 4, (int)RoleEnum.Admin },
                { 5, (int)RoleEnum.Employee }
                }
            );

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
