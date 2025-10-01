using Xunit;
using FluentAssertions;
using Application.Wrappers;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BackendWebService.Application.UnitTests.Handlers;

public class QueryableExtensionsTests
{
    [Fact]
    public void ToPaginatedList_WithValidData_ShouldReturnPaginatedResponse()
    {
        // Arrange
        var data = new List<string> { "item1", "item2", "item3", "item4", "item5" };
        var queryable = data.AsQueryable();
        var pageNumber = 1;
        var pageSize = 2;

        // Act
        var result = queryable.ToPaginatedList(pageNumber, pageSize);

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().HaveCount(2);
        result.Data.Should().Contain("item1");
        result.Data.Should().Contain("item2");
        result.TotalCount.Should().Be(5);
        result.CurrentPage.Should().Be(1);
        result.PageSize.Should().Be(2);
        result.Succeeded.Should().BeTrue();
    }

    [Fact]
    public void ToPaginatedList_WithEmptyData_ShouldReturnEmptyPaginatedResponse()
    {
        // Arrange
        var data = new List<string>();
        var queryable = data.AsQueryable();
        var pageNumber = 1;
        var pageSize = 10;

        // Act
        var result = queryable.ToPaginatedList(pageNumber, pageSize);

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().BeEmpty();
        result.TotalCount.Should().Be(0);
        result.CurrentPage.Should().Be(1);
        result.PageSize.Should().Be(10);
        result.Succeeded.Should().BeTrue();
    }

    [Fact]
    public void ToPaginatedList_WithZeroPageNumber_ShouldDefaultToPageOne()
    {
        // Arrange
        var data = new List<string> { "item1", "item2", "item3" };
        var queryable = data.AsQueryable();
        var pageNumber = 0;
        var pageSize = 2;

        // Act
        var result = queryable.ToPaginatedList(pageNumber, pageSize);

        // Assert
        result.Should().NotBeNull();
        result.CurrentPage.Should().Be(1);
        result.Data.Should().HaveCount(2);
    }

    [Fact]
    public void ToPaginatedList_WithZeroPageSize_ShouldDefaultToPageSizeTen()
    {
        // Arrange
        var data = new List<string> { "item1", "item2", "item3" };
        var queryable = data.AsQueryable();
        var pageNumber = 1;
        var pageSize = 0;

        // Act
        var result = queryable.ToPaginatedList(pageNumber, pageSize);

        // Assert
        result.Should().NotBeNull();
        result.PageSize.Should().Be(10);
        result.Data.Should().HaveCount(3);
    }

    [Fact]
    public void ToPaginatedList_WithNegativePageNumber_ShouldDefaultToPageOne()
    {
        // Arrange
        var data = new List<string> { "item1", "item2", "item3" };
        var queryable = data.AsQueryable();
        var pageNumber = -1;
        var pageSize = 2;

        // Act
        var result = queryable.ToPaginatedList(pageNumber, pageSize);

        // Assert
        result.Should().NotBeNull();
        result.CurrentPage.Should().Be(1);
        result.Data.Should().HaveCount(2);
    }

    [Fact]
    public void ToPaginatedList_WithPageNumberGreaterThanTotalPages_ShouldReturnEmptyData()
    {
        // Arrange
        var data = new List<string> { "item1", "item2", "item3" };
        var queryable = data.AsQueryable();
        var pageNumber = 10;
        var pageSize = 2;

        // Act
        var result = queryable.ToPaginatedList(pageNumber, pageSize);

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().BeEmpty();
        result.TotalCount.Should().Be(3);
        result.CurrentPage.Should().Be(10);
        result.PageSize.Should().Be(2);
    }

    [Fact]
    public void ToPaginatedList_WithSecondPage_ShouldReturnCorrectItems()
    {
        // Arrange
        var data = new List<string> { "item1", "item2", "item3", "item4", "item5" };
        var queryable = data.AsQueryable();
        var pageNumber = 2;
        var pageSize = 2;

        // Act
        var result = queryable.ToPaginatedList(pageNumber, pageSize);

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().HaveCount(2);
        result.Data.Should().Contain("item3");
        result.Data.Should().Contain("item4");
        result.TotalCount.Should().Be(5);
        result.CurrentPage.Should().Be(2);
        result.PageSize.Should().Be(2);
    }

    [Fact]
    public void ToPaginatedList_WithLastPage_ShouldReturnRemainingItems()
    {
        // Arrange
        var data = new List<string> { "item1", "item2", "item3", "item4", "item5" };
        var queryable = data.AsQueryable();
        var pageNumber = 3;
        var pageSize = 2;

        // Act
        var result = queryable.ToPaginatedList(pageNumber, pageSize);

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().HaveCount(1);
        result.Data.Should().Contain("item5");
        result.TotalCount.Should().Be(5);
        result.CurrentPage.Should().Be(3);
        result.PageSize.Should().Be(2);
    }

    [Fact]
    public void ToPaginatedList_WithLargePageSize_ShouldReturnAllItems()
    {
        // Arrange
        var data = new List<string> { "item1", "item2", "item3" };
        var queryable = data.AsQueryable();
        var pageNumber = 1;
        var pageSize = 100;

        // Act
        var result = queryable.ToPaginatedList(pageNumber, pageSize);

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().HaveCount(3);
        result.Data.Should().Contain("item1");
        result.Data.Should().Contain("item2");
        result.Data.Should().Contain("item3");
        result.TotalCount.Should().Be(3);
        result.CurrentPage.Should().Be(1);
        result.PageSize.Should().Be(100);
    }
}
