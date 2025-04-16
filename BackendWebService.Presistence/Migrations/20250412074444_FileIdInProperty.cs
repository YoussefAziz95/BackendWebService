using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FileIdInProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FileId",
                table: "Property",
                type: "int",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Property_FileLog_FileId",
                table: "Property");

            migrationBuilder.DropIndex(
                name: "IX_Property_FileId",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "Property");
        }
    }
}
