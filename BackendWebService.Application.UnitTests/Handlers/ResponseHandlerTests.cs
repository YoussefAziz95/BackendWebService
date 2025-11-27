using Xunit;
using FluentAssertions;
using Application.Wrappers;
using Application.Features;
using Domain.Enums;
using BackendWebService.Application.UnitTests.TestUtilities;

namespace BackendWebService.Application.UnitTests.Handlers;

public class ResponseHandlerTests
{
    private readonly ResponseHandler _responseHandler;

    public ResponseHandlerTests()
    {
        _responseHandler = new ResponseHandler();
    }

    [Fact]
    public void Deleted_ShouldReturnSuccessResponse()
    {
        // Act
        var result = _responseHandler.Deleted<string>();

        // Assert
        result.Should().NotBeNull();
        result.StatusCode.Should().Be(ApiResultStatusCode.Ok);
        result.Succeeded.Should().BeTrue();
        result.Message.Should().Be("Deleted Successfully");
    }

    [Fact]
    public void EmailVerified_ShouldReturnSuccessResponse()
    {
        // Act
        var result = _responseHandler.EmailVerified<string>();

        // Assert
        result.Should().NotBeNull();
        result.StatusCode.Should().Be(ApiResultStatusCode.Ok);
        result.Succeeded.Should().BeTrue();
        result.Message.Should().Be("EmailDto Verified Successfully");
    }

    [Fact]
    public void EmailSent_ShouldReturnSuccessResponse()
    {
        // Act
        var result = _responseHandler.EmailSent<string>();

        // Assert
        result.Should().NotBeNull();
        result.StatusCode.Should().Be(ApiResultStatusCode.Ok);
        result.Succeeded.Should().BeTrue();
        result.Message.Should().Be("EmailDto Sent Successfully");
    }

    [Fact]
    public void PasswordUpdated_ShouldReturnSuccessResponse()
    {
        // Act
        var result = _responseHandler.PasswordUpdated<string>();

        // Assert
        result.Should().NotBeNull();
        result.StatusCode.Should().Be(ApiResultStatusCode.Ok);
        result.Succeeded.Should().BeTrue();
        result.Message.Should().Be("Password Updated Successfully");
    }

    [Fact]
    public void Success_WithEntity_ShouldReturnSuccessResponseWithData()
    {
        // Arrange
        var testData = "test data";

        // Act
        var result = _responseHandler.Success(testData);

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().Be(testData);
        result.StatusCode.Should().Be(ApiResultStatusCode.Ok);
        result.Succeeded.Should().BeTrue();
    }

    [Fact]
    public void Ok_WithMessage_ShouldReturnSuccessResponseWithMessage()
    {
        // Arrange
        var message = "Operation completed successfully";

        // Act
        var result = _responseHandler.Ok<string>(message);

        // Assert
        result.Should().NotBeNull();
        result.Message.Should().Be(message);
        result.StatusCode.Should().Be(ApiResultStatusCode.Ok);
        result.Succeeded.Should().BeTrue();
    }

    [Fact]
    public void Ok_WithoutMessage_ShouldReturnSuccessResponseWithNullMessage()
    {
        // Act
        var result = _responseHandler.Ok<string>();

        // Assert
        result.Should().NotBeNull();
        result.Message.Should().BeNull();
        result.StatusCode.Should().Be(ApiResultStatusCode.Ok);
        result.Succeeded.Should().BeTrue();
    }

    [Fact]
    public void Success_WithMessage_ShouldReturnSuccessResponseWithMessage()
    {
        // Arrange
        var message = "Operation completed successfully";

        // Act
        var result = _responseHandler.Success<string>(message);

        // Assert
        result.Should().NotBeNull();
        result.Message.Should().Be(message);
        result.StatusCode.Should().Be(ApiResultStatusCode.Ok);
        result.Succeeded.Should().BeTrue();
    }

    [Fact]
    public void Success_WithInt_ShouldReturnSuccessResponseWithIntData()
    {
        // Arrange
        var id = 123;

        // Act
        var result = _responseHandler.Success(id);

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().Be(id);
        result.StatusCode.Should().Be(ApiResultStatusCode.Ok);
        result.Succeeded.Should().BeTrue();
    }

    [Fact]
    public void Uploaded_ShouldReturnSuccessResponseWithData()
    {
        // Arrange
        var testData = "uploaded file path";

        // Act
        var result = _responseHandler.Uploaded(testData);

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().Be(testData);
        result.StatusCode.Should().Be(ApiResultStatusCode.Ok);
        result.Succeeded.Should().BeTrue();
        result.Message.Should().Be("Uploaded Successfully");
    }

    [Fact]
    public void Updated_WithEntityAndMessage_ShouldReturnSuccessResponseWithDataAndMessage()
    {
        // Arrange
        var testData = "updated data";
        var message = "Custom update message";

        // Act
        var result = _responseHandler.Updated(testData, message);

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().Be(testData);
        result.Message.Should().Be(message);
        result.StatusCode.Should().Be(ApiResultStatusCode.Ok);
        result.Succeeded.Should().BeTrue();
    }

    [Fact]
    public void Updated_WithEntityOnly_ShouldReturnSuccessResponseWithDefaultMessage()
    {
        // Arrange
        var testData = "updated data";

        // Act
        var result = _responseHandler.Updated(testData);

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().Be(testData);
        result.Message.Should().Be("Updated Successfully");
        result.StatusCode.Should().Be(ApiResultStatusCode.Ok);
        result.Succeeded.Should().BeTrue();
    }

    [Fact]
    public void Unauthorized_ShouldReturnUnauthorizedResponse()
    {
        // Act
        var result = _responseHandler.Unauthorized<string>();

        // Assert
        result.Should().NotBeNull();
        result.StatusCode.Should().Be(ApiResultStatusCode.UnAuthorized);
        result.Succeeded.Should().BeTrue();
        result.Message.Should().Be("UnAuthorized");
    }

    [Fact]
    public void Unauthorized_WithMessage_ShouldReturnUnauthorizedResponseWithMessage()
    {
        // Arrange
        var message = "Access denied";

        // Act
        var result = _responseHandler.Unauthorized<string>(message);

        // Assert
        result.Should().NotBeNull();
        result.StatusCode.Should().Be(ApiResultStatusCode.UnAuthorized);
        result.Succeeded.Should().BeTrue();
        result.Message.Should().Be("UnAuthorized" + message);
    }

    [Fact]
    public void BadRequest_WithMessage_ShouldReturnBadRequestResponse()
    {
        // Arrange
        var message = "Invalid request";

        // Act
        var result = _responseHandler.BadRequest<string>(message);

        // Assert
        result.Should().NotBeNull();
        result.StatusCode.Should().Be(ApiResultStatusCode.BadRequest);
        result.Succeeded.Should().BeFalse();
        result.Message.Should().Be(message);
    }

    [Fact]
    public void BadRequest_WithoutMessage_ShouldReturnBadRequestResponseWithDefaultMessage()
    {
        // Act
        var result = _responseHandler.BadRequest<string>();

        // Assert
        result.Should().NotBeNull();
        result.StatusCode.Should().Be(ApiResultStatusCode.BadRequest);
        result.Succeeded.Should().BeFalse();
        result.Message.Should().Be("Bad Request");
    }

    [Fact]
    public void BadRequest_WithErrors_ShouldReturnBadRequestResponseWithErrors()
    {
        // Arrange
        var errors = new List<string> { "Error 1", "Error 2" };

        // Act
        var result = _responseHandler.BadRequest<string>(errors);

        // Assert
        result.Should().NotBeNull();
        result.StatusCode.Should().Be(ApiResultStatusCode.BadRequest);
        result.Succeeded.Should().BeFalse();
        result.Errors.Should().BeEquivalentTo(errors);
    }

    [Fact]
    public void NotFound_WithMessage_ShouldReturnNotFoundResponse()
    {
        // Arrange
        var message = "Resource not found";

        // Act
        var result = _responseHandler.NotFound<string>(message);

        // Assert
        result.Should().NotBeNull();
        result.StatusCode.Should().Be(ApiResultStatusCode.NotFound);
        result.Succeeded.Should().BeFalse();
        result.Message.Should().Be(message);
    }

    [Fact]
    public void NotFound_WithoutMessage_ShouldReturnNotFoundResponseWithDefaultMessage()
    {
        // Act
        var result = _responseHandler.NotFound<string>();

        // Assert
        result.Should().NotBeNull();
        result.StatusCode.Should().Be(ApiResultStatusCode.NotFound);
        result.Succeeded.Should().BeFalse();
        result.Message.Should().Be("Not Found");
    }

    [Fact]
    public void Created_WithEntity_ShouldReturnCreatedResponse()
    {
        // Arrange
        var testData = "created data";

        // Act
        var result = _responseHandler.Created(testData);

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().Be(testData);
        result.StatusCode.Should().Be(ApiResultStatusCode.Created);
        result.Succeeded.Should().BeTrue();
    }

    [Fact]
    public void Created_WithInt_ShouldReturnCreatedResponseWithIntData()
    {
        // Arrange
        var id = 456;

        // Act
        var result = _responseHandler.Created(id);

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().Be(id);
        result.StatusCode.Should().Be(ApiResultStatusCode.Created);
        result.Succeeded.Should().BeTrue();
    }

    [Fact]
    public void CannotDelete_WithMessage_ShouldReturnFailedDependencyResponse()
    {
        // Arrange
        var message = "Cannot delete due to dependencies";

        // Act
        var result = _responseHandler.CannotDelete<string>(message);

        // Assert
        result.Should().NotBeNull();
        result.StatusCode.Should().Be(ApiResultStatusCode.FailedDependency);
        result.Succeeded.Should().BeFalse();
        result.Message.Should().Be(message);
    }

    [Fact]
    public void CannotDelete_WithoutMessage_ShouldReturnFailedDependencyResponseWithDefaultMessage()
    {
        // Act
        var result = _responseHandler.CannotDelete<string>();

        // Assert
        result.Should().NotBeNull();
        result.StatusCode.Should().Be(ApiResultStatusCode.FailedDependency);
        result.Succeeded.Should().BeFalse();
        result.Message.Should().Be("Connot Delete Failed Dependency");
    }
}
