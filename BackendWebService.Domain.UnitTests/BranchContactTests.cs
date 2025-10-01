using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class BranchContactTests
{
    [Fact]
    public void BranchContact_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var branchContact = new BranchContact();

        // Assert
        branchContact.Should().NotBeNull();
    }

    [Fact]
    public void BranchContact_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var branchContact = new BranchContact();

        // Act
        var result = branchContact.ToString();

        // Assert
        result.Should().Contain("BranchContact");
    }

    [Fact]
    public void BranchContact_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var branchContact = new BranchContact();

        // Act & Assert
        branchContact.Should().BeAssignableTo<BaseEntity>();
        branchContact.Should().BeAssignableTo<IEntity>();
        branchContact.Should().BeAssignableTo<ITimeModification>();
    }
}
