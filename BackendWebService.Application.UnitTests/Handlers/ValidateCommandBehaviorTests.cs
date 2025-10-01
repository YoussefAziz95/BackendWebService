using Xunit;
using FluentAssertions;
using Moq;
using Application.ServicesImplementation.Common;
using Application.Features;
using Application.Contracts.Features;
using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BackendWebService.Application.UnitTests.Handlers;

public class ValidateCommandBehaviorTests
{
    [Fact]
    public async Task Handle_WithValidRequest_ShouldCallNextHandler()
    {
        // Arrange
        var validator = new Mock<IValidator<TestRequest>>();
        var validationResult = new ValidationResult();
        validator.Setup(v => v.ValidateAsync(It.IsAny<TestRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(validationResult);

        var nextHandler = new Mock<RequestHandlerDelegate<IResponse<string>>>();
        var expectedResponse = new Response<string> { Data = "success", Succeeded = true };
        nextHandler.Setup(h => h()).ReturnsAsync(expectedResponse);

        var behavior = new ValidateCommandBehavior<TestRequest, IResponse<string>>(validator.Object);
        var request = new TestRequest { Name = "Test" };

        // Act
        var result = await behavior.Handle(request, nextHandler.Object, CancellationToken.None);

        // Assert
        result.Should().Be(expectedResponse);
        validator.Verify(v => v.ValidateAsync(request, It.IsAny<CancellationToken>()), Times.Once);
        nextHandler.Verify(h => h(), Times.Once);
    }

    [Fact]
    public async Task Handle_WithInvalidRequest_ShouldReturnValidationErrorResponse()
    {
        // Arrange
        var validator = new Mock<IValidator<TestRequest>>();
        var validationResult = new ValidationResult();
        validationResult.Errors.Add(new ValidationFailure("Name", "Name is required"));
        validationResult.Errors.Add(new ValidationFailure("Name", "Name must be at least 3 characters"));
        
        validator.Setup(v => v.ValidateAsync(It.IsAny<TestRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(validationResult);

        var nextHandler = new Mock<RequestHandlerDelegate<IResponse<string>>>();
        var behavior = new ValidateCommandBehavior<TestRequest, IResponse<string>>(validator.Object);
        var request = new TestRequest { Name = "A" };

        // Act
        var result = await behavior.Handle(request, nextHandler.Object, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Succeeded.Should().BeFalse();
        result.Errors.Should().HaveCount(2);
        result.Errors.Should().Contain("Name is required");
        result.Errors.Should().Contain("Name must be at least 3 characters");
        
        validator.Verify(v => v.ValidateAsync(request, It.IsAny<CancellationToken>()), Times.Once);
        nextHandler.Verify(h => h(), Times.Never);
    }

    [Fact]
    public async Task Handle_WithEmptyValidationErrors_ShouldCallNextHandler()
    {
        // Arrange
        var validator = new Mock<IValidator<TestRequest>>();
        var validationResult = new ValidationResult(); // Empty validation result (no errors)
        
        validator.Setup(v => v.ValidateAsync(It.IsAny<TestRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(validationResult);

        var nextHandler = new Mock<RequestHandlerDelegate<IResponse<string>>>();
        var expectedResponse = new Response<string> { Data = "success", Succeeded = true };
        nextHandler.Setup(h => h()).ReturnsAsync(expectedResponse);

        var behavior = new ValidateCommandBehavior<TestRequest, IResponse<string>>(validator.Object);
        var request = new TestRequest { Name = "ValidName" };

        // Act
        var result = await behavior.Handle(request, nextHandler.Object, CancellationToken.None);

        // Assert
        result.Should().Be(expectedResponse);
        validator.Verify(v => v.ValidateAsync(request, It.IsAny<CancellationToken>()), Times.Once);
        nextHandler.Verify(h => h(), Times.Once);
    }

    [Fact]
    public async Task Handle_WithCancellationToken_ShouldPassTokenToValidator()
    {
        // Arrange
        var validator = new Mock<IValidator<TestRequest>>();
        var validationResult = new ValidationResult();
        validator.Setup(v => v.ValidateAsync(It.IsAny<TestRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(validationResult);

        var nextHandler = new Mock<RequestHandlerDelegate<IResponse<string>>>();
        var expectedResponse = new Response<string> { Data = "success", Succeeded = true };
        nextHandler.Setup(h => h()).ReturnsAsync(expectedResponse);

        var behavior = new ValidateCommandBehavior<TestRequest, IResponse<string>>(validator.Object);
        var request = new TestRequest { Name = "Test" };
        var cancellationToken = new CancellationToken();

        // Act
        var result = await behavior.Handle(request, nextHandler.Object, cancellationToken);

        // Assert
        result.Should().Be(expectedResponse);
        validator.Verify(v => v.ValidateAsync(request, cancellationToken), Times.Once);
    }

    [Fact]
    public async Task Handle_WithValidatorThrowingException_ShouldPropagateException()
    {
        // Arrange
        var validator = new Mock<IValidator<TestRequest>>();
        validator.Setup(v => v.ValidateAsync(It.IsAny<TestRequest>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new ValidationException("Validator error"));

        var nextHandler = new Mock<RequestHandlerDelegate<IResponse<string>>>();
        var behavior = new ValidateCommandBehavior<TestRequest, IResponse<string>>(validator.Object);
        var request = new TestRequest { Name = "Test" };

        // Act & Assert
        var action = async () => await behavior.Handle(request, nextHandler.Object, CancellationToken.None);
        await action.Should().ThrowAsync<ValidationException>();
        
        nextHandler.Verify(h => h(), Times.Never);
    }

    [Fact]
    public async Task Handle_WithNextHandlerThrowingException_ShouldPropagateException()
    {
        // Arrange
        var validator = new Mock<IValidator<TestRequest>>();
        var validationResult = new ValidationResult();
        validator.Setup(v => v.ValidateAsync(It.IsAny<TestRequest>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(validationResult);

        var nextHandler = new Mock<RequestHandlerDelegate<IResponse<string>>>();
        nextHandler.Setup(h => h()).ThrowsAsync(new InvalidOperationException("Next handler error"));

        var behavior = new ValidateCommandBehavior<TestRequest, IResponse<string>>(validator.Object);
        var request = new TestRequest { Name = "Test" };

        // Act & Assert
        var action = async () => await behavior.Handle(request, nextHandler.Object, CancellationToken.None);
        await action.Should().ThrowAsync<InvalidOperationException>();
        
        validator.Verify(v => v.ValidateAsync(request, It.IsAny<CancellationToken>()), Times.Once);
    }
}

// Test request class for testing
public class TestRequest : IRequest<IResponse<string>>
{
    public string Name { get; set; } = string.Empty;
}

// Test validator for testing
public class TestRequestValidator : AbstractValidator<TestRequest>
{
    public TestRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MinimumLength(3).WithMessage("Name must be at least 3 characters");
    }
}
