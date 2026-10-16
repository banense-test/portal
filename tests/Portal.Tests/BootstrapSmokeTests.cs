using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Portal.Tests;

/// <summary>
/// Bootstrap smoke tests: they prove the host boots and the Razor Pages pipeline
/// is wired. They are the CI baseline's own gate, not a substitute for the
/// per-use-case test cases the Test Designer produces in Elaboration.
/// </summary>
public class BootstrapSmokeTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public BootstrapSmokeTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task HealthEndpoint_ReturnsOk()
    {
        using var client = _factory.CreateClient();

        var response = await client.GetAsync("/health");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task MainPage_Renders()
    {
        using var client = _factory.CreateClient();

        var response = await client.GetAsync("/");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
