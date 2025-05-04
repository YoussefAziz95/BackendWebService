using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addingFirstZone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Zone] ON");
            migrationBuilder.Sql(
                @"INSERT INTO Zone (Id, Name)
                  SELECT 1, 'Shoubra'
                  WHERE NOT EXISTS (SELECT 1 FROM Zone WHERE Id = 1);"
            );

            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Zone] OFF");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
