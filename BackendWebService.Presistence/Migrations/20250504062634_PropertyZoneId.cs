using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PropertyZoneId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"UPDATE Property SET ZoneId = NULL;");

            migrationBuilder.CreateIndex(
                name: "IX_Property_ZoneId",
                table: "Property",
                column: "ZoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Property_Zone_ZoneId",
                table: "Property",
                column: "ZoneId",
                principalTable: "Zone",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Property_Zone_ZoneId",
                table: "Property");

            migrationBuilder.DropIndex(
                name: "IX_Property_ZoneId",
                table: "Property");
        }
    }
}
