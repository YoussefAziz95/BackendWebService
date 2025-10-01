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

public class DropdownServiceTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly DropdownService _dropdownService;

    public DropdownServiceTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _dropdownService = new DropdownService(_unitOfWorkMock.Object);
    }

    [Fact]
    public async Task GetCategories_WithValidRequest_ShouldReturnSuccessResponse()
    {
        // Arrange
        var request = new DropDownRequest
        {
            CompanyId = 1,
            Type = "Category"
        };

        var categories = new List<Category>
        {
            new Category { Id = 1, Name = "Category 1" },
            new Category { Id = 2, Name = "Category 2" }
        };

        _unitOfWorkMock.Setup(x => x.GenericRepository<Category>().GetAll(It.IsAny<Expression<Func<Category, bool>>>()))
            .Returns(categories.AsQueryable());

        // Act
        var result = await _dropdownService.GetCategories(request);

        // Assert
        result.Should().NotBeNull();
        result.Succeeded.Should().BeTrue();
        result.Data.Should().NotBeNull();
        result.Data.Count.Should().Be(2);
        result.Message.Should().Be("Retrieved Successfully");
    }

    [Fact]
    public async Task GetCategories_WithNoCategories_ShouldReturnEmptyList()
    {
        // Arrange
        var request = new DropDownRequest
        {
            CompanyId = 1,
            Type = "Category"
        };

        var emptyCategories = new List<Category>();

        _unitOfWorkMock.Setup(x => x.GenericRepository<Category>().GetAll(It.IsAny<Expression<Func<Category, bool>>>()))
            .Returns(emptyCategories.AsQueryable());

        // Act
        var result = await _dropdownService.GetCategories(request);

        // Assert
        result.Should().NotBeNull();
        result.Succeeded.Should().BeTrue();
        result.Data.Should().NotBeNull();
        result.Data.Count.Should().Be(0);
        result.Message.Should().Be("Retrieved Successfully");
    }

    [Fact]
    public async Task GetCategories_WithNullRequest_ShouldThrowException()
    {
        // Arrange
        DropDownRequest? request = null;

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => _dropdownService.GetCategories(request!));
    }

    [Fact]
    public async Task GetCategories_WithDifferentCompanyId_ShouldFilterCorrectly()
    {
        // Arrange
        var request = new DropDownRequest
        {
            CompanyId = 2,
            Type = "Category"
        };

        var allCategories = new List<Category>
        {
            new Category { Id = 1, Name = "Category 1", CompanyId = 1 },
            new Category { Id = 2, Name = "Category 2", CompanyId = 2 },
            new Category { Id = 3, Name = "Category 3", CompanyId = 1 }
        };

        _unitOfWorkMock.Setup(x => x.GenericRepository<Category>().GetAll(It.IsAny<Expression<Func<Category, bool>>>()))
            .Returns(allCategories.AsQueryable());

        // Act
        var result = await _dropdownService.GetCategories(request);

        // Assert
        result.Should().NotBeNull();
        result.Succeeded.Should().BeTrue();
        result.Data.Should().NotBeNull();
        result.Data.Count.Should().Be(1);
        result.Data.First().Id.Should().Be(2);
        result.Data.First().Name.Should().Be("Category 2");
    }

    [Theory]
    [InlineData(1, 2)]
    [InlineData(2, 1)]
    [InlineData(3, 0)]
    public async Task GetCategories_WithDifferentCompanyIds_ShouldReturnCorrectCount(int companyId, int expectedCount)
    {
        // Arrange
        var request = new DropDownRequest
        {
            CompanyId = companyId,
            Type = "Category"
        };

        var allCategories = new List<Category>
        {
            new Category { Id = 1, Name = "Category 1", CompanyId = 1 },
            new Category { Id = 2, Name = "Category 2", CompanyId = 2 }
        };

        _unitOfWorkMock.Setup(x => x.GenericRepository<Category>().GetAll(It.IsAny<Expression<Func<Category, bool>>>()))
            .Returns(allCategories.AsQueryable());

        // Act
        var result = await _dropdownService.GetCategories(request);

        // Assert
        result.Should().NotBeNull();
        result.Succeeded.Should().BeTrue();
        result.Data.Should().NotBeNull();
        result.Data.Count.Should().Be(expectedCount);
    }

    [Fact]
    public async Task GetCategories_WithException_ShouldReturnBadRequest()
    {
        // Arrange
        var request = new DropDownRequest
        {
            CompanyId = 1,
            Type = "Category"
        };

        _unitOfWorkMock.Setup(x => x.GenericRepository<Category>().GetAll(It.IsAny<Expression<Func<Category, bool>>>()))
            .Throws(new Exception("Database error"));

        // Act
        var result = await _dropdownService.GetCategories(request);

        // Assert
        result.Should().NotBeNull();
        result.Succeeded.Should().BeFalse();
        result.Message.Should().Be("Database error");
    }

    [Fact]
    public async Task GetCategories_WithValidCategories_ShouldMapCorrectly()
    {
        // Arrange
        var request = new DropDownRequest
        {
            CompanyId = 1,
            Type = "Category"
        };

        var categories = new List<Category>
        {
            new Category { Id = 1, Name = "Test Category 1", CompanyId = 1 },
            new Category { Id = 2, Name = "Test Category 2", CompanyId = 1 }
        };

        _unitOfWorkMock.Setup(x => x.GenericRepository<Category>().GetAll(It.IsAny<Expression<Func<Category, bool>>>()))
            .Returns(categories.AsQueryable());

        // Act
        var result = await _dropdownService.GetCategories(request);

        // Assert
        result.Should().NotBeNull();
        result.Succeeded.Should().BeTrue();
        result.Data.Should().NotBeNull();
        result.Data.Count.Should().Be(2);
        
        var firstCategory = result.Data.First();
        firstCategory.Id.Should().Be(1);
        firstCategory.Name.Should().Be("Test Category 1");
        
        var secondCategory = result.Data.Last();
        secondCategory.Id.Should().Be(2);
        secondCategory.Name.Should().Be("Test Category 2");
    }
}
