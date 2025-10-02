using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using BackendWebService.IntegrationTests.Base;
using BackendWebService.IntegrationTests.Infrastructure;
using FluentAssertions;

namespace BackendWebService.IntegrationTests.ExternalServices;

/// <summary>
/// Integration tests for external service integrations
/// </summary>
public class ExternalServiceIntegrationTests : BaseIntegrationTest
{
    private readonly WireMockServer _wireMockServer;

    public ExternalServiceIntegrationTests(IntegrationTestWebApplicationFactory factory) 
        : base(factory)
    {
        _wireMockServer = factory.GetEmailServiceMock() ?? WireMockServer.Start();
    }

    [Fact]
    public async Task ExternalService_ShouldHandleSuccessfulApiCall()
    {
        // Arrange
        var expectedResponse = new { message = "Success", data = "Test data" };
        
        _wireMockServer
            .Given(Request.Create()
                .WithPath("/api/external/test")
                .UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "application/json")
                .WithBody(JsonConvert.SerializeObject(expectedResponse)));

        // Act
        var response = await Client.GetAsync("/api/external/test");

        // Assert
        response.IsSuccessStatusCode.Should().BeTrue();
        
        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<dynamic>(content);
        
        result.Should().NotBeNull();
        ((string)result.message).Should().Be("Success");
    }

    [Fact]
    public async Task ExternalService_ShouldHandleApiError()
    {
        // Arrange
        _wireMockServer
            .Given(Request.Create()
                .WithPath("/api/external/error")
                .UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(500)
                .WithHeader("Content-Type", "application/json")
                .WithBody(JsonConvert.SerializeObject(new { error = "Internal Server Error" })));

        // Act
        var response = await Client.GetAsync("/api/external/error");

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.InternalServerError);
        
        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<dynamic>(content);
        ((string)result.error).Should().Be("Internal Server Error");
    }

    [Fact]
    public async Task ExternalService_ShouldHandleAuthenticationFailure()
    {
        // Arrange
        _wireMockServer
            .Given(Request.Create()
                .WithPath("/api/external/unauthorized")
                .UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(401)
                .WithHeader("Content-Type", "application/json")
                .WithBody(JsonConvert.SerializeObject(new { error = "Unauthorized" })));

        // Act
        var response = await Client.GetAsync("/api/external/unauthorized");

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task ExternalService_ShouldHandlePostRequest()
    {
        // Arrange
        var requestData = new { name = "Test", value = 123 };
        var expectedResponse = new { id = 1, status = "created" };
        
        _wireMockServer
            .Given(Request.Create()
                .WithPath("/api/external/create")
                .UsingPost()
                .WithBody(JsonConvert.SerializeObject(requestData)))
            .RespondWith(Response.Create()
                .WithStatusCode(201)
                .WithHeader("Content-Type", "application/json")
                .WithBody(JsonConvert.SerializeObject(expectedResponse)));

        // Act
        var json = JsonConvert.SerializeObject(requestData);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await Client.PostAsync("/api/external/create", content);

        // Assert
        response.IsSuccessStatusCode.Should().BeTrue();
        
        var responseContent = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<dynamic>(responseContent);
        ((int)result.id).Should().Be(1);
        ((string)result.status).Should().Be("created");
    }

    [Fact]
    public async Task ExternalService_ShouldHandleConcurrentRequests()
    {
        // Arrange
        var requestCount = 10;
        var tasks = new List<Task<HttpResponseMessage>>();
        
        _wireMockServer
            .Given(Request.Create()
                .WithPath("/api/external/concurrent")
                .UsingGet())
            .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithHeader("Content-Type", "application/json")
                .WithBody(JsonConvert.SerializeObject(new { message = "Success" })));

        // Act
        for (int i = 0; i < requestCount; i++)
        {
            tasks.Add(Client.GetAsync("/api/external/concurrent"));
        }

        var responses = await Task.WhenAll(tasks);

        // Assert
        responses.Should().HaveCount(requestCount);
        responses.Should().AllSatisfy(r => r.IsSuccessStatusCode.Should().BeTrue());
    }
}