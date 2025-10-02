using Application.Contracts.HubServices;
using Application.Features;

namespace BackendWebService.IntegrationTests.Infrastructure;

/// <summary>
/// Mock implementation of INotificationService for integration tests
/// </summary>
public class MockNotificationService : INotificationService
{
    private readonly List<AddNotificationRequest> _sentNotifications = new();
    private bool _simulateFailure = false;

    public Task<bool> SendMessageAsync(AddNotificationRequest request)
    {
        if (_simulateFailure)
        {
            return Task.FromResult(false);
        }

        if (request == null || 
            string.IsNullOrEmpty(request.KeyMessageTitle) || 
            string.IsNullOrEmpty(request.KeyMessageBody))
        {
            return Task.FromResult(false);
        }

        _sentNotifications.Add(request);
        return Task.FromResult(true);
    }

    // Test helper methods
    public void SimulateFailure(bool shouldFail)
    {
        _simulateFailure = shouldFail;
    }

    public IReadOnlyList<AddNotificationRequest> GetSentNotifications()
    {
        return _sentNotifications.AsReadOnly();
    }

    public void ClearSentNotifications()
    {
        _sentNotifications.Clear();
    }
}
