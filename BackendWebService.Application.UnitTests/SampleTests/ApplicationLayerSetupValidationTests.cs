using Xunit;
using FluentAssertions;
using Moq;
using BackendWebService.Application.UnitTests.TestUtilities;
using Application.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BackendWebService.Application.UnitTests.SampleTests;

/// <summary>
/// Sample tests to validate Application layer test project setup
/// </summary>
public class ApplicationLayerSetupValidationTests
{
    [Fact]
    public void TestProjectSetup_ShouldBeConfiguredCorrectly()
    {
        // Arrange & Act
        var testProject = typeof(ApplicationLayerSetupValidationTests).Assembly;

        // Assert
        testProject.Should().NotBeNull();
        testProject.GetName().Name.Should().Be("BackendWebService.Application.UnitTests");
    }

    [Fact]
    public void RepositoryMocks_ShouldCreateMocksSuccessfully()
    {
        // Arrange & Act
        var repositoryMock = RepositoryMocks.CreateRepositoryMock<object>();

        // Assert
        repositoryMock.Should().NotBeNull();
    }

    [Fact]
    public void ServiceMocks_ShouldCreateMocksSuccessfully()
    {
        // Arrange & Act
        var userServiceMock = ServiceMocks.Common.CreateUserServiceMock();
        var authServiceMock = ServiceMocks.Common.CreateAuthenticationServiceMock();
        var emailServiceMock = ServiceMocks.Infrastructure.CreateEmailServiceMock();

        // Assert
        userServiceMock.Should().NotBeNull();
        authServiceMock.Should().NotBeNull();
        emailServiceMock.Should().NotBeNull();
    }

    [Fact]
    public void ExternalDependencyMocks_ShouldCreateMocksSuccessfully()
    {
        // Arrange & Act
        var userManagerMock = ExternalDependencyMocks.Managers.CreateUserManagerMock();
        var roleManagerMock = ExternalDependencyMocks.Managers.CreateRoleManagerMock();
        var httpContextAccessorMock = ExternalDependencyMocks.ExternalServices.CreateHttpContextAccessorMock();

        // Assert
        userManagerMock.Should().NotBeNull();
        roleManagerMock.Should().NotBeNull();
        httpContextAccessorMock.Should().NotBeNull();
    }

    [Fact]
    public void TestDataBuilder_ShouldCreateTestEntitiesSuccessfully()
    {
        // Arrange & Act
        var user = TestDataBuilder.Entities.CreateUser();
        var role = TestDataBuilder.Entities.CreateRole();

        // Assert
        user.Should().NotBeNull();
        user.Id.Should().Be(1);
        user.Email.Should().Be("test@example.com");
        user.UserName.Should().Be("testuser");

        role.Should().NotBeNull();
        role.Id.Should().Be(1);
        role.Name.Should().Be("TestRole");
    }

    [Fact]
    public void TestDataBuilder_ShouldCreateTestDTOsSuccessfully()
    {
        // Arrange & Act
        var successResponse = TestDataBuilder.DTOs.CreateSuccessResponse("test data");
        var errorResponse = TestDataBuilder.DTOs.CreateErrorResponse<string>("test error");
        var dropDownResponse = TestDataBuilder.DTOs.CreateDropDownResponse("1", "Test Item");

        // Assert
        successResponse.Should().NotBeNull();
        successResponse.Succeeded.Should().BeTrue();
        successResponse.Data.Should().Be("test data");

        errorResponse.Should().NotBeNull();
        errorResponse.Succeeded.Should().BeFalse();
        errorResponse.Message.Should().Be("test error");

        dropDownResponse.Should().NotBeNull();
        dropDownResponse.Items.Should().ContainKey(1);
        dropDownResponse.Items[1].Should().Be("Test Item");
    }

    [Fact]
    public void MockSetup_ShouldWorkWithFluentAssertions()
    {
        // Arrange
        var serviceMock = ServiceMocks.Common.CreateAuthenticationServiceMock();
        var testEmail = "test@example.com";

        // Act
        serviceMock.Setup(x => x.getEmail())
            .Returns(testEmail);

        // Assert
        serviceMock.Verify(x => x.getEmail(), Times.Never);
        
        var result = serviceMock.Object.getEmail();
        result.Should().NotBeNull();
        result.Should().Be(testEmail);
        
        serviceMock.Verify(x => x.getEmail(), Times.Once);
    }

    [Fact]
    public void TestUtilities_ShouldBeAccessibleFromTestClasses()
    {
        // Arrange & Act
        var repositoryMock = RepositoryMocks.CreateRepositoryMock<object>();
        var serviceMock = ServiceMocks.CreateServiceMock<IAuthenticationService>();
        var externalMock = ExternalDependencyMocks.CreateExternalDependencyMock<IHttpContextAccessor>();

        // Assert
        repositoryMock.Should().NotBeNull();
        serviceMock.Should().NotBeNull();
        externalMock.Should().NotBeNull();
    }
}
