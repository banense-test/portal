// Portal — web host entry point.
//
// Bootstrap only. The three declared capability areas (UC-001 Clocking,
// UC-002 News, UC-003 Employee Directory) are implemented in later iterations
// on feature branches cut from iteration/Cn.
//
// CON-002: the backend exposes a REST API. CON-003: Razor Pages, no SPA —
// no client-side framework and no client-side router. A page-level script on an
// already-rendered page is Razor Pages as normal and is required by FR-012.

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();

app.Run();

/// <summary>
/// Exposed so the test project can reference the web assembly's entry point.
/// </summary>
public partial class Program;
