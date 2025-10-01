using Moq;
using Application.Contracts.Services;
using Application.Contracts.Infrastructures;
using Application.Contracts.HubServices;

namespace BackendWebService.Application.UnitTests.TestUtilities;

/// <summary>
/// Provides common service mocks for Application layer testing
/// </summary>
public static class ServiceMocks
{
    /// <summary>
    /// Creates a mock for any service interface
    /// </summary>
    public static Mock<T> CreateServiceMock<T>() where T : class
    {
        return new Mock<T>();
    }

    /// <summary>
    /// Creates a collection of common service mocks
    /// </summary>
    public static class Common
    {
        public static Mock<IAuthenticationService> CreateAuthenticationServiceMock()
        {
            return new Mock<IAuthenticationService>();
        }

        public static Mock<IUserService> CreateUserServiceMock()
        {
            return new Mock<IUserService>();
        }

        public static Mock<ICategoryService> CreateCategoryServiceMock()
        {
            return new Mock<ICategoryService>();
        }

        public static Mock<ICompanyService> CreateCompanyServiceMock()
        {
            return new Mock<ICompanyService>();
        }

        public static Mock<IOrganizationService> CreateOrganizationServiceMock()
        {
            return new Mock<IOrganizationService>();
        }

        public static Mock<IPreDocumentService> CreatePreDocumentServiceMock()
        {
            return new Mock<IPreDocumentService>();
        }

        public static Mock<ISupplierService> CreateSupplierServiceMock()
        {
            return new Mock<ISupplierService>();
        }

        public static Mock<ISupplierDocumentService> CreateSupplierDocumentServiceMock()
        {
            return new Mock<ISupplierDocumentService>();
        }

        public static Mock<IJwtProvider> CreateJwtProviderMock()
        {
            return new Mock<IJwtProvider>();
        }

        public static Mock<IServiceImplementation> CreateServiceImplementationMock()
        {
            return new Mock<IServiceImplementation>();
        }
    }

    /// <summary>
    /// Creates a collection of infrastructure service mocks
    /// </summary>
    public static class Infrastructure
    {
        public static Mock<IEmailService> CreateEmailServiceMock()
        {
            return new Mock<IEmailService>();
        }

        public static Mock<IFileHandler> CreateFileHandlerMock()
        {
            return new Mock<IFileHandler>();
        }

        public static Mock<INotificationService> CreateNotificationServiceMock()
        {
            return new Mock<INotificationService>();
        }
    }
}
