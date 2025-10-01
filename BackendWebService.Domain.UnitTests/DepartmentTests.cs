using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class DepartmentTests
{
    [Fact]
    public void Department_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var department = new Department();

        // Assert
        department.Should().NotBeNull();
        department.Name.Should().BeNull();
        department.Description.Should().BeNull();
        department.ParentDepartmentId.Should().BeNull();
        department.ParentDepartment.Should().BeNull();
        department.SubDepartments.Should().BeNull();
        department.OrganizationId.Should().BeNull();
        department.Organization.Should().BeNull();
        department.BranchId.Should().BeNull();
        department.Branch.Should().BeNull();
        department.Code.Should().BeNull();
        department.IsActive.Should().BeTrue();
    }

    [Fact]
    public void Department_AllProperties_ShouldBeSettable()
    {
        // Arrange
        var department = new Department();
        var parentDepartment = new Department();
        var subDepartments = new List<Department>();
        var organization = new Organization();
        var branch = new Branch();

        // Act
        department.Name = "IT Department";
        department.Description = "Information Technology Department";
        department.ParentDepartmentId = 123;
        department.ParentDepartment = parentDepartment;
        department.SubDepartments = subDepartments;
        department.OrganizationId = 456;
        department.Organization = organization;
        department.BranchId = 789;
        department.Branch = branch;
        department.Code = "IT001";
        department.IsActive = false;

        // Assert
        department.Name.Should().Be("IT Department");
        department.Description.Should().Be("Information Technology Department");
        department.ParentDepartmentId.Should().Be(123);
        department.ParentDepartment.Should().BeSameAs(parentDepartment);
        department.SubDepartments.Should().BeSameAs(subDepartments);
        department.OrganizationId.Should().Be(456);
        department.Organization.Should().BeSameAs(organization);
        department.BranchId.Should().Be(789);
        department.Branch.Should().BeSameAs(branch);
        department.Code.Should().Be("IT001");
        department.IsActive.Should().BeFalse();
    }

    [Fact]
    public void Department_WithNullValues_ShouldBeCreatable()
    {
        // Arrange & Act
        var department = new Department
        {
            Name = null!,
            Description = null!,
            ParentDepartmentId = null!,
            ParentDepartment = null!,
            SubDepartments = null!,
            OrganizationId = null!,
            Organization = null!,
            BranchId = null!,
            Branch = null!,
            Code = null
        };

        // Assert
        department.Name.Should().BeNull();
        department.Description.Should().BeNull();
        department.ParentDepartmentId.Should().BeNull();
        department.ParentDepartment.Should().BeNull();
        department.SubDepartments.Should().BeNull();
        department.OrganizationId.Should().BeNull();
        department.Organization.Should().BeNull();
        department.BranchId.Should().BeNull();
        department.Branch.Should().BeNull();
        department.Code.Should().BeNull();
    }

    [Fact]
    public void Department_WithMinimalData_ShouldBeCreatable()
    {
        // Arrange & Act
        var department = new Department
        {
            Name = "HR"
        };

        // Assert
        department.Name.Should().Be("HR");
        department.Description.Should().BeNull();
        department.ParentDepartmentId.Should().BeNull();
        department.OrganizationId.Should().BeNull();
        department.IsActive.Should().BeTrue();
    }

    [Fact]
    public void Department_WithCompleteData_ShouldBeCreatable()
    {
        // Arrange
        var parentDepartment = new Department { Id = 100 };
        var organization = new Organization { Id = 200 };
        var branch = new Branch { Id = 300 };

        // Act
        var department = new Department
        {
            Name = "Finance Department",
            Description = "Handles all financial operations",
            ParentDepartmentId = 100,
            ParentDepartment = parentDepartment,
            OrganizationId = 200,
            Organization = organization,
            BranchId = 300,
            Branch = branch,
            Code = "FIN001",
            IsActive = true
        };

        // Assert
        department.Name.Should().Be("Finance Department");
        department.Description.Should().Be("Handles all financial operations");
        department.ParentDepartmentId.Should().Be(100);
        department.ParentDepartment.Should().BeSameAs(parentDepartment);
        department.OrganizationId.Should().Be(200);
        department.Organization.Should().BeSameAs(organization);
        department.BranchId.Should().Be(300);
        department.Branch.Should().BeSameAs(branch);
        department.Code.Should().Be("FIN001");
        department.IsActive.Should().BeTrue();
    }

    [Fact]
    public void Department_WithEmptyStrings_ShouldBeCreatable()
    {
        // Arrange & Act
        var department = new Department
        {
            Name = "",
            Description = "",
            Code = ""
        };

        // Assert
        department.Name.Should().Be("");
        department.Description.Should().Be("");
        department.Code.Should().Be("");
    }

    [Fact]
    public void Department_WithLongStrings_ShouldBeCreatable()
    {
        // Arrange
        var longName = new string('A', 1000);
        var longDescription = new string('B', 2000);
        var longCode = new string('C', 500);

        // Act
        var department = new Department
        {
            Name = longName,
            Description = longDescription,
            Code = longCode
        };

        // Assert
        department.Name.Should().Be(longName);
        department.Description.Should().Be(longDescription);
        department.Code.Should().Be(longCode);
    }

    [Fact]
    public void Department_WithNegativeIds_ShouldBeCreatable()
    {
        // Arrange & Act
        var department = new Department
        {
            ParentDepartmentId = -1,
            OrganizationId = -1,
            BranchId = -1
        };

        // Assert
        department.ParentDepartmentId.Should().Be(-1);
        department.OrganizationId.Should().Be(-1);
        department.BranchId.Should().Be(-1);
    }

    [Fact]
    public void Department_WithZeroIds_ShouldBeCreatable()
    {
        // Arrange & Act
        var department = new Department
        {
            ParentDepartmentId = 0,
            OrganizationId = 0,
            BranchId = 0
        };

        // Assert
        department.ParentDepartmentId.Should().Be(0);
        department.OrganizationId.Should().Be(0);
        department.BranchId.Should().Be(0);
    }

    [Fact]
    public void Department_WithEmptySubDepartments_ShouldBeCreatable()
    {
        // Arrange & Act
        var department = new Department
        {
            SubDepartments = new List<Department>()
        };

        // Assert
        department.SubDepartments.Should().NotBeNull();
        department.SubDepartments.Should().BeEmpty();
    }

    [Fact]
    public void Department_WithMultipleSubDepartments_ShouldBeCreatable()
    {
        // Arrange
        var subDepartments = new List<Department>
        {
            new Department { Name = "Sub Dept 1" },
            new Department { Name = "Sub Dept 2" },
            new Department { Name = "Sub Dept 3" }
        };

        // Act
        var department = new Department
        {
            SubDepartments = subDepartments
        };

        // Assert
        department.SubDepartments.Should().HaveCount(3);
        department.SubDepartments.Should().Contain(subDepartments);
    }

    [Fact]
    public void Department_ShouldInheritFromBaseEntity()
    {
        // Arrange
        var department = new Department();

        // Assert
        department.Should().BeAssignableTo<BaseEntity>();
        department.Should().BeAssignableTo<IEntity>();
        department.Should().BeAssignableTo<ITimeModification>();
    }

    [Fact]
    public void Department_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var department = new Department { Id = 999 };

        // Act
        var result = department.ToString();

        // Assert
        result.Should().Contain("Department");
    }

    [Theory]
    [InlineData("Sales", "Handles sales operations", 1, true)]
    [InlineData("Marketing", "Handles marketing operations", 2, false)]
    [InlineData("", "", null!, true)]
    public void Department_WithVariousValues_ShouldBeCreatable(string name, string description, int? organizationId, bool isActive)
    {
        // Arrange & Act
        var department = new Department
        {
            Name = name,
            Description = description,
            OrganizationId = organizationId,
            IsActive = isActive
        };

        // Assert
        department.Name.Should().Be(name);
        department.Description.Should().Be(description);
        department.OrganizationId.Should().Be(organizationId);
        department.IsActive.Should().Be(isActive);
    }
}
