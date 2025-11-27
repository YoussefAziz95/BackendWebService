using Domain;
using Domain.Enums;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class EmployeeTests
{
    [Fact]
    public void Employee_DefaultConstructor_ShouldCreateInstance()
    {
        // Arrange & Act
        var employee = new Employee();

        // Assert
        employee.Should().NotBeNull();
        employee.UserId.Should().Be(0);
        employee.User.Should().BeNull();
        employee.RegistrationDate.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
        employee.AccountStatus.Should().Be(StatusEnum.Pending);
        employee.IsAvailable.Should().BeFalse();
        employee.Role.Should().Be(RoleEnum.Employee);
        employee.Assignments.Should().BeNull();
        employee.Jobs.Should().BeNull();
        employee.IsActive.Should().BeTrue();
        employee.IsDeleted.Should().BeFalse();
        employee.IsSystem.Should().BeFalse();
        employee.CreatedDate.Should().NotBeNull();
    }

    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(int.MaxValue)]
    public void Employee_UserId_ShouldBeSettable(int userId)
    {
        // Arrange
        var employee = new Employee();

        // Act
        employee.UserId = userId;

        // Assert
        employee.UserId.Should().Be(userId);
    }

    [Fact]
    public void Employee_User_ShouldBeSettable()
    {
        // Arrange
        var employee = new Employee();
        var user = new User();

        // Act
        employee.User = user;

        // Assert
        employee.User.Should().Be(user);
    }

    [Fact]
    public void Employee_RegistrationDate_ShouldBeSettable()
    {
        // Arrange
        var employee = new Employee();
        var registrationDate = DateTime.UtcNow.AddDays(-30);

        // Act
        employee.RegistrationDate = registrationDate;

        // Assert
        employee.RegistrationDate.Should().Be(registrationDate);
    }

    [Theory]
    [InlineData(StatusEnum.Pending)]
    [InlineData(StatusEnum.Active)]
    [InlineData(StatusEnum.Disabled)]
    [InlineData(StatusEnum.Deleted)]
    public void Employee_AccountStatus_ShouldBeSettable(StatusEnum accountStatus)
    {
        // Arrange
        var employee = new Employee();

        // Act
        employee.AccountStatus = accountStatus;

        // Assert
        employee.AccountStatus.Should().Be(accountStatus);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void Employee_IsAvailable_ShouldBeSettable(bool isAvailable)
    {
        // Arrange
        var employee = new Employee();

        // Act
        employee.IsAvailable = isAvailable;

        // Assert
        employee.IsAvailable.Should().Be(isAvailable);
    }

    [Theory]
    [InlineData(RoleEnum.Admin)]
    [InlineData(RoleEnum.Employee)]
    [InlineData(RoleEnum.Customer)]
    public void Employee_Role_ShouldBeSettable(RoleEnum role)
    {
        // Arrange
        var employee = new Employee();

        // Act
        employee.Role = role;

        // Assert
        employee.Role.Should().Be(role);
    }

    [Fact]
    public void Employee_Assignments_ShouldBeSettable()
    {
        // Arrange
        var employee = new Employee();
        var assignment = new EmployeeAssignment();

        // Act
        employee.Assignments = new List<EmployeeAssignment> { assignment };

        // Assert
        employee.Assignments.Should().NotBeNull();
        employee.Assignments.Should().Contain(assignment);
    }

    [Fact]
    public void Employee_Jobs_ShouldBeSettable()
    {
        // Arrange
        var employee = new Employee();
        var job = new EmployeeJob();

        // Act
        employee.Jobs = new List<EmployeeJob> { job };

        // Assert
        employee.Jobs.Should().NotBeNull();
        employee.Jobs.Should().Contain(job);
    }

    [Fact]
    public void Employee_WithMinimalData_ShouldBeCreatable()
    {
        // Arrange & Act
        var employee = new Employee
        {
            UserId = 1
        };

        // Assert
        employee.UserId.Should().Be(1);
        employee.AccountStatus.Should().Be(StatusEnum.Pending);
        employee.Role.Should().Be(RoleEnum.Employee);
        employee.IsAvailable.Should().BeFalse();
        employee.IsActive.Should().BeTrue();
    }

    [Fact]
    public void Employee_WithCompleteData_ShouldBeCreatable()
    {
        // Arrange & Act
        var user = new User();
        var registrationDate = DateTime.UtcNow.AddDays(-30);
        var assignment = new EmployeeAssignment();
        var job = new EmployeeJob();
        var employee = new Employee
        {
            UserId = 1,
            User = user,
            RegistrationDate = registrationDate,
            AccountStatus = StatusEnum.Active,
            IsAvailable = true,
            Role = RoleEnum.Employee,
            Assignments = new List<EmployeeAssignment> { assignment },
            Jobs = new List<EmployeeJob> { job }
        };

        // Assert
        employee.UserId.Should().Be(1);
        employee.User.Should().Be(user);
        employee.RegistrationDate.Should().Be(registrationDate);
        employee.AccountStatus.Should().Be(StatusEnum.Active);
        employee.IsAvailable.Should().BeTrue();
        employee.Role.Should().Be(RoleEnum.Employee);
        employee.Assignments.Should().Contain(assignment);
        employee.Jobs.Should().Contain(job);
    }

    [Fact]
    public void Employee_WithZeroUserId_ShouldBeCreatable()
    {
        // Arrange & Act
        var employee = new Employee
        {
            UserId = 0
        };

        // Assert
        employee.UserId.Should().Be(0);
        employee.AccountStatus.Should().Be(StatusEnum.Pending);
    }

    [Fact]
    public void Employee_WithNegativeUserId_ShouldBeCreatable()
    {
        // Arrange & Act
        var employee = new Employee
        {
            UserId = -1
        };

        // Assert
        employee.UserId.Should().Be(-1);
        employee.AccountStatus.Should().Be(StatusEnum.Pending);
    }

    [Fact]
    public void Employee_WithNullUser_ShouldBeCreatable()
    {
        // Arrange & Act
        var employee = new Employee
        {
            UserId = 1,
            User = null!
        };

        // Assert
        employee.UserId.Should().Be(1);
        employee.User.Should().BeNull();
    }

    [Fact]
    public void Employee_WithNullCollections_ShouldBeCreatable()
    {
        // Arrange & Act
        var employee = new Employee
        {
            UserId = 1,
            Assignments = null!,
            Jobs = null
        };

        // Assert
        employee.UserId.Should().Be(1);
        employee.Assignments.Should().BeNull();
        employee.Jobs.Should().BeNull();
    }

    [Fact]
    public void Employee_WithDifferentStatuses_ShouldBeCreatable()
    {
        // Arrange & Act
        var employee1 = new Employee { UserId = 1, AccountStatus = StatusEnum.Active };
        var employee2 = new Employee { UserId = 2, AccountStatus = StatusEnum.Disabled };
        var employee3 = new Employee { UserId = 3, AccountStatus = StatusEnum.Deleted };

        // Assert
        employee1.AccountStatus.Should().Be(StatusEnum.Active);
        employee2.AccountStatus.Should().Be(StatusEnum.Disabled);
        employee3.AccountStatus.Should().Be(StatusEnum.Deleted);
    }

    [Fact]
    public void Employee_WithDifferentRoles_ShouldBeCreatable()
    {
        // Arrange & Act
        var employee1 = new Employee { UserId = 1, Role = RoleEnum.Admin };
        var employee2 = new Employee { UserId = 2, Role = RoleEnum.Employee };
        var employee3 = new Employee { UserId = 3, Role = RoleEnum.Customer };

        // Assert
        employee1.Role.Should().Be(RoleEnum.Admin);
        employee2.Role.Should().Be(RoleEnum.Employee);
        employee3.Role.Should().Be(RoleEnum.Customer);
    }

    [Fact]
    public void Employee_WithAvailabilityStatus_ShouldBeCreatable()
    {
        // Arrange & Act
        var availableEmployee = new Employee { UserId = 1, IsAvailable = true };
        var unavailableEmployee = new Employee { UserId = 2, IsAvailable = false };

        // Assert
        availableEmployee.IsAvailable.Should().BeTrue();
        unavailableEmployee.IsAvailable.Should().BeFalse();
    }

    [Fact]
    public void Employee_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var employee = new Employee { UserId = 1 };

        // Act
        var result = employee.ToString();

        // Assert
        result.Should().Contain("Employee");
    }

    [Fact]
    public void Employee_ShouldInheritFromBaseEntity()
    {
        // Arrange & Act
        var employee = new Employee();

        // Assert
        employee.Should().BeAssignableTo<BaseEntity>();
        employee.Should().BeAssignableTo<IEntity>();
        employee.Should().BeAssignableTo<ITimeModification>();
    }

    [Fact]
    public void Employee_AllProperties_ShouldBeSettable()
    {
        // Arrange
        var employee = new Employee();
        var user = new User();
        var registrationDate = DateTime.UtcNow.AddDays(-30);
        var assignment = new EmployeeAssignment();
        var job = new EmployeeJob();

        // Act
        employee.UserId = 1;
        employee.User = user;
        employee.RegistrationDate = registrationDate;
        employee.AccountStatus = StatusEnum.Active;
        employee.IsAvailable = true;
        employee.Role = RoleEnum.Employee;
        employee.Assignments = new List<EmployeeAssignment> { assignment };
        employee.Jobs = new List<EmployeeJob> { job };

        // Assert
        employee.UserId.Should().Be(1);
        employee.User.Should().Be(user);
        employee.RegistrationDate.Should().Be(registrationDate);
        employee.AccountStatus.Should().Be(StatusEnum.Active);
        employee.IsAvailable.Should().BeTrue();
        employee.Role.Should().Be(RoleEnum.Employee);
        employee.Assignments.Should().Contain(assignment);
        employee.Jobs.Should().Contain(job);
    }
}
