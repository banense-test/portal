## Document Control
| Field | Value |
|---|---|
| Phase | Elaboration |
| Status | Draft |
| Milestone Target | End-of-Elaboration (Lifecycle Architecture) — NOT YET ACHIEVED |

## Functionality
| ID | Requirement | Testable Threshold | Source |
|---|---|---|---|
| NFR-004 | Audit traceability: who publishes/edits/unpublishes each news item (author + timestamp); any worker-category change; every clocking HR corrects or inserts (who, when, previous value, reason). Employee fields are read-only from AD — nothing to audit there. | Every audited action persists an immutable audit record with the declared fields: news (author + timestamp), category change (author + timestamp), clocking correction (who, when, previous value, reason), clocking insertion (who, when, reason). The original record is never overwritten or deleted (CON-019, CON-020). | NFR-004 |
| NFR-005 | Two-level authorization from AD group membership: HR group → publish/edit/unpublish news + manage categories; everyone else → employee (read directory/news + own clockings). No role matrix, no permission screen, no per-category rule. | A non-HR-group user attempting any HR-only action (UC-002, UC-003, UC-005, UC-006, UC-007, UC-009, UC-010, UC-011, UC-012) is denied; an HR-group user can perform them. Authorization derives solely from AD group membership — no portal-side role store. | NFR-005 |
| — | Authentication via Keycloak OIDC (portal is a client only; register client, redirect, validate token, read roles from claims). | Every request is authenticated via a validated Keycloak OIDC token; unauthenticated requests redirect to Keycloak login. | CON-006 |
| — | Employee data read from AD on demand, never copied; portal stores only `AD user id → worker category`. | The portal database contains no employee field other than the `AD user id → worker category` mapping; all six directory fields are projected from AD at read time. | CON-007 |
| — | No access from outside the corporate network (internal-only application). | Requests originating outside the corporate network are not served. | CON-009 |
## Usability
| ID | Requirement | Testable Threshold | Source |
|---|---|---|---|
| — | Custom design at docs/inputs/employee-portal-design.html is mandatory and authoritative for the UI visual layer. | The implemented UI matches the custom design's visual layer (not only structure). | CON-008 |
| — | Responsive web only; compatible with current Chrome and Edge (corporate browsers). | All pages render and function correctly in current Chrome and Edge. | CON-005 |
| — | Employee can find a colleague's phone/email in under 10 seconds. | From the directory screen, a colleague's phone/email is reachable within 10 seconds of initiating a search (AC-003). | AC-003 |
## Reliability
| ID | Requirement | Testable Threshold | Source |
|---|---|---|---|
| NFR-003 | Availability window: extended working hours Mon–Fri 7:00–19:00, with fault tolerance within the corporate network. 24/7 not required. | System available and responsive Mon–Fri 07:00–19:00 Europe/Madrid; outside this window no availability commitment. | NFR-003 |
| — | Clocking made while the network is down up to 5 minutes is not lost: clocking page keeps the press in localStorage and retries its POST up to 5 minutes; beyond 5 minutes the employee reports to HR. Applies to clocking only — directory and news show a "no connection" message. | A clocking press during a network outage ≤ 5 min is persisted (retried) with the original press timestamp; > 5 min the employee reports to HR (UC-011/UC-012). Directory and news render a "no connection" message, not a stale/partial result. | AC-005 |
| — | Backups covered by Infrastructure's existing server-backup practice (verified restore test). No backup design/tooling in this project. | Out of scope for this project (CON-013); verified by Infrastructure's restore test, not by this project's acceptance. | CON-013 |

**Implied reliability requirement (what stakeholders would reject even if functional requirements are met):** a clocking press must never be silently lost — the offline-retry window (AC-005) plus the idempotency key (CON-021) together guarantee at-most-once persistence with no silent drop. This is the reliability floor behind AC-001 and AC-004.
## Performance
| ID | Requirement | Testable Threshold | Source |
|---|---|---|---|
| NFR-001 | Pages load in under 3 seconds on the corporate network. | Time-to-interactive ≤ 3.0 s for every page, measured on the corporate network with current Chrome/Edge (CON-005). | NFR-001 |
| NFR-002 | Clock in/out operation responds in under 1 second. | Server round-trip for the clocking POST ≤ 1.0 s from press to confirmation, measured on the corporate network. | NFR-002 |

**Measurement basis:** thresholds are the declared values (NFR-001, NFR-002); the measurement conditions (corporate network, current Chrome/Edge) are the declared constraints (CON-005, CON-009). No percentile or load profile is declared — the thresholds are absolute ceilings, not statistical targets. `[ASSUMPTION — requires validation]` basis: "normal load" is not quantified in the declared scope; the 200-employee / 3-office population (Vision) is the implicit load context.
## Supportability

| ID | Requirement | Source |
|---|---|---|
| — | Post-launch: Infrastructure team operates the portal in production (deployment, monitoring, patching); dev team hands over at end of Transition. | CON-011 |
| — | No data migration; portal starts empty; historical Excel stays read-only archive (not imported). | CON-012 |

## Design Constraints

| ID | Constraint | Source |
|---|---|---|
| CON-001 | Backend: .NET 10, REST API | CON-001 |
| CON-002 | Frontend: Razor Pages (no SPA, no client-side router; page-level scripts allowed) | CON-002 |
| CON-003 | Database: PostgreSQL | CON-003 |
| CON-004 | Hosting: internal Windows Server (no cloud) | CON-004 |
| CON-006 | Keycloak is an OIDC client dependency only — not part of this project | CON-006 |
| CON-007 | Employee data read from AD on demand, never copied | CON-007 |
| CON-008 | Custom design (docs/inputs/employee-portal-design.html) mandatory and authoritative | CON-008 |
| CON-009 | No access from outside the corporate network | CON-009 |
| CON-014 | Single timezone (Europe/Madrid); clockings stored UTC, displayed Europe/Madrid | CON-014 |
| CON-015 | At most one featured news item (invariant) | CON-015 |
| CON-016 | Worker categories: closed list of exactly four values (Full-time, Part-time, Contractor, Intern) | CON-016 |
| CON-017 | Worker category descriptive only — does not drive access control | CON-017 |
| CON-018 | At most one category per worker; may be empty; no default | CON-018 |
| CON-019 | Original clocking never overwritten/deleted; corrections audited | CON-019 |
| CON-020 | News never hard-deleted; unpublish hides | CON-020 |
| CON-021 | Server accepts client timestamp; idempotency key rejects duplicates (clocking only) | CON-021 |

## Interfaces

| ID | Interface | Source |
|---|---|---|
| — | Keycloak OIDC: register client, redirect for login, validate token, read roles from claims. | CON-006 |
| — | Active Directory: read six employee fields (name, job title, department, office, email, extension) + group membership on demand; never write. | CON-007, CON-010, FR-008 |
| — | CSV export: monthly clocking report, exact column order (EmployeeId, FullName, WorkerCategory, Date, ClockIn, ClockOut, HoursWorked, Corrected), Europe/Madrid timestamps. | FR-002 |

## Applicable Standards

| ID | Standard | Source |
|---|---|---|
| — | No external regulatory/legal standards declared for this internal intranet. | — |

## Traceability
| Element | Traces From | Link Type | Traces To |
|---|---|---|---|
| NFR-001 | Declared input | — | Performance (quantified: ≤ 3.0 s TTI) |
| NFR-002 | Declared input | — | Performance (quantified: ≤ 1.0 s clocking round-trip) |
| NFR-003 | Declared input | — | Reliability (quantified: Mon–Fri 07:00–19:00 Europe/Madrid) |
| NFR-004 | Declared input | — | UC-003, UC-005, UC-006, UC-007, UC-009, UC-010, UC-011, UC-012 |
| NFR-005 | Declared input | — | All UCs |
| AC-003 | Declared input | — | Usability (quantified: ≤ 10 s directory lookup) |
| AC-005 | Declared input | — | Reliability (quantified: ≤ 5 min offline retry) |
| CON-001…CON-021 | Declared input | — | Vision (Constraints) |
