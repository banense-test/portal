var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();

// Liveness probe. The portal is reachable only from the internal corporate
// network (CON-019); this endpoint carries no data and no identity.
app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

app.Run();

/// <summary>
/// Entry point marker so the test project can host the application in-process.
/// </summary>
public partial class Program;
