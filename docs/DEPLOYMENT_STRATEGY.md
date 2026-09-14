# Deployment Strategy — Employee Portal

## Document Control

| Field | Value |
|---|---|
| Phase | Inception |
| Status | Draft |
| Milestone Target | End-of-Inception (Lifecycle Objectives) — NOT YET ACHIEVED |
| Project | Portal |
| Owner | Deployment Manager |

## Deployment Mode

**Custom-built** deployment (selected at Inception). The portal is built for a single customer (Cuba Corp), installed on their internal infrastructure, and operated by their Infrastructure team post-launch (CON-011). This is neither shrink-wrapped (no third-party distribution) nor downloadable (no public artifact).

## Target User Community and Environments

| Environment | Purpose | Operator |
|---|---|---|
| Development Site | Gate 1 acceptance (development-site tests) | Development team |
| Production Site | Gate 2 acceptance (install-site tests) + go-live | Infrastructure team (CON-011) |

**User community:** 200 employees across 3 offices (STK-004), plus HR administrators (STK-001). All access is from the corporate browser (Chrome/Edge, CON-005) on the internal network only (CON-009).

## Deployment Topology (sketch)

```plantuml
@startuml
skinparam nodeStyle rectangle

node "Development Site (Gate 1)" as DEV {
  node "Dev Windows Server" as DEVS {
    component "IIS + .NET 10 App" as DEVAPP
    database "PostgreSQL (dev)" as DEVPG
  }
}

node "Production Site (Gate 2)" as PROD {
  node "Windows Server (CON-004)" as SRV {
    component "IIS" as IIS
    component ".NET 10 App\n(Razor Pages + REST API)" as APP
    database "PostgreSQL (CON-003)" as PG
  }
}

node "External - operated by Infrastructure" as EXT {
  node "Keycloak (OIDC)" as KC <<external>>
  node "Active Directory" as AD <<external>>
}

actor "Employee / HR\n(corporate browser)" as USER

USER --> IIS : HTTPS (Chrome/Edge, CON-005)
IIS --> APP : hosts
APP --> PG : SQL
APP --> KC : OIDC redirect / token validation (CON-006)
APP --> AD : LDAP read on demand (CON-007, CON-010)

note right of PROD
  CON-009: internal network only.
  CON-011: Infrastructure operates post-launch.
  CON-013: backups via Infrastructure practice.
  NFR-003: availability Mon-Fri 7:00-19:00.
end note

note right of DEV
  Gate 1: development-site acceptance.
  Same topology as production, isolated data.
end note
@enduml
```

**Topology summary:** single-node deployment — one Windows Server hosting IIS + the .NET 10 app, with PostgreSQL co-located (or a co-located DB node, decided in Elaboration). Keycloak and AD are external, operated by Infrastructure (CON-006, CON-010). No cloud, no multi-node topology, no load balancing (200 users, NFR-003 availability window). This matches the SAD Deployment View; the Deployment Model optional artifact is **not triggered** (single-node, single-environment).

## Rollout Approach

**Two-gate acceptance path** (established at Inception):

```plantuml
@startuml
start
:Build SCM release (versioned, tagged);
:Deploy to Development Site;
:Gate 1 - Development-site acceptance tests;
if (Gate 1 passed?) then (yes)
  :Deploy to Production Site (install);
  :Gate 2 - Install-site acceptance tests;
  if (Gate 2 passed?) then (yes)
    :Go-live;
    :Handover to Infrastructure (CON-011);
    stop
  else (no)
    :Rollback to previous release;
    stop
  endif
else (no)
  :Fix defects;
  :Re-deploy to Development Site;
endif
@enduml
```

**Gate 1 — Development site.** The development team deploys the SCM release to the development site and runs acceptance tests there first. No production install until Gate 1 passes.

**Gate 2 — Install site.** After Gate 1 passes, the release is installed on the production site and install-site acceptance tests run. This is the final gate before go-live.

**Rollback criteria.** Rollback to the previous SCM release is triggered when Gate 2 (install-site acceptance) fails. Gate 1 failures do not roll back — they loop back to defect fixing and re-deploy on the development site.

**Handover.** At the end of Transition, the development team hands over to the Infrastructure team, who operate the portal in production (deployment, monitoring, patching) exactly as they operate AD and Keycloak (CON-011).

## Deployment Constraints and Risks

| Constraint | Deployment consequence |
|---|---|
| CON-004 | Internal Windows Server (IIS) hosting — no cloud |
| CON-006 | Keycloak is an OIDC client dependency only — never deployed/provisioned here |
| CON-009 | No access from outside the corporate network |
| CON-011 | Infrastructure operates post-launch; dev team hands over at end of Transition |
| CON-012 | No data migration — portal starts empty; historical Excel stays read-only archive |
| CON-013 | Backups covered by Infrastructure's existing practice (verified restore) — no backup design in this project |

| Risk | Deployment relevance |
|---|---|
| R001 | AD attribute gaps (job title, extension) may render blank in the directory — validate early in Elaboration against UC-008 |
| R002 | Digital clocking adoption — mitigated by communication and training at go-live (BG-003, AC-004) |

## Traceability

| Element | Traces From | Link Type | Traces To |
|---|---|---|---|
| Custom-built mode | CON-004, CON-011 | DependsOn | — |
| Two-gate acceptance path | AC-001…AC-005 | DependsOn | Transition plan |
| Single-node topology | CON-004, NFR-003 | DependsOn | SAD Deployment View |
| Handover to Infrastructure | CON-011 | DependsOn | Transition plan |
| R001 | CON-007, FR-008, UC-008 | DependsOn | Elaboration PoC |
| R002 | BG-003, AC-004, FR-001 | DependsOn | Transition plan |
