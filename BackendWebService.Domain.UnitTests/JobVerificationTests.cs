using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class JobVerificationTests
{
    [Fact]
    public void JobVerification_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var jobVerification = new JobVerification();

        // Assert
        jobVerification.Should().NotBeNull();
    }

    [Fact]
    public void JobVerification_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var jobVerification = new JobVerification();

        // Act
        var result = jobVerification.ToString();

        // Assert
        result.Should().Contain("JobVerification");
    }

    [Fact]
    public void JobVerification_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var jobVerification = new JobVerification();

        // Act & Assert
        jobVerification.Should().BeAssignableTo<BaseEntity>();
        jobVerification.Should().BeAssignableTo<IEntity>();
        jobVerification.Should().BeAssignableTo<ITimeModification>();
    }
}
