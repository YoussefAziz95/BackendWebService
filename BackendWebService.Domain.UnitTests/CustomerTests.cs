using Domain;
using Domain.Enums;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class CustomerTests
{
    [Fact]
    public void Customer_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var customer = new Customer();

        // Assert
        customer.Should().NotBeNull();
        customer.MFAEnabled.Should().BeFalse();
        customer.Role.Should().Be(RoleEnum.Customer);
        customer.Status.Should().Be(StatusEnum.Active);
        customer.CustomerServices.Should().NotBeNull();
        customer.CustomerPaymentMethods.Should().NotBeNull();
    }

    [Fact]
    public void Customer_WithMinimalData_ShouldBeCreatable()
    {
        // Arrange
        var userId = 123;

        // Act
        var customer = new Customer
        {
            UserId = userId
        };

        // Assert
        customer.UserId.Should().Be(userId);
        customer.MFAEnabled.Should().BeFalse();
        customer.Role.Should().Be(RoleEnum.Customer);
        customer.Status.Should().Be(StatusEnum.Active);
    }

    [Fact]
    public void Customer_WithCompleteData_ShouldBeCreatable()
    {
        // Arrange
        var userId = 456;
        var mfaEnabled = true;
        var role = RoleEnum.Admin;
        var status = StatusEnum.Pending;

        // Act
        var customer = new Customer
        {
            UserId = userId,
            MFAEnabled = mfaEnabled,
            Role = role,
            Status = status
        };

        // Assert
        customer.UserId.Should().Be(userId);
        customer.MFAEnabled.Should().Be(mfaEnabled);
        customer.Role.Should().Be(role);
        customer.Status.Should().Be(status);
    }

    [Theory]
    [InlineData(RoleEnum.Admin)]
    [InlineData(RoleEnum.Employee)]
    [InlineData(RoleEnum.Customer)]
    public void Customer_Role_ShouldBeSettable(RoleEnum role)
    {
        // Arrange
        var customer = new Customer();

        // Act
        customer.Role = role;

        // Assert
        customer.Role.Should().Be(role);
    }

    [Theory]
    [InlineData(StatusEnum.Active)]
    [InlineData(StatusEnum.Pending)]
    [InlineData(StatusEnum.Completed)]
    [InlineData(StatusEnum.Returned)]
    [InlineData(StatusEnum.Deleted)]
    public void Customer_Status_ShouldBeSettable(StatusEnum status)
    {
        // Arrange
        var customer = new Customer();

        // Act
        customer.Status = status;

        // Assert
        customer.Status.Should().Be(status);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void Customer_MFAEnabled_ShouldBeSettable(bool mfaEnabled)
    {
        // Arrange
        var customer = new Customer();

        // Act
        customer.MFAEnabled = mfaEnabled;

        // Assert
        customer.MFAEnabled.Should().Be(mfaEnabled);
    }

    [Fact]
    public void Customer_Collections_ShouldBeInitialized()
    {
        // Act
        var customer = new Customer();

        // Assert
        customer.CustomerServices.Should().NotBeNull();
        customer.CustomerPaymentMethods.Should().NotBeNull();
        customer.CustomerServices.Should().BeEmpty();
        customer.CustomerPaymentMethods.Should().BeEmpty();
    }

    [Fact]
    public void Customer_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var customer = new Customer();

        // Act
        var result = customer.ToString();

        // Assert
        result.Should().Contain("Customer");
    }

    [Fact]
    public void Customer_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var customer = new Customer();

        // Act & Assert
        customer.Should().BeAssignableTo<BaseEntity>();
        customer.Should().BeAssignableTo<IEntity>();
        customer.Should().BeAssignableTo<ITimeModification>();
    }
}