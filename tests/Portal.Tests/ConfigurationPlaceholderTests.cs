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
    private const string PlaceholderMarker = "__";

    [Fact]
    public void IdentityAndDirectorySettings_ArePlaceholders()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
        Assert.True(File.Exists(path), $"appsettings.json not found at {path}");

        using var document = JsonDocument.Parse(File.ReadAllText(path));
        var root = document.RootElement;

        var oidc = root.GetProperty("Authentication").GetProperty("Oidc");
        AssertPlaceholder(oidc, "Authority");
        AssertPlaceholder(oidc, "ClientId");
        AssertPlaceholder(oidc, "ClientSecret");

        var ldap = root.GetProperty("Directory").GetProperty("Ldap");
        AssertPlaceholder(ldap, "Host");
        AssertPlaceholder(ldap, "BindAccount");
        AssertPlaceholder(ldap, "BindPassword");
        AssertPlaceholder(ldap, "BaseDn");
    }

    private static void AssertPlaceholder(JsonElement section, string propertyName)
    {
        var value = section.GetProperty(propertyName).GetString();

        Assert.False(string.IsNullOrWhiteSpace(value), $"{propertyName} is empty");
        Assert.Contains(PlaceholderMarker, value);
    }
}
