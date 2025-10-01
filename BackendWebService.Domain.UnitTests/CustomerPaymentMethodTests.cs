using Domain;
using Domain.Enums;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class CustomerPaymentMethodTests
{
    [Fact]
    public void CustomerPaymentMethod_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var customerPaymentMethod = new CustomerPaymentMethod();

        // Assert
        customerPaymentMethod.Should().NotBeNull();
    }

    [Fact]
    public void CustomerPaymentMethod_WithMinimalData_ShouldBeCreatable()
    {
        // Arrange
        var customerId = 123;
        var paymentMethodId = 456;

        // Act
        var customerPaymentMethod = new CustomerPaymentMethod
        {
            CustomerId = customerId,
            PaymentMethodId = paymentMethodId
        };

        // Assert
        customerPaymentMethod.CustomerId.Should().Be(customerId);
        customerPaymentMethod.PaymentMethodId.Should().Be(paymentMethodId);
    }

    [Fact]
    public void CustomerPaymentMethod_WithCompleteData_ShouldBeCreatable()
    {
        // Arrange
        var customerId = 123;
        var paymentMethodId = 456;
        var serviceId = 789;
        var propertyId = 101;
        var notes = "Additional notes";
        var voiceNoteId = 102;
        var filesId = 103;
        var status = StatusEnum.Completed;
        var description = "Complete payment method";
        var requestedDate = DateTime.UtcNow.AddDays(-1);
        var scheduledDate = DateTime.UtcNow.AddDays(1);
        var completedDate = DateTime.UtcNow;
        var updatedByUserId = 999;

        // Act
        var customerPaymentMethod = new CustomerPaymentMethod
        {
            CustomerId = customerId,
            PaymentMethodId = paymentMethodId,
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
            UpdatedByUserId = updatedByUserId
        };

        // Assert
        customerPaymentMethod.CustomerId.Should().Be(customerId);
        customerPaymentMethod.PaymentMethodId.Should().Be(paymentMethodId);
        customerPaymentMethod.ServiceId.Should().Be(serviceId);
        customerPaymentMethod.PropertyId.Should().Be(propertyId);
        customerPaymentMethod.Notes.Should().Be(notes);
        customerPaymentMethod.VoiceNoteId.Should().Be(voiceNoteId);
        customerPaymentMethod.FilesId.Should().Be(filesId);
        customerPaymentMethod.Status.Should().Be(status);
        customerPaymentMethod.Description.Should().Be(description);
        customerPaymentMethod.RequestedDate.Should().Be(requestedDate);
        customerPaymentMethod.ScheduledDate.Should().Be(scheduledDate);
        customerPaymentMethod.CompletedDate.Should().Be(completedDate);
        customerPaymentMethod.UpdatedByUserId.Should().Be(updatedByUserId);
    }

    [Theory]
    [InlineData(StatusEnum.Pending)]
    [InlineData(StatusEnum.Active)]
    [InlineData(StatusEnum.Completed)]
    [InlineData(StatusEnum.Returned)]
    [InlineData(StatusEnum.Deleted)]
    public void CustomerPaymentMethod_Status_ShouldBeSettable(StatusEnum status)
    {
        // Arrange
        var customerPaymentMethod = new CustomerPaymentMethod();

        // Act
        customerPaymentMethod.Status = status;

        // Assert
        customerPaymentMethod.Status.Should().Be(status);
    }

    [Theory]
    [InlineData("Payment method description")]
    [InlineData("Another description")]
    [InlineData("")]
    public void CustomerPaymentMethod_Description_ShouldBeSettable(string description)
    {
        // Arrange
        var customerPaymentMethod = new CustomerPaymentMethod();

        // Act
        customerPaymentMethod.Description = description;

        // Assert
        customerPaymentMethod.Description.Should().Be(description);
    }

    [Fact]
    public void CustomerPaymentMethod_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var customerPaymentMethod = new CustomerPaymentMethod();

        // Act
        var result = customerPaymentMethod.ToString();

        // Assert
        result.Should().Contain("CustomerPaymentMethod");
    }

    [Fact]
    public void CustomerPaymentMethod_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var customerPaymentMethod = new CustomerPaymentMethod();

        // Act & Assert
        customerPaymentMethod.Should().BeAssignableTo<BaseEntity>();
        customerPaymentMethod.Should().BeAssignableTo<IEntity>();
        customerPaymentMethod.Should().BeAssignableTo<ITimeModification>();
    }
}
