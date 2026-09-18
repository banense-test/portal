using Xunit;

namespace Portal.Tests;

/// <summary>
/// Bootstrap smoke test.
///
/// Proves two things the pipeline must be able to prove before any real work
/// lands: the test job executes, and the web assembly produced by the build job
/// is loadable from the test project. Real test cases (TC-NNN) arrive with the
/// first Construction iteration.
/// </summary>
public class BootstrapSmokeTests
{
    [Fact]
    public void WebAssembly_IsLoadable_FromTestProject()
    {
        var assembly = typeof(Portal.Web.Pages.IndexModel).Assembly;

        Assert.Equal("Portal.Web", assembly.GetName().Name);
    }
}
