using Xunit;
using FluentAssertions;
using Moq;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using Application.Identity.Jwt;
using Application.Contracts.Persistence;
using Application.Model.Jwt;
using Domain;
using System.Security.Claims;

namespace BackendWebService.Application.UnitTests.Services;

public class JwtServiceTests
{
    private readonly Mock<IOptions<IdentitySettings>> _jwtOptionsMock;
    private readonly Mock<UserManager<User>> _userManagerMock;
    private readonly Mock<IUserClaimsPrincipalFactory<User>> _claimsPrincipalMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IUserRefreshTokenRepository> _userRefreshTokenRepositoryMock;
    private readonly JwtService _jwtService;
    private readonly IdentitySettings _identitySettings;

    public JwtServiceTests()
    {
        _jwtOptionsMock = new Mock<IOptions<IdentitySettings>>();
        _userManagerMock = new Mock<UserManager<User>>(
            Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);
        _claimsPrincipalMock = new Mock<IUserClaimsPrincipalFactory<User>>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _userRefreshTokenRepositoryMock = new Mock<IUserRefreshTokenRepository>();

        _identitySettings = new IdentitySettings
        {
            SecretKey = "ThisIsAVeryLongSecretKeyForJWTTokenGenerationThatIsAtLeast32CharactersLong",
            Issuer = "BackendWebService",
            Audience = "BackendWebServiceUsers",
            ExpirationMinutes = 60,
            Encryptkey = "ThisIsA16CharKey"
        };

        _jwtOptionsMock.Setup(x => x.Value).Returns(_identitySettings);

        _jwtService = new JwtService(
            _jwtOptionsMock.Object,
            _userManagerMock.Object,
            _claimsPrincipalMock.Object,
            _unitOfWorkMock.Object,
            _userRefreshTokenRepositoryMock.Object);
    }

    [Fact]
    public async Task GenerateAsync_WithValidUser_ShouldReturnValidAccessToken()
    {
        // Arrange
        var user = TestDataBuilder.Entities.CreateUser("test@example.com", "testuser");
        var claims = new List<Claim>
        {
            new Claim("sub", user.UserName!),
            new Claim("email", user.Email!),
            new Claim("role", "User")
        };

        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims));

        _claimsPrincipalMock.Setup(x => x.CreateAsync(user))
            .ReturnsAsync(claimsPrincipal);
        _unitOfWorkMock.Setup(x => x.GenericRepository<UserRefreshToken>().AddAsync(It.IsAny<UserRefreshToken>()))
            .Returns(Task.CompletedTask);
        _unitOfWorkMock.Setup(x => x.CommitAsync())
            .Returns(Task.CompletedTask);
        _unitOfWorkMock.Setup(x => x.SaveAsync())
            .ReturnsAsync(1);

        // Act
        var result = await _jwtService.GenerateAsync(user);

        // Assert
        result.Should().NotBeNull();
        result.Token.Should().NotBeNullOrEmpty();
        result.RefreshToken.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task GenerateByPhoneNumberAsync_WithValidPhoneNumber_ShouldReturnValidAccessToken()
    {
        // Arrange
        var phoneNumber = "1234567890";
        var user = TestDataBuilder.Entities.CreateUser("test@example.com", "testuser");
        user.PhoneNumber = phoneNumber;

        var claims = new List<Claim>
        {
            new Claim("sub", user.UserName!),
            new Claim("email", user.Email!),
            new Claim("role", "User")
        };

        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims));

        _userManagerMock.Setup(x => x.Users.AsNoTracking().FirstOrDefaultAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<User, bool>>>()))
            .ReturnsAsync(user);
        _claimsPrincipalMock.Setup(x => x.CreateAsync(user))
            .ReturnsAsync(claimsPrincipal);
        _unitOfWorkMock.Setup(x => x.GenericRepository<UserRefreshToken>().AddAsync(It.IsAny<UserRefreshToken>()))
            .Returns(Task.CompletedTask);
        _unitOfWorkMock.Setup(x => x.CommitAsync())
            .Returns(Task.CompletedTask);
        _unitOfWorkMock.Setup(x => x.SaveAsync())
            .ReturnsAsync(1);

        // Act
        var result = await _jwtService.GenerateByPhoneNumberAsync(phoneNumber);

        // Assert
        result.Should().NotBeNull();
        result.Token.Should().NotBeNullOrEmpty();
        result.RefreshToken.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task GenerateByPhoneNumberAsync_WithInvalidPhoneNumber_ShouldReturnNull()
    {
        // Arrange
        var phoneNumber = "invalid";

        _userManagerMock.Setup(x => x.Users.AsNoTracking().FirstOrDefaultAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<User, bool>>>()))
            .ReturnsAsync((User?)null);

        // Act
        var result = await _jwtService.GenerateByPhoneNumberAsync(phoneNumber);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task RefreshToken_WithValidRefreshTokenId_ShouldReturnNewAccessToken()
    {
        // Arrange
        var refreshTokenId = Guid.NewGuid();
        var user = TestDataBuilder.Entities.CreateUser("test@example.com", "testuser");
        var refreshToken = new UserRefreshToken { Id = refreshTokenId, UserId = user.Id, IsValid = true };

        var claims = new List<Claim>
        {
            new Claim("sub", user.UserName!),
            new Claim("email", user.Email!),
            new Claim("role", "User")
        };

        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims));

        _userRefreshTokenRepositoryMock.Setup(x => x.GetTokenWithInvalidation(refreshTokenId))
            .ReturnsAsync(refreshToken);
        _userRefreshTokenRepositoryMock.Setup(x => x.GetUserByRefreshToken(refreshTokenId))
            .ReturnsAsync(user);
        _unitOfWorkMock.Setup(x => x.SaveAsync())
            .ReturnsAsync(1);
        _claimsPrincipalMock.Setup(x => x.CreateAsync(user))
            .ReturnsAsync(claimsPrincipal);
        _unitOfWorkMock.Setup(x => x.GenericRepository<UserRefreshToken>().AddAsync(It.IsAny<UserRefreshToken>()))
            .Returns(Task.CompletedTask);
        _unitOfWorkMock.Setup(x => x.CommitAsync())
            .Returns(Task.CompletedTask);

        // Act
        var result = await _jwtService.RefreshToken(refreshTokenId);

        // Assert
        result.Should().NotBeNull();
        result.Token.Should().NotBeNullOrEmpty();
        result.RefreshToken.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task RefreshToken_WithInvalidRefreshTokenId_ShouldReturnNull()
    {
        // Arrange
        var refreshTokenId = Guid.NewGuid();

        _userRefreshTokenRepositoryMock.Setup(x => x.GetTokenWithInvalidation(refreshTokenId))
            .ReturnsAsync((UserRefreshToken?)null);

        // Act
        var result = await _jwtService.RefreshToken(refreshTokenId);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task RefreshTokenAsync_WithValidTokenString_ShouldReturnNewAccessToken()
    {
        // Arrange
        var refreshTokenId = Guid.NewGuid();
        var tokenString = refreshTokenId.ToString();
        var user = TestDataBuilder.Entities.CreateUser("test@example.com", "testuser");
        var refreshToken = new UserRefreshToken { Id = refreshTokenId, UserId = user.Id, IsValid = true };

        var claims = new List<Claim>
        {
            new Claim("sub", user.UserName!),
            new Claim("email", user.Email!),
            new Claim("role", "User")
        };

        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims));

        _userRefreshTokenRepositoryMock.Setup(x => x.GetTokenWithInvalidation(refreshTokenId))
            .ReturnsAsync(refreshToken);
        _userRefreshTokenRepositoryMock.Setup(x => x.GetUserByRefreshToken(refreshTokenId))
            .ReturnsAsync(user);
        _unitOfWorkMock.Setup(x => x.SaveAsync())
            .ReturnsAsync(1);
        _claimsPrincipalMock.Setup(x => x.CreateAsync(user))
            .ReturnsAsync(claimsPrincipal);
        _unitOfWorkMock.Setup(x => x.GenericRepository<UserRefreshToken>().AddAsync(It.IsAny<UserRefreshToken>()))
            .Returns(Task.CompletedTask);
        _unitOfWorkMock.Setup(x => x.CommitAsync())
            .Returns(Task.CompletedTask);

        // Act
        var result = await _jwtService.RefreshTokenAsync(tokenString);

        // Assert
        result.Should().NotBeNull();
        result.Token.Should().NotBeNullOrEmpty();
        result.RefreshToken.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task RefreshTokenAsync_WithInvalidTokenString_ShouldReturnNull()
    {
        // Arrange
        var tokenString = "invalid-token";

        // Act
        var result = await _jwtService.RefreshTokenAsync(tokenString);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public void GetUserPages_WithValidUserId_ShouldReturnUserPages()
    {
        // Arrange
        var userId = 1;
        var userRole = new UserRole
        {
            UserId = userId,
            Role = new Role
            {
                Id = 1,
                Name = "User",
                Claims = new List<RoleClaim>
                {
                    new RoleClaim { Id = 1, ClaimType = "Permission.Read" },
                    new RoleClaim { Id = 2, ClaimType = "Permission.Write" }
                }
            }
        };

        _unitOfWorkMock.Setup(x => x.GenericRepository<UserRole>().GetAll(
            It.IsAny<System.Linq.Expressions.Expression<System.Func<UserRole, bool>>>(),
            It.IsAny<System.Linq.Expressions.Expression<System.Func<UserRole, object>>[]>()))
            .Returns(new List<UserRole> { userRole }.AsQueryable());

        // Act
        var result = _jwtService.GetUserPages(userId);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
    }
}