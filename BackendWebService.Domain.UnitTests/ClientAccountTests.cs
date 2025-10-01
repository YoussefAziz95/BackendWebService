using Domain;
using FluentAssertions;
using Xunit;

namespace BackendWebService.Domain.UnitTests;

public class ClientAccountTests
{
    [Fact]
    public void ClientAccount_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var clientAccount = new ClientAccount();

        // Assert
        clientAccount.Should().NotBeNull();
        clientAccount.IsSocialLogin.Should().BeFalse();
        clientAccount.TwoFactorEnabled.Should().BeFalse();
        clientAccount.LockoutEnabled.Should().BeTrue();
        clientAccount.AccessFailedCount.Should().Be(0);
        clientAccount.AccountStatus.Should().Be("Active");
        clientAccount.CreatedDate.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
    }

    [Fact]
    public void ClientAccount_WithMinimalData_ShouldBeCreatable()
    {
        // Arrange
        var customerId = 123;
        var passwordHash = "hashed_password";

        // Act
        var clientAccount = new ClientAccount
        {
            CustomerId = customerId,
            PasswordHash = passwordHash
        };

        // Assert
        clientAccount.CustomerId.Should().Be(customerId);
        clientAccount.PasswordHash.Should().Be(passwordHash);
        clientAccount.AccountStatus.Should().Be("Active");
    }

    [Fact]
    public void ClientAccount_WithCompleteData_ShouldBeCreatable()
    {
        // Arrange
        var customerId = 456;
        var email = "test@example.com";
        var passwordHash = "hashed_password";
        var isSocialLogin = true;
        var socialProvider = "Google";
        var socialProviderId = "google_123";
        var twoFactorEnabled = true;
        var lockoutEnabled = false;
        var lockoutEnd = DateTimeOffset.UtcNow.AddDays(1);
        var accessFailedCount = 3;
        var accountStatus = "Locked";
        var accountStatusReason = "Too many failed attempts";

        // Act
        var clientAccount = new ClientAccount
        {
            CustomerId = customerId,
            Email = email,
            PasswordHash = passwordHash,
            IsSocialLogin = isSocialLogin,
            SocialProvider = socialProvider,
            SocialProviderId = socialProviderId,
            TwoFactorEnabled = twoFactorEnabled,
            LockoutEnabled = lockoutEnabled,
            LockoutEnd = lockoutEnd,
            AccessFailedCount = accessFailedCount,
            AccountStatus = accountStatus,
            AccountStatusReason = accountStatusReason
        };

        // Assert
        clientAccount.CustomerId.Should().Be(customerId);
        clientAccount.Email.Should().Be(email);
        clientAccount.PasswordHash.Should().Be(passwordHash);
        clientAccount.IsSocialLogin.Should().Be(isSocialLogin);
        clientAccount.SocialProvider.Should().Be(socialProvider);
        clientAccount.SocialProviderId.Should().Be(socialProviderId);
        clientAccount.TwoFactorEnabled.Should().Be(twoFactorEnabled);
        clientAccount.LockoutEnabled.Should().Be(lockoutEnabled);
        clientAccount.LockoutEnd.Should().Be(lockoutEnd);
        clientAccount.AccessFailedCount.Should().Be(accessFailedCount);
        clientAccount.AccountStatus.Should().Be(accountStatus);
        clientAccount.AccountStatusReason.Should().Be(accountStatusReason);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void ClientAccount_IsSocialLogin_ShouldBeSettable(bool isSocialLogin)
    {
        // Arrange
        var clientAccount = new ClientAccount();

        // Act
        clientAccount.IsSocialLogin = isSocialLogin;

        // Assert
        clientAccount.IsSocialLogin.Should().Be(isSocialLogin);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void ClientAccount_TwoFactorEnabled_ShouldBeSettable(bool twoFactorEnabled)
    {
        // Arrange
        var clientAccount = new ClientAccount();

        // Act
        clientAccount.TwoFactorEnabled = twoFactorEnabled;

        // Assert
        clientAccount.TwoFactorEnabled.Should().Be(twoFactorEnabled);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void ClientAccount_LockoutEnabled_ShouldBeSettable(bool lockoutEnabled)
    {
        // Arrange
        var clientAccount = new ClientAccount();

        // Act
        clientAccount.LockoutEnabled = lockoutEnabled;

        // Assert
        clientAccount.LockoutEnabled.Should().Be(lockoutEnabled);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(10)]
    public void ClientAccount_AccessFailedCount_ShouldBeSettable(int accessFailedCount)
    {
        // Arrange
        var clientAccount = new ClientAccount();

        // Act
        clientAccount.AccessFailedCount = accessFailedCount;

        // Assert
        clientAccount.AccessFailedCount.Should().Be(accessFailedCount);
    }

    [Theory]
    [InlineData("Active")]
    [InlineData("Locked")]
    [InlineData("Suspended")]
    [InlineData("Pending")]
    public void ClientAccount_AccountStatus_ShouldBeSettable(string accountStatus)
    {
        // Arrange
        var clientAccount = new ClientAccount();

        // Act
        clientAccount.AccountStatus = accountStatus;

        // Assert
        clientAccount.AccountStatus.Should().Be(accountStatus);
    }

    [Fact]
    public void ClientAccount_ToString_ShouldReturnExpectedFormat()
    {
        // Arrange
        var clientAccount = new ClientAccount();

        // Act
        var result = clientAccount.ToString();

        // Assert
        result.Should().Contain("ClientAccount");
    }

    [Fact]
    public void ClientAccount_InheritsFromBaseEntity_ShouldHaveBaseProperties()
    {
        // Arrange
        var clientAccount = new ClientAccount();

        // Act & Assert
        clientAccount.Should().BeAssignableTo<BaseEntity>();
        clientAccount.Should().BeAssignableTo<IEntity>();
        clientAccount.Should().BeAssignableTo<ITimeModification>();
    }
}
