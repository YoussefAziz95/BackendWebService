using Xunit;
using FluentAssertions;
using Moq;
using Application.Implementations.Common;
using Application.Contracts.Persistence;
using Application.Contracts.Features;
using Application.Features;
using Application.Wrappers;
using Domain;
using System.Linq.Expressions;

namespace BackendWebService.Application.UnitTests.Services;

public class ExceptionLogServiceTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly ExceptionLogService _exceptionLogService;

    public ExceptionLogServiceTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _exceptionLogService = new ExceptionLogService(_unitOfWorkMock.Object);
    }

    [Fact]
    public async Task AddAsync_WithValidRequest_ShouldReturnSuccessResponse()
    {
        // Arrange
        var request = new AddExceptionLogRequest
        {
            Message = "Test exception message",
            StackTrace = "Test stack trace",
            Source = "Test source"
        };

        var exceptionLog = new ExceptionLog
        {
            Id = 1,
            Message = request.Message,
            StackTrace = request.StackTrace,
            Source = request.Source
        };

        _unitOfWorkMock.Setup(x => x.GenericRepository<ExceptionLog>().AddAsync(It.IsAny<ExceptionLog>()))
            .Returns(Task.CompletedTask);
        _unitOfWorkMock.Setup(x => x.SaveAsync())
            .ReturnsAsync(1);

        // Act
        var result = await _exceptionLogService.AddAsync(request);

        // Assert
        result.Should().NotBeNull();
        result.Succeeded.Should().BeTrue();
        result.Data.Should().Be(1);
        result.Message.Should().Be("Created Successfully");
    }

    [Fact]
    public async Task AddAsync_WithSaveFailure_ShouldReturnBadRequest()
    {
        // Arrange
        var request = new AddExceptionLogRequest
        {
            Message = "Test exception message",
            StackTrace = "Test stack trace",
            Source = "Test source"
        };

        _unitOfWorkMock.Setup(x => x.GenericRepository<ExceptionLog>().AddAsync(It.IsAny<ExceptionLog>()))
            .Returns(Task.CompletedTask);
        _unitOfWorkMock.Setup(x => x.SaveAsync())
            .ReturnsAsync(0);

        // Act
        var result = await _exceptionLogService.AddAsync(request);

        // Assert
        result.Should().NotBeNull();
        result.Succeeded.Should().BeFalse();
        result.Message.Should().Be("Something went wrong");
    }

    [Fact]
    public async Task AddAsync_WithNullRequest_ShouldThrowException()
    {
        // Arrange
        AddExceptionLogRequest? request = null;

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => _exceptionLogService.AddAsync(request!));
    }

    [Fact]
    public async Task GetAsync_WithValidId_ShouldReturnSuccessResponse()
    {
        // Arrange
        var exceptionLogId = 1;
        var exceptionLog = new ExceptionLog
        {
            Id = exceptionLogId,
            Message = "Test exception message",
            StackTrace = "Test stack trace",
            Source = "Test source"
        };

        _unitOfWorkMock.Setup(x => x.GenericRepository<ExceptionLog>().Get(It.IsAny<Expression<Func<ExceptionLog, bool>>>()))
            .Returns(exceptionLog);

        // Act
        var result = await _exceptionLogService.GetAsync(exceptionLogId);

        // Assert
        result.Should().NotBeNull();
        result.Succeeded.Should().BeTrue();
        result.Data.Should().NotBeNull();
        result.Data.Id.Should().Be(exceptionLogId);
        result.Message.Should().Be("Retrieved Successfully");
    }

    [Fact]
    public async Task GetAsync_WithNonExistentId_ShouldReturnNotFound()
    {
        // Arrange
        var exceptionLogId = 999;

        _unitOfWorkMock.Setup(x => x.GenericRepository<ExceptionLog>().Get(It.IsAny<Expression<Func<ExceptionLog, bool>>>()))
            .Returns((ExceptionLog?)null);

        // Act
        var result = await _exceptionLogService.GetAsync(exceptionLogId);

        // Assert
        result.Should().NotBeNull();
        result.Succeeded.Should().BeFalse();
        result.Message.Should().Be("Not Found");
    }

    [Fact]
    public async Task GetAllAsync_WithValidData_ShouldReturnSuccessResponse()
    {
        // Arrange
        var exceptionLogs = new List<ExceptionLog>
        {
            new ExceptionLog { Id = 1, Message = "Exception 1" },
            new ExceptionLog { Id = 2, Message = "Exception 2" }
        };

        _unitOfWorkMock.Setup(x => x.GenericRepository<ExceptionLog>().GetAll())
            .Returns(exceptionLogs.AsQueryable());

        // Act
        var result = await _exceptionLogService.GetAllAsync();

        // Assert
        result.Should().NotBeNull();
        result.Succeeded.Should().BeTrue();
        result.Data.Should().NotBeNull();
        result.Data.Count.Should().Be(2);
        result.Message.Should().Be("Retrieved Successfully");
    }

    [Fact]
    public async Task GetAllAsync_WithNoData_ShouldReturnEmptyList()
    {
        // Arrange
        var emptyExceptionLogs = new List<ExceptionLog>();

        _unitOfWorkMock.Setup(x => x.GenericRepository<ExceptionLog>().GetAll())
            .Returns(emptyExceptionLogs.AsQueryable());

        // Act
        var result = await _exceptionLogService.GetAllAsync();

        // Assert
        result.Should().NotBeNull();
        result.Succeeded.Should().BeTrue();
        result.Data.Should().NotBeNull();
        result.Data.Count.Should().Be(0);
        result.Message.Should().Be("Retrieved Successfully");
    }

    [Fact]
    public async Task DeleteAsync_WithValidId_ShouldReturnSuccessResponse()
    {
        // Arrange
        var exceptionLogId = 1;
        var exceptionLog = new ExceptionLog { Id = exceptionLogId, Message = "Test exception" };

        _unitOfWorkMock.Setup(x => x.GenericRepository<ExceptionLog>().Get(It.IsAny<Expression<Func<ExceptionLog, bool>>>()))
            .Returns(exceptionLog);
        _unitOfWorkMock.Setup(x => x.GenericRepository<ExceptionLog>().GetByIdAsync(exceptionLogId))
            .ReturnsAsync(exceptionLog);
        _unitOfWorkMock.Setup(x => x.GenericRepository<ExceptionLog>().Delete(exceptionLog))
            .Returns(exceptionLog);
        _unitOfWorkMock.Setup(x => x.SaveAsync())
            .ReturnsAsync(1);

        // Act
        var result = await _exceptionLogService.DeleteAsync(exceptionLogId);

        // Assert
        result.Should().NotBeNull();
        result.Succeeded.Should().BeTrue();
        result.Message.Should().Be("Deleted Successfully");
    }

    [Fact]
    public async Task DeleteAsync_WithNonExistentId_ShouldReturnNotFound()
    {
        // Arrange
        var exceptionLogId = 999;

        _unitOfWorkMock.Setup(x => x.GenericRepository<ExceptionLog>().Get(It.IsAny<Expression<Func<ExceptionLog, bool>>>()))
            .Returns((ExceptionLog?)null);

        // Act
        var result = await _exceptionLogService.DeleteAsync(exceptionLogId);

        // Assert
        result.Should().NotBeNull();
        result.Succeeded.Should().BeFalse();
        result.Message.Should().Be("Not Found");
    }

    [Fact]
    public async Task DeleteAsync_WithSaveFailure_ShouldReturnBadRequest()
    {
        // Arrange
        var exceptionLogId = 1;
        var exceptionLog = new ExceptionLog { Id = exceptionLogId, Message = "Test exception" };

        _unitOfWorkMock.Setup(x => x.GenericRepository<ExceptionLog>().Get(It.IsAny<Expression<Func<ExceptionLog, bool>>>()))
            .Returns(exceptionLog);
        _unitOfWorkMock.Setup(x => x.GenericRepository<ExceptionLog>().GetByIdAsync(exceptionLogId))
            .ReturnsAsync(exceptionLog);
        _unitOfWorkMock.Setup(x => x.GenericRepository<ExceptionLog>().Delete(exceptionLog))
            .Returns(exceptionLog);
        _unitOfWorkMock.Setup(x => x.SaveAsync())
            .ReturnsAsync(0);

        // Act
        var result = await _exceptionLogService.DeleteAsync(exceptionLogId);

        // Assert
        result.Should().NotBeNull();
        result.Succeeded.Should().BeFalse();
        result.Message.Should().Be("Something went wrong");
    }

    [Fact]
    public void CheckIdExists_WithExistingId_ShouldReturnTrue()
    {
        // Arrange
        var exceptionLogId = 1;
        var exceptionLog = new ExceptionLog { Id = exceptionLogId, Message = "Test exception" };

        _unitOfWorkMock.Setup(x => x.GenericRepository<ExceptionLog>().Get(It.IsAny<Expression<Func<ExceptionLog, bool>>>()))
            .Returns(exceptionLog);

        // Act
        var result = _exceptionLogService.CheckIdExists(exceptionLogId);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void CheckIdExists_WithNonExistentId_ShouldReturnFalse()
    {
        // Arrange
        var exceptionLogId = 999;

        _unitOfWorkMock.Setup(x => x.GenericRepository<ExceptionLog>().Get(It.IsAny<Expression<Func<ExceptionLog, bool>>>()))
            .Returns((ExceptionLog?)null);

        // Act
        var result = _exceptionLogService.CheckIdExists(exceptionLogId);

        // Assert
        result.Should().BeFalse();
    }
}
