## Document Control

- Phase: Inception
- Status: Draft — iteration 1, submitted for review
- Milestone Target: End of Inception (Lifecycle Objectives) — NOT YET ACHIEVED

## Use-Case Diagram
```plantuml
@startuml Portal_UseCaseOverview
title Portal — system boundary, actors and use cases (Inception iteration 1)
skinparam shadowing false
left to right direction
skinparam packageStyle rectangle

actor "Employee\n(STK-004)" as ACT001
actor "HR Administrator\n(STK-001)" as ACT002
actor "Active Directory\n(external system)" as ACT003
actor "Keycloak\n(external system)" as ACT004

rectangle "Employee Portal" {
  usecase "UC-001 Clock In and Clock Out" as UC001
  usecase "UC-002 View Own Clocking History" as UC002
  usecase "UC-003 View All Employee Clockings" as UC003
  usecase "UC-004 Export Monthly Clocking Report as CSV" as UC004
  usecase "UC-005 Correct or Insert a Clocking" as UC005
  usecase "UC-006 Publish News Item" as UC006
  usecase "UC-007 Read News List" as UC007
  usecase "UC-008 Filter News by Category" as UC008
  usecase "UC-009 Display Featured News Banner" as UC009
  usecase "UC-010 Feature or Un-feature a News Item" as UC010
  usecase "UC-011 Edit Published News Item" as UC011
  usecase "UC-012 Unpublish News Item" as UC012
  usecase "UC-013 Search Employee Directory" as UC013
  usecase "UC-014 View Directory Entry" as UC014
  usecase "UC-015 Assign or Clear Worker Category" as UC015
  usecase "UC-016 Clock In/Out Survives a Network Drop" as UC016
}

ACT001 --> UC001
ACT001 --> UC002
ACT001 --> UC007
ACT001 --> UC008
ACT001 --> UC009
ACT001 --> UC013
ACT001 --> UC014
ACT001 --> UC016

ACT002 --> UC003
ACT002 --> UC004
ACT002 --> UC005
ACT002 --> UC006
ACT002 --> UC010
ACT002 --> UC011
ACT002 --> UC012
ACT002 --> UC015

ACT003 --> UC004
ACT003 --> UC013
ACT003 --> UC014
ACT003 --> UC015

ACT004 --> UC001
ACT004 --> UC002
ACT004 --> UC003
ACT004 --> UC004
ACT004 --> UC005
ACT004 --> UC006
ACT004 --> UC007
ACT004 --> UC008
ACT004 --> UC009
ACT004 --> UC010
ACT004 --> UC011
ACT004 --> UC012
ACT004 --> UC013
ACT004 --> UC014
ACT004 --> UC015
ACT004 --> UC016

note bottom of ACT004
  Keycloak is the OIDC identity provider for every
  authenticated use case (CON-001). It runs inside the
  corporate network (CON-032) and is not deployed by
  this project. NFR-005: AD group membership decides
  the level — HR or employee.
end note

note bottom of ACT003
  Active Directory is read over LDAP and is the single
  source of truth for name, job title, department,
  office, email and extension (CON-003). The portal
  never writes to it (CON-004). It participates only in
  the four use cases that resolve employee data:
  UC-004 (FullName), UC-013, UC-014 and UC-015.
end note

note top of UC016
  UC-016 is the network-drop behaviour of the clocking
  page; it is realized as the alternative flow of UC-001.
end note
@enduml
```

### System boundary

**Inside the boundary.** The portal's own behaviour: recording a clocking, holding the clocking record and its corrections, publishing and presenting news, presenting the directory, holding the worker-category link, and writing the audit entries. The portal's own database (PostgreSQL 18, CON-031) is inside.

**On the boundary.** Two external systems the portal depends on and does not build: Active Directory, read over LDAP and never written (CON-003, CON-004), and Keycloak, the OIDC identity provider that federates AD (CON-001). Keycloak is external to the project but **inside the corporate network** (CON-032) — the OIDC redirect is an intra-network call and login works with no internet link.

**Outside the boundary, and declared out of scope.** The payroll system, the vacation/sick-leave system, the historical Excel archive on the shared drive (CON-036), and any native mobile app or PWA (CON-039). The full exclusion list is published in the Vision under "Not in scope".

**No time-trigger actor.** No scheduled job, batch export or recurring report is declared. The CSV export is initiated by HR, not by a clock.

**No administrative actor.** NFR-004 states the audit is read directly from the database and there is no in-portal audit view screen, so no auditor or administrator actor interacts with the portal.

**Cross-cutting mechanisms are not use cases.** Authentication, authorization and the audit trail are specified in the Supplementary Specification and `<<include>>`d by the use cases that depend on them — see "Cross-cutting mechanisms" under the Use-Case Survey. No use case named "Authenticate", "Authorize" or "Log" exists, and none is to be added.

## Actors

| ID | Actor | Type | Goal in the portal | Declared source |
|---|---|---|---|---|
| ACT-001 | Employee | Human, primary | Clock in and out, see their own month, read and filter news, find a colleague | STK-004 |
| ACT-002 | HR Administrator | Human, primary | See all clockings, export a month, correct or insert a clocking, publish/edit/unpublish/feature news, assign or clear a worker category | STK-001 |
| ACT-003 | Active Directory | External system, supporting | Supply name, job title, department, office, email and extension over LDAP; supply the AD group membership that decides the authorization level | CON-003, NFR-005 |
| ACT-004 | Keycloak | External system, supporting | Authenticate the user and return the identity and group claims the portal authorizes on | CON-001, CON-032 |

ACT-001 and ACT-002 are the same person in different roles: NFR-005 derives the level from AD group membership, so an HR group member is an HR Administrator and everybody else is an Employee. There is no third level and no role matrix.

## Use-Case Survey

Every use case below realizes a declared requirement. The `Source` column carries the declared `FR-NNN` identifier copied exactly.

| UC | Name | Primary actor | Source | Priority | Volatility | Detail in this iteration |
|---|---|---|---|---|---|---|
| UC-001 | Clock In and Clock Out | ACT-001 Employee | FR-001 | Must | Low | Detailed |
| UC-002 | View Own Clocking History | ACT-001 Employee | FR-002 | Must | Low | Outline |
| UC-003 | View All Employee Clockings | ACT-002 HR Administrator | FR-003 | Must | Low | Outline |
| UC-004 | Export Monthly Clocking Report as CSV | ACT-002 HR Administrator | FR-004 | Must | Medium | Detailed |
| UC-005 | Correct or Insert a Clocking | ACT-002 HR Administrator | FR-005 | Must | Low | Outline |
| UC-006 | Publish News Item | ACT-002 HR Administrator | FR-006 | Must | Low | Outline |
| UC-007 | Read News List | ACT-001 Employee | FR-007 | Must | Low | Outline |
| UC-008 | Filter News by Category | ACT-001 Employee | FR-008 | Must | Low | Outline |
| UC-009 | Display Featured News Banner | ACT-001 Employee | FR-009 | Must | Low | Outline |
| UC-010 | Feature or Un-feature a News Item | ACT-002 HR Administrator | FR-010 | Must | Low | Outline |
| UC-011 | Edit Published News Item | ACT-002 HR Administrator | FR-011 | Must | Low | Outline |
| UC-012 | Unpublish News Item | ACT-002 HR Administrator | FR-012 | Must | Low | Outline |
| UC-013 | Search Employee Directory | ACT-001 Employee | FR-013 | Must | Medium | Outline |
| UC-014 | View Directory Entry | ACT-001 Employee | FR-014 | Must | Medium | Detailed |
| UC-015 | Assign or Clear Worker Category | ACT-002 HR Administrator | FR-015 | Must | Low | Detailed |
| UC-016 | Clock In/Out Survives a Network Drop | ACT-001 Employee | FR-016 | Must | Medium | Detailed |

**Priority.** All sixteen are `Must`. The scope statement's "Includes" list declares every one of them, and no declared item is optional — so no Should/Could split is invented here. A reduction in scope is a Change Request, not a priority decision taken in this artifact.

**Volatility.** `Medium` marks the four use cases where a future change is plausible without a change of business: UC-004 (the export is the artifact HR hands to other processes, so its column set is the most likely place for a request to land), UC-013 and UC-014 (R001 — job title and extension may not be filled consistently across the three offices), and UC-016 (the retry window is a declared parameter). The remaining twelve are `Low`: their behaviour is fixed by a declared business rule. Volatility is annotated so the Software Architect can encapsulate the volatile behaviour rather than let it spread.

**Detail level.** Inception details the architecturally significant use cases only. UC-001, UC-004, UC-014 and UC-015 are detailed below because each forces a decision the architecture must carry: the client-supplied timestamp and idempotency key, the CSV's empty-versus-zero semantics, the LDAP read with no local copy, and the two-column category link that is the portal's only write about a person. The remaining twelve are outlined and are detailed in Elaboration.

### Use-case relationships

```plantuml
@startuml Portal_UC_Relations
title Use-case relationships — include, extend and the one shared process
skinparam shadowing false
left to right direction

usecase "UC-001 Clock In and Clock Out" as UC001
usecase "UC-016 Clock In/Out Survives a Network Drop" as UC016
usecase "UC-007 Read News List" as UC007
usecase "UC-008 Filter News by Category" as UC008
usecase "UC-009 Display Featured News Banner" as UC009
usecase "UC-013 Search Employee Directory" as UC013
usecase "UC-014 View Directory Entry" as UC014
usecase "UC-015 Assign or Clear Worker Category" as UC015
usecase "UC-010 Feature or Un-feature a News Item" as UC010
usecase "UC-012 Unpublish News Item" as UC012

UC016 .> UC001 : <<extend>>\nnetwork drop during a press
UC008 .> UC007 : <<extend>>\nfilter applied to the list
UC009 .> UC007 : <<extend>>\nfeatured item present
UC014 .> UC013 : <<include>>\nentry shown from the result
UC015 .> UC014 : <<extend>>\nHR acts on the entry
UC010 .> UC012 : <<extend>>\nunpublishing the featured item\nun-features it (CON-020)

note bottom
  UC-016 is declared as FR-016 and is modelled as a use case because it
  carries its own trigger (a network drop during a press) and its own
  measurable outcome (AC-005). It is realized as the alternative flow of
  UC-001 — not as a separate subsystem.
end note
@enduml
```

## Use-Case Specifications

### UC-001 Clock In and Clock Out

| Field | Value |
|---|---|
| Primary actor | ACT-001 Employee |
| Source | FR-001 |
| Priority | Must |
| Volatility | Low |
| Trigger | The employee presses the Clock In or Clock Out button on the main screen. |
| Precondition | The employee is authenticated (ACT-004 Keycloak) and is on the main screen. |
| Postcondition | A clocking is recorded with the press timestamp, stored in UTC; the employee's status is inverted and the confirmation is shown. |
| Related rules | CON-007, CON-013, CON-014, CON-039 |

**Main flow**

1. The employee opens the main screen.
2. The portal shows one button whose label follows the employee's current status — Clock In when no open clocking exists for today, Clock Out when one does.
3. The employee presses the button.
4. The browser takes the press timestamp and queues the press in localStorage with an idempotency key.
5. The browser POSTs the clocking.
6. The server records the clocking with the client-supplied press timestamp, stored in UTC.
7. The browser clears the queued press and the employee sees the confirmation and the new status.

**Alternative flows**

- **A1 — Network drop during the press (UC-016, FR-016).** The POST does not reach the server. The browser retries for up to 5 minutes. If the network returns, the queued press is POSTed with its original timestamp and the server records the press time, not the receipt time. If it does not return within 5 minutes, the employee sees the no-connection message and reports the clocking to HR (AC-005).
- **A2 — Repeated press with the same idempotency key.** The server returns the already-recorded result instead of recording a second clocking.
- **A3 — A second pair attempted on the same calendar day.** CON-014 permits at most one clocking pair per employee per calendar day; the portal does not open a second pair.

```plantuml
@startuml Portal_UC001_Clocking
title UC-001 Clock In and Clock Out — main flow and the network-drop alternative (UC-016)
skinparam shadowing false

start
:Employee opens the main screen;
note right
  CON-013: a clocking pair never crosses midnight.
  CON-014: at most one clocking pair per employee per calendar day.
  CON-007: stored in UTC, displayed in Europe/Madrid.
  CON-039: this retry is the only offline behaviour — no PWA,
  no service worker, no client cache of directory or news.
end note
:Employee sees the Clock In or Clock Out button\naccording to the current status;
:Employee presses the button;
:Browser takes the press timestamp;
:Browser queues the press in localStorage\nwith an idempotency key;
:Browser POSTs the clocking;

if (POST reaches the server?) then (yes)
  :Server records the clocking with the client-supplied\npress timestamp, stored in UTC;
  note right
    A repeated idempotency key returns the already-recorded
    result instead of recording a second clocking.
  end note
  :Browser clears the queued press;
  :Employee sees the confirmation and the new status;
  stop
else (no)
  :Browser retries the POST for up to 5 minutes;
  if (network restored within 5 minutes?) then (yes)
    :Browser POSTs the queued press\nwith its original timestamp;
    :Server records the clocking with the press timestamp,\nnot the time the server received it;
    :Employee sees the confirmation;
    stop
  else (no)
    :Employee sees the no-connection message;
    :Employee reports the clocking to HR;
    stop
  endif
endif
@enduml
```

```plantuml
@startuml Portal_UC001_Sequence
title UC-001 / UC-016 — clocking press, network drop and idempotent retry
skinparam shadowing false
autonumber

actor "Employee\n(STK-004)" as EMP
participant "Clocking page\n(Razor Pages + page script)" as UI
participant "Clocking API\n(REST)" as API
database "PostgreSQL 18" as DB

EMP -> UI : press Clock In / Clock Out
activate UI
UI -> UI : take the press timestamp
UI -> UI : queue the press in localStorage\nwith an idempotency key
UI -> API : POST /clockings\n{ pressTimestamp, idempotencyKey }
activate API

alt network reachable
  API -> DB : look up the idempotency key
  activate DB
  DB --> API : not found
  deactivate DB
  API -> DB : insert the clocking\n(pressTimestamp stored in UTC)
  activate DB
  DB --> API : recorded
  deactivate DB
  API --> UI : 201 Created, new status
  UI -> UI : clear the queued press
  UI --> EMP : confirmation and new status
else network down
  API --> UI : no response
  UI -> UI : retry the POST for up to 5 minutes
  note right of UI
    CON-039: this retry is the only offline behaviour.
    No PWA, no service worker, no client cache.
  end note
  alt network restored within 5 minutes
    UI -> API : POST the queued press\nwith its original timestamp
    API -> DB : insert the clocking\n(pressTimestamp, not the receipt time)
    activate DB
    DB --> API : recorded
    deactivate DB
    API --> UI : 201 Created
    UI --> EMP : confirmation
  else still down after 5 minutes
    UI --> EMP : no-connection message
    EMP -> EMP : report the clocking to HR
    note right of EMP
      AC-005: beyond 5 minutes the employee
      reports the clocking to HR.
    end note
  end
end

note over API, DB
  A repeated idempotency key returns the already-recorded result
  instead of recording a second clocking.
  CON-013: a pair never crosses midnight.
  CON-014: at most one pair per employee per calendar day.
  CON-007: stored in UTC, displayed in Europe/Madrid.
end note
deactivate API
deactivate UI
@enduml
```

### UC-004 Export Monthly Clocking Report as CSV

| Field | Value |
|---|---|
| Primary actor | ACT-002 HR Administrator |
| Source | FR-004 |
| Priority | Must |
| Volatility | Medium |
| Trigger | HR selects a calendar month and requests the export. |
| Precondition | HR is authenticated and is a member of the HR AD group (NFR-005). |
| Postcondition | A CSV file is produced covering 00:00 on the first day to 23:59:59 on the last day of the month, Europe/Madrid, with the seven declared columns in the declared order. |
| Related rules | CON-011, CON-013, CON-014, CON-015, CON-016, CON-017 |

**Main flow**

1. HR opens the clocking report screen and selects one calendar month.
2. The portal selects every clocking pair in that month.
3. The portal groups the pairs by employee and calendar date.
4. The portal resolves `FullName` from Active Directory and `WorkerCategory` from the portal's category link.
5. The portal computes `HoursWorked` from the recorded clocking times.
6. The portal writes the CSV with the seven columns in the declared order and HR downloads it.

**Alternative flows**

- **A1 — Clock-out missing for a day.** The row is still exported, with `ClockOut` and `HoursWorked` empty (CON-016). A zero would state the employee worked no hours, which is false.
- **A2 — A day with no clocking.** No row is produced — a weekend, a holiday, a sick day or a day before the employee joined (CON-015). The portal records clockings, not absences.
- **A3 — A day HR corrected or inserted.** `Corrected` is `Y`; otherwise `N` (CON-017).
- **A4 — An employee with no category assigned.** The row is exported with `WorkerCategory` blank; no default value is invented (CON-024).

```plantuml
@startuml Portal_UC004_Export
title UC-004 Export Monthly Clocking Report as CSV — flow and business rules
skinparam shadowing false

|HR Administrator|
start
:Open the clocking report screen;
:Select one calendar month;

|Portal|
:Select every clocking pair in the month\n(00:00 on the first day to 23:59:59 on the last,\nEurope/Madrid);
:Group by employee and calendar date;
note right
  CON-013: a pair never crosses midnight.
  CON-014: at most one pair per employee per day.
  CON-015: a day with no clocking produces no row —
  the portal records clockings, not absences.
end note
:Resolve FullName and WorkerCategory\n(AD over LDAP; category from the portal link table);
if (clock-out missing for the day?) then (yes)
  :Leave ClockOut and HoursWorked empty;
  note right
    CON-016: empty states the value is unknown;
    a zero would state the employee worked no hours.
  end note
else (no)
  :Compute HoursWorked from the recorded times;
endif
:Format the row;
note right
  CON-011: EmployeeId = AD sAMAccountName, read from
  the authenticated session and written as-is.
  CON-017: Date ISO 8601; ClockIn/ClockOut 24-hour HH:mm
  with no seconds; HoursWorked decimal hours, two decimals,
  computed from the recorded times, not the rounded display;
  Corrected = Y when HR corrected or inserted any clocking
  of that day, N otherwise.
end note
:Write the CSV with the seven columns\nin the declared order;
|HR Administrator|
:Download the CSV;
stop
@enduml
```

### UC-014 View Directory Entry

| Field | Value |
|---|---|
| Primary actor | ACT-001 Employee |
| Source | FR-014 |
| Priority | Must |
| Volatility | Medium |
| Trigger | The employee opens a directory entry from a search result. |
| Precondition | The employee is authenticated and the corporate network is reachable. |
| Postcondition | The entry shows name, job title, department, office, email, extension phone number and worker category. |
| Related rules | CON-003, CON-004, CON-022, CON-024, CON-026, NFR-006, R001 |

**Main flow**

1. The employee opens a directory entry.
2. The portal reads name, job title, department, office, email and extension from Active Directory over LDAP.
3. The portal reads the worker category from its own category link, keyed by AD user id.
4. The portal renders the seven fields.

**Alternative flows**

- **A1 — Job title or extension empty in AD (R001).** The field renders empty. No value is invented and no placeholder is substituted.
- **A2 — No category assigned.** The category field renders blank (CON-024).
- **A3 — Network unavailable.** The page shows the no-connection message (NFR-006). Nothing is cached locally (CON-039).

```plantuml
@startuml Portal_UC014_Directory
title UC-014 View Directory Entry — LDAP read, no local copy
skinparam shadowing false

actor "Employee\n(STK-004)" as EMP
participant "Directory page\n(Razor Pages)" as UI
participant "Directory service" as SVC
participant "Active Directory\n(LDAP)" as AD
database "PostgreSQL 18\ncategory link table" as DB

EMP -> UI : search by name, department or office
UI -> SVC : find entries
SVC -> AD : LDAP query for name, job title, department,\noffice, email, extension
AD --> SVC : matching entries
note right of AD
  CON-003: AD is the single source of truth.
  CON-004: the portal never writes to AD.
  R001: job title or extension may be empty in some offices.
end note
SVC -> DB : read worker category by AD user id
DB --> SVC : category, or none
note right of DB
  CON-022: two columns only — AD user id, category.
  CON-024: at most one category, possibly empty;
  no default value is invented.
end note
SVC --> UI : directory entries
UI --> EMP : name, job title, department, office,\nemail, extension, worker category
note right of UI
  CON-026: corporate data only.
  NFR-006: when the network is unavailable the page shows
  a no-connection message; nothing is cached locally (CON-039).
end note
@enduml
```

### UC-015 Assign or Clear Worker Category

| Field | Value |
|---|---|
| Primary actor | ACT-002 HR Administrator |
| Source | FR-015 |
| Priority | Must |
| Volatility | Low |
| Trigger | HR assigns or clears a worker's category from the directory screen. |
| Precondition | HR is authenticated and is a member of the HR AD group (NFR-005). |
| Postcondition | The category link is written or cleared, the change is audited, and the directory shows the new value. |
| Related rules | CON-022, CON-023, CON-024, CON-025, NFR-004 |

**Main flow**

1. HR opens the directory screen and finds the employee.
2. HR opens the category control, which offers the four closed values.
3. HR selects one value, or clears the category.
4. The portal writes the link — AD user id to category.
5. The portal writes the audit entry: who, when, previous value.
6. The directory shows the new value.

**Alternative flows**

- **A1 — Clearing the category.** The link is removed; the employee still appears in the directory and in the export with the field blank (CON-024).
- **A2 — A fifth value requested.** Not available. The list is closed and fixed for this project; a fifth value requires a Change Request (CON-025).

```plantuml
@startuml Portal_UC015_Category
title UC-015 Assign or Clear Worker Category — the only write the portal makes about a person
skinparam shadowing false

start
:HR Administrator opens the directory screen;
note right
  CON-023: the category is descriptive and does NOT drive
  access control. It is used in exactly two places — as a
  directory column and as a CSV column. Nowhere else.
end note
:HR Administrator finds the employee;
:HR Administrator opens the category control;
note right
  CON-025: the list is closed — Full-time, Part-time,
  Contractor, Intern. Not configurable, no screen to
  create or rename, no fifth value without a CR.
end note
if (assign or clear?) then (assign)
  :HR Administrator selects one of the four values;
else (clear)
  :HR Administrator clears the category;
  note right
    CON-024: a worker has at most one category and it
    may be empty. No default value is invented.
  end note
endif
:Portal writes the link — AD user id to category;
note right
  CON-022: the local table holds two columns and
  nothing else. No duplicate of the employee, no
  synchronisation, no reconciliation.
end note
:Portal writes the audit entry (who, when, previous value);
:Directory shows the new value;
stop
@enduml
```

### UC-002 View Own Clocking History

| Field | Value |
|---|---|
| Primary actor | ACT-001 Employee |
| Source | FR-002 |
| Priority | Must |
| Volatility | Low |
| Trigger | The employee opens their own clocking history. |
| Precondition | The employee is authenticated. |
| Postcondition | The employee's own clockings for the current month are shown. |
| Main flow | 1. The employee opens the history view. 2. The portal selects the employee's own clockings for the current month. 3. The portal shows them, with times displayed in Europe/Madrid (CON-007). |
| Alternative flow | A1 — A day with a missing clock-out is shown as an incomplete day (CON-013). |
| Related rules | CON-007, CON-013 |

### UC-003 View All Employee Clockings

| Field | Value |
|---|---|
| Primary actor | ACT-002 HR Administrator |
| Source | FR-003 |
| Priority | Must |
| Volatility | Low |
| Trigger | HR opens the all-employee clocking view. |
| Precondition | HR is authenticated and is a member of the HR AD group (NFR-005). |
| Postcondition | The clockings of all employees are shown. |
| Main flow | 1. HR opens the view. 2. The portal selects the clockings of all employees. 3. The portal shows them, with times displayed in Europe/Madrid (CON-007). |
| Related rules | CON-007, NFR-005 |

### UC-005 Correct or Insert a Clocking

| Field | Value |
|---|---|
| Primary actor | ACT-002 HR Administrator |
| Source | FR-005 |
| Priority | Must |
| Volatility | Low |
| Trigger | HR corrects or inserts a clocking on behalf of an employee who forgot to clock out. |
| Precondition | HR is authenticated and is a member of the HR AD group (NFR-005). |
| Postcondition | The correction is recorded and audited; the original record is neither overwritten in place nor deleted. |
| Main flow | 1. HR opens the clocking of the employee and the day. 2. HR enters the corrected or inserted value and a free-text reason. 3. The portal records the correction as a new record, leaving the original intact. 4. The portal writes the audit entry: who, when, previous value, reason. |
| Alternative flow | A1 — The day is marked `Corrected = Y` in the CSV export (CON-017). |
| Related rules | CON-012, CON-017, NFR-004 |

### UC-006 Publish News Item

| Field | Value |
|---|---|
| Primary actor | ACT-002 HR Administrator |
| Source | FR-006 |
| Priority | Must | 
| Volatility | Low |
| Trigger | HR publishes an internal news item or announcement. |
| Precondition | HR is authenticated and is a member of the HR AD group (NFR-005). |
| Postcondition | The item is published with title, body, date and category, and the publication is audited. |
| Main flow | 1. HR enters title, body, date and category. 2. HR optionally sets the featured flag (UC-010). 3. The portal publishes the item. 4. The portal writes the audit entry: author and timestamp. |
| Related rules | CON-018, NFR-004 |

### UC-007 Read News List

| Field | Value |
|---|---|
| Primary actor | ACT-001 Employee |
| Source | FR-007 |
| Priority | Must |
| Volatility | Low |
| Trigger | The employee opens the main page. |
| Precondition | The employee is authenticated and the corporate network is reachable. |
| Postcondition | The published news is shown sorted by date, newest first, read-only. |
| Main flow | 1. The employee opens the main page. 2. The portal selects the published items. 3. The portal shows them newest first. |
| Alternative flow | A1 — Network unavailable: the no-connection message is shown (NFR-006). |
| Related rules | CON-021, NFR-006 |

### UC-008 Filter News by Category

| Field | Value |
|---|---|
| Primary actor | ACT-001 Employee |
| Source | FR-008 |
| Priority | Must |
| Volatility | Low |
| Trigger | The employee selects a category filter on the news list. |
| Precondition | The news list is shown. |
| Postcondition | Only the items of the selected category are shown. |
| Main flow | 1. The employee selects one of General, HR, IT, Events. 2. The portal filters the list to that category. |
| Related rules | FR-008 (the four categories are declared) |

### UC-009 Display Featured News Banner

| Field | Value |
|---|---|
| Primary actor | ACT-001 Employee |
| Source | FR-009 |
| Priority | Must |
| Volatility | Low |
| Trigger | The employee opens the main page. |
| Precondition | The employee is authenticated. |
| Postcondition | The featured item appears with a banner at the top of the main page, or no banner appears when no item is featured. |
| Main flow | 1. The employee opens the main page. 2. The portal reads the featured item. 3. If one exists, the portal renders the banner above the list; if none exists, no banner is rendered. |
| Related rules | CON-019, CON-020 |

### UC-010 Feature or Un-feature a News Item

| Field | Value |
|---|---|
| Primary actor | ACT-002 HR Administrator |
| Source | FR-010 |
| Priority | Must |
| Volatility | Low |
| Trigger | HR sets or clears the featured flag, when publishing or when editing. |
| Precondition | HR is authenticated and is a member of the HR AD group (NFR-005). |
| Postcondition | At most one item is featured; featuring one un-features the previous one; HR may leave none featured. |
| Main flow | 1. HR sets the featured flag on an item. 2. The portal un-features the previously featured item. 3. The portal marks the new item featured. |
| Alternative flow | A1 — HR clears the flag: the banner disappears and no other item is promoted (CON-019). |
| Related rules | CON-018, CON-019 |

### UC-011 Edit Published News Item

| Field | Value |
|---|---|
| Primary actor | ACT-002 HR Administrator |
| Source | FR-011 |
| Priority | Must |
| Volatility | Low |
| Trigger | HR edits a news item after publishing. |
| Precondition | HR is authenticated and is a member of the HR AD group (NFR-005). |
| Postcondition | The item is updated and the edit is audited with who and when. |
| Main flow | 1. HR opens the published item. 2. HR changes the content. 3. The portal saves the change. 4. The portal writes the audit entry: who and when. |
| Related rules | NFR-004 |

### UC-012 Unpublish News Item

| Field | Value |
|---|---|
| Primary actor | ACT-002 HR Administrator |
| Source | FR-012 |
| Priority | Must |
| Volatility | Low |
| Trigger | HR unpublishes a news item. |
| Precondition | HR is authenticated and is a member of the HR AD group (NFR-005). |
| Postcondition | The item is hidden and never deleted; the unpublish is audited. |
| Main flow | 1. HR unpublishes the item. 2. The portal hides it. 3. The portal writes the audit entry: who and when. |
| Alternative flow | A1 — The item was featured: it is un-featured too, the banner disappears and no other item is promoted (CON-020). |
| Related rules | CON-020, CON-021, NFR-004 |

### UC-013 Search Employee Directory

| Field | Value |
|---|---|
| Primary actor | ACT-001 Employee |
| Source | FR-013 |
| Priority | Must |
| Volatility | Medium |
| Trigger | The employee searches for a colleague. |
| Precondition | The employee is authenticated and the corporate network is reachable. |
| Postcondition | Matching colleagues are listed. |
| Main flow | 1. The employee enters a name, department or office. 2. The portal queries Active Directory over LDAP. 3. The portal lists the matching entries. |
| Alternative flow | A1 — Network unavailable: the no-connection message is shown (NFR-006). |
| Related rules | CON-003, CON-026, NFR-006, R001 |

### UC-016 Clock In/Out Survives a Network Drop

| Field | Value |
|---|---|
| Primary actor | ACT-001 Employee |
| Source | FR-016 |
| Priority | Must |
| Volatility | Medium |
| Trigger | The corporate network drops while the employee's clocking press is in flight. |
| Precondition | The employee has pressed the Clock In or Clock Out button (UC-001). |
| Postcondition | The clocking is recorded with the timestamp the employee pressed the button, or the employee is told the clocking was not recorded. |
| Main flow | 1. The press is held in the browser in localStorage with an idempotency key. 2. The browser retries the POST for up to 5 minutes. 3. When the network returns, the server records the clocking with the client-supplied press timestamp. 4. The server rejects a duplicate by its idempotency key. |
| Alternative flow | A1 — Still down after 5 minutes: the employee sees the no-connection message and reports the clocking to HR (AC-005). |
| Related rules | CON-013, CON-014, CON-039 |

**Realization note.** UC-016 is declared as FR-016 and is modelled as a use case because it carries its own trigger and its own measurable outcome (AC-005). It is realized as the alternative flow of UC-001, not as a separate subsystem: one action, one queue, one entity. Two clocking presses by the same employee cannot conflict (CON-013, CON-014), so there is nothing to reconcile and no conflict resolution to write.

### News lifecycle across UC-006, UC-010, UC-011 and UC-012

```plantuml
@startuml Portal_NewsLifecycle
title News lifecycle — UC-006, UC-010, UC-011, UC-012 and the featured-item invariant
skinparam shadowing false

start
:HR Administrator publishes a news item\n(title, body, date, category);
note right
  CON-018: featuring is a manual flag HR sets, when publishing or
  when editing — never automatic. No criteria, no dates, no rule
  promotes an item by itself.
end note
:Portal writes the audit entry (who, when);
if (featured flag set at publication?) then (yes)
  :Portal un-features the previously featured item;
  note right
    CON-019: at most one item is featured at any moment —
    a system invariant, not a screen convention.
  end note
  :New item appears in the banner at the top of the main page;
else (no)
  :No banner change;
endif
:Item appears in the news list, newest first;
:Employee reads the list and filters by category;
if (HR Administrator edits the item?) then (yes)
  :Portal writes the audit entry (who, when);
endif
if (HR Administrator changes the featured flag?) then (yes)
  if (featured now?) then (yes)
    :Portal un-features the previously featured item;
    :Banner shows this item;
  else (no)
    :Banner disappears; no other item is promoted;
  endif
endif
if (HR Administrator unpublishes the item?) then (yes)
  :Item is hidden and never deleted;
  note right
    CON-021: deleting would destroy the audit trail.
  end note
  if (item was featured?) then (yes)
    :Item is un-featured too; no other item is promoted;
  endif
endif
stop
@enduml
```

## Traceability

| Element | Traces From | Link Type | Traces To |
|---|---|---|---|
| UC-001 | FR-001 | Refines | — |
| UC-002 | FR-002 | Refines | — |
| UC-003 | FR-003 | Refines | — |
| UC-004 | FR-004 | Refines | — |
| UC-005 | FR-005 | Refines | — |
| UC-006 | FR-006 | Refines | — |
| UC-007 | FR-007 | Refines | — |
| UC-008 | FR-008 | Refines | — |
| UC-009 | FR-009 | Refines | — |
| UC-010 | FR-010 | Refines | — |
| UC-011 | FR-011 | Refines | — |
| UC-012 | FR-012 | Refines | — |
| UC-013 | FR-013 | Refines | — |
| UC-014 | FR-014 | Refines | — |
| UC-015 | FR-015 | Refines | — |
| UC-016 | FR-016 | Refines | — |
