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
        // Arrange & Act
        var customer = new Customer();

        // Assert
        customer.Should().NotBeNull();
        customer.UserId.Should().Be(0);
        customer.User.Should().BeNull();
        customer.MFAEnabled.Should().BeFalse();
        customer.Role.Should().Be(RoleEnum.Customer);
        customer.Status.Should().Be(StatusEnum.Active);
        customer.CustomerServices.Should().NotBeNull();
        customer.CustomerServices.Should().BeEmpty();
        customer.CustomerPaymentMethods.Should().NotBeNull();
        customer.CustomerPaymentMethods.Should().BeEmpty();
        customer.IsActive.Should().BeTrue();
        customer.IsDeleted.Should().BeFalse();
        customer.IsSystem.Should().BeFalse();
        customer.CreatedDate.Should().NotBeNull();
    }

    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(int.MaxValue)]
    public void Customer_UserId_ShouldBeSettable(int userId)
    {
        // Arrange
        var customer = new Customer();

        // Act
        customer.UserId = userId;

        // Assert
        customer.UserId.Should().Be(userId);
    }

    [Fact]
    public void Customer_User_ShouldBeSettable()
    {
        // Arrange
        var customer = new Customer();
        var user = new User();

        // Act
        customer.User = user;

        // Assert
        customer.User.Should().Be(user);
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
    [InlineData(StatusEnum.Pending)]
    [InlineData(StatusEnum.Active)]
    [InlineData(StatusEnum.Disabled)]
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

    [Fact]
    public void Customer_CustomerServices_ShouldAcceptMultipleItems()
    {
        // Arrange
        var customer = new Customer();
        var service1 = new CustomerService();
        var service2 = new CustomerService();

        // Act
        customer.CustomerServices.Add(service1);
        customer.CustomerServices.Add(service2);

        // Assert
        customer.CustomerServices.Should().HaveCount(2);
        customer.CustomerServices.Should().Contain(service1);
        customer.CustomerServices.Should().Contain(service2);
    }

    [Fact]
    public void Customer_CustomerPaymentMethods_ShouldAcceptMultipleItems()
    {
        // Arrange
        var customer = new Customer();
        var paymentMethod1 = new CustomerPaymentMethod();
        var paymentMethod2 = new CustomerPaymentMethod();

        // Act
        customer.CustomerPaymentMethods.Add(paymentMethod1);
        customer.CustomerPaymentMethods.Add(paymentMethod2);

        // Assert
        customer.CustomerPaymentMethods.Should().HaveCount(2);
        customer.CustomerPaymentMethods.Should().Contain(paymentMethod1);
        customer.CustomerPaymentMethods.Should().Contain(paymentMethod2);
    }

    [Fact]
    public void Customer_WithMinimalData_ShouldBeCreatable()
    {
        // Arrange & Act
        var customer = new Customer
        {
            UserId = 1
        };

        // Assert
        customer.UserId.Should().Be(1);
        customer.MFAEnabled.Should().BeFalse();
        customer.Role.Should().Be(RoleEnum.Customer);
        customer.Status.Should().Be(StatusEnum.Active);
        customer.IsActive.Should().BeTrue();
    }

    [Fact]
    public void Customer_WithCompleteData_ShouldBeCreatable()
    {
        // Arrange & Act
        var user = new User();
        var service = new CustomerService();
        var paymentMethod = new CustomerPaymentMethod();
        var customer = new Customer
        {
            UserId = 1,
            User = user,
            MFAEnabled = true,
            Role = RoleEnum.Customer,
            Status = StatusEnum.Active
        };
        customer.CustomerServices.Add(service);
        customer.CustomerPaymentMethods.Add(paymentMethod);

        // Assert
        customer.UserId.Should().Be(1);
        customer.User.Should().Be(user);
        customer.MFAEnabled.Should().BeTrue();
        customer.Role.Should().Be(RoleEnum.Customer);
        customer.Status.Should().Be(StatusEnum.Active);
        customer.CustomerServices.Should().Contain(service);
        customer.CustomerPaymentMethods.Should().Contain(paymentMethod);
    }

    [Fact]
    public void Customer_WithZeroUserId_ShouldBeCreatable()
    {
        // Arrange & Act
        var customer = new Customer
        {
            UserId = 0
        };

        // Assert
        customer.UserId.Should().Be(0);
        customer.Role.Should().Be(RoleEnum.Customer);
        customer.Status.Should().Be(StatusEnum.Active);
    }

    [Fact]
    public void Customer_WithNegativeUserId_ShouldBeCreatable()
    {
        // Arrange & Act
        var customer = new Customer
        {
            UserId = -1
        };

        // Assert
        customer.UserId.Should().Be(-1);
        customer.Role.Should().Be(RoleEnum.Customer);
        customer.Status.Should().Be(StatusEnum.Active);
    }

    [Fact]
    public void Customer_WithNullUser_ShouldBeCreatable()
    {
        // Arrange & Act
        var customer = new Customer
        {
            UserId = 1,
            User = null
        };

        // Assert
        customer.UserId.Should().Be(1);
        customer.User.Should().BeNull();
    }

    [Fact]
    public void Customer_WithMFAEnabled_ShouldBeCreatable()
    {
        // Arrange & Act
        var customer = new Customer
        {
            UserId = 1,
            MFAEnabled = true
        };

        // Assert
        customer.UserId.Should().Be(1);
        customer.MFAEnabled.Should().BeTrue();
    }

    [Fact]
    public void Customer_WithMFADisabled_ShouldBeCreatable()
    {
        // Arrange & Act
        var customer = new Customer
        {
            UserId = 1,
            MFAEnabled = false
        };

        // Assert
        customer.UserId.Should().Be(1);
        customer.MFAEnabled.Should().BeFalse();
    }

    [Fact]
    public void Customer_WithDifferentStatuses_ShouldBeCreatable()
    {
        // Arrange & Act
        var customer1 = new Customer { UserId = 1, Status = StatusEnum.Active };
        var customer2 = new Customer { UserId = 2, Status = StatusEnum.Pending };
        var customer3 = new Customer { UserId = 3, Status = StatusEnum.Disabled };
        var customer4 = new Customer { UserId = 4, Status = StatusEnum.Deleted };

        // Assert
        customer1.Status.Should().Be(StatusEnum.Active);
        customer2.Status.Should().Be(StatusEnum.Pending);
        customer3.Status.Should().Be(StatusEnum.Disabled);
        customer4.Status.Should().Be(StatusEnum.Deleted);
    }

    [Fact]
    public void Customer_WithDifferentRoles_ShouldBeCreatable()
    {
        // Arrange & Act
        var customer1 = new Customer { UserId = 1, Role = RoleEnum.Admin };
        var customer2 = new Customer { UserId = 2, Role = RoleEnum.Employee };
        var customer3 = new Customer { UserId = 3, Role = RoleEnum.Customer };

        // Assert
        customer1.Role.Should().Be(RoleEnum.Admin);
        customer2.Role.Should().Be(RoleEnum.Employee);
        customer3.Role.Should().Be(RoleEnum.Customer);
    }

    [Fact]
    public void Customer_CustomerServices_ShouldBeInitializedAsEmptyList()
    {
        // Arrange & Act
        var customer = new Customer();

        // Assert
        customer.CustomerServices.Should().NotBeNull();
        customer.CustomerServices.Should().BeEmpty();
    }

    [Fact]
    public void Customer_CustomerPaymentMethods_ShouldBeInitializedAsEmptyList()
    {
        // Arrange & Act
        var customer = new Customer();

        // Assert
        customer.CustomerPaymentMethods.Should().NotBeNull();
        customer.CustomerPaymentMethods.Should().BeEmpty();
    }

    [Fact]
    public void Customer_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var customer = new Customer { UserId = 1 };

        // Act
        var result = customer.ToString();

        // Assert
        result.Should().Contain("Customer");
    }

    [Fact]
    public void Customer_ShouldInheritFromBaseEntity()
    {
        // Arrange & Act
        var customer = new Customer();

        // Assert
        customer.Should().BeAssignableTo<BaseEntity>();
        customer.Should().BeAssignableTo<IEntity>();
        customer.Should().BeAssignableTo<ITimeModification>();
    }

    [Fact]
    public void Customer_AllProperties_ShouldBeSettable()
    {
        // Arrange
        var customer = new Customer();
        var user = new User();
        var service = new CustomerService();
        var paymentMethod = new CustomerPaymentMethod();

        // Act
        customer.UserId = 1;
        customer.User = user;
        customer.MFAEnabled = true;
        customer.Role = RoleEnum.Customer;
        customer.Status = StatusEnum.Active;
        customer.CustomerServices.Add(service);
        customer.CustomerPaymentMethods.Add(paymentMethod);

        // Assert
        customer.UserId.Should().Be(1);
        customer.User.Should().Be(user);
        customer.MFAEnabled.Should().BeTrue();
        customer.Role.Should().Be(RoleEnum.Customer);
        customer.Status.Should().Be(StatusEnum.Active);
        customer.CustomerServices.Should().Contain(service);
        customer.CustomerPaymentMethods.Should().Contain(paymentMethod);
    }
}
