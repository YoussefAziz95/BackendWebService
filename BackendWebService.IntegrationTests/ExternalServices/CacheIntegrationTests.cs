using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using BackendWebService.IntegrationTests.Base;
using BackendWebService.IntegrationTests.Infrastructure;
using FluentAssertions;
using System.Text;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace BackendWebService.IntegrationTests.ExternalServices;

/// <summary>
/// Integration tests for distributed cache (memory cache) interactions
/// </summary>
public class CacheIntegrationTests : BaseIntegrationTest
{
    private readonly IDistributedCache _distributedCache;

    public CacheIntegrationTests(IntegrationTestWebApplicationFactory factory) 
        : base(factory)
    {
        _distributedCache = ServiceProvider.GetRequiredService<IDistributedCache>();
    }

    [Fact]
    public async Task Cache_ShouldSetAndGetStringValue()
    {
        // Arrange
        var key = "test-string-key";
        var value = "test-string-value";

        // Act
        await _distributedCache.SetStringAsync(key, value);
        var retrievedValue = await _distributedCache.GetStringAsync(key);

        // Assert
        retrievedValue.Should().Be(value, "String value should be stored and retrieved correctly");
    }

    [Fact]
    public async Task Cache_ShouldSetAndGetByteArrayValue()
    {
        // Arrange
        var key = "test-byte-key";
        var value = Encoding.UTF8.GetBytes("test-byte-value");

        // Act
        await _distributedCache.SetAsync(key, value);
        var retrievedValue = await _distributedCache.GetAsync(key);

        // Assert
        retrievedValue.Should().NotBeNull("Byte array value should be stored");
        retrievedValue.Should().BeEquivalentTo(value, "Byte array value should be retrieved correctly");
    }

    [Fact]
    public async Task Cache_ShouldHandleJsonSerialization()
    {
        // Arrange
        var key = "test-json-key";
        var testObject = new { Name = "Test", Value = 123, IsActive = true };
        var jsonValue = JsonSerializer.Serialize(testObject);

        // Act
        await _distributedCache.SetStringAsync(key, jsonValue);
        var retrievedJson = await _distributedCache.GetStringAsync(key);
        var deserializedObject = JsonSerializer.Deserialize<dynamic>(retrievedJson!);

        // Assert
        retrievedJson.Should().Be(jsonValue, "JSON value should be stored and retrieved correctly");
        deserializedObject.Should().NotBeNull("JSON should be deserializable");
    }

    [Fact]
    public async Task Cache_ShouldHandleExpiration()
    {
        // Arrange
        var key = "test-expiration-key";
        var value = "test-expiration-value";
        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(1)
        };

        // Act
        await _distributedCache.SetStringAsync(key, value, options);
        var retrievedValue = await _distributedCache.GetStringAsync(key);

        // Assert
        retrievedValue.Should().Be(value, "Value should be available before expiration");

        // Wait for expiration
        await Task.Delay(1100);
        var expiredValue = await _distributedCache.GetStringAsync(key);

        // Assert
        expiredValue.Should().BeNull("Value should be null after expiration");
    }

    [Fact]
    public async Task Cache_ShouldHandleSlidingExpiration()
    {
        // Arrange
        var key = "test-sliding-key";
        var value = "test-sliding-value";
        var options = new DistributedCacheEntryOptions
        {
            SlidingExpiration = TimeSpan.FromSeconds(2)
        };

        // Act
        await _distributedCache.SetStringAsync(key, value, options);
        var retrievedValue = await _distributedCache.GetStringAsync(key);

        // Assert
        retrievedValue.Should().Be(value, "Value should be available with sliding expiration");

        // Access the value to reset sliding expiration
        await Task.Delay(1000);
        var refreshedValue = await _distributedCache.GetStringAsync(key);
        refreshedValue.Should().Be(value, "Value should still be available after refresh");

        // Wait for sliding expiration
        await Task.Delay(2100);
        var expiredValue = await _distributedCache.GetStringAsync(key);

        // Assert
        expiredValue.Should().BeNull("Value should be null after sliding expiration");
    }

    [Fact]
    public async Task Cache_ShouldHandleRemoveOperation()
    {
        // Arrange
        var key = "test-remove-key";
        var value = "test-remove-value";

        // Act
        await _distributedCache.SetStringAsync(key, value);
        var retrievedValue = await _distributedCache.GetStringAsync(key);
        await _distributedCache.RemoveAsync(key);
        var removedValue = await _distributedCache.GetStringAsync(key);

        // Assert
        retrievedValue.Should().Be(value, "Value should be stored before removal");
        removedValue.Should().BeNull("Value should be null after removal");
    }

    [Fact]
    public async Task Cache_ShouldHandleConcurrentOperations()
    {
        // Arrange
        var tasks = new List<Task>();
        var keyPrefix = "concurrent-test-";
        var valuePrefix = "concurrent-value-";

        // Act - Concurrent writes
        for (int i = 0; i < 10; i++)
        {
            int index = i; // Capture loop variable
            tasks.Add(Task.Run(async () =>
            {
                var key = $"{keyPrefix}{index}";
                var value = $"{valuePrefix}{index}";
                await _distributedCache.SetStringAsync(key, value);
            }));
        }

        await Task.WhenAll(tasks);

        // Verify all values were stored
        var verifyTasks = new List<Task<string?>>();
        for (int i = 0; i < 10; i++)
        {
            var key = $"{keyPrefix}{i}";
            verifyTasks.Add(_distributedCache.GetStringAsync(key));
        }

        var results = await Task.WhenAll(verifyTasks);

        // Assert
        results.Should().HaveCount(10, "All concurrent operations should complete");
        results.Should().AllSatisfy(r => r.Should().NotBeNull("All values should be stored"));
    }

    [Fact]
    public async Task Cache_ShouldHandleLargeValues()
    {
        // Arrange
        var key = "test-large-key";
        var largeValue = new string('A', 10000); // 10KB string

        // Act
        await _distributedCache.SetStringAsync(key, largeValue);
        var retrievedValue = await _distributedCache.GetStringAsync(key);

        // Assert
        retrievedValue.Should().Be(largeValue, "Large values should be stored and retrieved correctly");
    }

    [Fact]
    public async Task Cache_ShouldHandleSpecialCharacters()
    {
        // Arrange
        var key = "test-special-key";
        var value = "Special characters: !@#$%^&*()àáâãäåæçèéêë";

        // Act
        await _distributedCache.SetStringAsync(key, value);
        var retrievedValue = await _distributedCache.GetStringAsync(key);

        // Assert
        retrievedValue.Should().Be(value, "Special characters should be handled correctly");
    }

    [Fact]
    public async Task Cache_ShouldHandleNullValues()
    {
        // Arrange
        var key = "test-null-key";

        // Act
        await _distributedCache.SetStringAsync(key, null!);
        var retrievedValue = await _distributedCache.GetStringAsync(key);

        // Assert
        retrievedValue.Should().BeNull("Null values should be handled correctly");
    }

    [Fact]
    public async Task Cache_ShouldHandleEmptyKeys()
    {
        // Arrange
        var key = "";
        var value = "test-empty-key-value";

        // Act & Assert
        var action = async () => await _distributedCache.SetStringAsync(key, value);
        await action.Should().NotThrowAsync("Empty keys should be handled gracefully");
    }

    [Fact]
    public async Task Cache_ShouldHandleNonExistentKeys()
    {
        // Arrange
        var nonExistentKey = "non-existent-key";

        // Act
        var retrievedValue = await _distributedCache.GetStringAsync(nonExistentKey);

        // Assert
        retrievedValue.Should().BeNull("Non-existent keys should return null");
    }

    [Fact]
    public async Task Cache_ShouldHandleRefreshOperation()
    {
        // Arrange
        var key = "test-refresh-key";
        var value = "test-refresh-value";
        var options = new DistributedCacheEntryOptions
        {
            SlidingExpiration = TimeSpan.FromSeconds(5)
        };

        // Act
        await _distributedCache.SetStringAsync(key, value, options);
        await _distributedCache.RefreshAsync(key);
        var retrievedValue = await _distributedCache.GetStringAsync(key);

        // Assert
        retrievedValue.Should().Be(value, "Value should be available after refresh");
    }

    [Fact]
    public async Task Cache_ShouldHandleComplexObjects()
    {
        // Arrange
        var key = "test-complex-key";
        var complexObject = new
        {
            Id = 1,
            Name = "Test Object",
            Properties = new[] { "Property1", "Property2", "Property3" },
            NestedObject = new
            {
                Value = 42,
                IsActive = true
            }
        };
        var jsonValue = JsonSerializer.Serialize(complexObject);

        // Act
        await _distributedCache.SetStringAsync(key, jsonValue);
        var retrievedJson = await _distributedCache.GetStringAsync(key);
        var deserializedObject = JsonSerializer.Deserialize<dynamic>(retrievedJson!);

        // Assert
        retrievedJson.Should().Be(jsonValue, "Complex objects should be stored and retrieved correctly");
        deserializedObject.Should().NotBeNull("Complex objects should be deserializable");
    }
}
