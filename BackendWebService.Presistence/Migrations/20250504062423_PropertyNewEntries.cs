using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PropertyNewEntries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Property_FileLog_FileId",
                table: "Property");

            migrationBuilder.DropTable(
                name: "PropertyZone");

            migrationBuilder.DropIndex(
                name: "IX_Property_FileId",
                table: "Property");

            migrationBuilder.RenameColumn(
                name: "FileId",
                table: "Property",
                newName: "ZoneId");

            migrationBuilder.AlterColumn<int>(
                name: "ZoneId",
                table: "Property",
                nullable: true,
                oldNullable: false);

            migrationBuilder.AddColumn<int>(
                name: "ApartmentNumber",
                table: "Property",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BuildingNumber",
                table: "Property",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactNumber",
                table: "Property",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FloorNumber",
                table: "Property",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StreetNumber",
                table: "Property",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zone_Name",
                table: "Zone",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Zone_Name",
                table: "Zone");

            migrationBuilder.DropColumn(
                name: "ApartmentNumber",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "BuildingNumber",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "FloorNumber",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "StreetNumber",
                table: "Property");

            migrationBuilder.RenameColumn(
                name: "ZoneId",
                table: "Property",
                newName: "FileId");

            migrationBuilder.CreateTable(
                name: "PropertyZone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    IsSystem = table.Column<bool>(type: "bit", nullable: true),
                    OrganizationId = table.Column<int>(type: "int", nullable: true),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZoneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyZone", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Property_FileId",
                table: "Property",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Property_FileLog_FileId",
                table: "Property",
                column: "FileId",
                principalTable: "FileLog",
                principalColumn: "Id");
        }
    }
}
