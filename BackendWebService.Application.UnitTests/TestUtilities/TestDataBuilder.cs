using Domain;
using Application.Features;

namespace BackendWebService.Application.UnitTests.TestUtilities;

/// <summary>
/// Provides test data builders for Application layer testing
/// </summary>
public static class TestDataBuilder
{
    /// <summary>
    /// Creates test data for common entities
    /// </summary>
    public static class Entities
    {
        public static User CreateUser(string? email = null, string? userName = null)
        {
            return new User
            {
                Id = 1,
                Email = email ?? "test@example.com",
                UserName = userName ?? "testuser",
                FirstName = "Test",
                LastName = "User",
                IsActive = true,
                CreatedDate = DateTime.UtcNow
            };
        }

        public static Role CreateRole(string? name = null)
        {
            return new Role
            {
                Id = 1,
                Name = name ?? "TestRole",
                NormalizedName = (name ?? "TestRole").ToUpperInvariant(),
                IsActive = true,
                CreatedDate = DateTime.UtcNow
            };
        }
    }

    /// <summary>
    /// Creates test data for common DTOs and responses
    /// </summary>
    public static class DTOs
    {
        public static Response<T> CreateSuccessResponse<T>(T data, string? message = null)
        {
            return new Response<T>(data, message ?? "Success");
        }

        public static Response<T> CreateErrorResponse<T>(string? message = null, string[]? errors = null)
        {
            var response = new Response<T>(message ?? "Error");
            response.Errors = errors?.ToList() ?? new List<string> { "An error occurred" };
            return response;
        }

        public static DropDownResponse CreateDropDownResponse(string? value = null, string? text = null)
        {
            var items = new Dictionary<int, string>
            {
                { int.Parse(value ?? "1"), text ?? "Test Item" }
            };
            return new DropDownResponse(items);
        }

        public static GetPaginatedRequest CreatePaginatedRequest(int pageNumber = 1, int pageSize = 10)
        {
            return new GetPaginatedRequest
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
    }
}
