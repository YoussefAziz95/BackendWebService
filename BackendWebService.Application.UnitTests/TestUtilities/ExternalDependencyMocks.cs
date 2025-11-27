using Moq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Domain;

namespace BackendWebService.Application.UnitTests.TestUtilities;

/// <summary>
/// Provides mocks for external dependencies in Application layer testing
/// </summary>
public static class ExternalDependencyMocks
{
    /// <summary>
    /// Creates a mock for any external dependency interface
    /// </summary>
    public static Mock<T> CreateExternalDependencyMock<T>() where T : class
    {
        return new Mock<T>();
    }

    /// <summary>
    /// Creates a collection of manager mocks
    /// </summary>
    public static class Managers
    {
        public static Mock<UserManager<User>> CreateUserManagerMock()
        {
            return new Mock<UserManager<User>>(
                Mock.Of<IUserStore<User>>(),
                null, null, null, null, null, null, null, null);
        }

        public static Mock<RoleManager<Role>> CreateRoleManagerMock()
        {
            return new Mock<RoleManager<Role>>(
                Mock.Of<IRoleStore<Role>>(),
                null, null, null, null);
        }

        public static Mock<SignInManager<User>> CreateSignInManagerMock()
        {
            return new Mock<SignInManager<User>>(
                Mock.Of<UserManager<User>>(),
                Mock.Of<IHttpContextAccessor>(),
                Mock.Of<IUserClaimsPrincipalFactory<User>>(),
                null, null, null, null);
        }
    }

    /// <summary>
    /// Creates a collection of external service mocks
    /// </summary>
    public static class ExternalServices
    {
        public static Mock<IHttpContextAccessor> CreateHttpContextAccessorMock()
        {
            return new Mock<IHttpContextAccessor>();
        }

        public static Mock<IMemoryCache> CreateMemoryCacheMock()
        {
            return new Mock<IMemoryCache>();
        }

        public static Mock<IConfiguration> CreateConfigurationMock()
        {
            return new Mock<IConfiguration>();
        }

        public static Mock<ILogger<T>> CreateLoggerMock<T>()
        {
            return new Mock<ILogger<T>>();
        }

        public static Mock<ILoggerFactory> CreateLoggerFactoryMock()
        {
            return new Mock<ILoggerFactory>();
        }
    }
}
