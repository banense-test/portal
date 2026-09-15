## Document Control

| Field | Value |
|---|---|
| Phase | Elaboration |
| Status | Draft |
| Milestone Target | End-of-Elaboration (Lifecycle Architecture) — NOT YET ACHIEVED |

## Architectural Representation

This document presents the **architectural baseline** for the Employee Portal, produced during Elaboration iteration 1. It supersedes the Inception candidate sketch: all five 4+1 views are now present, the design mechanisms are derived from the analysis mechanisms, and the subsystem interfaces are specified. The baseline is validated against the architecturally significant use cases (UC-001, UC-008, UC-003) via sequence diagrams in the Use-Case view.

The architecture is represented using the 4+1 view model:

| View | Section | Primary diagram |
|---|---|---|
| Use-Case | Use-Case View | Sequence diagrams (UC-001, UC-008, UC-003) |
| Logical | Logical View | Component diagram (subsystems + interfaces) |
| Process | Process View | Activity diagram (concurrency + invariant enforcement) |
| Deployment | Deployment View | Deployment diagram (single-node topology) |
| Implementation | Implementation View | Package diagram (solution/project layout) |

## Architectural Goals and Constraints

**Goals** (trace to Business Goals BG-001…BG-003):
- Centralize clocking, news, and directory in one internal web app with no data duplication (CON-007).
- Deliver audited clocking corrections/insertions, news publication, and category management (NFR-004).
- Meet page-load < 3s (NFR-001) and clocking < 1s (NFR-002) on the corporate network.

**Constraints** (the architecture must honor every one — CON-001…CON-021). The load-bearing architectural constraints are:

| Constraint | Architectural consequence |
|---|---|
| CON-001 | Backend is .NET 10 REST API — single framework, no polyglot |
| CON-002 | Razor Pages, no SPA, no client-side router; page-level JS allowed (clocking retry) |
| CON-003 | PostgreSQL persistence |
| CON-004 | Internal Windows Server hosting (IIS) — no cloud |
| CON-006 | Keycloak is an OIDC client dependency only — never designed/provisioned here |
| CON-007 | AD read on demand, never copied; portal stores only `AD user id → worker category` |
| CON-008 | Custom design (docs/inputs/employee-portal-design.html) authoritative for UI |
| CON-009 | No access from outside the corporate network |
| CON-014 | Single timezone; clockings UTC storage, Europe/Madrid display |
| CON-015 | At most one featured news item (invariant) |
| CON-016 | Worker categories: closed list of exactly four values |
| CON-019 | Original clocking never overwritten/deleted; corrections audited |
| CON-020 | News never hard-deleted; unpublish hides |
| CON-021 | Server accepts client timestamp; idempotency key rejects duplicates (clocking only) |

**Technology stack** (only what the stakeholder declared — nothing invented):

| Concern | Choice | Source |
|---|---|---|
| Backend framework | .NET 10 | CON-001 (version policy pin: .NET 10) |
| Frontend | Razor Pages | CON-002 |
| Database | PostgreSQL | CON-003 (no version declared — not pinned) |
| Identity | Keycloak OIDC (external, consumed) | CON-006 |
| Directory source | Active Directory (external, read-only) | CON-007, CON-010 |

No other technology is declared. The PostgreSQL driver version is not pinned by policy and is not invented here; it is resolved at implementation time against the enterprise version policy.

**Key decisions and trade-offs (ADRs):**

**ADR-001 — Layered architecture (Presentation / Application / Domain / Infrastructure).** *Context:* internal web app, 200 users, three functional areas, Razor Pages + .NET 10 REST API + PostgreSQL. *Decision:* four-layer architecture with domain subsystems decomposed by area of change (Clocking, News, Directory, Worker Category). *Alternatives:* microservices (rejected — 200 users, single node, no independent scaling); feature-based modular monolith (rejected — feature decomposition maximizes change ripple; the two volatile areas are UC-001 and UC-008). *Consequences:* Designer refines subsystems into classes; Implementer builds within these boundaries.

**ADR-002 — AD on-demand projection (no copy, no sync).** *Context:* CON-007 mandates employee data read from AD on demand, never copied; portal stores only `AD user id → worker category`. *Decision:* Directory subsystem reads six AD fields at read time and joins with the portal-owned category mapping; no sync job. *Alternatives:* local employee cache (rejected — violates CON-007, introduces reconciliation); nightly sync (rejected — same). *Consequences:* R001 retired via analysis-only PoC (see §Use-Case View); gap-tolerant rendering confirmed.

**ADR-003 — Persistence mechanism (PostgreSQL, immutable records).** *Context:* CON-003 declares PostgreSQL; CON-019/CON-020 require immutable clocking and news records; CON-015 requires a single-featured invariant. *Decision:* PostgreSQL as the single store; clocking and news records append-only (corrections/insertions and unpublish are separate audited records, never in-place overwrites); featured invariant enforced transactionally. *Alternatives:* in-place update with audit columns (rejected — CON-019/CON-020 forbid overwrite/delete); document store (rejected — CON-003 declares PostgreSQL). *Consequences:* Database Designer models the immutable-record schema.

**ADR-004 — Interface-based subsystem boundaries.** *Context:* subsystems must have low coupling and be replaceable (heuristic 5). *Decision:* every domain subsystem exposes an interface (`IClockingService`, `INewsService`, `IDirectoryService`, `IWorkerCategoryService`); the Application layer depends only on these interfaces, never on concrete classes. The AD read path is behind `IEmployeeDirectorySource` so the LDAP client is swappable without touching the Directory domain. *Alternatives:* direct class-to-class dependencies (rejected — high coupling, untestable). *Consequences:* Designer realizes interfaces into classes; Implementer wires via dependency injection.

## Use-Case View

The architecturally significant use cases are **UC-001 (Clock In/Out)**, **UC-008 (Search Directory)**, and **UC-003 (Publish News)** — all fully specified in the Use-Case Model. They are prioritized first because they force the highest-risk decisions:

- **UC-001** forces client-timestamp acceptance + idempotency (CON-021) and the offline-retry window (AC-005), and is the adoption-critical screen (R002, BG-003).
- **UC-008** forces the AD on-demand projection boundary (CON-007) and surfaces R001 (attribute gaps across offices).
- **UC-003** establishes the audit mechanism (NFR-004) reused by all HR UCs, and the single-featured invariant (CON-015).

**Prioritized use-case list for the Project Manager** (architectural significance = risk + coverage + criticality):

| Rank | UC | Rationale |
|---|---|---|
| 1 | UC-001 Clock In/Out | Highest risk (CON-021, AC-005, R002); first screen employees see |
| 2 | UC-008 Search Directory | Surfaces R001 (AD attribute consistency); validates CON-007 boundary |
| 3 | UC-003 Publish News | Establishes the audit mechanism (NFR-004) reused by all HR UCs |
| 4 | UC-011 Correct Clocking | Validates the immutable-record + audit pattern (CON-019) |
| 5 | UC-005 Feature News | Validates the single-featured invariant (CON-015) |
| 6 | UC-002 Export CSV | Validates timezone + column-order rules (CON-014, FR-002) |
| 7 | UC-004 Read & Filter News | Read path; validates featured banner + category filter |
| 8 | UC-006 Edit News | Reuses audit mechanism |
| 9 | UC-007 Unpublish News | Reuses audit mechanism; validates soft-hide (CON-020) |
| 10 | UC-009 Assign Worker Category | Closed-list category (CON-016) + audit |
| 11 | UC-010 Clear Worker Category | Empty-category rule (CON-018) + audit |
| 12 | UC-012 Insert Clocking | Reuses immutable-record + audit pattern |

**R001 retirement (analysis-only PoC):** R001 (AD attribute consistency across offices) is retired by reasoning, not by running code — the disposition is recorded via `record_poc_decision` (mode `analysis-only`). The acceptance criteria: a per-office attribute-population map confirmed with STK-003, plus a gap-tolerant rendering path (UC-008 A2 renders blank fields gracefully). The architectural consequence is already designed in: the Directory subsystem treats every AD field as nullable and renders blanks without failing the entry. No throwaway prototype branch exists; the gap-tolerant path is production code in the Directory subsystem.

**Sequence diagrams (Use-Case view validation):**

**UC-001 — Clock In/Out** (validates CON-021 client-timestamp + idempotency, CON-019 append-only):

```plantuml
@startuml
actor "Employee" as EMP
participant "Razor Page\n(ClockInOut)" as UI
participant "ClockingController\n(REST API)" as API
participant "ClockingService" as SVC
participant "ClockingRepository" as REPO
database "PostgreSQL" as DB
participant "Keycloak" as KC

EMP -> UI : press Clock In/Out
UI -> UI : record press timestamp (Europe/Madrid)\n+ generate idempotency key (CON-021)
UI -> API : POST /clocking {timestamp, idempotencyKey}
API -> KC : validate OIDC token (CON-006)
KC --> API : token valid + claims
API -> SVC : clockInOut(employeeId, timestamp, key)
SVC -> REPO : findByKey(key)
REPO -> DB : SELECT ... WHERE idempotency_key = key
DB --> REPO : (none)
SVC -> REPO : insert(clocking)
REPO -> DB : INSERT clocking (UTC, CON-014)
DB --> REPO : ok
SVC --> API : result
API --> UI : 200 confirmation
UI --> EMP : show confirmation + refresh history

note over SVC, DB
  CON-021: server accepts client timestamp;
  idempotency key rejects duplicates.
  CON-019: clocking append-only, never overwritten.
end note
@enduml
```

**UC-008 — Search Directory** (validates CON-007 AD on-demand projection, R001 gap tolerance):

```plantuml
@startuml
actor "Employee" as EMP
participant "Directory Page" as UI
participant "DirectoryController" as API
participant "DirectoryService" as SVC
participant "AD Client (LDAP)" as AD
participant "CategoryRepository" as CAT
database "PostgreSQL" as DB

EMP -> UI : enter search term (name/department/office)
UI -> API : GET /directory?q=term
API -> SVC : search(term)
SVC -> AD : read 6 fields on demand (CON-007)
AD --> SVC : name, title, dept, office, email, extension
SVC -> CAT : getCategories(adUserIds)
CAT -> DB : SELECT category WHERE ad_user_id IN (...)
DB --> CAT : category mappings
CAT --> SVC : categories
SVC --> API : entries (6 AD fields + category)
API --> UI : 200 list
UI --> EMP : render entries (blank field if AD gap, R001)

note over SVC, AD
  CON-007: AD read on demand, never copied.
  Portal stores only "AD user id -> category".
  R001: attribute gaps render blank (UC-008 A2).
end note
@enduml
```

**UC-003 — Publish News** (validates CON-015 single-featured invariant + NFR-004 audit):

```plantuml
@startuml
actor "HR Administrator" as HR
participant "News Page" as UI
participant "NewsController" as API
participant "NewsService" as SVC
participant "NewsRepository" as REPO
participant "AuditService" as AUD
database "PostgreSQL" as DB

HR -> UI : enter title/body/date/category (+ featured)
UI -> API : POST /news
API -> SVC : publish(item, author)
SVC -> REPO : beginTransaction()
SVC -> REPO : unfeaturePrevious() [if featured, CON-015]
REPO -> DB : UPDATE news SET featured=false
SVC -> REPO : insert(item)
REPO -> DB : INSERT news (author + timestamp)
SVC -> AUD : record(author, timestamp)
AUD -> DB : INSERT audit record (NFR-004)
SVC -> REPO : commit()
SVC --> API : result
API --> UI : 201 confirmation
UI --> HR : show confirmation

note over SVC, DB
  CON-015: single-featured invariant enforced
  transactionally (unfeature previous + insert new).
  CON-020: news never hard-deleted.
  NFR-004: audit author + timestamp.
end note
@enduml
```

## Logical View

The baseline decomposition is a **layered architecture** with four layers. Within the Domain layer, subsystems are decomposed by **area of change**, not by feature: each subsystem encapsulates one decision likely to change (per the Use-Case Model's "Volatility: Medium" annotations — UC-001 clocking interaction and UC-008 directory field availability are the two most volatile UCs; no High-volatility UC exists). Every subsystem boundary is defined by an interface (ADR-004).

```plantuml
@startuml
skinparam componentStyle rectangle
skinparam packageStyle rectangle

package "Presentation Layer" {
  component "Razor Pages UI" as UI <<presentation>>
  component "Page-level JS\n(clocking retry)" as JS <<presentation>>
}

package "Application Layer" {
  component "REST API Controllers" as API <<application>>
}

package "Domain Layer" {
  component "Clocking" as CLK <<domain>>
  component "News" as NWS <<domain>>
  component "Directory" as DIR <<domain>>
  component "Worker Category" as CAT <<domain>>
}

package "Infrastructure Layer" {
  component "PostgreSQL Persistence" as DB <<infrastructure>>
  component "AD Client (LDAP read)" as AD <<infrastructure>>
  component "Keycloak OIDC Client" as KC <<infrastructure>>
  component "Audit Log" as AUD <<mechanism>>
}

interface "IClockingService" as ICLK
interface "INewsService" as INWS
interface "IDirectoryService" as IDIR
interface "IWorkerCategoryService" as ICAT
interface "IAuditService" as IAUD
interface "IEmployeeDirectorySource" as IAD

actor "Employee / HR" as USER

USER --> UI : HTTPS
UI --> JS : clocking press
JS --> API : POST /clocking (timestamp + idempotency key)
UI --> API : HTTP

API --> ICLK
API --> INWS
API --> IDIR
API --> ICAT

ICLK .. CLK : realizes
INWS .. NWS : realizes
IDIR .. DIR : realizes
ICAT .. CAT : realizes

CLK --> DB : persist clocking
NWS --> DB : persist news
CAT --> DB : persist category mapping
DIR --> IAD : read 6 fields on demand
IAD .. AD : realizes
DIR --> CAT : category lookup
API --> KC : validate OIDC token
API --> AD : group membership (authorization)
CLK --> IAUD : audit correction/insertion
NWS --> IAUD : audit publish/edit/unpublish
CAT --> IAUD : audit assign/clear
IAUD .. AUD : realizes
AUD --> DB : append-only audit records

note right of DIR
  CON-007: AD read on demand, never copied.
  Portal stores only "AD user id -> category".
  R001: attribute gaps render blank (UC-008 A2).
end note

note right of KC
  CON-006: Keycloak is an OIDC client
  dependency only - not part of this project.
end note

note right of AUD
  NFR-004: cross-cutting audit mechanism
  (who, when, previous value, reason).
end note
@enduml
```

**Subsystem rationale** (each encapsulates one area of change):

| Subsystem | ID | Encapsulates | Volatility source |
|---|---|---|---|
| Clocking | COMP-001 | Client-timestamp + idempotency (CON-021), offline-retry window (AC-005), immutable-record audit (CON-019) | UC-001 (Medium) |
| Directory | COMP-002 | AD on-demand projection boundary (CON-007), six-field read, attribute-gap handling | UC-008 (Medium), R001 |
| News | COMP-003 | Publication/edit/unpublish/feature lifecycle, single-featured invariant (CON-015), soft-hide (CON-020) | Stable (Low) |
| Worker Category | COMP-004 | Closed-list of four values (CON-016), at-most-one + empty rule (CON-018) | Stable (Low) |
| Audit | COMP-005 | Append-only audit records (who/when/previous/reason) | NFR-004 (cross-cutting) |
| AD Client | COMP-006 | LDAP read of six fields + group membership | CON-007, CON-010 |
| Keycloak OIDC Client | COMP-007 | OIDC token validation, login redirect | CON-006 |
| PostgreSQL Persistence | COMP-008 | Relational store, transactional invariant enforcement | CON-003, CON-019, CON-020 |

**Analysis mechanisms → design mechanisms** (abstract capability → concrete solution):

| Analysis mechanism | Capability | Design mechanism (concrete) | Properties it must hold |
|---|---|---|---|
| Persistence | Store clockings, news, category mapping, audit records | PostgreSQL relational store; append-only tables for clocking/news; transactional invariant enforcement | ACID; immutable clocking/news records (CON-019, CON-020); single-featured invariant enforceable (CON-015) |
| Authentication | Validate OIDC token, redirect for login | Keycloak OIDC client (OpenID Connect middleware in .NET 10) | Delegated to Keycloak; portal is client only (CON-006) |
| Authorization | Two-level access from AD group membership | AD group claim → policy-based authorization (HR group vs. everyone else) | No role matrix, no permission screen (NFR-005) |
| Directory projection | Read six AD fields on demand | LDAP read via `IEmployeeDirectorySource`; nullable field handling | Never copied; read-only; gap-tolerant (blank render) (CON-007, R001) |
| Audit | Record who/when/previous-value/reason | Append-only audit tables + `IAuditService` | Append-only; covers news, category, clocking corrections/insertions (NFR-004) |
| Idempotency | Reject duplicate clocking presses | Unique constraint on idempotency key (clocking table) | Key-based; clocking only (CON-021) |
| Offline retry | Hold clocking press in localStorage, retry ≤ 5 min | Page-level JS retry loop + localStorage persistence | Clocking only; directory/news show "no connection" (AC-005) |

## Process View

The system is **request/response only** — no scheduled jobs, no background sync (CON-007, CON-013). Concurrency concerns are limited to invariant enforcement at the persistence boundary and the client/server reconciliation of the offline-retry path.

```plantuml
@startuml
start
:Request arrives (HTTP);
:Keycloak OIDC token validated (CON-006);
:AD group membership resolved (NFR-005);
if (HR-only action?) then (yes)
  :Authorize HR group;
else (no)
  :Authorize employee;
endif
:Route to domain service;
if (Clocking press?) then (yes)
  :Idempotency key check (CON-021);
  if (Duplicate?) then (yes)
    :Return existing result;
    stop
  else (no)
    :Insert clocking (UTC, CON-014);
  endif
else if (Feature/unpublish news?) then (yes)
  :Transactional invariant enforcement\n(single-featured, CON-015);
else if (Correct/insert clocking?) then (yes)
  :Append-only audit record\n(never overwrite, CON-019);
else (default)
  :Standard read/write;
endif
:Commit transaction;
:Return response;
stop

note right
  Concurrency model: request/response only.
  No scheduled jobs, no background sync (CON-007, CON-013).
  Invariants (CON-015, CON-019, CON-020) enforced
  transactionally at the persistence boundary.
  Offline retry (AC-005) is client-side; server-side
  idempotency (CON-021) reconciles retries.
end note
@enduml
```

**Concurrency-relevant facts:**

- The single-featured invariant (CON-015) and the immutable-record rules (CON-019, CON-020) require **transactional enforcement** at the persistence boundary — concurrent feature/unpublish or correct/insert operations must not violate invariants. The News subsystem wraps feature + insert in a single transaction (see UC-003 sequence diagram).
- The offline-retry path (AC-005) introduces a client-side retry loop that is reconciled with server-side idempotency (CON-021): a retried POST carries the same idempotency key, so the server returns the existing result rather than creating a duplicate.
- No threads, no background workers, no message queues — the 200-user, single-node scale (NFR-003 availability window) does not justify them.

## Deployment View

```plantuml
@startuml
skinparam nodeStyle rectangle

node "Corporate Network (CON-009)" as CORP {
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

note right of EXT
  CON-006: Keycloak already running, maintained
  separately - portal is a client only.
  CON-010: AD operated by Infrastructure;
  project neither administers nor writes to it.
end note

note right of PG
  CON-013: backups covered by Infrastructure's
  existing server-backup practice (verified restore).
  No backup design in this project.
end note

note bottom of CORP
  CON-009: no access from outside the corporate network.
  NFR-003: availability Mon-Fri 7:00-19:00.
end note
@enduml
```

**Topology summary:** single-node deployment — one Windows Server hosting IIS + the .NET 10 app, with PostgreSQL on the same node (or a co-located DB node). Keycloak and AD are external, operated by Infrastructure (CON-006, CON-010). No cloud, no multi-node topology, no load balancing (200 users, NFR-003 availability window). The Deployment Model optional artifact is **not triggered** (single-node, single-environment) — deployment detail lives here in the SAD.

## Implementation View

The build structure is a single .NET 10 solution with four projects, layered per the Logical view. The Domain layer depends on nothing (innermost); the Infrastructure layer depends on the Domain; the Application layer depends on both; the Presentation layer depends on the Application.

```plantuml
@startuml
skinparam packageStyle rectangle

package "Portal.Web" <<Presentation>> {
  component "Razor Pages" as RP
  component "Page-level JS" as JS
}

package "Portal.Application" <<Application>> {
  component "REST API Controllers" as API
  component "Application Services" as AS
}

package "Portal.Domain" <<Domain>> {
  package "Clocking" as CLK
  package "News" as NWS
  package "Directory" as DIR
  package "WorkerCategory" as CAT
}

package "Portal.Infrastructure" <<Infrastructure>> {
  package "Persistence" as PER
  package "AdClient" as ADC
  package "KeycloakClient" as KCC
  package "Audit" as AUD
}

Portal.Web ..> Portal.Application
Portal.Application ..> Portal.Domain
Portal.Application ..> Portal.Infrastructure
Portal.Infrastructure ..> Portal.Domain

note bottom of Portal.Domain
  Domain depends on nothing (innermost layer).
  Subsystems decomposed by area of change.
end note
@enduml
```

**Project layout:**

| Project | Layer | Contents |
|---|---|---|
| Portal.Web | Presentation | Razor Pages, page-level JS (clocking retry localStorage) |
| Portal.Application | Application | REST API controllers, DTOs, application services |
| Portal.Domain | Domain | Clocking, News, Directory, WorkerCategory subsystems + interfaces |
| Portal.Infrastructure | Infrastructure | Persistence (PostgreSQL), AdClient (LDAP), KeycloakClient (OIDC), Audit |

Dependency direction is strictly inward: Web → Application → Domain; Infrastructure → Domain. The Domain layer has no outward dependencies, so the subsystems are unit-testable in isolation and the AD/Keycloak/PostgreSQL adapters are swappable behind their interfaces (ADR-004).

## Data View

The portal's own data is minimal by design (CON-007 — no employee copy). Persistent entities:

| Entity | Purpose | Notes |
|---|---|---|
| Clocking | Employee clock in/out records | Immutable (CON-019); client timestamp + idempotency key (CON-021); UTC storage (CON-014) |
| Clocking correction/insertion audit | Audit trail for HR corrections/insertions | who, when, previous value, reason (NFR-004) |
| News | News items | Never hard-deleted (CON-020); featured flag (CON-015 invariant) |
| News audit | Audit trail for publish/edit/unpublish | author + timestamp (NFR-004) |
| Worker category mapping | `AD user id → worker category` | The ONLY portal-owned employee field (CON-007); closed list of four (CON-016); at most one, may be empty (CON-018) |
| Category audit | Audit trail for assign/clear | who, when (NFR-004) |

Employee identity and the six directory fields are **projected from AD at read time** and never stored (CON-007). The Data Model optional artifact is **not triggered** (≤ 10 entities, no migration — CON-012); data detail lives in the Design Model.

## Size and Performance

- **Scale:** 200 employees, 3 offices, single timezone (CON-014). No horizontal scaling required.
- **Performance targets:** page load < 3s (NFR-001); clocking < 1s (NFR-002) on the corporate network.
- **Architectural tactics to meet NFR-001/NFR-002:** AD projection is on-demand and read-only (no sync latency); clocking is a single-row insert with idempotency-key lookup; news/directory reads are simple indexed queries. The AD read path (UC-008) is the main latency risk and is validated against R001 (gap-tolerant rendering, not latency-bound).

## Quality

| Quality attribute | Requirement | Architectural response |
|---|---|---|
| Performance | NFR-001, NFR-002 | Single-node, indexed reads, on-demand AD projection |
| Availability | NFR-003 (Mon–Fri 7:00–19:00) | Single-node; no 24/7 requirement; fault tolerance within corporate network |
| Auditability | NFR-004 | Append-only audit mechanism; immutable clocking/news records |
| Security | NFR-005, CON-009 | Two-level AD-group authorization; internal-network-only |
| Maintainability | CON-011 | Layered architecture; interface-based boundaries; clean handover to Infrastructure at end of Transition |

## Traceability

| Element | Traces From | Link Type | Traces To |
|---|---|---|---|
| COMP-001 Clocking | UC-001, CON-021, AC-005 | Derives | Design Model (Elaboration) |
| COMP-002 Directory | UC-008, CON-007, R001 | Derives | Design Model (Elaboration) |
| COMP-003 News | UC-003…UC-007, CON-015, CON-020 | Derives | Design Model (Elaboration) |
| COMP-004 Worker Category | UC-009, UC-010, CON-016, CON-018 | Derives | Design Model (Elaboration) |
| COMP-005 Audit | NFR-004 | Derives | Design Model (Elaboration) |
| COMP-006 AD Client | CON-007, CON-010 | Derives | Design Model (Elaboration) |
| COMP-007 Keycloak OIDC Client | CON-006 | Derives | Design Model (Elaboration) |
| COMP-008 PostgreSQL Persistence | CON-003, CON-019, CON-020 | Derives | Design Model (Elaboration) |
| ADR-001…ADR-004 | CON-001…CON-021 | Derives | (baseline) |
| R001 | CON-007, FR-008, UC-008 | DependsOn | analysis-only PoC (retired) |
| R002 | BG-003, AC-004, FR-001 | DependsOn | Transition plan |
