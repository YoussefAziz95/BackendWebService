using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SD_MasterData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var hasher = new PasswordHasher<User>();

            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Address] ON");

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "StreetAddress", "City", "State", "Country", "PostalCode", "CreatedBy", "CreatedDate", "IsActive", "IsDeleted", "IsSystem" },
                values: new object[,]
                {
                    { 1, "45 Engine Blvd, Stuttgart, Germany", "Stuttgart", "Baden-Württemberg", "Germany", "70173", "System", DateTime.Now, true, false, true },
                    { 2, "78 Brake Street, Milan, Italy", "Milan", "Lombardy", "Italy", "20121", "System", DateTime.Now, true, false, true }
                });

            // Disable IDENTITY_INSERT for Address table
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Address] OFF");

            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Role] ON");

            migrationBuilder.InsertData(
            table: "Role",
            columns: new[] { "Id", "Name", "DisplayName", "NormalizedName", "ConcurrencyStamp", "ParentId", "IsSystem", "CreatedBy", "CreatedDate", "IsActive", "IsDeleted" },
            values: new object[,]
            {

                    { (int)RoleEnum.SuperAdmin, Enum.GetName(typeof(RoleEnum), RoleEnum.SuperAdmin), Enum.GetName(typeof(RoleEnum), RoleEnum.SuperAdmin), "SUPERADMIN", null, null, true, "System", DateTime.Now, true, false },
                    { (int)RoleEnum.Admin, Enum.GetName(typeof(RoleEnum), RoleEnum.Admin), Enum.GetName(typeof(RoleEnum), RoleEnum.Admin), "ADMIN", null, null, true, "System", DateTime.Now, true, false },
                    { (int)RoleEnum.Technician, Enum.GetName(typeof(RoleEnum), RoleEnum.Technician), Enum.GetName(typeof(RoleEnum), RoleEnum.Technician), "TECHNICIAN", null, null, true, "System", DateTime.Now, true, false },
                    { (int)RoleEnum.Customer, Enum.GetName(typeof(RoleEnum), RoleEnum.Customer), Enum.GetName(typeof(RoleEnum), RoleEnum.Customer), "CUSTOMER", null, null, true, "System", DateTime.Now, true, false }
            });

            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Role] OFF");


            // Seed Organizations data

            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Organization] ON");
            migrationBuilder.InsertData(
                table: "Organization",
                columns: new[]
                {"Id", "Type", "Name", "TaxNo", "Email", "Phone", "FaxNo", "CreatedBy", "CreatedDate", "IsActive","IsDeleted", "IsSystem", "Country", "City", "StreetAddress"},

                values: new object[,]
                {
                    { 1, (int)OrganizationEnum.Organization ,"The Framework", "321456789", "info@domain.net", "321-456-789","321456789",  "System", DateTime.Now, true, false, true,"USA", "Detroit", "123 Motorway Ave" },
                    { 2, (int)OrganizationEnum.Organization ,"AutoParts Global", "321456789", "info@domain.net", "321-456-789","321456789",  "System", DateTime.Now, true, false, true,"USA", "Detroit", "123 Motorway Ave" },
                    { 3, (int)OrganizationEnum.Company ,"Turbo Engines Ltd.", "321456789", "info@domain.net", "321-456-789","321456789",  "System", DateTime.Now, true, false, true,"Germany", "Stuttgart", "45 Engine Blvd" },
                    { 4, (int)OrganizationEnum.Company ,"Elite Brake Systems", "123456789", "support@domain.net", "123-456-789","321456789",  "System", DateTime.Now, true, false, true,"Italy", "Milan", "78 Brake Street" },
                    { 5, (int)OrganizationEnum.Supplier ,"Titan Tires Co.", "123456789", "contac4t@domain2.net", "123-456-789","321456789",  "System", DateTime.Now, true, false, true,"Japan", "Osaka", "250 Tire Road" },
                    { 6, (int)OrganizationEnum.Supplier ,"Speedy Lubricants", "123456789", "contact5@domain2.net", "123-456-789","321456789",  "System", DateTime.Now, true, false, true,"UAE", "Abu Dhabi", "99 Oil Street" },
                    { 7, (int)OrganizationEnum.Supplier ,"EcoAuto Batteries", "123456789", "contac6t@domain2.net", "123-456-789","321456789",  "System", DateTime.Now, true, false, true,"China", "Beijing", "600 Battery Lane" },
                    { 8, (int)OrganizationEnum.Supplier ,"Global Exhaust Solutions", "123456789", "contact7@domain2.net", "123-456-789","321456789",  "System", DateTime.Now, true, false, true,"Brazil", "São Paulo", "18 Exhaust Blvd" },
                    { 9, (int)OrganizationEnum.Supplier ,"CarTech Electronics", "123456789", "contact8@domain2.net", "123-456-789","321456789",  "System", DateTime.Now, true, false, true,"USA", "Silicon Valley", "777 Tech Park" },
                    { 10, (int)OrganizationEnum.Supplier ,"Global Electronics", "123456789", "contact9@domain2.net", "123-456-789","321456789",  "System", DateTime.Now, true, false, true,"USA", "Silicon Valley", "777 Tech Park" },
                });

            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Organization] OFF");

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
                    {
                        3, "USR0003", "Ethan", "Carter", "supp_admin", "SUPP_ADMIN",
                        "supp.admin@dom.com", "SUPP.ADMIN@DOM.COM", "123456789", true, false, true,
                        DateTime.UtcNow, 2, "Suppliers", "Supplier Admin", 3, "System",
                        null, null, true, hasher.HashPassword(null, "SuperAdmin@123"), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(),
                        true, false, null, false, 0
                    },
                    {
                        4, "USR0004", "Ava", "Smith", "supp_rep", "SUPP_REP",
                        "supp.rep@dom.com", "SUPP.REP@DOM.COM", "123456789", true, false, true,
                        DateTime.UtcNow, 2, "Sales", "Supplier Rep", 3, "System",
                        null, null, true, hasher.HashPassword(null, "SuperAdmin@123"), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(),
                        true, false, null, false, 0
                    },
                    {
                        5, "USR0005", "Noah", "Miller", "tech_lead", "TECH_LEAD",
                        "tech.lead@dom.com", "TECH.LEAD@DOM.COM", "123456789", true, false, true,
                        DateTime.UtcNow, 3, "Tech", "Lead Technician", 4, "System",
                        null, null, true, hasher.HashPassword(null, "SuperAdmin@123"), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(),
                        true, false, null, false, 0
                    },
                    {
                        6, "USR0006", "Emma", "Johnson", "mech_pro", "MECH_PRO",
                        "mech.pro@dom.com", "MECH.PRO@DOM.COM", "123456789", true, false, true,
                        DateTime.UtcNow, 4, "Workforce", "Senior Mechanic", 4, "System",
                        null, null, true, hasher.HashPassword(null, "SuperAdmin@123"), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(),
                        true, false, null, false, 0
                    },
                    {
                        7, "USR0007", "Ahmed", "Jane", "mx_repair", "MX_REPAIR",
                        "mx.repair@dom.com", "MX.REPAIR@DOM.COM", "123456789", true, false, true,
                        DateTime.UtcNow, 4, "Workforce", "Repair Specialist", 4, "System",
                        null, null, true, hasher.HashPassword(null, "SuperAdmin@123"), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(),
                        true, false, null, false, 0
                    },
                    {
                        8, "USR0008", "Ashraf", "Mostafa", "mech_star", "MECH_STAR",
                        "mech.star@dom.com", "MECH.STAR@DOM.COM", "123456789", true, false, true,
                        DateTime.UtcNow, 4, "Workforce", "Top Mechanic", 4, "System",
                        null, null, true, hasher.HashPassword(null, "SuperAdmin@123"), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(),
                        true, false, null, false, 0
                    },
                    {
                        9, "USR0009", "James", "Brown", "wh_mgr", "WH_MGR",
                        "wh.manager@dom.com", "WH.MANAGER@DOM.COM", "123456789", true, false, true,
                        DateTime.UtcNow, 4, "Logistics", "Warehouse Manager", 4, "System",
                        null, null, true, hasher.HashPassword(null, "SuperAdmin@123"), Guid.NewGuid().ToString(), Guid.NewGuid().ToString(),
                        true, false, null, false, 0
                    }
                });

            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Users] OFF");
            migrationBuilder.InsertData(
            table: "UserRole",
            columns: new[] { "UserId", "RoleId" },
            values: new object[,]
            {
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
                { 5, 1, "VoiceNote", ".av.mp3", true, "System", DateTime.Now, true, false },
            });


            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[FileType] OFF");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
