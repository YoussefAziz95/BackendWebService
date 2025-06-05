using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SD_MasterDataForeign : Migration
    {

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var hasher = new PasswordHasher<User>();
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Category] ON");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name", "ParentId", "CreatedBy", "CreatedDate", "IsActive", "IsDeleted", "IsSystem" },
                values: new object[,]
                {
                    { 1, "Engines", null, "System", DateTime.Now, true, false, true },
                    { 2, "Brakes", null, "System", DateTime.Now, true, false, true },
                    { 3, "Tires", null, "System", DateTime.Now, true, false, true },
                    { 4, "Lubricants", null, "System", DateTime.Now, true, false, true },
                    { 5, "Electronics", null, "System", DateTime.Now, true, false, true },
                    { 6, "Batteries", null, "System", DateTime.Now, true, false, true },
                    { 7, "Exhaust Systems", null, "System", DateTime.Now, true, false, true },
                    { 8, "Engine Parts", 1, "System", DateTime.Now, true, false, true },
                    { 9, "Brake Pads", 2, "System", DateTime.Now, true, false, true },
                    { 10, "Winter Tires", 3, "System", DateTime.Now, true, false, true },
                    { 11, "Motor Oil", 4, "System", DateTime.Now, true, false, true },
                    { 12, "Car Batteries", 6, "System", DateTime.Now, true, false, true }
                });
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Category] OFF");
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Service] ON");
            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "Id", "Name", "Description", "Code", "CategoryId", "CreatedBy", "CreatedDate", "IsActive", "IsDeleted", "IsSystem" },
                values: new object[,]
                {
                    { 1, "Engine Diagnosis","Engine Diagnosis", "ENG-DIAG-001", 1, "System", DateTime.Now, true, false, true },
                    { 2, "Oil Change","Oil Change", "LUB-OIL-002", 11, "System", DateTime.Now, true, false, true },
                    { 3, "Brake Pad Replace","Brake Pad Replacement", "BRK-PAD-003", 9, "System", DateTime.Now, true, false, true },
                    { 4, "Tire Rotation","Tire Rotation", "TIR-ROT-004", 3, "System", DateTime.Now, true, false, true },
                    { 5, "Battery Replace","Battery Replacement", "BAT-RPL-005", 12, "System", DateTime.Now, true, false, true },
                    { 6, "Exhaust System Ins","Exhaust System Inspection", "EXH-INSP-006", 7, "System", DateTime.Now, true, false, true },
                    { 7, "Winter Tire Instal","Winter Tire Installation", "WIN-TIR-007", 10, "System", DateTime.Now, true, false, true },
                    { 8, "Spark Plug Replace","Spark Plug Replacement", "ENG-SPK-008", 8, "System", DateTime.Now, true, false, true },
                    { 9, "ABS Diagnostics ","ABS Diagnostics", "BRK-ABS-009", 2, "System", DateTime.Now, true, false, true },
                    { 10,"Motor Oil Top", "Motor Oil Top-up", "LUB-MOT-010", 11, "System", DateTime.Now, true, false, true },
                    { 11,"Electrical Vault ", "Electrical Fault Repair", "ELE-FLT-011", 5, "System", DateTime.Now, true, false, true },
                    { 12,"High Performance ", "High Performance Engine Tuning", "ENG-TUNE-012", 8, "System", DateTime.Now, true, false, true }
                });

            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Service] OFF");

            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Users] ON");


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
                   { 10, "CTR0010", "John", "Doe", "jdoe", "JOHN.DOE", "john.doe@domain.com",
                    "JOHN.DOE@DOMAIN.COM", "1234567890", true, false, true, DateTime.Now, 1, "Customers", "Standard Customer", (int)RoleEnum.Customer, "System", null, null, true,
                    hasher.HashPassword(null, "User@123"), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), true, false, null, false, 0 },

                    { 11, "CTR0011", "Jane", "Smith", "janesmith", "JANE.SMITH", "jane.smith@domain.com",
                    "JANE.SMITH@DOMAIN.COM", "0987654321", true, false, true, DateTime.Now, 1, "Customers", "VIP Customer", (int)RoleEnum.Customer, "System", null, null, true,
                    hasher.HashPassword(null, "User@123"), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), true, false, null, false, 0 },

                    { 12, "CTR0012", "Adam", "Lee", "adamlee", "ADAM.LEE", "adam.lee@domain.com",
                    "ADAM.LEE@DOMAIN.COM", "1122334455", true, false, true, DateTime.Now, 1, "Customers", "Standard Customer", (int)RoleEnum.Customer, "System", null, null, true,
                    hasher.HashPassword(null, "User@123"), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), true, false, null, false, 0 },

                    { 13, "CTR0013", "Sara", "Connor", "saraconnor", "SARA.CONNOR", "sara.connor@domain.com",
                    "SARA.CONNOR@DOMAIN.COM", "2233445566", true, false, true, DateTime.Now, 1, "Customers", "Premium Member", (int)RoleEnum.Customer, "System", null, null, true,
                    hasher.HashPassword(null, "User@123"), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), true, false, null, false, 0 },

                    { 14, "CTR0014", "Michael", "Brown", "michaelbrown", "MICHAEL.BROWN", "michael.b@domain.com",
                    "MICHAEL.BROWN@DOMAIN.COM", "3564556677", true, false, true, DateTime.Now, 1, "Customers", "Frequent Buyer", (int)RoleEnum.Customer, "System", null, null, true,
                    hasher.HashPassword(null, "User@123"), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), true, false, null, false, 0 },

                    { 15, "CTR0015", "Emily", "Clark", "emilyclark", "EMILY.CLARK", "emily.c@domain.com",
                    "EMILY.C@DOMAIN.COM", "3344556677", true, false, true, DateTime.Now, 1, "Customers", "Occasional Buyer", (int)RoleEnum.Customer, "System", null, null, true,
                    hasher.HashPassword(null, "User@123"), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), true, false, null, false, 0 },

                    { 16, "CTR0016", "Daniel", "James", "danieljames", "DANIEL.JAMES", "daniel.j@domain.com",
                    "DANIEL.J@DOMAIN.COM", "4455667788", true, false, true, DateTime.Now, 1, "Customers", "New Customer", (int)RoleEnum.Customer, "System", null, null, true,
                    hasher.HashPassword(null, "User@123"), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), true, false, null, false, 0 },

                    { 17, "CTR0017", "Olivia", "King", "oliviaking", "OLIVIA.KING", "olivia.k@domain.com",
                    "OLIVIA.K@DOMAIN.COM", "5566778899", true, false, true, DateTime.Now, 1, "Customers", "VIP Customer", (int)RoleEnum.Customer, "System", null, null, true,
                    hasher.HashPassword(null, "User@123"), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), true, false, null, false, 0 },

                    { 18, "CTR0018", "Alex", "Reed", "alexreed", "ALEX.REED", "alex.r@domain.com",
                    "ALEX.R@DOMAIN.COM", "6677889900", true, false, true, DateTime.Now, 1, "Customers", "Standard Customer", (int)RoleEnum.Customer, "System", null, null, true,
                    hasher.HashPassword(null, "User@123"), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), true, false, null, false, 0 },

                    { 19, "CTR0019", "Linda", "Taylor", "lindataylor", "LINDA.TAYLOR", "linda.t@domain.com",
                    "LINDA.T@DOMAIN.COM", "7788990011", true, false, true, DateTime.Now, 1, "Customers", "Occasional Buyer", (int)RoleEnum.Customer, "System", null, null, true,
                    hasher.HashPassword(null, "User@123"), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), true, false, null, false, 0 },


                });

            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Users] OFF");


            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Customer] ON");
            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "UserId", "Role", "MFAEnabled", "Status" },
                values: new object[,]
                {
                    {1, 11, (int)RoleEnum.Customer,  false, (int)StatusEnum.New},
                    {2, 12, (int)RoleEnum.Customer,  false, (int)StatusEnum.New},
                    {3, 13, (int)RoleEnum.Customer,  false, (int)StatusEnum.New},
                    {4, 14, (int)RoleEnum.Customer,  false, (int)StatusEnum.New},
                    {5, 15, (int)RoleEnum.Customer,  false, (int)StatusEnum.New},
                    {6, 16, (int)RoleEnum.Customer,  false, (int)StatusEnum.New},
                    {7, 17, (int)RoleEnum.Customer,  false, (int)StatusEnum.New},
                    {8, 18, (int)RoleEnum.Customer,  false, (int)StatusEnum.New},
                    {9, 19, (int)RoleEnum.Customer,  false, (int)StatusEnum.New},
                });

            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Customer] OFF");



        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }

}