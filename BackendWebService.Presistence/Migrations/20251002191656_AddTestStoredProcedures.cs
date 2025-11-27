using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTestStoredProcedures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // PERMANENT FIX: Add test stored procedures for integration tests
            
            // Simple test stored procedure - returns count of active users
            migrationBuilder.Sql(@"
                CREATE PROCEDURE GetActiveUsersCount
                AS
                BEGIN
                    SELECT COUNT(*) AS UserCount
                    FROM Users
                    WHERE IsActive = 1
                END
            ");
            
            // Stored procedure with parameters - returns users by organization
            migrationBuilder.Sql(@"
                CREATE PROCEDURE GetUsersByOrganization
                    @OrganizationId INT
                AS
                BEGIN
                    SELECT Id, UserName, Email, FirstName, LastName, OrganizationId
                    FROM Users
                    WHERE OrganizationId = @OrganizationId AND IsActive = 1
                END
            ");
            
            // Stored procedure with output parameter
            migrationBuilder.Sql(@"
                CREATE PROCEDURE GetUserCountByOrganization
                    @OrganizationId INT,
                    @UserCount INT OUTPUT
                AS
                BEGIN
                    SELECT @UserCount = COUNT(*)
                    FROM Users
                    WHERE OrganizationId = @OrganizationId AND IsActive = 1
                END
            ");
            
            // Stored procedure that returns multiple result sets
            migrationBuilder.Sql(@"
                CREATE PROCEDURE GetOrganizationSummary
                    @OrganizationId INT
                AS
                BEGIN
                    -- First result set: Organization info
                    SELECT Id, Name, Country, City, Email
                    FROM Organization
                    WHERE Id = @OrganizationId
                    
                    -- Second result set: User count
                    SELECT COUNT(*) AS UserCount
                    FROM Users
                    WHERE OrganizationId = @OrganizationId
                    
                    -- Third result set: Company count
                    SELECT COUNT(*) AS CompanyCount
                    FROM Company
                    WHERE OrganizationId = @OrganizationId
                END
            ");
            
            // Stored procedure for testing error scenarios
            migrationBuilder.Sql(@"
                CREATE PROCEDURE TestErrorProcedure
                    @ShouldError BIT = 0
                AS
                BEGIN
                    IF @ShouldError = 1
                    BEGIN
                        RAISERROR('Test error from stored procedure', 16, 1)
                    END
                    ELSE
                    BEGIN
                        SELECT 'Success' AS Result
                    END
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Clean up test stored procedures
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS GetActiveUsersCount");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS GetUsersByOrganization");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS GetUserCountByOrganization");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS GetOrganizationSummary");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS TestErrorProcedure");
        }
    }
}
