using FluentAssertions;
using Moq;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

/// <summary>
/// Basic tests to validate that the unit test project setup is working correctly.
/// These tests verify that all required packages are properly installed and configured.
/// </summary>
public class ProjectSetupValidationTests
{
    [Fact]
    public void XUnit_ShouldBeWorking()
    {
        // Arrange
        var expectedValue = "Hello, Unit Tests!";
        
        // Act
        var actualValue = "Hello, Unit Tests!";
        
        // Assert
        actualValue.Should().Be(expectedValue);
    }

    [Fact]
    public void FluentAssertions_ShouldBeWorking()
    {
        // Arrange
        var numbers = new[] { 1, 2, 3, 4, 5 };
        
        // Act & Assert
        numbers.Should().NotBeEmpty()
               .And.HaveCount(5)
               .And.Contain(3)
               .And.NotContain(6);
    }

    [Fact]
    public void Moq_ShouldBeWorking()
    {
        // Arrange
        var mock = new Mock<IExampleInterface>();
        mock.Setup(x => x.GetValue()).Returns("Mocked Value");
        
        // Act
        var result = mock.Object.GetValue();
        
        // Assert
        result.Should().Be("Mocked Value");
        mock.Verify(x => x.GetValue(), Times.Once);
    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(5, 10, 15)]
    [InlineData(-1, 1, 0)]
    public void XUnit_Theory_ShouldBeWorking(int a, int b, int expectedSum)
    {
        // Act
        var actualSum = a + b;
        
        // Assert
        actualSum.Should().Be(expectedSum);
    }
}

/// <summary>
/// Example interface for Moq testing
/// </summary>
public interface IExampleInterface
{
    string GetValue();
}
