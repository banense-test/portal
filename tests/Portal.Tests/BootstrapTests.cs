using Portal.Web.Pages;
using Xunit;

namespace Portal.Tests;

public sealed class BootstrapTests
{
    [Fact]
    public void IndexPageModel_IsConstructible()
    {
        var model = new IndexModel();

        Assert.NotNull(model);
    }
}
