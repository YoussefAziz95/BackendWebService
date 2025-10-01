using Domain;
using Domain.Enums;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class CustomerServiceTests
{
    [Fact]
    public void CustomerService_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var customerService = new CustomerService();

        // Assert
        customerService.Should().NotBeNull();
        customerService.Status.Should().Be(StatusEnum.Pending);
        customerService.RequestedDate.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
    }

    [Fact]
    public void CustomerService_WithMinimalData_ShouldBeCreatable()
    {
        // Arrange
        var customerId = 123;
        var serviceId = 456;
        var description = "Test service";

        // Act
        var customerService = new CustomerService
        {
            CustomerId = customerId,
            ServiceId = serviceId,
            Description = description
        };

        // Assert
        customerService.CustomerId.Should().Be(customerId);
        customerService.ServiceId.Should().Be(serviceId);
        customerService.Description.Should().Be(description);
        customerService.Status.Should().Be(StatusEnum.Pending);
    }

    [Fact]
    public void CustomerService_WithCompleteData_ShouldBeCreatable()
    {
        // Arrange
        var customerId = 123;
        var serviceId = 456;
        var propertyId = 789;
        var notes = "Additional notes";
        var voiceNoteId = 101;
        var filesId = 102;
        var status = StatusEnum.Completed;
        var description = "Complete service";
        var requestedDate = DateTime.UtcNow.AddDays(-1);
        var scheduledDate = DateTime.UtcNow.AddDays(1);
        var completedDate = DateTime.UtcNow;
        var handledByUserId = 999;

        // Act
        var customerService = new CustomerService
        {
            CustomerId = customerId,
            ServiceId = serviceId,
            PropertyId = propertyId,
            Notes = notes,
            VoiceNoteId = voiceNoteId,
            FilesId = filesId,
            Status = status,
            Description = description,
            RequestedDate = requestedDate,
            ScheduledDate = scheduledDate,
            CompletedDate = completedDate,
            HandledByUserId = handledByUserId
        };

        // Assert
        customerService.CustomerId.Should().Be(customerId);
        customerService.ServiceId.Should().Be(serviceId);
        customerService.PropertyId.Should().Be(propertyId);
        customerService.Notes.Should().Be(notes);
        customerService.VoiceNoteId.Should().Be(voiceNoteId);
        customerService.FilesId.Should().Be(filesId);
        customerService.Status.Should().Be(status);
        customerService.Description.Should().Be(description);
        customerService.RequestedDate.Should().Be(requestedDate);
        customerService.ScheduledDate.Should().Be(scheduledDate);
        customerService.CompletedDate.Should().Be(completedDate);
        customerService.HandledByUserId.Should().Be(handledByUserId);
    }

    [Theory]
    [InlineData(StatusEnum.Pending)]
    [InlineData(StatusEnum.Active)]
    [InlineData(StatusEnum.Completed)]
    [InlineData(StatusEnum.Returned)]
    [InlineData(StatusEnum.Deleted)]
    public void CustomerService_Status_ShouldBeSettable(StatusEnum status)
    {
        // Arrange
        var customerService = new CustomerService();

        // Act
        customerService.Status = status;

        // Assert
        customerService.Status.Should().Be(status);
    }

    [Theory]
    [InlineData("Service description")]
    [InlineData("Another service")]
    [InlineData("")]
    public void CustomerService_Description_ShouldBeSettable(string description)
    {
        // Arrange
        var customerService = new CustomerService();

        // Act
        customerService.Description = description;

        // Assert
        customerService.Description.Should().Be(description);
    }

    [Theory]
    [InlineData("Additional notes")]
    [InlineData("")]
    [InlineData(null)]
    public void CustomerService_Notes_ShouldBeSettable(string notes)
    {
        // Arrange
        var customerService = new CustomerService();

        // Act
        customerService.Notes = notes;

        // Assert
        customerService.Notes.Should().Be(notes);
    }

    [Fact]
    public void CustomerService_RequestedDate_ShouldDefaultToCurrentTime()
    {
        // Act
        var customerService = new CustomerService();

        // Assert
        customerService.RequestedDate.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
    }

    [Fact]
    public void CustomerService_OptionalProperties_ShouldBeNullable()
    {
        // Arrange
        var customerService = new CustomerService();

        // Act & Assert
        customerService.PropertyId.Should().BeNull();
        customerService.Notes.Should().BeNull();
        customerService.VoiceNoteId.Should().BeNull();
        customerService.FilesId.Should().BeNull();
        customerService.ScheduledDate.Should().BeNull();
        customerService.CompletedDate.Should().BeNull();
        customerService.HandledByUserId.Should().BeNull();
    }

    [Fact]
    public void CustomerService_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var customerService = new CustomerService();

        // Act
        var result = customerService.ToString();

        // Assert
        result.Should().Contain("CustomerService");
    }

    [Fact]
    public void CustomerService_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var customerService = new CustomerService();

        // Act & Assert
        customerService.Should().BeAssignableTo<BaseEntity>();
        customerService.Should().BeAssignableTo<IEntity>();
        customerService.Should().BeAssignableTo<ITimeModification>();
    }
}
