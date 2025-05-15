using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MajorDomainChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileLog_FileType_FileTypeId",
                table: "FileLog");

            migrationBuilder.DropIndex(
                name: "IX_FileLog_FileTypeId",
                table: "FileLog");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Technician");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Technician");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Technician");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Technician");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Technician");

            migrationBuilder.DropColumn(
                name: "ApartmentNumber",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "BuildingNumber",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "FloorNumber",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "FullAddress",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "StreetNumber",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "FileLog");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "FileLog",
                newName: "FileName");

            migrationBuilder.RenameColumn(
                name: "FileTypeId",
                table: "FileLog",
                newName: "FileType");

            migrationBuilder.RenameColumn(
                name: "AssignedTechnicianId",
                table: "CustomerService",
                newName: "VoiceNoteId");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Technician",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Technician",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Technician",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Technician",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Technician",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSystem",
                table: "Technician",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "Technician",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Technician",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Technician",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Technician",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Service",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactName",
                table: "Property",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FilesId",
                table: "CustomerService",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "CustomerService",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                table: "CustomerService",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "additionalPhoneNumber",
                table: "CustomerService",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Technician_UserId",
                table: "Technician",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerService_FilesId",
                table: "CustomerService",
                column: "FilesId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerService_PropertyId",
                table: "CustomerService",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerService_VoiceNoteId",
                table: "CustomerService",
                column: "VoiceNoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerService_FileLog_FilesId",
                table: "CustomerService",
                column: "FilesId",
                principalTable: "FileLog",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerService_FileLog_VoiceNoteId",
                table: "CustomerService",
                column: "VoiceNoteId",
                principalTable: "FileLog",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerService_Property_PropertyId",
                table: "CustomerService",
                column: "PropertyId",
                principalTable: "Property",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Technician_Users_UserId",
                table: "Technician",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerService_FileLog_FilesId",
                table: "CustomerService");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerService_FileLog_VoiceNoteId",
                table: "CustomerService");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerService_Property_PropertyId",
                table: "CustomerService");

            migrationBuilder.DropForeignKey(
                name: "FK_Technician_Users_UserId",
                table: "Technician");

            migrationBuilder.DropIndex(
                name: "IX_Technician_UserId",
                table: "Technician");

            migrationBuilder.DropIndex(
                name: "IX_CustomerService_FilesId",
                table: "CustomerService");

            migrationBuilder.DropIndex(
                name: "IX_CustomerService_PropertyId",
                table: "CustomerService");

            migrationBuilder.DropIndex(
                name: "IX_CustomerService_VoiceNoteId",
                table: "CustomerService");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Technician");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Technician");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Technician");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Technician");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Technician");

            migrationBuilder.DropColumn(
                name: "IsSystem",
                table: "Technician");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Technician");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Technician");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Technician");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Technician");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "ContactName",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "FilesId",
                table: "CustomerService");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "CustomerService");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "CustomerService");

            migrationBuilder.DropColumn(
                name: "additionalPhoneNumber",
                table: "CustomerService");

            migrationBuilder.RenameColumn(
                name: "FileType",
                table: "FileLog",
                newName: "FileTypeId");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "FileLog",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "VoiceNoteId",
                table: "CustomerService",
                newName: "AssignedTechnicianId");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Technician",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Technician",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Technician",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Technician",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Technician",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddColumn<int>(
                name: "FloorNumber",
                table: "Property",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullAddress",
                table: "Property",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StreetNumber",
                table: "Property",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "Property",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "FileLog",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Customer",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FileLog_FileTypeId",
                table: "FileLog",
                column: "FileTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileLog_FileType_FileTypeId",
                table: "FileLog",
                column: "FileTypeId",
                principalTable: "FileType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
