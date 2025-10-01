using Xunit;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Identity;
using Persistence.Data;
using BackendWebService.Persistence.UnitTests.TestUtilities;
using Domain;
using Domain.Enums;
using Application.Model.Notifications;
using System.Linq;

namespace BackendWebService.Persistence.UnitTests.Repositories.Identity;

public class RoleRepositoryTests : IDisposable
{
    private readonly ApplicationDbContext _context;
    private readonly RoleRepository _roleRepository;

    public RoleRepositoryTests()
    {
        _context = DbContextMocks.CreateInMemoryDbContext();
        _roleRepository = new RoleRepository(_context);
        
        // Set up user info for testing
        _context.userInfo = new UserInfo
        {
            Username = "testuser",
            UserId = 1,
            OrganizationId = 1,
            RoleId = 1,
            RoleParentId = 1
        };
    }

    [Fact]
    public void Constructor_ShouldInitializeCorrectly()
    {
        // Act & Assert
        _roleRepository.Should().NotBeNull();
    }

    #region GetRoles Tests

    [Fact]
    public void GetRoles_ShouldReturnRolesForOrganization()
    {
        // Arrange
        var roles = TestDataBuilder.Collections.CreateRoles(3);
        roles[0].ParentId = 1;
        roles[1].ParentId = 1;
        roles[2].ParentId = 2; // Different parent
        
        _context.Roles.AddRange(roles);
        _context.SaveChanges();

        // Act
        var result = _roleRepository.getRoles();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2); // Only roles with parent ID 1
        result.Should().OnlyContain(r => r.ParentId == 1);
    }

    [Fact]
    public void GetRoles_WithNoRoles_ShouldReturnEmptyQueryable()
    {
        // Act
        var result = _roleRepository.getRoles();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }

    [Fact]
    public void GetRoles_WithZeroRoleParentId_ShouldReturnAllRoles()
    {
        // Arrange
        _context.userInfo.RoleParentId = 0;
        var roles = TestDataBuilder.Collections.CreateRoles(3);
        roles[0].ParentId = 1;
        roles[1].ParentId = 2;
        roles[2].ParentId = 3;
        
        _context.Roles.AddRange(roles);
        _context.SaveChanges();

        // Act
        var result = _roleRepository.getRoles();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(3);
    }

    #endregion

    #region GetActorType Tests

    [Fact]
    public void GetActorType_WithValidId_ShouldReturnRoleName()
    {
        // Arrange
        var role = TestDataBuilder.Entities.CreateRole(name: "AdminRole");
        _context.Roles.Add(role);
        _context.SaveChanges();

        // Act
        var result = _roleRepository.GetActorType(1);

        // Assert
        result.Should().Be("AdminRole");
    }

    [Fact]
    public void GetActorType_WithInvalidId_ShouldReturnEmptyString()
    {
        // Act
        var result = _roleRepository.GetActorType(999);

        // Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public void GetActorType_WithNullName_ShouldReturnEmptyString()
    {
        // Arrange
        var role = TestDataBuilder.Entities.CreateRole(name: null);
        _context.Roles.Add(role);
        _context.SaveChanges();

        // Act
        var result = _roleRepository.GetActorType(1);

        // Assert
        result.Should().BeEmpty();
    }

    #endregion

    #region GetRolePermissions Tests

    [Fact]
    public void GetRolePermissions_WithValidRoleId_ShouldReturnClaims()
    {
        // Arrange
        var role = TestDataBuilder.Entities.CreateRole();
        var roleClaim1 = new RoleClaim
        {
            Id = 1,
            RoleId = 1,
            ClaimType = "Permission",
            ClaimValue = "Read"
        };
        var roleClaim2 = new RoleClaim
        {
            Id = 2,
            RoleId = 1,
            ClaimType = "Permission",
            ClaimValue = "Write"
        };
        
        _context.Roles.Add(role);
        _context.RoleClaims.AddRange(roleClaim1, roleClaim2);
        _context.SaveChanges();

        // Act
        var result = _roleRepository.GetRolePermissions(1);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result.Should().Contain(c => c.Id == 1 && c.Value == "Read");
        result.Should().Contain(c => c.Id == 2 && c.Value == "Write");
    }

    [Fact]
    public void GetRolePermissions_WithInvalidRoleId_ShouldThrowException()
    {
        // Act & Assert
        var action = () => _roleRepository.GetRolePermissions(999);
        action.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void GetRolePermissions_WithNoClaims_ShouldReturnEmptyList()
    {
        // Arrange
        var role = TestDataBuilder.Entities.CreateRole();
        _context.Roles.Add(role);
        _context.SaveChanges();

        // Act
        var result = _roleRepository.GetRolePermissions(1);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }

    #endregion

    #region GetActions Tests

    [Fact]
    public void GetActions_ShouldThrowNotImplementedException()
    {
        // Act & Assert
        var action = () => _roleRepository.getActions(1);
        action.Should().Throw<NotImplementedException>();
    }

    #endregion

    #region GetRole Tests

    [Fact]
    public void GetRole_ShouldThrowNotImplementedException()
    {
        // Act & Assert
        var action = () => _roleRepository.getRole(1);
        action.Should().Throw<NotImplementedException>();
    }

    #endregion

    #region UserInfo Tests

    [Fact]
    public void GetRoles_WithNullUserInfo_ShouldThrowException()
    {
        // Arrange
        _context.userInfo = null;
        var roles = TestDataBuilder.Collections.CreateRoles(1);
        _context.Roles.AddRange(roles);
        _context.SaveChanges();

        // Act & Assert
        var action = () => _roleRepository.getRoles();
        action.Should().Throw<NullReferenceException>();
    }

    #endregion

    #region Edge Cases

    [Fact]
    public void GetRoles_WithNegativeRoleParentId_ShouldReturnEmptyQueryable()
    {
        // Arrange
        _context.userInfo.RoleParentId = -1;
        var roles = TestDataBuilder.Collections.CreateRoles(2);
        roles[0].ParentId = 1;
        roles[1].ParentId = 2;
        
        _context.Roles.AddRange(roles);
        _context.SaveChanges();

        // Act
        var result = _roleRepository.getRoles();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }

    [Fact]
    public void GetActorType_WithMultipleRoles_ShouldReturnCorrectRoleName()
    {
        // Arrange
        var role1 = TestDataBuilder.Entities.CreateRole(name: "AdminRole");
        var role2 = TestDataBuilder.Entities.CreateRole(name: "UserRole");
        
        _context.Roles.AddRange(role1, role2);
        _context.SaveChanges();

        // Act
        var result1 = _roleRepository.GetActorType(1);
        var result2 = _roleRepository.GetActorType(2);

        // Assert
        result1.Should().Be("AdminRole");
        result2.Should().Be("UserRole");
    }

    #endregion

    public void Dispose()
    {
        _context?.Dispose();
    }
}
