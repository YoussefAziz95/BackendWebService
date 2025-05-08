using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SP_GetUserPages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"CREATE PROCEDURE [dbo].[sp_GetUserPages]
           @UserId INT
            AS
            SELECT DISTINCT
                p.id as Id, 
                REVERSE(PARSENAME(REPLACE(REVERSE(p.ClaimType), ',', '.'), 1)) AS Groups,
                REVERSE(PARSENAME(REPLACE(REVERSE(p.ClaimType), ',', '.'), 2)) AS menu,
                REVERSE(PARSENAME(REPLACE(REVERSE(p.ClaimType), ',', '.'), 3)) AS page,
                REVERSE(PARSENAME(REPLACE(REVERSE(p.ClaimType), ',', '.'), 4)) AS permission
            FROM 
                dbo.Users u
                JOIN dbo.UserRole ur ON  u.Id = ur.UserId
                JOIN dbo.RoleClaim p ON p.RoleId = ur.RoleId
                WHERE p.ClaimValue = 'Permission' AND u.id = @UserId";
            migrationBuilder.Sql(sql);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sql = @"DROP PROCEDURE [dbo].[sp_GetUserPages]";
            migrationBuilder.Sql(sql);


        }
    }
}
