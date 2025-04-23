using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class renamingAppConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoogleConfig_Configuration_ConfigurationId",
                table: "GoogleConfig");

            migrationBuilder.DropForeignKey(
                name: "FK_LDAPConfig_Configuration_ConfigurationId",
                table: "LDAPConfig");

            migrationBuilder.DropForeignKey(
                name: "FK_MicrosoftConfig_Configuration_ConfigurationId",
                table: "MicrosoftConfig");

            migrationBuilder.DropTable(
                name: "Configuration");

            migrationBuilder.CreateTable(
                name: "AppConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfigurationTypeId = table.Column<int>(type: "int", nullable: false),
                    ConfigurationType = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_AppConfiguration", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_GoogleConfig_AppConfiguration_ConfigurationId",
                table: "GoogleConfig",
                column: "ConfigurationId",
                principalTable: "AppConfiguration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LDAPConfig_AppConfiguration_ConfigurationId",
                table: "LDAPConfig",
                column: "ConfigurationId",
                principalTable: "AppConfiguration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MicrosoftConfig_AppConfiguration_ConfigurationId",
                table: "MicrosoftConfig",
                column: "ConfigurationId",
                principalTable: "AppConfiguration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoogleConfig_AppConfiguration_ConfigurationId",
                table: "GoogleConfig");

            migrationBuilder.DropForeignKey(
                name: "FK_LDAPConfig_AppConfiguration_ConfigurationId",
                table: "LDAPConfig");

            migrationBuilder.DropForeignKey(
                name: "FK_MicrosoftConfig_AppConfiguration_ConfigurationId",
                table: "MicrosoftConfig");

            migrationBuilder.DropTable(
                name: "AppConfiguration");

            migrationBuilder.CreateTable(
                name: "Configuration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfigurationType = table.Column<int>(type: "int", nullable: false),
                    ConfigurationTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    IsSystem = table.Column<bool>(type: "bit", nullable: true),
                    OrganizationId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuration", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_GoogleConfig_Configuration_ConfigurationId",
                table: "GoogleConfig",
                column: "ConfigurationId",
                principalTable: "Configuration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LDAPConfig_Configuration_ConfigurationId",
                table: "LDAPConfig",
                column: "ConfigurationId",
                principalTable: "Configuration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MicrosoftConfig_Configuration_ConfigurationId",
                table: "MicrosoftConfig",
                column: "ConfigurationId",
                principalTable: "Configuration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
