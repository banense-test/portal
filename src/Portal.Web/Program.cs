// Employee Portal - application entry point.
//
// Stack (declared, not inferred):
//   CON-022  backend .NET 10 exposing a REST API
//   CON-023  frontend Razor Pages - no SPA, no client-side framework, no client-side router.
//            A page-level script on an already-rendered page is Razor Pages as normal.
//   CON-024  PostgreSQL 18 (patch floats, major pinned)
//   CON-002  OIDC client of the existing Keycloak, which federates Active Directory
//   CON-005  directory fields read from Active Directory over LDAP, read-only
//   CON-028  the team works against stand-ins, never the real Keycloak or AD.
//            Placeholder values live in configuration, never in code.
//
// This file is the bootstrap skeleton only. Authentication, authorization, the LDAP
// directory reader, the clocking subsystem, the news subsystem and the reporting
// subsystem are built by the Implementer in later iterations.

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();

app.Run();
