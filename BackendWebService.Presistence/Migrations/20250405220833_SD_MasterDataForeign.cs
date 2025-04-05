using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendWebService.Persistence.Migrations
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

            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[PreDocument] ON");

            migrationBuilder.InsertData(
                table: "PreDocument",
                columns: new[] { "Id", "Name", "IsRequired", "IsMultiple", "IsLocal", "FileTypeId", "CreatedBy", "CreatedDate", "IsActive", "IsDeleted", "IsSystem" },
                values: new object[,]
                {
                    { 1, "Business License", true, false, true, 1, "System", DateTime.Now, true, false, true },
                    { 2, "Tax Registration", true, false, true, 1, "System", DateTime.Now, true, false, true },
                    { 3, "Insurance Policy", false, false, true, 2, "System", DateTime.Now, true, false, true },
                    { 4, "Company Logo", false, true, false, 3, "System", DateTime.Now, true, false, true },
                    { 5, "ID Proof", true, false, true, 4, "System", DateTime.Now, true, false, true },
                    { 6, "Contracts", false, true, false, 5, "System", DateTime.Now, true, false, true },
                    { 7, "Financial Statements", false, false, true, 6, "System", DateTime.Now, true, false, true }
                });

            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[PreDocument] OFF");

            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[AspNetUsers] ON");
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "UserName", "PhoneNumber", "Email", "FirstName", "LastName", "MainRole", "OrganizationId", "Department", "Title", "IsSystem", "CreatedBy", "CreatedDate", "IsActive", "IsDeleted", "AccessFailedCount", "HasOtp", "EmailConfirmed", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnabled", "PasswordHash", "SecurityStamp", "IsDefaultPassword" },
                values: new object[,]
                {
                    { 11, "SuperCustomer","321456789", "customer@domain.com", "Liam", "Anderson", 1, 1, "Customeristration", "Super Customer", true, "System", DateTime.Now, true, false, 0, false, true, true, false, false ,hasher.HashPassword(null, "Customer@123"), Guid.NewGuid().ToString(), true},
                    { 12, "FamilyManager", "321456789","family.manager@domain.com", "Sophia", "Williams", 2, 1, "Management", "Family Manager", true, "System", DateTime.Now, true, false, 0, false, true, true, false, false ,hasher.HashPassword(null, "Customer@123"), Guid.NewGuid().ToString(), true},
                    { 13, "FamilyCustomer", "123456789","family.customer@domain.com", "Ethan", "Carter", 3, 2, "Familys", "Family Customeristrator", true, "System", DateTime.Now, true, false, 0, false, true, true, false, false ,hasher.HashPassword(null, "Customer@123"), Guid.NewGuid().ToString(), true},
                    { 14, "FamilyRep", "123456789","family.rep@domain.com", "Ava", "Smith", 3, 2, "Sales", "Family Representative", true, "System", DateTime.Now, true, false, 0, false, true, true, false, false ,hasher.HashPassword(null, "Customer@123"), Guid.NewGuid().ToString(), true},
                    { 15, "TechnicianLead", "123456789","tech.lead@domain.com", "Noah", "Miller", 4, 3, "Technical", "Lead Technician", true, "System", DateTime.Now, true, false, 0, false, true, true, false, false ,hasher.HashPassword(null, "Customer@123"), Guid.NewGuid().ToString(), true},
                    { 16, "Technician anicPro", "123456789","technician anic@domain.com", "Emma", "Johnson", 4, 4, "Workforce", "Senior Technician anic", true, "System", DateTime.Now, true, false, 0, false, true, true, false, false ,hasher.HashPassword(null, "Customer@123"), Guid.NewGuid().ToString(), true},
                    { 17, "MaximosRepair Pro", "123456789","mrepair@domain.com", "Ahmed", "Jane", 4, 4, "Workforce", "Senior Maximos Repair", true, "System", DateTime.Now, true, false, 0, false, true, true, false, false ,hasher.HashPassword(null, "Customer@123"), Guid.NewGuid().ToString(), true},
                    { 18, "Technician anicPro", "123456789","technician anicpro@domain.com", "Ashraf", "Mostafa", 4, 4, "Workforce", "Best Familyanic", true, "System", DateTime.Now, true, false, 0, false, true, true, false, false ,hasher.HashPassword(null, "Customer@123"), Guid.NewGuid().ToString(), true},
                    { 19, "WarehouseManager", "123456789","warehouse.manager@domain.com", "James", "Brown", 4, 4, "Logistics", "Warehouse Manager", true, "System", DateTime.Now, true, false, 0, false, true, true, false, false ,hasher.HashPassword(null, "Customer@123"), Guid.NewGuid().ToString(), true},
                });
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[AspNetUsers] OFF");
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Customer] ON");
            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Role", "UserId", "PhoneNumber", "MFAEnabled", "Status", "IsSystem", "CreatedBy", "CreatedDate", "IsActive", "IsDeleted" },
                values: new object[,]
                {
                    { 1,(int)RoleEnum.Customer, 11, "1234567890", false, 1,true, "System", DateTime.Now, true, false},
                    { 2,(int)RoleEnum.Customer, 12, "0987654321", true, 1, true, "System", DateTime.Now, true, false},
                    { 3,(int)RoleEnum.Customer, 13, "1122334455", false, 0,true, "System", DateTime.Now, true, false},
                    { 4,(int)RoleEnum.Customer, 14, "2233445566", true, 1, true, "System", DateTime.Now, true, false},
                    { 5,(int)RoleEnum.Customer, 15, "3564556677", false, 2,true, "System", DateTime.Now, true, false},
                    { 6,(int)RoleEnum.Customer, 16, "3344556677", false, 1,true, "System", DateTime.Now, true, false},
                    { 7,(int)RoleEnum.Customer, 17, "4455667788", true, 0, true, "System", DateTime.Now, true, false},
                    { 8,(int)RoleEnum.Customer, 18, "5566778899", false, 1,true, "System", DateTime.Now, true, false},
                    { 9,(int)RoleEnum.Customer, 19, "6677889900", true, 1, true, "System", DateTime.Now, true, false},
                });
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Customer] OFF");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }

}