using System.Text.Json;
using Xunit;

namespace Portal.Tests;

/// <summary>
/// CON-031: the OIDC client and the LDAP connection are configured with
/// placeholder values held in configuration, never in code. Infrastructure
/// substitutes the real values at deployment. A real credential committed to
/// the repository is a defect, so the scaffold asserts the placeholders hold.
/// </summary>
public sealed class ConfigurationPlaceholderTests
{
    [Fact]
    public void IdentityAndDirectorySettings_ArePlaceholders()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
        Assert.True(File.Exists(path), $"appsettings.json not found at {path}");

        using var document = JsonDocument.Parse(File.ReadAllText(path));
        var root = document.RootElement;

        var oidc = root.GetProperty("Authentication").GetProperty("Oidc");
        Assert.StartsWith("__", oidc.GetProperty("Authority").GetString());
        Assert.StartsWith("__", oidc.GetProperty("ClientId").GetString());
        Assert.StartsWith("__", oidc.GetProperty("ClientSecret").GetString());

        var ldap = root.GetProperty("Directory").GetProperty("Ldap");
        Assert.StartsWith("__", ldap.GetProperty("Host").GetString());
        Assert.StartsWith("__", ldap.GetProperty("BindAccount").GetString());
        Assert.StartsWith("__", ldap.GetProperty("BaseDn").GetString());
    }
}
