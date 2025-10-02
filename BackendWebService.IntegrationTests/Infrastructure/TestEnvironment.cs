namespace BackendWebService.IntegrationTests.Infrastructure;

/// <summary>
/// Implementation to mark test environments
/// </summary>
public class TestEnvironment : ITestEnvironment
{
    public bool IsTestEnvironment => true;
}
