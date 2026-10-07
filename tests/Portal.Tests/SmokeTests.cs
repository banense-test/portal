using Xunit;

namespace Portal.Tests;

/// <summary>
/// Bootstrap harness check. It proves the test runner is wired to the solution;
/// the first real test arrives with the first subsystem.
/// </summary>
public class SmokeTests
{
    [Fact]
    public void TestHarness_Runs()
    {
        Assert.True(true);
    }
}
