using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class NotificationDetailTests
{
    [Fact]
    public void NotificationDetail_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var notificationDetail = new NotificationDetail();

        // Assert
        notificationDetail.Should().NotBeNull();
    }

    [Fact]
    public void NotificationDetail_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var notificationDetail = new NotificationDetail();

        // Act
        var result = notificationDetail.ToString();

        // Assert
        result.Should().Contain("NotificationDetail");
    }

    [Fact]
    public void NotificationDetail_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var notificationDetail = new NotificationDetail();

        // Act & Assert
        notificationDetail.Should().BeAssignableTo<BaseEntity>();
        notificationDetail.Should().BeAssignableTo<IEntity>();
        notificationDetail.Should().BeAssignableTo<ITimeModification>();
    }
}
