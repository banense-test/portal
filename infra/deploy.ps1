#requires -Version 5.1
<#
.SYNOPSIS
  Skeleton deployment script for the Portal ASP.NET Core application on internal Windows Server.

.DESCRIPTION
  This script is a placeholder to be refined in Transition with:
  - target server name and credentials (STK-003)
  - IIS site / application pool configuration
  - PostgreSQL connection string injection
  - Keycloak OIDC client secret injection
  - database migration step
  - rollback path

.NOTES
  Deployment mode: custom-built single-server (CON-007).
  No cloud, no container orchestrator, no Helm chart.
#>

[CmdletBinding()]
param(
    [Parameter(Mandatory=$true)]
    [ValidateSet('Staging','Production')]
    [string]$Environment,

    [Parameter(Mandatory=$true)]
    [string]$ServerName,

    [Parameter(Mandatory=$true)]
    [string]$ArtifactPath
)

Write-Host "Deploying Portal to $Environment on $ServerName from $ArtifactPath"

# TODO: stop IIS app pool
# TODO: backup current deployment folder
# TODO: copy new artifact
# TODO: apply database migrations
# TODO: start IIS app pool
# TODO: smoke test: login, clocking, directory, news

Write-Host 'Deployment skeleton complete — manual steps remain.'
