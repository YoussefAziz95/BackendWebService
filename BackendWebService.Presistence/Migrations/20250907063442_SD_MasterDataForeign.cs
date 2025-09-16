using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json.Linq;

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
                columns: new[] { "Id", "FileId", "Name", "ParentId", "CreatedBy", "CreatedDate", "IsActive", "IsDeleted", "IsSystem" },
                values: new object[,]
                {
                    { 1, 1,"Engines", null, "System", DateTime.Now, true, false, true },
                    { 2, 1,"Brakes", null, "System", DateTime.Now, true, false, true },
                    { 3, 1,"Tires", null, "System", DateTime.Now, true, false, true },
                    { 4, 1,"Lubricants", null, "System", DateTime.Now, true, false, true },
                    { 5, 1,"Electronics", null, "System", DateTime.Now, true, false, true },
                    { 6, 1,"Batteries", null, "System", DateTime.Now, true, false, true },
                    { 7, 1,"Exhaust Systems", null, "System", DateTime.Now, true, false, true },
                    { 8, 1,"Engine Parts", 1, "System", DateTime.Now, true, false, true },
                    { 9, 1,"Brake Pads", 2, "System", DateTime.Now, true, false, true },
                    { 10, 1,"Winter Tires", 3, "System", DateTime.Now, true, false, true },
                    { 11, 1,"Motor Oil", 4, "System", DateTime.Now, true, false, true },
                    { 12, 1,"Car Batteries", 6, "System", DateTime.Now, true, false, true }
                });
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Category] OFF");

            // Enable IDENTITY_INSERT for Company table
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Company] ON");
            migrationBuilder.InsertData(
            table: "Company",
               columns: new[] { "Id", "OrganizationId", "CompanyName", "RegistrationNumber", "ContactEmail", "ContactPhone", "Status", "CreatedBy", "CreatedDate", "IsActive", "IsDeleted", "IsSystem" },
               values: new object[,]
               {
                    { 1, 3,"Turbo Engines Ltd.", "REG123456", "info@domain.net", "321-456-789", (int)StatusEnum.Active, "System", DateTime.Now, true, false, true },
                    { 2, 4, "Elite Brake Systems", "REG789012", "support@domain.net", "123-456-789", (int)StatusEnum.Active, "System", DateTime.Now, true, false, true }
               });

            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Company] OFF");
            // Enable IDENTITY_INSERT for Supplier table
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Supplier] ON");

            migrationBuilder.InsertData(
                table: "Supplier",
                columns: new[] { "Id", "OrganizationId", "Rating", "BankAccount", "Status", "CreatedBy", "CreatedDate", "IsActive", "IsDeleted", "IsSystem" },
                values: new object[,]
                {
                    { 1, 5, 4.5m, "IBAN1234567890", (int)StatusEnum.Active, "System", DateTime.Now, true, false, true },
                    { 2, 6, 4.2m, "IBAN2345678901", (int)StatusEnum.Active, "System", DateTime.Now, true, false, true },
                    { 3, 7, 4.8m, "IBAN3456789012", (int)StatusEnum.Active, "System", DateTime.Now, true, false, true },
                    { 4, 8, 4.0m, "IBAN4567890123", (int)StatusEnum.Active, "System", DateTime.Now, true, false, true },
                    { 5, 9, 4.7m, "IBAN5678901234", (int)StatusEnum.Active, "System", DateTime.Now, true, false, true },
                    { 6, 10, 4.3m, "IBAN6789012345", (int)StatusEnum.Active, "System", DateTime.Now, true, false, true }
                });

            // Disable IDENTITY_INSERT for Supplier table
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Supplier] OFF");

            // Enable IDENTITY_INSERT for SupplierCategory table
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[SupplierCategory] ON");

            migrationBuilder.InsertData(
                table: "SupplierCategory",
                columns: new[] { "Id", "SupplierId", "CategoryId", "CreatedBy", "CreatedDate", "IsActive", "IsDeleted", "IsSystem" },
                values: new object[,]
                {
                    { 1, 1, 3, "System", DateTime.Now, true, false, true }, // Titan Tires Co. -> Tires
                    { 2, 1, 10, "System", DateTime.Now, true, false, true }, // Titan Tires Co. -> Winter Tires
                    { 3, 2, 4, "System", DateTime.Now, true, false, true }, // Speedy Lubricants -> Lubricants
                    { 4, 2, 11, "System", DateTime.Now, true, false, true }, // Speedy Lubricants -> Motor Oil
                    { 5, 3, 6, "System", DateTime.Now, true, false, true }, // EcoAuto Batteries -> Batteries
                    { 6, 3, 12, "System", DateTime.Now, true, false, true }, // EcoAuto Batteries -> Car Batteries
                    { 7, 4, 7, "System", DateTime.Now, true, false, true }, // Global Exhaust Solutions -> Exhaust Systems
                    { 8, 5, 5, "System", DateTime.Now, true, false, true }, // CarTech Electronics -> Electronics
                    { 9, 6, 5, "System", DateTime.Now, true, false, true }  // Global Electronics -> Electronics
                });

            // Disable IDENTITY_INSERT for SupplierCategory table
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[SupplierCategory] OFF");


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
                    "UpdatedDate", "UpdatedBy", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp",
                    "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount"
                },
                values: new object[,]
                {
                    { 10, "CTR0010", "John", "Doe", "jdoe", "JDOE", "john.doe@domain.com",
                      "JOHN.DOE@DOMAIN.COM", "1234567890", true, false, true, DateTime.Now, 1, "Customers", "Standard Customer", (int)RoleEnum.Customer, "System", null, null, true,
                      hasher.HashPassword(null, "User@123"), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), true, false, null, false, 0 },

                    { 11, "CTR0011", "Jane", "Smith", "janesmith", "JANESMITH", "jane.smith@domain.com",
                      "JANE.SMITH@DOMAIN.COM", "0987654321", true, false, true, DateTime.Now, 1, "Customers", "VIP Customer", (int)RoleEnum.Customer, "System", null, null, true,
                      hasher.HashPassword(null, "User@123"), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), true, false, null, false, 0 },

                    { 12, "CTR0012", "Adam", "Lee", "adamlee", "ADAMLEE", "adam.lee@domain.com",
                      "ADAM.LEE@DOMAIN.COM", "1122334455", true, false, true, DateTime.Now, 1, "Customers", "Standard Customer", (int)RoleEnum.Customer, "System", null, null, true,
                      hasher.HashPassword(null, "User@123"), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), true, false, null, false, 0 },

                    { 13, "CTR0013", "Sara", "Connor", "saraconnor", "SARACONNOR", "sara.connor@domain.com",
                      "SARA.CONNOR@DOMAIN.COM", "2233445566", true, false, true, DateTime.Now, 1, "Customers", "Premium Member", (int)RoleEnum.Customer, "System", null, null, true,
                      hasher.HashPassword(null, "User@123"), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), true, false, null, false, 0 },

                    { 14, "CTR0014", "Michael", "Brown", "michaelbrown", "MICHAELBROWN", "michael.b@domain.com",
                      "MICHAEL.B@DOMAIN.COM", "3564556677", true, false, true, DateTime.Now, 1, "Customers", "Frequent Buyer", (int)RoleEnum.Customer, "System", null, null, true,
                      hasher.HashPassword(null, "User@123"), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), true, false, null, false, 0 },

                    { 15, "CTR0015", "Emily", "Clark", "emilyclark", "EMILYCLARK", "emily.c@domain.com",
                      "EMILY.C@DOMAIN.COM", "3344556677", true, false, true, DateTime.Now, 1, "Customers", "Occasional Buyer", (int)RoleEnum.Customer, "System", null, null, true,
                      hasher.HashPassword(null, "User@123"), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), true, false, null, false, 0 },

                    { 16, "CTR0016", "Daniel", "James", "danieljames", "DANIELJAMES", "daniel.j@domain.com",
                      "DANIEL.J@DOMAIN.COM", "4455667788", true, false, true, DateTime.Now, 1, "Customers", "New Customer", (int)RoleEnum.Customer, "System", null, null, true,
                      hasher.HashPassword(null, "User@123"), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), true, false, null, false, 0 },

                    { 17, "CTR0017", "Olivia", "King", "oliviaking", "OLIVIAKING", "olivia.k@domain.com",
                      "OLIVIA.K@DOMAIN.COM", "5566778899", true, false, true, DateTime.Now, 1, "Customers", "VIP Customer", (int)RoleEnum.Customer, "System", null, null, true,
                      hasher.HashPassword(null, "User@123"), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), true, false, null, false, 0 },

                    { 18, "CTR0018", "Alex", "Reed", "alexreed", "ALEXREED", "alex.r@domain.com",
                      "ALEX.R@DOMAIN.COM", "6677889900", true, false, true, DateTime.Now, 1, "Customers", "Standard Customer", (int)RoleEnum.Customer, "System", null, null, true,
                      hasher.HashPassword(null, "User@123"), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), true, false, null, false, 0 },

                    { 19, "CTR0019", "Linda", "Taylor", "lindataylor", "LINDATAYLOR", "linda.t@domain.com",
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