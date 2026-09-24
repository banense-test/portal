using Xunit;

namespace Portal.Tests;

/// <summary>
/// Bootstrap harness check. It exists to prove the CI test job actually executes
/// tests, so that a green test job is evidence and not an empty run. The Implementer
/// replaces it with real tests for UC-001..UC-009 as the subsystems land.
/// </summary>
public class BootstrapHarnessTests
{
    [Fact]
    public void TestHarness_IsWired()
    {
        Assert.True(true);
    }
}
