namespace BackendWebService.IntegrationTests.Infrastructure;

/// <summary>
/// Interface to mark test environments
/// </summary>
public interface ITestEnvironment
{
    bool IsTestEnvironment { get; }
}
