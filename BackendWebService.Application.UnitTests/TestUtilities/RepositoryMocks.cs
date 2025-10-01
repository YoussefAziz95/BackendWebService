using Moq;

namespace BackendWebService.Application.UnitTests.TestUtilities;

/// <summary>
/// Provides common repository mocks for Application layer testing
/// </summary>
public static class RepositoryMocks
{
    /// <summary>
    /// Creates a mock for any repository interface
    /// </summary>
    public static Mock<T> CreateRepositoryMock<T>() where T : class
    {
        return new Mock<T>();
    }

    /// <summary>
    /// Creates a collection of common repository mocks
    /// Note: Most repository interfaces are excluded from compilation in the Application layer
    /// This class provides a foundation for mocking when repository interfaces become available
    /// </summary>
    public static class Common
    {
        // Repository mocks will be added here as interfaces become available
        // For now, we'll focus on testing the available Application layer components
    }
}
