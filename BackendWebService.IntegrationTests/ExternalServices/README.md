# External Service Integration Tests

This directory contains comprehensive integration tests for external service interactions in the BackendWebService solution.

## Overview

The external service integration tests validate the integration with various external dependencies including:
- Email services (SMTP)
- Notification services (SignalR)
- Caching services (Distributed Memory Cache)
- Authentication services (JWT)
- Third-party APIs

## Test Structure

### Test Files

1. **EmailServiceIntegrationTests.cs** - Tests email service integration
2. **SignalRIntegrationTests.cs** - Tests SignalR hub integration
3. **CacheIntegrationTests.cs** - Tests distributed memory cache integration
4. **JwtAuthenticationIntegrationTests.cs** - Tests JWT authentication integration
5. **ExternalServiceFailureTests.cs** - Tests failure scenarios and error handling
6. **ExternalServiceTestInfrastructure.cs** - Base infrastructure for external service tests
7. **ExternalServiceTestConfiguration.cs** - Configuration for external service tests
8. **ExternalServiceTestDataBuilder.cs** - Test data builders for external services
9. **ExternalServiceTestUtilities.cs** - Utility methods for external service tests

### Test Categories

#### 1. Email Service Tests
- **Valid Email Sending**: Tests successful email delivery
- **Email Validation**: Tests email address validation
- **Template Processing**: Tests email template rendering
- **Error Handling**: Tests SMTP errors, authentication failures, and network issues
- **Performance**: Tests email sending performance and concurrency

#### 2. SignalR Tests
- **Connection Management**: Tests hub connections and disconnections
- **Message Broadcasting**: Tests real-time message broadcasting
- **User Groups**: Tests user group management
- **Error Handling**: Tests connection failures and message delivery errors
- **Performance**: Tests concurrent connections and message throughput

#### 3. Cache Tests
- **Cache Operations**: Tests get, set, and remove operations
- **Cache Expiration**: Tests cache expiration and TTL
- **Cache Serialization**: Tests object serialization and deserialization
- **Cache Performance**: Tests cache performance and memory usage
- **Cache Consistency**: Tests cache consistency across operations

#### 4. JWT Authentication Tests
- **Token Generation**: Tests JWT token creation
- **Token Validation**: Tests JWT token validation
- **Token Refresh**: Tests token refresh mechanisms
- **Security**: Tests token security and expiration
- **Error Handling**: Tests authentication failures and invalid tokens

#### 5. Failure Scenario Tests
- **Service Unavailable**: Tests when external services are down
- **Network Timeouts**: Tests network timeout handling
- **Authentication Failures**: Tests authentication error handling
- **Rate Limiting**: Tests rate limiting and throttling
- **Concurrent Failures**: Tests handling of multiple concurrent failures

## Test Infrastructure

### WireMock Integration
- Uses WireMock.Net for mocking external HTTP services
- Provides realistic HTTP responses for testing
- Supports dynamic response configuration
- Enables testing of various HTTP scenarios

### Test Configuration
- Configurable test settings via `ExternalServiceTestConfiguration`
- Support for different test environments
- Customizable timeouts and retry policies
- Environment-specific service endpoints

### Test Data Builders
- Fluent API for creating test data
- Support for various data scenarios (valid, invalid, edge cases)
- Consistent test data across test methods
- Easy maintenance and updates

### Test Utilities
- Common utility methods for external service testing
- HTTP client creation and configuration
- JSON serialization/deserialization helpers
- Retry logic and timeout handling
- Resource cleanup utilities

## Running Tests

### Prerequisites
- .NET 8.0 SDK
- Docker (for containerized services)
- WireMock.Net package

### Command Line
```bash
# Run all external service tests
dotnet test BackendWebService.IntegrationTests --filter "Category=ExternalServices"

# Run specific test class
dotnet test BackendWebService.IntegrationTests --filter "ClassName=EmailServiceIntegrationTests"

# Run with verbose output
dotnet test BackendWebService.IntegrationTests --filter "Category=ExternalServices" --verbosity normal
```

### Visual Studio
1. Open the solution in Visual Studio
2. Navigate to Test Explorer
3. Filter by "ExternalServices" category
4. Run individual tests or entire test classes

## Test Configuration

### Environment Variables
```bash
# Email service configuration
EMAIL_SMTP_SERVER=localhost
EMAIL_SMTP_PORT=587
EMAIL_USERNAME=test@example.com
EMAIL_PASSWORD=testpassword

# Notification service configuration
NOTIFICATION_HUB_URL=http://localhost:5000/notificationHub
NOTIFICATION_TIMEOUT=30

# Cache configuration
CACHE_CONNECTION_STRING=localhost:6379
CACHE_DATABASE=0

# JWT configuration
JWT_SECRET_KEY=your-secret-key
JWT_ISSUER=BackendWebService
JWT_AUDIENCE=BackendWebService-Users
```

### Test Settings
```json
{
  "TestSettings": {
    "EmailService": {
      "SmtpServer": "localhost",
      "SmtpPort": 587,
      "EnableSsl": true,
      "Username": "test@example.com",
      "Password": "testpassword"
    },
    "NotificationService": {
      "HubUrl": "http://localhost:5000/notificationHub",
      "Timeout": 30,
      "RetryCount": 3
    },
    "CacheService": {
      "ConnectionString": "localhost:6379",
      "Database": 0,
      "Timeout": 30
    }
  }
}
```

## Best Practices

### Test Isolation
- Each test should be independent and not rely on other tests
- Use proper setup and teardown methods
- Clean up resources after each test
- Avoid shared state between tests

### Test Data Management
- Use test data builders for consistent data creation
- Avoid hardcoded test data
- Use meaningful test data that reflects real-world scenarios
- Clean up test data after tests complete

### Error Handling
- Test both success and failure scenarios
- Validate error messages and status codes
- Test timeout and retry mechanisms
- Ensure proper resource cleanup on errors

### Performance Testing
- Test with realistic data volumes
- Measure response times and throughput
- Test concurrent operations
- Monitor memory usage and resource consumption

### Mocking Strategy
- Use WireMock for HTTP service mocking
- Mock external dependencies, not internal services
- Provide realistic mock responses
- Test various response scenarios (success, error, timeout)

## Troubleshooting

### Common Issues

#### 1. WireMock Server Not Starting
- Check if the port is available
- Verify WireMock.Net package is installed
- Check firewall settings

#### 2. Test Timeouts
- Increase timeout values in test configuration
- Check network connectivity
- Verify external service availability

#### 3. Authentication Failures
- Verify test credentials are correct
- Check JWT configuration
- Ensure proper token generation

#### 4. Cache Issues
- Verify cache connection string
- Check cache server availability
- Clear cache between tests

### Debug Tips
- Enable verbose logging in test configuration
- Use breakpoints in test methods
- Check WireMock server logs
- Monitor network traffic with tools like Fiddler

## Maintenance

### Adding New Tests
1. Create test class following naming convention
2. Inherit from appropriate base class
3. Add test methods with descriptive names
4. Use test data builders for data creation
5. Add proper assertions and error handling

### Updating Test Data
1. Modify test data builders as needed
2. Update test configuration files
3. Ensure backward compatibility
4. Update documentation

### Performance Optimization
1. Monitor test execution times
2. Optimize test data creation
3. Use parallel test execution where appropriate
4. Clean up resources efficiently

## Contributing

When contributing to external service integration tests:

1. Follow existing naming conventions
2. Add comprehensive test coverage
3. Include both positive and negative test cases
4. Update documentation as needed
5. Ensure tests are maintainable and readable

## Support

For questions or issues with external service integration tests:

1. Check this documentation first
2. Review existing test implementations
3. Check test logs and error messages
4. Contact the development team for assistance
