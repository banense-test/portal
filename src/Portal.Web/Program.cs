// Portal — Employee Portal host.
//
// Bootstrap skeleton only. The three functional areas (clocking, news, directory)
// are implemented in Elaboration against the stand-in OIDC issuer and the stand-in
// directory (CON-035). No real Keycloak or AD value is ever committed: the OIDC and
// LDAP settings in appsettings.json are placeholders Infrastructure replaces at
// deployment (CON-035).

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();

// Liveness probe. Used by the CI smoke test and by Infrastructure's monitoring.
app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

app.Run();

// Exposed so the test project can host the application in-process
// (WebApplicationFactory<Program>).
public partial class Program;
