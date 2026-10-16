## Document Control

- Phase: Inception
- Status: Draft — iteration 1, submitted for review
- Milestone Target: End of Inception (Lifecycle Objectives) — NOT YET ACHIEVED

## Deployment Topology

The Development Case records the Deployment Model's §5.2 trigger as FIRED: the deployment view is genuinely multi-node and multi-environment. This document is the deployment view in full; the Software Architecture Document carries the same topology in its Deployment View section and this document is its authoritative form.

```plantuml
@startuml Portal_DeploymentModel_Topology
title Deployment Model — Portal node topology (Inception iteration 1)
skinparam shadowing false

node "Corporate network — CON-008" {
  node "Offices 1-3 — employee and HR workstations" {
    node "Corporate browser\nChrome / Edge — CON-009" as BROWSER
  }
  node "Windows Server estate — CON-005, CON-006" {
    node "Application server" {
      artifact "Portal.Web\n.NET 10, Razor Pages + REST API\nCON-029, CON-030" as APP
    }
    node "Database server" {
      database "PostgreSQL 18\nCON-031" as DB
    }
  }
  node "Identity server — Infrastructure-operated" {
    component "Keycloak\nOIDC identity provider\nCON-032: intra-network" as KC
  }
  node "Domain controllers — Infrastructure-operated" {
    component "Active Directory\nLDAP, read only — CON-003, CON-004" as AD
  }
}

node "Hosted SCM provider — CON-033" {
  component "Hosted CI\nbuild and test only" as CI
}

BROWSER --> APP : HTTPS\nintra-network
APP --> DB : TCP
APP --> KC : OIDC redirect + token
APP --> AD : LDAP
CI ..> APP : build artifact only\nnever deploys

note bottom of KC
  NOT INSTALLED BY THIS PROJECT (CON-001).
  CON-032: Keycloak runs INSIDE the corporate network.
  A topology that puts it in a cloud node is wrong.
end note

note bottom of AD
  NOT WRITTEN BY THIS PROJECT (CON-004).
  Read over LDAP only; no AD modification is requested.
end note

note bottom of CI
  CON-033: 'no cloud' and 'internal network only' govern the
  portal at runtime, not the development toolchain.
  CI holds no production data or credentials and never deploys.
end note
@enduml
```

### What this project installs, and what it does not

| Node | Operated by | Installed by this project | Declared by |
|---|---|---|---|
| Corporate browser (Chrome / Edge) | The employee's workstation | Nothing. The clocking page script is served with the page. No installable app, no service worker, no client cache (CON-039). | CON-009, CON-039 |
| Application server | Infrastructure | The .NET 10 application — Razor Pages and the REST endpoints. | CON-005, CON-006, CON-029, CON-030 |
| Database server | Infrastructure | Nothing. Infrastructure installs PostgreSQL 18 on the estate it already operates. | CON-031 |
| Identity server | Infrastructure | **Nothing.** Keycloak is not ours to deploy (CON-001). It runs inside the corporate network (CON-032); the portal is an OIDC client of it. | CON-001, CON-032 |
| Domain controllers | Infrastructure | **Nothing.** The portal reads AD over LDAP and never writes to it (CON-003, CON-004). | CON-003, CON-004 |
| Hosted SCM provider | The workspace's configured provider | The repository, and the CI that builds and tests. CI never holds production data or credentials and never deploys (CON-033). | CON-033 |

**Two negative facts this topology records.** Keycloak is not installed by this project, and no write reaches Active Directory. Both are declared constraints (CON-001, CON-004) and both are the basis of Infrastructure's acceptance (CON-006). A topology that omits them invites a later reader to add them.

**No cloud node carries the portal.** CON-008 restricts the portal to the internal corporate network. The hosted CI node is drawn outside the corporate network boundary because it is the development toolchain, not the runtime (CON-033).

**No Keycloak node is drawn as something we install.** CON-032 places Keycloak inside the corporate network and states that a deployment view putting it in a cloud node contradicts the constraint. It is drawn as an Infrastructure-operated intra-network node, and the portal's only relationship to it is the OIDC redirect.

## Nodes and Connectors

### Nodes

| Node | Type | Environment | Declared by |
|---|---|---|---|
| Corporate browser | Execution environment — Chrome / Edge | Production | CON-009 |
| Application server | Execution environment — .NET 10 runtime | Development, test, production | CON-005, CON-006, CON-029 |
| Database server | Execution environment — PostgreSQL 18 | Development, test, production | CON-031 |
| Identity server | Execution environment — Keycloak | Production (Infrastructure-operated) | CON-001, CON-032 |
| Domain controllers | Execution environment — Active Directory | Production (Infrastructure-operated) | CON-003 |
| Hosted SCM provider | Execution environment — hosted CI | Development toolchain | CON-033 |

### Connectors

| Connector | From | To | Protocol | Properties | Declared by |
|---|---|---|---|---|---|
| Page and API traffic | Corporate browser | Application server | HTTPS | Intra-network only; no interface crosses the corporate boundary | CON-008, CON-009 |
| Data access | Application server | Database server | TCP | Transactional; the audit write shares the caller's transaction | CON-031, NFR-004 |
| Authentication | Application server | Identity server | OIDC redirect + token | Intra-network; login works with no internet link | CON-001, CON-032 |
| Directory read | Application server | Domain controllers | LDAP | Read only; no write reaches AD | CON-003, CON-004 |
| Build and test | Hosted CI | Application server | Artifact only | CI never deploys; Infrastructure deploys | CON-033 |

### Deployment artifacts

| Artifact | Node | Contents | Declared by |
|---|---|---|---|
| `Portal.Web` | Application server | The .NET 10 application: Razor Pages, the REST endpoints, the domain components, the identity and audit mechanisms, the data access layer. One deployable (ADR-001). | CON-029, CON-030 |
| Configuration | Application server | Placeholder OIDC and LDAP values — issuer, client id, client secret, LDAP host, bind account, base DN. Held in configuration, never in code. Infrastructure substitutes the real values at deployment. | CON-035 |
| Database schema | Database server | The four tables plus the audit table. No employee table exists. | CON-003, CON-022, CON-031 |

**No migration artifact.** CON-036 declares there is no data migration: the portal starts empty and records clockings from go-live onwards. The historical Excel sheets stay on the shared drive as a read-only archive and are not imported. No import path and no migration script is deployed.

**No backup artifact.** CON-038 declares Infrastructure's existing server-backup practice already covers this PostgreSQL instance in restorable form, confirmed in writing with a verified restore test. No backup tooling and no restore procedure is part of this project.

## Environment Mapping

Three environments are declared. Development and test run against stand-ins the team controls; production runs against the real Keycloak and the real Active Directory, whose values Infrastructure substitutes at deployment.

```plantuml
@startuml Portal_DeploymentModel_Environments
title Deployment Model — environment mapping and the stand-in to real substitution
skinparam shadowing false
skinparam componentStyle rectangle

package "Development environment" {
  component "Portal.Web\n.NET 10" as DEVAPP
  component "Stand-in OIDC issuer\nplaceholder issuer, client id, secret\nCON-035" as DEVIDP
  component "Stand-in directory\ncarries the declared attributes,\nincluding empty job title and extension\nCON-035, R001" as DEVDIR
  database "PostgreSQL 18\nlocal instance" as DEVDB
  DEVAPP --> DEVIDP
  DEVAPP --> DEVDIR
  DEVAPP --> DEVDB
}

package "Test environment" {
  component "Portal.Web\n.NET 10" as TSTAPP
  component "Stand-in OIDC issuer" as TSTIDP
  component "Stand-in directory" as TSTDIR
  database "PostgreSQL 18" as TSTDB
  TSTAPP --> TSTIDP
  TSTAPP --> TSTDIR
  TSTAPP --> TSTDB
}

package "Production environment — Infrastructure operates" {
  component "Portal.Web\n.NET 10" as PRDAPP
  component "Keycloak\nreal, intra-network\nCON-032" as PRDIDP
  component "Active Directory\nreal, LDAP read only\nCON-003" as PRDDIR
  database "PostgreSQL 18\nCON-031" as PRDDB
  PRDAPP --> PRDIDP
  PRDAPP --> PRDDIR
  PRDAPP --> PRDDB
}

DEVIDP ..> PRDIDP : real values substituted\nat deployment (CON-035)
DEVDIR ..> PRDDIR : real values substituted\nat deployment (CON-035)

note bottom
  CON-035: the OIDC client and the LDAP connection are configured with
  placeholder values held in configuration, never in code. Infrastructure
  puts the real values in at deployment. The team builds and tests against
  stand-ins it controls. Validation against the real Keycloak and the real
  AD is done by people (Infrastructure with HR) and is the one human gate.
end note
@enduml
```

| Environment | Identity provider | Directory | Database | Who operates it |
|---|---|---|---|---|
| Development | Stand-in OIDC issuer with placeholder values | Stand-in directory carrying the declared attributes, including entries with empty job title and extension | Local PostgreSQL 18 | The team |
| Test | Stand-in OIDC issuer | Stand-in directory | PostgreSQL 18 | The team |
| Production | The real Keycloak, intra-network (CON-032) | The real Active Directory, read over LDAP (CON-003) | PostgreSQL 18 on the estate (CON-031) | Infrastructure |

### The stand-in to real substitution

| Configuration value | Development and test | Production | Substituted by |
|---|---|---|---|
| OIDC issuer | Placeholder | The real Keycloak issuer | Infrastructure at deployment (CON-035) |
| OIDC client id | Placeholder | The registered client id (CON-002) | Infrastructure at deployment |
| OIDC client secret | Placeholder | The real secret | Infrastructure at deployment |
| LDAP host | Placeholder | The real domain controller | Infrastructure at deployment |
| LDAP bind account | Placeholder | The real bind account | Infrastructure at deployment |
| LDAP base DN | Placeholder | The real base DN | Infrastructure at deployment |

**No credential is committed.** Every value above is a configuration entry with a placeholder in the repository (CON-035). This is what makes the stand-in strategy possible and is the project's answer to R001 and R005: the empty-attribute case and the claim shape are exercised in test, not discovered in production.

### The one human gate

Validation against the real Keycloak and the real Active Directory is performed by people — Infrastructure with HR — and its feedback must reach the team before Elaboration closes (CON-035). It is not team work to plan and it is not a deployment step this project performs. The Development Case bounds it in the Risk List with a ceiling of 14 days, after which the process suspends and nothing is auto-filled. CON-028 grants the remedy in advance: if that validation delays a milestone, the remedy is another iteration, never a cut to declared scope.

### Environment-specific behaviour

| Behaviour | Development and test | Production |
|---|---|---|
| Authentication | Against the stand-in issuer | Against the real Keycloak (CON-001) |
| Directory read | Against the stand-in directory | Against the real AD (CON-003) |
| No-connection message (NFR-006) | Exercised by making the stand-in source unreachable | Shown when the corporate network is unavailable |
| Clocking retry (FR-016) | Exercised by blocking the POST on demand | The real corporate network |
| Availability and performance (NFR-001, NFR-002, NFR-003) | Not measurable on the target estate | Measured on the estate Infrastructure operates |

**R008 is recorded here as a deployment fact.** The declared performance and availability budgets are stated against the corporate network and the existing Windows Server estate. The team cannot measure them on the target estate; Infrastructure operates it. The budgets are therefore treated as design constraints, not as measurements, and the Software Architecture Document records the tactics that serve them.
