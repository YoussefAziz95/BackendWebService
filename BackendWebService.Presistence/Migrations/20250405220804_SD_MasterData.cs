using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendWebService.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SD_MasterData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var hasher = new PasswordHasher<User>();
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[AspNetRoles] ON");

            migrationBuilder.InsertData(
            table: "AspNetRoles",
            columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp", "ParentId", "IsSystem", "CreatedBy", "CreatedDate", "IsActive", "IsDeleted" },
            values: new object[,]
            {
                    { (int)RoleEnum.SuperAdmin, Enum.GetName(typeof(RoleEnum), RoleEnum.SuperAdmin), "SUPERADMIN", null, null, true, "System", DateTime.Now, true, false },
                    { (int)RoleEnum.Admin, Enum.GetName(typeof(RoleEnum), RoleEnum.Admin), "ADMIN", null, null, true, "System", DateTime.Now, true, false },
                    { (int)RoleEnum.Technician, Enum.GetName(typeof(RoleEnum), RoleEnum.Technician), "TECHNICIAN", null, null, true, "System", DateTime.Now, true, false },
                    { (int)RoleEnum.Customer, Enum.GetName(typeof(RoleEnum), RoleEnum.Customer), "CUSTOMER", null, null, true, "System", DateTime.Now, true, false }
            });

            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[AspNetRoles] OFF");
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[AspNetRoleClaims] ON");



            migrationBuilder.InsertData(
            table: "AspNetRoleClaims",
            columns: new[] { "Id", "RoleId", "ClaimType", "ClaimValue", "CreatedBy", "CreatedDate", "IsActive", "IsDeleted", "IsSystem" },
            values: new object[,]
            {
                    { 1, "1", "permission", "Users.Menu.Permissions.View",  "System", DateTime.Now, true, false, true},
                    { 2, "1", "permission", "Users.Menu.User.View",  "System", DateTime.Now, true, false, true},
                    { 3, "1", "permission", "Users.Button.User.Get",  "System", DateTime.Now, true, false, true},
                    { 4, "1", "permission", "Users.Button.User.Create",  "System", DateTime.Now, true, false, true},
                    { 5, "1", "permission", "Users.Button.User.Edit",  "System", DateTime.Now, true, false, true},
                    { 6, "1", "permission", "Users.Button.User.Delete",  "System", DateTime.Now, true, false, true},
                    { 7, "1", "permission", "Users.Menu.Role.View",  "System", DateTime.Now, true, false, true},
                    { 8, "1", "permission", "Users.Button.Role.Get",  "System", DateTime.Now, true, false, true},
                    { 9, "1", "permission", "Users.Button.Role.Create",  "System", DateTime.Now, true, false, true},
                    { 10, "1", "permission", "Users.Button.Role.Edit",  "System", DateTime.Now, true, false, true},
                    { 11, "1", "permission", "Users.Button.Role.Delete",  "System", DateTime.Now, true, false, true},
                    { 12, "1", "permission", "Organization.Menu.Category.View",  "System", DateTime.Now, true, false, true},
                    { 13, "1", "permission", "Organization.Button.Category.Get",  "System", DateTime.Now, true, false, true},
                    { 14, "1", "permission", "Organization.Button.Category.Create",  "System", DateTime.Now, true, false, true},
                    { 15, "1", "permission", "Organization.Button.Category.Edit",  "System", DateTime.Now, true, false, true},
                    { 16, "1", "permission", "Organization.Button.Category.Delete",  "System", DateTime.Now, true, false, true},
                    { 17, "1", "permission", "Organization.Button.Category.Title",  "System", DateTime.Now, true, false, true},
                    { 18, "1", "permission", "Organization.Category.MultiSelect",  "System", DateTime.Now, true, false, true},
                    { 19, "1", "permission", "Organization.Category.View",  "System", DateTime.Now, true, false, true},
                    { 20, "1", "permission", "Organization.Menu.PreDocuments.View",  "System", DateTime.Now, true, false, true},
                    { 21, "1", "permission", "Organization.Button.PreDocuments.Get",  "System", DateTime.Now, true, false, true},
                    { 22, "1", "permission", "Organization.Button.PreDocuments.Create",  "System", DateTime.Now, true, false, true},
                    { 23, "1", "permission", "Organization.Button.PreDocuments.Edit",  "System", DateTime.Now, true, false, true},
                    { 24, "1", "permission", "Organization.Button.PreDocuments.Delete",  "System", DateTime.Now, true, false, true},
                    { 25, "1", "permission", "Company.Menu.Company.View",  "System", DateTime.Now, true, false, true},
                    { 26, "1", "permission", "Company.Button.Company.Get",  "System", DateTime.Now, true, false, true},
                    { 27, "1", "permission", "Company.Button.Company.Create",  "System", DateTime.Now, true, false, true},
                    { 28, "1", "permission", "Company.Button.Company.Edit",  "System", DateTime.Now, true, false, true},
                    { 29, "1", "permission", "Company.Button.Company.Delete",  "System", DateTime.Now, true, false, true},
                    { 30, "1", "permission", "Suppliers.Menu.Supplier.View",  "System", DateTime.Now, true, false, true},
                    { 31, "1", "permission", "Suppliers.Button.Supplier.Get",  "System", DateTime.Now, true, false, true},
                    { 32, "1", "permission", "Suppliers.Button.Supplier.Create",  "System", DateTime.Now, true, false, true},
                    { 33, "1", "permission", "Suppliers.Button.Supplier.Edit",  "System", DateTime.Now, true, false, true},
                    { 34, "1", "permission", "Suppliers.Button.Supplier.Delete",  "System", DateTime.Now, true, false, true},
                    { 35, "1", "permission", "Suppliers.Menu.SupplierDocument.View",  "System", DateTime.Now, true, false, true},
                    { 36, "1", "permission", "Suppliers.Button.SupplierDocument.Create",  "System", DateTime.Now, true, false, true},
                    { 37, "1", "permission", "Suppliers.Button.SupplierDocument.Get",  "System", DateTime.Now, true, false, true},
                    { 38, "1", "permission", "Suppliers.Button.SupplierDocument.Edit",  "System", DateTime.Now, true, false, true},
                    { 39, "1", "permission", "Offers.Menu.Service.View",  "System", DateTime.Now, true, false, true},
                    { 40, "1", "permission", "Offers.Button.Service.Get",  "System", DateTime.Now, true, false, true},
                    { 41, "1", "permission", "Offers.Button.Service.Create",  "System", DateTime.Now, true, false, true},
                    { 42, "1", "permission", "Offers.Button.Service.Edit",  "System", DateTime.Now, true, false, true},
                    { 43, "1", "permission", "Offers.Button.Service.Delete",  "System", DateTime.Now, true, false, true},
                    { 44, "1", "permission", "Offers.Menu.Workflow.View",  "System", DateTime.Now, true, false, true},
                    { 45, "1", "permission", "Offers.Button.Workflow.Get",  "System", DateTime.Now, true, false, true},
                    { 46, "1", "permission", "Offers.Button.Workflow.Create",  "System", DateTime.Now, true, false, true},
                    { 47, "1", "permission", "Offers.Button.Workflow.Edit",  "System", DateTime.Now, true, false, true},
                    { 48, "1", "permission", "Offers.Button.Workflow.Delete",  "System", DateTime.Now, true, false, true},
                    { 49, "1", "permission", "Offers.Menu.Action.View",  "System", DateTime.Now, true, false, true},
                    { 50, "1", "permission", "Offers.Button.Action.Get",  "System", DateTime.Now, true, false, true},
                    { 51, "1", "permission", "Offers.Button.Action.Create",  "System", DateTime.Now, true, false, true},
                    { 52, "1", "permission", "Offers.Button.Action.Edit",  "System", DateTime.Now, true, false, true},
                    { 53, "1", "permission", "Offers.Button.Action.Delete",  "System", DateTime.Now, true, false, true},
                    { 54, "1", "permission", "Offers.Offer.Deal.Create",  "System", DateTime.Now, true, false, true},
                    { 55, "1", "permission", "Offers.Button.Deal.View",  "System", DateTime.Now, true, false, true},
                    { 56, "1", "permission", "Offers.Button.Deal.Get",  "System", DateTime.Now, true, false, true},
                    { 57, "1", "permission", "Offers.Button.Deal.Create",  "System", DateTime.Now, true, false, true},
                    { 58, "1", "permission", "Offers.Button.Deal.Edit",  "System", DateTime.Now, true, false, true},
                    { 59, "1", "permission", "Offers.Button.Deal.Delete",  "System", DateTime.Now, true, false, true},
                    { 60, "1", "permission", "Offers.Menu.Offer.View",  "System", DateTime.Now, true, false, true},
                    { 61, "1", "permission", "Offers.Button.Offer.Get",  "System", DateTime.Now, true, false, true},
                    { 62, "1", "permission", "Offers.Button.Offer.Create",  "System", DateTime.Now, true, false, true},
                    { 63, "1", "permission", "Offers.Button.Offer.Edit",  "System", DateTime.Now, true, false, true},
                    { 64, "1", "permission", "Offers.Button.Offer.Delete",  "System", DateTime.Now, true, false, true},
                    { 65, "1", "permission", "Offers.Button.Category.Title",  "System", DateTime.Now, true, false, true},
                    { 66, "1", "permission", "Offers.Button.Category.MultiSelect",  "System", DateTime.Now, true, false, true},
                 
                // Add more claims as needed
                });
            // Seed Organizations data

            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Organization] ON");
            migrationBuilder.InsertData(
                table: "Organization",
                columns: new[]
                {"Id", "Type", "Name", "TaxNo", "Email", "Phone", "FaxNo", "CreatedBy", "CreatedDate", "IsActive","IsDeleted", "IsSystem", "Country", "City", "StreetAddress"},

                values: new object[,]
                {
                    { 1, (int)OrganizationEnum.Administrator ,"AutoParts Global", "321456789", "info@intX.net", "321-456-789","321456789",  "System", DateTime.Now, true, false, true,"USA", "Detroit", "123 Motorway Ave" },
                    { 2, (int)OrganizationEnum.Company ,"Turbo Engines Ltd.", "321456789", "info@intX.net", "321-456-789","321456789",  "System", DateTime.Now, true, false, true,"Germany", "Stuttgart", "45 Engine Blvd" },
                    { 3, (int)OrganizationEnum.Supplier ,"Elite Brake Systems", "123456789", "support@intX.net", "123-456-789","321456789",  "System", DateTime.Now, true, false, true,"Italy", "Milan", "78 Brake Street" },
                    { 4, (int)OrganizationEnum.Supplier ,"Titan Tires Co.", "123456789", "contac4t@intX2.net", "123-456-789","321456789",  "System", DateTime.Now, true, false, true,"Japan", "Osaka", "250 Tire Road" },
                    { 5, (int)OrganizationEnum.Supplier ,"Speedy Lubricants", "123456789", "contact5@intX2.net", "123-456-789","321456789",  "System", DateTime.Now, true, false, true,"UAE", "Abu Dhabi", "99 Oil Street" },
                    { 6, (int)OrganizationEnum.Supplier ,"EcoAuto Batteries", "123456789", "contac6t@intX2.net", "123-456-789","321456789",  "System", DateTime.Now, true, false, true,"China", "Beijing", "600 Battery Lane" },
                    { 7, (int)OrganizationEnum.Supplier ,"Global Exhaust Solutions", "123456789", "contact7@intX2.net", "123-456-789","321456789",  "System", DateTime.Now, true, false, true,"Brazil", "São Paulo", "18 Exhaust Blvd" },
                    { 8, (int)OrganizationEnum.Supplier ,"CarTech Electronics", "123456789", "contact8@intX2.net", "123-456-789","321456789",  "System", DateTime.Now, true, false, true,"USA", "Silicon Valley", "777 Tech Park" },
                    { 9, (int)OrganizationEnum.Supplier ,"Global Electronics", "123456789", "contact9@intX2.net", "123-456-789","321456789",  "System", DateTime.Now, true, false, true,"USA", "Silicon Valley", "777 Tech Park" },
                });

            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Organization] OFF");

            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[AspNetUsers] ON");


            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "UserName", "PhoneNumber", "Email", "NormalizedEmail", "FirstName", "LastName", "MainRole", "OrganizationId", "Department", "Title", "IsSystem", "CreatedBy", "CreatedDate", "IsActive", "IsDeleted", "AccessFailedCount", "HasOtp", "EmailConfirmed", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnabled", "PasswordHash", "SecurityStamp",
                "IsDefaultPassword" },
                values: new object[,]
                {
                    { 1, "SuperAdmin", "321456789", "admin@domain.com", "ADMIN@DOMAIN.COM", "Liam", "Anderson", 1, 1, "Administrator", "Super SuperAdmin", true, "System", DateTime.UtcNow, true, false, 0, false, true, true, false, false, hasher.HashPassword(null, "SuperAdmin@123"), Guid.NewGuid().ToString(), true },
                    { 2, "CompanyManager", "321456789", "company.manager@domain.com", "COMPANY.MANAGER@DOMAIN.COM", "Sophia", "Williams", 2, 1, "Management", "Company Manager", true, "System", DateTime.UtcNow, true, false, 0, false, true, true, false, false, hasher.HashPassword(null, "SuperAdmin@123"), Guid.NewGuid().ToString(), true },
                    { 3, "SupplierAdmin", "123456789", "supplier.admin@domain.com", "SUPPLIER.ADMIN@DOMAIN.COM", "Ethan", "Carter", 3, 2, "Suppliers", "Supplier Administrator", true, "System", DateTime.UtcNow, true, false, 0, false, true, true, false, false, hasher.HashPassword(null, "SuperAdmin@123"), Guid.NewGuid().ToString(), true },
                    { 4, "SupplierRep", "123456789", "supplier.rep@domain.com", "SUPPLIER.REP@DOMAIN.COM", "Ava", "Smith", 3, 2, "Sales", "Supplier Representative", true, "System", DateTime.UtcNow, true, false, 0, false, true, true, false, false, hasher.HashPassword(null, "SuperAdmin@123"), Guid.NewGuid().ToString(), true },
                    { 5, "TechnicianLead", "123456789", "tech.lead@domain.com", "TECH.LEAD@DOMAIN.COM", "Noah", "Miller", 4, 3, "Technical", "Lead Technician", true, "System", DateTime.UtcNow, true, false, 0, false, true, true, false, false, hasher.HashPassword(null, "SuperAdmin@123"), Guid.NewGuid().ToString(), true },
                    { 6, "MechanicPro", "123456789", "mechanic@domain.com", "MECHANIC@DOMAIN.COM", "Emma", "Johnson", 4, 4, "Workforce", "Senior Mechanic", true, "System", DateTime.UtcNow, true, false, 0, false, true, true, false, false, hasher.HashPassword(null, "SuperAdmin@123"), Guid.NewGuid().ToString(), true },
                    { 7, "MaximosRepair Pro", "123456789", "mrepair@domain.com", "MREPAIR@DOMAIN.COM", "Ahmed", "Jane", 4, 4, "Workforce", "Senior Maximos Repair", true, "System", DateTime.UtcNow, true, false, 0, false, true, true, false, false, hasher.HashPassword(null, "SuperAdmin@123"), Guid.NewGuid().ToString(), true },
                    { 8, "MechanicPro", "123456789", "mechanicpro@domain.com", "MECHANICPRO@DOMAIN.COM", "Ashraf", "Mostafa", 4, 4, "Workforce", "Best Mechanic", true, "System", DateTime.UtcNow, true, false, 0, false, true, true, false, false, hasher.HashPassword(null, "SuperAdmin@123"), Guid.NewGuid().ToString(), true },
                    { 9, "WarehouseManager", "123456789", "warehouse.manager@domain.com", "WAREHOUSE.MANAGER@DOMAIN.COM", "James", "Brown", 4, 4, "Logistics", "Warehouse Manager", true, "System", DateTime.UtcNow, true, false, 0, false, true, true, false, false, hasher.HashPassword(null, "SuperAdmin@123"), Guid.NewGuid().ToString(), true },
                });
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[AspNetUsers] OFF");
            migrationBuilder.InsertData(
            table: "AspNetUserRoles",
            columns: new[] { "UserId", "RoleId" },
            values: new object[,]
            {
                { 1,1},
                { 2,1},
                { 3,3},
                { 4,3},
                { 5,4},
                { 6,4},
                { 7,4}
            });


            //Seed FileType data

            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[FileType] ON");
            migrationBuilder.InsertData(
            table: "FileType",
            columns: new[] { "Id", "OrganizationId", "Type", "Extentions", "IsSystem", "CreatedBy", "CreatedDate", "IsActive", "IsDeleted" },
            values: new object[,]
            {
                { 1, 1, "Image", ".jpg.png.jpeg", true, "System", DateTime.Now, true, false },
                { 2, 1, "Document", ".pdf.docx.txt", true, "System", DateTime.Now, true, false },
                { 3, 1, "Spreadsheet", ".xlsx.csv", true, "System", DateTime.Now, true, false },
                { 4, 1, "Archive", ".zip.rar", true, "System", DateTime.Now, true, false },
            });


            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[FileType] OFF");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
