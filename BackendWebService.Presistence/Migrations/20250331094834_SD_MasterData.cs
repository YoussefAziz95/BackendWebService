using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace intCafeWeb.Persistence.Migrations
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
                    { "1", "Organization", "ORGANIZATION", null, null, true, "System", DateTime.Now, true, false },
                    { "2", "Company", "COMPANY", null, null, true, "System", DateTime.Now, true, false },
                    { "3", "Supplier", "VENDOR", null, null, true, "System", DateTime.Now, true, false },
                    { "4", "Customer", "CUSTOMER", null, null, true, "System", DateTime.Now, true, false }
            });

            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[AspNetRoles] OFF");
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[AspNetRoleClaims] ON");



            migrationBuilder.InsertData(
            table: "AspNetRoleClaims",
            columns: new[] { "Id", "RoleId", "ClaimType", "ClaimValue" },
            values: new object[,]
            {
                    { 1, "1", "permission", "Users.Menu.Permissions.View"},
                    { 2, "1", "permission", "Users.Menu.User.View"},
                    { 3, "1", "permission", "Users.Button.User.Get"},
                    { 4, "1", "permission", "Users.Button.User.Create"},
                    { 5, "1", "permission", "Users.Button.User.Edit"},
                    { 6, "1", "permission", "Users.Button.User.Delete"},
                    { 7, "1", "permission", "Users.Menu.Role.View"},
                    { 8, "1", "permission", "Users.Button.Role.Get"},
                    { 9, "1", "permission", "Users.Button.Role.Create"},
                    { 10, "1", "permission", "Users.Button.Role.Edit"},
                    { 11, "1", "permission", "Users.Button.Role.Delete"},
                    { 12, "1", "permission", "Organization.Menu.Category.View"},
                    { 13, "1", "permission", "Organization.Button.Category.Get"},
                    { 14, "1", "permission", "Organization.Button.Category.Create"},
                    { 15, "1", "permission", "Organization.Button.Category.Edit"},
                    { 16, "1", "permission", "Organization.Button.Category.Delete"},
                    { 17, "1", "permission", "Organization.Button.Category.Title"},
                    { 18, "1", "permission", "Organization.Category.MultiSelect"},
                    { 19, "1", "permission", "Organization.Category.View"},
                    { 20, "1", "permission", "Organization.Menu.PreDocuments.View"},
                    { 21, "1", "permission", "Organization.Button.PreDocuments.Get"},
                    { 22, "1", "permission", "Organization.Button.PreDocuments.Create"},
                    { 23, "1", "permission", "Organization.Button.PreDocuments.Edit"},
                    { 24, "1", "permission", "Organization.Button.PreDocuments.Delete"},
                    { 25, "1", "permission", "Company.Menu.Company.View"},
                    { 26, "1", "permission", "Company.Button.Company.Get"},
                    { 27, "1", "permission", "Company.Button.Company.Create"},
                    { 28, "1", "permission", "Company.Button.Company.Edit"},
                    { 29, "1", "permission", "Company.Button.Company.Delete"},
                    { 30, "1", "permission", "Suppliers.Menu.Supplier.View"},
                    { 31, "1", "permission", "Suppliers.Button.Supplier.Get"},
                    { 32, "1", "permission", "Suppliers.Button.Supplier.Create"},
                    { 33, "1", "permission", "Suppliers.Button.Supplier.Edit"},
                    { 34, "1", "permission", "Suppliers.Button.Supplier.Delete"},
                    { 35, "1", "permission", "Suppliers.Menu.SupplierDocument.View"},
                    { 36, "1", "permission", "Suppliers.Button.SupplierDocument.Create"},
                    { 37, "1", "permission", "Suppliers.Button.SupplierDocument.Get"},
                    { 38, "1", "permission", "Suppliers.Button.SupplierDocument.Edit"},
                    { 39, "1", "permission", "Offers.Menu.Service.View"},
                    { 40, "1", "permission", "Offers.Button.Service.Get"},
                    { 41, "1", "permission", "Offers.Button.Service.Create"},
                    { 42, "1", "permission", "Offers.Button.Service.Edit"},
                    { 43, "1", "permission", "Offers.Button.Service.Delete"},
                    { 44, "1", "permission", "Offers.Menu.Workflow.View"},
                    { 45, "1", "permission", "Offers.Button.Workflow.Get"},
                    { 46, "1", "permission", "Offers.Button.Workflow.Create"},
                    { 47, "1", "permission", "Offers.Button.Workflow.Edit"},
                    { 48, "1", "permission", "Offers.Button.Workflow.Delete"},
                    { 49, "1", "permission", "Offers.Menu.Action.View"},
                    { 50, "1", "permission", "Offers.Button.Action.Get"},
                    { 51, "1", "permission", "Offers.Button.Action.Create"},
                    { 52, "1", "permission", "Offers.Button.Action.Edit"},
                    { 53, "1", "permission", "Offers.Button.Action.Delete"},
                    { 54, "1", "permission", "Offers.Offer.Deal.Create"},
                    { 55, "1", "permission", "Offers.Button.Deal.View"},
                    { 56, "1", "permission", "Offers.Button.Deal.Get"},
                    { 57, "1", "permission", "Offers.Button.Deal.Create"},
                    { 58, "1", "permission", "Offers.Button.Deal.Edit"},
                    { 59, "1", "permission", "Offers.Button.Deal.Delete"},
                    { 60, "1", "permission", "Offers.Menu.Offer.View"},
                    { 61, "1", "permission", "Offers.Button.Offer.Get"},
                    { 62, "1", "permission", "Offers.Button.Offer.Create"},
                    { 63, "1", "permission", "Offers.Button.Offer.Edit"},
                    { 64, "1", "permission", "Offers.Button.Offer.Delete"},
                    { 65, "1", "permission", "Offers.Button.Category.Title"},
                    { 66, "1", "permission", "Offers.Button.Category.MultiSelect"},
                 
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
                columns: new[] { "Id", "UserName", "PhoneNumber", "Email", "NormalizedEmail", "FirstName", "LastName", "MainRole", "OrganizationId", "Department", "Title", "IsSystem", "CreatedBy", "CreatedDate", "IsActive", "IsDeleted", "AccessFailedCount", "HasOtp", "EmailConfirmed", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnabled", "PasswordHash", "SecurityStamp" },
                values: new object[,]
                {
                    { 1, "SuperAdmin", "321456789", "admin@domain.com", "ADMIN@DOMAIN.COM", "Liam", "Anderson", 1, 1, "Administrator", "Super SuperAdmin", true, "System", DateTime.UtcNow, true, false, 0, false, true, true, false, false, hasher.HashPassword(null, "SuperAdmin@123"), Guid.NewGuid().ToString() },
                    { 2, "CompanyManager", "321456789", "company.manager@domain.com", "COMPANY.MANAGER@DOMAIN.COM", "Sophia", "Williams", 2, 1, "Management", "Company Manager", true, "System", DateTime.UtcNow, true, false, 0, false, true, true, false, false, hasher.HashPassword(null, "SuperAdmin@123"), Guid.NewGuid().ToString() },
                    { 3, "SupplierAdmin", "123456789", "supplier.admin@domain.com", "SUPPLIER.ADMIN@DOMAIN.COM", "Ethan", "Carter", 3, 2, "Suppliers", "Supplier Administrator", true, "System", DateTime.UtcNow, true, false, 0, false, true, true, false, false, hasher.HashPassword(null, "SuperAdmin@123"), Guid.NewGuid().ToString() },
                    { 4, "SupplierRep", "123456789", "supplier.rep@domain.com", "SUPPLIER.REP@DOMAIN.COM", "Ava", "Smith", 3, 2, "Sales", "Supplier Representative", true, "System", DateTime.UtcNow, true, false, 0, false, true, true, false, false, hasher.HashPassword(null, "SuperAdmin@123"), Guid.NewGuid().ToString() },
                    { 5, "TechnicianLead", "123456789", "tech.lead@domain.com", "TECH.LEAD@DOMAIN.COM", "Noah", "Miller", 4, 3, "Technical", "Lead Technician", true, "System", DateTime.UtcNow, true, false, 0, false, true, true, false, false, hasher.HashPassword(null, "SuperAdmin@123"), Guid.NewGuid().ToString() },
                    { 6, "MechanicPro", "123456789", "mechanic@domain.com", "MECHANIC@DOMAIN.COM", "Emma", "Johnson", 4, 4, "Workforce", "Senior Mechanic", true, "System", DateTime.UtcNow, true, false, 0, false, true, true, false, false, hasher.HashPassword(null, "SuperAdmin@123"), Guid.NewGuid().ToString() },
                    { 7, "MaximosRepair Pro", "123456789", "mrepair@domain.com", "MREPAIR@DOMAIN.COM", "Ahmed", "Jane", 4, 4, "Workforce", "Senior Maximos Repair", true, "System", DateTime.UtcNow, true, false, 0, false, true, true, false, false, hasher.HashPassword(null, "SuperAdmin@123"), Guid.NewGuid().ToString() },
                    { 8, "MechanicPro", "123456789", "mechanicpro@domain.com", "MECHANICPRO@DOMAIN.COM", "Ashraf", "Mostafa", 4, 4, "Workforce", "Best Mechanic", true, "System", DateTime.UtcNow, true, false, 0, false, true, true, false, false, hasher.HashPassword(null, "SuperAdmin@123"), Guid.NewGuid().ToString() },
                    { 9, "WarehouseManager", "123456789", "warehouse.manager@domain.com", "WAREHOUSE.MANAGER@DOMAIN.COM", "James", "Brown", 4, 4, "Logistics", "Warehouse Manager", true, "System", DateTime.UtcNow, true, false, 0, false, true, true, false, false, hasher.HashPassword(null, "SuperAdmin@123"), Guid.NewGuid().ToString() },
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
