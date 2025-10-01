using FluentAssertions;
using Domain;
using Domain.Enums;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class OperatorOverloadTests
{
    #region BaseEntity Operator Overload Tests

    [Fact]
    public void BaseEntity_EqualityOperator_WithSameId_ShouldReturnTrue()
    {
        // Arrange
        var entity1 = new TestEntity { Id = 1 };
        var entity2 = new TestEntity { Id = 1 };

        // Act
        var result = entity1 == entity2!;

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void BaseEntity_EqualityOperator_WithDifferentId_ShouldReturnFalse()
    {
        // Arrange
        var entity1 = new TestEntity { Id = 1 };
        var entity2 = new TestEntity { Id = 2 };

        // Act
        var result = entity1 == entity2!;

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void BaseEntity_EqualityOperator_WithNull_ShouldReturnFalse()
    {
        // Arrange
        var entity1 = new TestEntity { Id = 1 };
        TestEntity? entity2 = null;

        // Act
        var result = entity1 == entity2!;

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void BaseEntity_EqualityOperator_WithBothNull_ShouldReturnTrue()
    {
        // Arrange
        TestEntity? entity1 = null;
        TestEntity? entity2 = null;

        // Act
#pragma warning disable CS8604 // Possible null reference argument for parameter
        var result = entity1 == entity2;
#pragma warning restore CS8604

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void BaseEntity_InequalityOperator_WithSameId_ShouldReturnFalse()
    {
        // Arrange
        var entity1 = new TestEntity { Id = 1 };
        var entity2 = new TestEntity { Id = 1 };

        // Act
        var result = entity1 != entity2!;

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void BaseEntity_InequalityOperator_WithDifferentId_ShouldReturnTrue()
    {
        // Arrange
        var entity1 = new TestEntity { Id = 1 };
        var entity2 = new TestEntity { Id = 2 };

        // Act
        var result = entity1 != entity2!;

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void BaseEntity_InequalityOperator_WithNull_ShouldReturnTrue()
    {
        // Arrange
        var entity1 = new TestEntity { Id = 1 };
        TestEntity? entity2 = null;

        // Act
        var result = entity1 != entity2!;

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void BaseEntity_InequalityOperator_WithBothNull_ShouldReturnFalse()
    {
        // Arrange
        TestEntity? entity1 = null;
        TestEntity? entity2 = null;

        // Act
#pragma warning disable CS8604 // Possible null reference argument for parameter
        var result = entity1 != entity2;
#pragma warning restore CS8604

        // Assert
        result.Should().BeFalse();
    }

    #endregion

    #region Enum Operator Tests

    [Fact]
    public void StatusEnum_EqualityOperator_WithSameValue_ShouldReturnTrue()
    {
        // Arrange
        var status1 = StatusEnum.Active;
        var status2 = StatusEnum.Active;

        // Act
        var result = status1 == status2;

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void StatusEnum_EqualityOperator_WithDifferentValue_ShouldReturnFalse()
    {
        // Arrange
        var status1 = StatusEnum.Active;
        var status2 = StatusEnum.Pending;

        // Act
        var result = status1 == status2;

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void StatusEnum_InequalityOperator_WithSameValue_ShouldReturnFalse()
    {
        // Arrange
        var status1 = StatusEnum.Active;
        var status2 = StatusEnum.Active;

        // Act
        var result = status1 != status2;

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void StatusEnum_InequalityOperator_WithDifferentValue_ShouldReturnTrue()
    {
        // Arrange
        var status1 = StatusEnum.Active;
        var status2 = StatusEnum.Pending;

        // Act
        var result = status1 != status2;

        // Assert
        result.Should().BeTrue();
    }

    #endregion

    #region Implicit Conversion Tests

    [Fact]
    public void StatusEnum_ImplicitConversion_FromInt_ShouldWork()
    {
        // Arrange
        int intValue = 3;

        // Act
        StatusEnum status = (StatusEnum)intValue;

        // Assert
        status.Should().Be(StatusEnum.Active);
    }

    [Fact]
    public void StatusEnum_ImplicitConversion_ToInt_ShouldWork()
    {
        // Arrange
        var status = StatusEnum.Active;

        // Act
        int intValue = (int)status;

        // Assert
        intValue.Should().Be(3);
    }

    [Fact]
    public void StatusEnum_ImplicitConversion_WithInvalidValue_ShouldWork()
    {
        // Arrange
        int intValue = 999;

        // Act
        StatusEnum status = (StatusEnum)intValue;

        // Assert
        status.Should().Be((StatusEnum)999);
    }

    #endregion

    #region Comparison Operator Tests

    [Fact]
    public void StatusEnum_ComparisonOperators_ShouldWorkCorrectly()
    {
        // Arrange
        var status1 = StatusEnum.Saved; // 0
        var status2 = StatusEnum.Active; // 3
        var status3 = StatusEnum.Completed; // 14

        // Act & Assert
        (status1 < status2).Should().BeTrue();
        (status2 < status3).Should().BeTrue();
        (status1 < status3).Should().BeTrue();
        (status2 > status1).Should().BeTrue();
        (status3 > status2).Should().BeTrue();
        (status3 > status1).Should().BeTrue();
        (status1 <= status2).Should().BeTrue();
        (status2 <= status3).Should().BeTrue();
        (status2 >= status1).Should().BeTrue();
        (status3 >= status2).Should().BeTrue();
    }

    [Fact]
    public void StatusEnum_ComparisonOperators_WithSameValue_ShouldWorkCorrectly()
    {
        // Arrange
        var status1 = StatusEnum.Active;
        var status2 = StatusEnum.Active;

        // Act & Assert
        (status1 <= status2).Should().BeTrue();
        (status1 >= status2).Should().BeTrue();
        (status1 < status2).Should().BeFalse();
        (status1 > status2).Should().BeFalse();
    }

    #endregion

    #region Arithmetic Operator Tests

    [Fact]
    public void StatusEnum_ArithmeticOperators_ShouldWorkCorrectly()
    {
        // Arrange
        var status1 = StatusEnum.Saved; // 0
        var status2 = StatusEnum.Active; // 3

        // Act & Assert
        ((int)status1 + (int)status2).Should().Be(3);
        ((int)status2 - (int)status1).Should().Be(3);
        ((int)status1 * (int)status2).Should().Be(0);
        // Division by zero should throw exception
        Action divideByZero = () => { var result = (int)status2 / (int)status1; };
        divideByZero.Should().Throw<DivideByZeroException>();
    }

    [Fact]
    public void StatusEnum_ArithmeticOperators_WithOverflow_ShouldWorkCorrectly()
    {
        // Arrange
        var status1 = StatusEnum.Completed; // 14
        var status2 = StatusEnum.Pending; // 16

        // Act & Assert
        ((int)status1 + (int)status2).Should().Be(30);
        ((int)status2 - (int)status1).Should().Be(2);
    }

    #endregion

    #region Bitwise Operator Tests

    [Fact]
    public void StatusEnum_BitwiseOperators_ShouldWorkCorrectly()
    {
        // Arrange
        var status1 = StatusEnum.Saved; // 0
        var status2 = StatusEnum.Active; // 3

        // Act & Assert
        ((int)status1 & (int)status2).Should().Be(0);
        ((int)status1 | (int)status2).Should().Be(3);
        ((int)status1 ^ (int)status2).Should().Be(3);
        (~(int)status1).Should().Be(-1);
    }

    [Fact]
    public void StatusEnum_BitwiseOperators_WithShift_ShouldWorkCorrectly()
    {
        // Arrange
        var status = StatusEnum.Active; // 3

        // Act & Assert
        ((int)status << 1).Should().Be(6);
        ((int)status >> 1).Should().Be(1);
    }

    #endregion

    #region Logical Operator Tests

    [Fact]
    public void StatusEnum_LogicalOperators_ShouldWorkCorrectly()
    {
        // Arrange
        var status1 = StatusEnum.Saved; // 0
        var status2 = StatusEnum.Active; // 3

        // Act & Assert
        ((int)status1 == 0 && (int)status2 != 0).Should().BeTrue(); // status1 is zero, status2 is non-zero
        ((int)status1 != 0 || (int)status2 != 0).Should().BeTrue(); // At least one non-zero
        ((int)status1 == 0).Should().BeTrue(); // Zero is falsy
        ((int)status2 == 0).Should().BeFalse(); // Non-zero is truthy
    }

    #endregion

    #region Helper Classes

    private class TestEntity : BaseEntity
    {
    }

    #endregion
}
