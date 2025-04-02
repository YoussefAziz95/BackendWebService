using Domain.Enums;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace intCafeWeb.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SD_CompanyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Company] ON");
            migrationBuilder.InsertData(
                table: "Company",
                columns: new[]
                {
                    "Id", "OrganizationId", "CreatedBy", "CreatedDate",
                    "IsActive", "IsDeleted", "IsSystem", "Status"
                },
                values: new object[,]
                {
                    { 1, 2, "System", DateTime.Now, true, false, true, (int)StatusEnum.Active },
                }
            );

            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Company] OFF");
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Supplier] ON");
            migrationBuilder.InsertData(
                table: "Supplier",
                columns: new[]
                {
                    "Id", "OrganizationId","CreatedBy", "CreatedDate", 
                    "IsActive", "IsDeleted", "IsSystem", "Status"
                },
                values: new object[,]
                {
                    { 1, 3, "System", DateTime.Now, true, false, true,(int)StatusEnum.Active},
                    { 2, 4, "System", DateTime.Now, true, false, true,(int)StatusEnum.Active},
                    { 3, 5, "System", DateTime.Now, true, false, true,(int)StatusEnum.Active},
                    { 4, 6, "System", DateTime.Now, true, false, true,(int)StatusEnum.Active},
                    { 5, 7, "System", DateTime.Now, true, false, true,(int)StatusEnum.Active},
                    { 6, 8, "System", DateTime.Now, true, false, true,(int)StatusEnum.Active},
                    { 7, 9, "System", DateTime.Now, true, false, true,(int)StatusEnum.Active},
                }
            );

            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Supplier] OFF");
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[SupplierAccount] ON");
            migrationBuilder.InsertData(
                table: "SupplierAccount",
                columns: new[]
                {
                    "Id", "CompanyId", "SupplierId", "ApprovedDate", "IsApproved", "CreatedBy", "CreatedDate", "IsActive", "IsDeleted", "IsSystem"
                },
                values: new object[,]
                {
                    { 1, 1, 1, DateTime.Now.AddDays(-10), false, "System", DateTime.Now, true, false, true },
                    { 2, 1, 2, DateTime.Now.AddDays(-10), false, "System", DateTime.Now, true, false, true },
                    { 3, 1, 3, DateTime.Now.AddDays(-10), false, "System", DateTime.Now, true, false, true },
                    { 4, 1, 4, DateTime.Now.AddDays(-10), false, "System", DateTime.Now, true, false, true },
                    { 5, 1, 5, DateTime.Now.AddDays(-10), false, "System", DateTime.Now, true, false, true },
                    { 6, 1, 6, DateTime.Now.AddDays(-10), false, "System", DateTime.Now, true, false, true },
                    { 7, 1, 7, DateTime.Now.AddDays(-5), false, "System", DateTime.Now, true, false, true }
                }
            );

            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[SupplierAccount] OFF");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
