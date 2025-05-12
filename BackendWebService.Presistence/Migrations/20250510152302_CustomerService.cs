using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CustomerService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerRequest");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "FileId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FileId",
                table: "Category",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CustomerService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    AssignedTechnicianId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    RequestedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScheduledDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrganizationId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    IsSystem = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerService_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CustomerService_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_FileId",
                table: "Product",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_FileId",
                table: "Category",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerService_CustomerId",
                table: "CustomerService",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerService_ServiceId",
                table: "CustomerService",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_FileLog_FileId",
                table: "Category",
                column: "FileId",
                principalTable: "FileLog",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_FileLog_FileId",
                table: "Product",
                column: "FileId",
                principalTable: "FileLog",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_FileLog_FileId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_FileLog_FileId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "CustomerService");

            migrationBuilder.DropIndex(
                name: "IX_Product_FileId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Category_FileId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Category");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CustomerRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignedTechnicianId = table.Column<int>(type: "int", nullable: true),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    IsSystem = table.Column<bool>(type: "bit", nullable: true),
                    OrganizationId = table.Column<int>(type: "int", nullable: true),
                    RequestedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScheduledDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerRequest", x => x.Id);
                });
        }
    }
}
