using Domain;
using Domain.Enums;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class ConsumerTests
{
    [Fact]
    public void Consumer_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var consumer = new Consumer();

        // Assert
        consumer.Should().NotBeNull();
        consumer.OrganizationId.Should().Be(0);
        consumer.Organization.Should().BeNull();
        consumer.Rating.Should().BeNull();
        consumer.BankAccount.Should().BeNull();
        consumer.Status.Should().Be(StatusEnum.Active);
        consumer.ConsumerCustomers.Should().BeNull();
        consumer.ConsumerAccounts.Should().BeNull();
    }

    [Fact]
    public void Consumer_AllProperties_ShouldBeSettable()
    {
        // Arrange
        var consumer = new Consumer();
        var organization = new Organization();
        var consumerCustomers = new List<ConsumerCustomer>();
        var consumerAccounts = new List<ConsumerAccount>();

        // Act
        consumer.OrganizationId = 123;
        consumer.Organization = organization;
        consumer.Rating = 4.5m;
        consumer.BankAccount = "1234567890";
        consumer.Status = StatusEnum.Pending;
        consumer.ConsumerCustomers = consumerCustomers;
        consumer.ConsumerAccounts = consumerAccounts;

        // Assert
        consumer.OrganizationId.Should().Be(123);
        consumer.Organization.Should().BeSameAs(organization);
        consumer.Rating.Should().Be(4.5m);
        consumer.BankAccount.Should().Be("1234567890");
        consumer.Status.Should().Be(StatusEnum.Pending);
        consumer.ConsumerCustomers.Should().BeSameAs(consumerCustomers);
        consumer.ConsumerAccounts.Should().BeSameAs(consumerAccounts);
    }

    [Fact]
    public void Consumer_WithNullValues_ShouldBeCreatable()
    {
        // Arrange & Act
        var consumer = new Consumer
        {
            Organization = null!,
            Rating = null!,
            BankAccount = null!,
            ConsumerCustomers = null!,
            ConsumerAccounts = null!
        };

        // Assert
        consumer.Organization.Should().BeNull();
        consumer.Rating.Should().BeNull();
        consumer.BankAccount.Should().BeNull();
        consumer.ConsumerCustomers.Should().BeNull();
        consumer.ConsumerAccounts.Should().BeNull();
    }

    [Fact]
    public void Consumer_WithMinimalData_ShouldBeCreatable()
    {
        // Arrange & Act
        var consumer = new Consumer
        {
            OrganizationId = 1
        };

        // Assert
        consumer.OrganizationId.Should().Be(1);
        consumer.Status.Should().Be(StatusEnum.Active);
    }

    [Fact]
    public void Consumer_WithCompleteData_ShouldBeCreatable()
    {
        // Arrange
        var organization = new Organization { Id = 456 };
        var consumerCustomers = new List<ConsumerCustomer> { new ConsumerCustomer() };
        var consumerAccounts = new List<ConsumerAccount> { new ConsumerAccount() };

        // Act
        var consumer = new Consumer
        {
            OrganizationId = 456,
            Organization = organization,
            Rating = 4.8m,
            BankAccount = "9876543210",
            Status = StatusEnum.Completed,
            ConsumerCustomers = consumerCustomers,
            ConsumerAccounts = consumerAccounts
        };

        // Assert
        consumer.OrganizationId.Should().Be(456);
        consumer.Organization.Should().BeSameAs(organization);
        consumer.Rating.Should().Be(4.8m);
        consumer.BankAccount.Should().Be("9876543210");
        consumer.Status.Should().Be(StatusEnum.Completed);
        consumer.ConsumerCustomers.Should().BeSameAs(consumerCustomers);
        consumer.ConsumerAccounts.Should().BeSameAs(consumerAccounts);
    }

    [Fact]
    public void Consumer_WithEmptyStrings_ShouldBeCreatable()
    {
        // Arrange & Act
        var consumer = new Consumer
        {
            BankAccount = ""
        };

        // Assert
        consumer.BankAccount.Should().Be("");
    }

    [Fact]
    public void Consumer_WithLongStrings_ShouldBeCreatable()
    {
        // Arrange
        var longBankAccount = new string('A', 1000);

        // Act
        var consumer = new Consumer
        {
            BankAccount = longBankAccount
        };

        // Assert
        consumer.BankAccount.Should().Be(longBankAccount);
    }

    [Fact]
    public void Consumer_WithNegativeOrganizationId_ShouldBeCreatable()
    {
        // Arrange & Act
        var consumer = new Consumer
        {
            OrganizationId = -1
        };

        // Assert
        consumer.OrganizationId.Should().Be(-1);
    }

    [Fact]
    public void Consumer_WithZeroOrganizationId_ShouldBeCreatable()
    {
        // Arrange & Act
        var consumer = new Consumer
        {
            OrganizationId = 0
        };

        // Assert
        consumer.OrganizationId.Should().Be(0);
    }

    [Fact]
    public void Consumer_WithNegativeRating_ShouldBeCreatable()
    {
        // Arrange & Act
        var consumer = new Consumer
        {
            Rating = -1.5m
        };

        // Assert
        consumer.Rating.Should().Be(-1.5m);
    }

    [Fact]
    public void Consumer_WithZeroRating_ShouldBeCreatable()
    {
        // Arrange & Act
        var consumer = new Consumer
        {
            Rating = 0m
        };

        // Assert
        consumer.Rating.Should().Be(0m);
    }

    [Fact]
    public void Consumer_WithMaxRating_ShouldBeCreatable()
    {
        // Arrange & Act
        var consumer = new Consumer
        {
            Rating = 5.0m
        };

        // Assert
        consumer.Rating.Should().Be(5.0m);
    }

    [Fact]
    public void Consumer_WithEmptyCollections_ShouldBeCreatable()
    {
        // Arrange & Act
        var consumer = new Consumer
        {
            ConsumerCustomers = new List<ConsumerCustomer>(),
            ConsumerAccounts = new List<ConsumerAccount>()
        };

        // Assert
        consumer.ConsumerCustomers.Should().NotBeNull();
        consumer.ConsumerCustomers.Should().BeEmpty();
        consumer.ConsumerAccounts.Should().NotBeNull();
        consumer.ConsumerAccounts.Should().BeEmpty();
    }

    [Fact]
    public void Consumer_WithMultipleConsumerCustomers_ShouldBeCreatable()
    {
        // Arrange
        var consumerCustomers = new List<ConsumerCustomer>
        {
            new ConsumerCustomer { Id = 1 },
            new ConsumerCustomer { Id = 2 },
            new ConsumerCustomer { Id = 3 }
        };

        // Act
        var consumer = new Consumer
        {
            ConsumerCustomers = consumerCustomers
        };

        // Assert
        consumer.ConsumerCustomers.Should().HaveCount(3);
        consumer.ConsumerCustomers.Should().Contain(consumerCustomers);
    }

    [Fact]
    public void Consumer_WithMultipleConsumerAccounts_ShouldBeCreatable()
    {
        // Arrange
        var consumerAccounts = new List<ConsumerAccount>
        {
            new ConsumerAccount { Id = 1 },
            new ConsumerAccount { Id = 2 },
            new ConsumerAccount { Id = 3 }
        };

        // Act
        var consumer = new Consumer
        {
            ConsumerAccounts = consumerAccounts
        };

        // Assert
        consumer.ConsumerAccounts.Should().HaveCount(3);
        consumer.ConsumerAccounts.Should().Contain(consumerAccounts);
    }

    [Fact]
    public void Consumer_ShouldInheritFromBaseEntity()
    {
        // Arrange
        var consumer = new Consumer();

        // Assert
        consumer.Should().BeAssignableTo<BaseEntity>();
        consumer.Should().BeAssignableTo<IEntity>();
        consumer.Should().BeAssignableTo<ITimeModification>();
    }

    [Fact]
    public void Consumer_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var consumer = new Consumer { Id = 999 };

        // Act
        var result = consumer.ToString();

        // Assert
        result.Should().Contain("Consumer");
    }

    [Theory]
    [InlineData(100, 4.5, "1234567890", StatusEnum.Active)]
    [InlineData(200, 3.2, "9876543210", StatusEnum.Pending)]
    [InlineData(0, 0.0, "", StatusEnum.Completed)]
    public void Consumer_WithVariousValues_ShouldBeCreatable(int organizationId, decimal rating, string bankAccount, StatusEnum status)
    {
        // Arrange & Act
        var consumer = new Consumer
        {
            OrganizationId = organizationId,
            Rating = rating,
            BankAccount = bankAccount,
            Status = status
        };

        // Assert
        consumer.OrganizationId.Should().Be(organizationId);
        consumer.Rating.Should().Be(rating);
        consumer.BankAccount.Should().Be(bankAccount);
        consumer.Status.Should().Be(status);
    }
}
