## Document Control
- **Phase:** Inception
- **Status:** Draft — iteration 2, submitted for review
- **Milestone Target:** End of Inception (not yet achieved)
## Use-Case Diagram
Fifteen use cases, one per declared requirement FR-001 to FR-015. Two human actors and two external
systems sit on the boundary. Authentication (NFR-001) is deliberately **not** a use case: it is
mechanism MECH-01 in the Supplementary Specification, included by every use case.

```plantuml
@startuml
title Portal - System boundary, actors and use cases

left to right direction

actor "Employee\nSTK-004" as EMP
actor "HR Administrator\nSTK-001" as HR
actor "Active Directory\n(external system, STK-003)" as AD
actor "Keycloak\n(external system, STK-003)" as KC

EMP <|-- HR

rectangle "Employee Portal - system boundary" {
  usecase "UC-001 Clock In and Clock Out" as UC001
  usecase "UC-002 View Own Clocking History" as UC002
  usecase "UC-003 View All Employee Clockings" as UC003
  usecase "UC-004 Export Monthly Clocking Report as CSV" as UC004
  usecase "UC-005 Correct or Insert Clocking" as UC005
  usecase "UC-006 Publish News" as UC006
  usecase "UC-007 Edit Published News" as UC007
  usecase "UC-008 Unpublish News" as UC008
  usecase "UC-009 Feature or Un-feature News" as UC009
  usecase "UC-010 Read and Filter News" as UC010
  usecase "UC-011 Search Employee Directory" as UC011
  usecase "UC-012 Assign or Clear Worker Category" as UC012
  usecase "UC-013 Retry Clocking Through a Network Drop" as UC013
  usecase "UC-014 Recognize Directory Unavailable" as UC014
  usecase "UC-015 Recognize News Unavailable" as UC015
}

EMP --> UC001
EMP --> UC002
EMP --> UC010
EMP --> UC011
HR --> UC003
HR --> UC004
HR --> UC005
HR --> UC006
HR --> UC007
HR --> UC008
HR --> UC009
HR --> UC012

UC013 .> UC001 : <<extend>>
UC014 .> UC011 : <<extend>>
UC015 .> UC010 : <<extend>>

AD --> UC011
AD --> UC004

note right of KC
  Keycloak realizes MECH-01 (NFR-001).
  Authentication is a portal-wide mechanism
  included by every use case and recorded in
  the Supplementary Specification. It initiates
  no use case, so it carries no association here.
end note

note bottom of UC013
  FR-013, FR-014 and FR-015 are the conditional
  exception paths of UC-001, UC-011 and UC-010 -
  not independent employee goals.
end note
@enduml
```

**Why three use cases are drawn as `<<extend>>`.** FR-013, FR-014 and FR-015 are declared
requirements, so each carries its own use case per the Development Case. But none of them is an
independent actor goal: FR-013 is what UC-001 does when the network drops, and FR-014/FR-015 are what
UC-011 and UC-010 do when the network is unreachable. Modelling them as extensions keeps the declared
requirement traceable without inventing three goals the employee does not have.

**Active Directory participates in two use cases, not one.** It supplies the six read-only directory
attributes to UC-011, and it supplies FullName to UC-004 — the export's second column is a directory
value, not a portal-owned one. Keycloak initiates nothing: it is the mechanism behind MECH-01, and a
mechanism is not an actor goal.

## Actors

| Actor | Type | Represents | Goals in the portal | Source |
|---|---|---|---|---|
| Employee | Primary human | STK-004 — 200 people across 3 offices | Clock in and out; see own month; read and filter news; find a colleague | STK-004 |
| HR Administrator | Primary human, generalizes Employee | STK-001 — HR Director and the HR AD group | Everything an Employee can do, plus: see all clockings; export the monthly CSV; correct or insert a clocking; publish, edit, unpublish and feature news; assign or clear a worker category | STK-001, CON-008 |
| Active Directory | External system | STK-003 — operated by Infrastructure | Supplies the six read-only directory attributes over LDAP to UC-011; supplies FullName to UC-004; supplies sAMAccountName and AD group membership through the session | STK-003, CON-003, CON-004 |
| Keycloak | External system | STK-003 — operated by Infrastructure | Authenticates the corporate identity via OIDC and federates AD. Realizes MECH-01; initiates no use case | STK-003, CON-002, NFR-001 |

**HR Administrator generalizes Employee.** CON-008 gives exactly two levels from AD group membership.
An HR Administrator is an Employee who additionally holds the HR group. This is a UML generalization,
not a role matrix — there is no third level and no per-category rule.

**Actor types checked and found absent.** No time-based trigger exists: nothing in the declared scope
runs on a schedule, and CON-018 explicitly forbids any rule that features a news item by itself. No
hardware device exists: CON-002 and the scope statement exclude biometric clocking. No administrative
actor exists beyond HR: there is no permission administration screen (CON-008) and no audit view
screen (NFR-005) — the audit trail is read directly from the database by people outside the portal.

## Use-Case Survey
Fifteen use cases. Inception details the four architecturally significant ones (UC-001, UC-004,
UC-009, UC-011); the RequirementsSpecifier details the remaining eleven in Elaboration.

| UC | Name | Primary actor | Source | Priority | Volatility | Rules bound | Detail in this iteration |
|---|---|---|---|---|---|---|---|
| UC-001 | Clock In and Clock Out | Employee | FR-001 | Must | Low | CON-011, CON-012, CON-013, CON-017, CON-036 | **Detailed** — architecturally significant: the client-timestamp and idempotency contract (FR-013) forces a design decision |
| UC-002 | View Own Clocking History | Employee | FR-002 | Must | Low | CON-011, CON-012 | Outline |
| UC-003 | View All Employee Clockings | HR Administrator | FR-003 | Must | Medium | CON-011, CON-012 | Outline |
| UC-004 | Export Monthly Clocking Report as CSV | HR Administrator | FR-004 | Must | **High** | CON-004, CON-007, CON-009, CON-015, CON-016, CON-021 | **Detailed** — architecturally significant: a fixed external contract with a derived Corrected flag |
| UC-005 | Correct or Insert Clocking | HR Administrator | FR-005 | Must | Medium | CON-011, CON-012, CON-013, CON-017 | Outline |
| UC-006 | Publish News | HR Administrator | FR-006 | Must | Low | CON-010, CON-014, CON-018; news-category list (FR-006) | Outline |
| UC-007 | Edit Published News | HR Administrator | FR-007 | Must | Low | CON-010, CON-014, CON-018 | Outline |
| UC-008 | Unpublish News | HR Administrator | FR-008 | Must | Low | CON-010, CON-014, CON-019 | Outline |
| UC-009 | Feature or Un-feature News | HR Administrator | FR-009 | Must | **High** | CON-010, CON-018, CON-019 | **Detailed** — architecturally significant: a system invariant (CON-010) that must hold wherever the change comes from |
| UC-010 | Read and Filter News | Employee | FR-010 | Must | Medium | CON-014; news-category list (FR-010) | Outline |
| UC-011 | Search Employee Directory | Employee | FR-011 | Must | Medium | CON-003, CON-009, CON-015, CON-016, CON-020, CON-021 | **Detailed** — architecturally significant: the LDAP read, the category filter and the R001 empty-attribute case |
| UC-012 | Assign or Clear Worker Category | HR Administrator | FR-012 | Must | **High** | CON-009, CON-015, CON-016, CON-021 | Outline — the only write the portal makes about a person |
| UC-013 | Retry Clocking Through a Network Drop | Employee | FR-013 | Must | Medium | CON-036, CON-011, CON-012 | Outline — extends UC-001 |
| UC-014 | Recognize Directory Unavailable | Employee | FR-014 | Must | Low | CON-003 | Outline — extends UC-011 |
| UC-015 | Recognize News Unavailable | Employee | FR-015 | Must | Low | — (nothing is cached, so no rule is enforced by absence) | Outline — extends UC-010 |

**ATM test applied to all fifteen.** Each has a primary actor who initiates it, a trigger event, and
an outcome the actor can observe. The three extension use cases pass on the same basis: the actor is
the Employee, the trigger is the network becoming unreachable, and the observable outcome is a
no-connection message or a preserved clocking.

**Priority.** All fifteen are Must. CON-023 forbids cutting or deferring declared scope, so MoSCoW
cannot be used as a scope lever on this project; the lever is iteration count.

### Business-rule binding — the handoff to the RequirementsSpecifier

Every use case is bound to the constraints that govern it. A use case detailed without its bound
rules is under-specified, and a rule bound to no use case is unenforced.

Two closed lists exist in this system and they are never interchangeable. **News categories**
(General, HR, IT, Events) are declared by FR-006 and FR-010 and govern UC-006 and UC-010.
**Worker categories** (Full-time, Part-time, Contractor, Intern) are declared by CON-009 and govern
UC-004, UC-011 and UC-012 — CON-015 names exactly two permitted uses, a directory column that also
filters and a CSV export column, and forbids the category from driving any access decision.

```plantuml
@startuml
title Portal - Business-rule clusters and the use cases each one binds

left to right direction

package "Clocking integrity" {
  class "CON-011 pair never crosses midnight\nCON-012 one pair per employee per day\nCON-013 originals never overwritten\nCON-017 only HR corrects or inserts\nCON-036 retry is one action, one queue" as R_CLK
}

package "Export contract" {
  class "CON-004 EmployeeId is sAMAccountName\nCON-007 Europe/Madrid, UTC storage\nCON-009 closed category list\nCON-016 category may be empty" as R_EXP
}

package "News lifecycle" {
  class "CON-010 at most one featured\nCON-014 never deleted, only unpublished\nCON-018 featuring is manual only\nCON-019 unpublish promotes nothing" as R_NEWS
}

package "News category list" {
  class "FR-006 category: General, HR, IT, Events\nFR-010 filter by the same four values" as R_NCAT
}

package "Worker category ownership" {
  class "CON-009 closed four-value list\nCON-015 column that also filters,\n drives no access decision\nCON-016 at most one, may be empty\nCON-021 stored as a link, two columns" as R_CAT
}

package "Directory read" {
  class "CON-003 read-only over LDAP, no copy\nCON-020 corporate data only\nCON-021 no duplicate of the employee" as R_DIR
}

package "Use cases" {
  class "UC-001 Clock In and Clock Out" as UC001
  class "UC-002 View Own Clocking History" as UC002
  class "UC-003 View All Employee Clockings" as UC003
  class "UC-004 Export Monthly CSV" as UC004
  class "UC-005 Correct or Insert Clocking" as UC005
  class "UC-006 Publish News" as UC006
  class "UC-007 Edit Published News" as UC007
  class "UC-008 Unpublish News" as UC008
  class "UC-009 Feature or Un-feature News" as UC009
  class "UC-010 Read and Filter News" as UC010
  class "UC-011 Search Employee Directory" as UC011
  class "UC-012 Assign or Clear Worker Category" as UC012
  class "UC-013 Retry Clocking Through a Network Drop" as UC013
  class "UC-014 Recognize Directory Unavailable" as UC014
  class "UC-015 Recognize News Unavailable" as UC015
}

R_CLK --> UC001
R_CLK --> UC002
R_CLK --> UC003
R_CLK --> UC005
R_CLK --> UC013

R_EXP --> UC004

R_NEWS --> UC006
R_NEWS --> UC007
R_NEWS --> UC008
R_NEWS --> UC009
R_NEWS --> UC010

R_NCAT --> UC006
R_NCAT --> UC010

R_CAT --> UC004
R_CAT --> UC011
R_CAT --> UC012

R_DIR --> UC011
R_DIR --> UC014

note bottom of R_CAT
  CON-015 names exactly two permitted uses of the
  worker category: a directory column that also
  filters, and a CSV export column. The cluster
  therefore binds UC-011 (column plus filter),
  UC-004 (export column) and UC-012 (the only
  write). Its prohibitive half is absolute: the
  category drives no access decision anywhere.
  A worker category used to filter news, or read
  in an authorization decision, is a defect.
end note

note bottom of R_NCAT
  Two different closed lists, never interchangeable.
  News categories (General, HR, IT, Events) come
  from FR-006 and FR-010 and govern UC-006 and
  UC-010. Worker categories (Full-time, Part-time,
  Contractor, Intern) come from CON-009 and govern
  UC-004, UC-011 and UC-012.
end note

note bottom of R_DIR
  UC-014 binds CON-003 by absence: nothing is
  cached, so a no-connection message is the only
  correct behaviour. UC-015 binds no rule - the
  news area caches nothing either.
end note
@enduml
```

**UC-010 is bound to the news-category list, not the worker-category cluster.** FR-010 filters news
by General, HR, IT and Events — the closed list FR-006 declares. The worker-category cluster
(CON-009, CON-015, CON-016, CON-021) binds UC-004, UC-011 and UC-012. UC-011 renders the worker
category as a column and filters the result set by it, which is CON-015's permissive half; it never
reads the category to decide what the employee may see, which is its prohibitive half.

**Mechanisms every use case includes.** MECH-01 (authenticated corporate identity, NFR-001) is
included by all fifteen. MECH-02 (HR group authorization, CON-008) is included by the eight HR use
cases. MECH-03 (audit trail write, NFR-005) is included by UC-005, UC-006, UC-007, UC-008 and UC-012 —
the five actions NFR-005 names. MECH-04 (directory read over LDAP) is included by UC-004 and UC-011.
The include graph is drawn once, in the Supplementary Specification, and is not duplicated here.

## Use-Case Specifications
### UC-001 Clock In and Clock Out

| Field | Value |
|---|---|
| Primary actor | Employee |
| Source | FR-001, with FR-013 as its exception path |
| Trigger | The employee presses the Clock In or Clock Out button on the main screen |
| Precondition | The employee is authenticated (MECH-01); the session supplies sAMAccountName and AD group membership |
| Postcondition | After a Clock In press one ClockIn event row exists for the employee-day; after a Clock Out press a ClockOut event row exists for the same `WorkDate`; the effective pair is the two rows no other row supersedes. The employee sees a confirmation carrying the press time |
| Priority / Volatility | Must / Low |

**Main flow**

1. The portal resolves the employee's identity from the session.
2. The portal reads today's clocking events for that employee and resolves the effective pair — the rows no other row supersedes (CON-012).
3. The portal renders the button for the state the pair is in: **no pair** → Clock In; **pair open** → Clock Out; **pair complete** → no clocking button, with a message that today's pair is complete and that a correction is HR's action under UC-005 (CON-017).
4. The employee presses the button.
5. The browser stamps the press time from the client clock and queues the POST with an idempotency key.
6. The server rejects a duplicate idempotency key by returning the original result, or appends a ClockIn or ClockOut event row carrying the client timestamp.
7. The employee sees a confirmation showing the recorded time.

**Alternative flows**

- **A1 — Duplicate press.** The idempotency key is already recorded. The server returns the original result; no second event row is appended. The employee sees the same confirmation.
- **A2 — Network down, recovered within 5 minutes.** The POST fails. The browser keeps the press in localStorage and retries for up to 5 minutes. On success the employee sees a confirmation carrying the press time, not the retry time. See UC-013.
- **A3 — Network down beyond 5 minutes.** The retry stops. The employee is told to report the clocking to HR, who corrects or inserts it under UC-005.
- **A4 — Pair already complete.** The employee has already clocked in and out today. CON-012 permits at most one pair per employee per calendar day, so the portal renders no clocking button and appends no event row. The employee is told the pair is complete and that only HR can correct or insert a clocking (CON-017), under UC-005. A second pair is not opened.
- **A5 — Pair open and a Clock In press arrives.** The portal offers Clock Out only in this state. A Clock In POST that arrives anyway is rejected under CON-012 and appends no row; the employee sees the open pair and the Clock Out button.

**Business rules enforced**

CON-011 (a pair never crosses midnight), CON-012 (at most one pair per employee per calendar day),
CON-013 (originals never overwritten), CON-017 (no self-service correction — only HR corrects or
inserts), CON-036 (one action, one queue, one entity — no reconciliation).

**Clocking record shape — the same in UC-002, UC-003 and UC-005.** A press appends an event row; it
never updates one. A complete pair is two rows — one ClockIn, one ClockOut — and an HR correction
appends a further row that names the row it supersedes and carries the previous value. The effective
pair is therefore a query over supersession, not a stored record, and it is the same query in UC-002
(own history), UC-003 (all clockings) and UC-004 (the export). UC-005 appends the correction row and
never overwrites or deletes the original, which is CON-013 holding by construction.

**Not audited.** The employee's own clocking is the fact itself, not a change to a fact. NFR-005
audits only the clockings HR corrects or inserts (UC-005). Writing an audit entry here would record
that the employee did what the clocking event row already says.

```plantuml
@startuml
title UC-001 Clock In and Clock Out - main flow, the three CON-012 states and the FR-013 retry path

|Employee|
start
:Open the main screen;

|Portal|
:Resolve identity from the session (MECH-01);
:Read today's clocking events and resolve the effective pair (CON-012);
note right
  ADR-010: each press appends an event row.
  The effective pair is the two rows no other
  row supersedes - a query, not a record.
end note
if (pair state?) then (no pair)
  :Render Clock In button;
elseif (pair open) then
  :Render Clock Out button;
else (pair complete)
  :Render no clocking button;
  :State that today's pair is complete and that a
   correction is HR's action under UC-005 (CON-017);
  |Employee|
  :See the complete-pair message;
  stop
endif

|Employee|
:Press the button;

|Browser|
:Stamp the press time from the client clock;
:Queue the POST with an idempotency key (FR-013);
:Send POST;

|Server|
if (idempotency key already recorded?) then (yes)
  :Return the original result;
  note right
    Duplicate rejected.
    No second event row is appended.
  end note
else (no)
  :Enforce the pair rules (CON-011, CON-012);
  :Append a ClockIn or ClockOut event row
   carrying the client timestamp;
  :Return confirmation;
endif

|Browser|
if (response received?) then (yes)
  |Employee|
  :See confirmation with the recorded time;
  stop
else (no - corporate network down)
  |Browser|
  :Keep the press in localStorage;
  :Retry the POST for up to 5 minutes;
  if (retry succeeded within 5 minutes?) then (yes)
    |Employee|
    :See confirmation with the press time;
    stop
  else (no)
    |Employee|
    :See a message to report the clocking to HR;
    stop
  endif
endif
@enduml
```

### UC-004 Export Monthly Clocking Report as CSV

| Field | Value |
|---|---|
| Primary actor | HR Administrator |
| Source | FR-004 |
| Trigger | HR chooses a calendar month and requests the export |
| Precondition | The HR Administrator is authenticated and holds the HR AD group (MECH-02) |
| Postcondition | A CSV is produced with the eight columns in the declared order, one row per employee per day that has at least one clocking |
| Priority / Volatility | Must / **High** — the column contract is consumed outside the portal and is fixed by FR-004 alone |

**Main flow**

1. HR chooses one calendar month.
2. The portal resolves the month window in Europe/Madrid — 00:00 on the first day to 23:59:59 on the last.
3. The portal selects every clocking pair and every HR correction or insertion in that window.
4. The portal groups pairs by employee and calendar date (CON-011).
5. For each group the portal emits one row: EmployeeId, FullName, WorkerCategory, Date, ClockIn, ClockOut, HoursWorked, Corrected.
6. The portal streams the CSV in the fixed column order.
7. HR receives the file.

**Alternative flows**

- **A1 — Missing clock-out.** ClockOut and HoursWorked are exported empty; the row is still exported.
- **A2 — No clocking on a day.** No row is produced for that employee-day.
- **A3 — Worker has no category.** WorkerCategory is blank (CON-016). No default value is invented.
- **A4 — HR corrected or inserted a clocking that day.** Corrected = Y for that employee-day; otherwise N.
- **A5 — Directory attribute empty.** FullName is the one directory value in the contract; if AD returns it empty the column is exported empty and the row is still produced. This is the R001 case reaching the export, not only the directory screen.

**Column contract**

| Column | Derivation |
|---|---|
| EmployeeId | AD sAMAccountName, read from the session (CON-004) |
| FullName | From the directory over LDAP (MECH-04) |
| WorkerCategory | From the portal-owned category link; blank when unset (CON-016) |
| Date | ISO 8601, e.g. 2026-06-22 |
| ClockIn | 24-hour HH:mm, no seconds, Europe/Madrid |
| ClockOut | 24-hour HH:mm, no seconds, Europe/Madrid; empty when missing |
| HoursWorked | Decimal hours, two decimals, computed from recorded times — not minute-rounded; empty when clock-out is missing |
| Corrected | Y if HR corrected or inserted any clocking that day, else N |

```plantuml
@startuml
title UC-004 Export Monthly Clocking Report as CSV - row and Corrected-flag derivation

|HR Administrator|
start
:Choose one calendar month;

|Portal|
:Resolve the month window in Europe/Madrid;
note right
  00:00 first day to 23:59:59 last day.
  CON-007: stored UTC, displayed Europe/Madrid.
end note
:Select every clocking pair in the window;
:Select every HR correction or insertion in the window;
:Group pairs by employee and calendar date (CON-011);
:Emit one row per employee-day group;
:EmployeeId = sAMAccountName from the session record (CON-004);

|Active Directory|
:Return FullName for the employee (MECH-04);
note right
  R001: an empty attribute exports empty.
  The row is still produced.
end note

|Portal|
:WorkerCategory from the category link, blank when unset (CON-016);
:Date as ISO 8601;
:ClockIn and ClockOut as HH:mm, 24-hour, no seconds;

if (clock-out present?) then (yes)
  :HoursWorked = decimal hours, two decimals;
else (no)
  :Leave ClockOut and HoursWorked empty;
  note right: The row is still exported.
endif

if (any correction or insertion that day?) then (yes)
  :Corrected = Y;
else (no)
  :Corrected = N;
endif

:Stream the CSV with the fixed column order;
|HR Administrator|
:Receive the file;
stop
@enduml
```

### UC-009 Feature or Un-feature News

| Field | Value |
|---|---|
| Primary actor | HR Administrator |
| Source | FR-009 |
| Trigger | HR sets or clears the featured flag while publishing or editing a news item, or unpublishes the featured item |
| Precondition | The HR Administrator is authenticated and holds the HR AD group (MECH-02) |
| Postcondition | At most one news item is featured; the banner shows that item or no item |
| Priority / Volatility | Must / **High** — the single-featured rule is a policy, and CON-010 requires it to hold wherever the change comes from |

**Main flow**

1. HR opens a news item for publish or edit and sets the featured flag.
2. The portal begins a transaction.
3. The portal clears the featured flag on the currently featured item, if any.
4. The portal sets the featured flag on the chosen item.
5. The portal commits.
6. The employee sees the new item in the banner.

**Alternative flows**

- **A1 — Un-feature.** HR clears the flag. No item is featured; the banner disappears. No automatic promotion (CON-019).
- **A2 — Unpublish the featured item.** The item is unpublished (UC-008) and its featured flag is cleared. Nothing is promoted in its place (CON-019).
- **A3 — No item was featured.** Step 3 is a no-op.

**Business rules enforced**

CON-010 (at most one featured, wherever the change comes from), CON-018 (featuring is manual only — no
criteria, dates or rules promote an item), CON-019 (unpublishing the featured item promotes nothing).

**Audit.** Featuring is set while publishing or editing, so the audit entry NFR-005 requires is the one
UC-006 or UC-007 writes for that publication or edit — author and timestamp. NFR-005 does not name
featuring as a separately audited action, and no second entry is invented for it.

```plantuml
@startuml
title UC-009 Feature or Un-feature News - the single-featured invariant (CON-010)

|HR Administrator|
start
:Open a news item for publish or edit;
:Set the featured flag;

|Portal|
:Begin the transaction;
:Clear the featured flag on the currently featured item;
note right
  CON-010: at most one item is featured at any
  moment. The invariant holds wherever the change
  comes from, not only in the HR form.
end note
:Set the featured flag on the chosen item;
:Commit;
note right
  The audit entry for this publication or edit
  is written by UC-006 or UC-007 (NFR-005).
end note

|Employee|
:See the new item in the banner;

|HR Administrator|
:Alternatively, un-feature the current item;

|Portal|
:Clear the flag;
:Leave no item featured;
note right: CON-019: no automatic promotion.

|HR Administrator|
:Alternatively, unpublish the featured item;

|Portal|
:Unpublish the item (UC-008);
:Clear its featured flag;
:Promote nothing in its place;
note right
  CON-019: the banner disappears and no other
  item is promoted.
end note
stop
@enduml
```

### UC-011 Search Employee Directory

| Field | Value |
|---|---|
| Primary actor | Employee |
| Source | FR-011, with FR-014 as its exception path |
| Trigger | The employee enters a search term — a name, a department or an office — and may narrow it by worker category |
| Precondition | The employee is authenticated (MECH-01); the corporate network is reachable |
| Postcondition | The employee sees matching colleagues with seven fields, optionally narrowed by worker category; no private personal information is shown |
| Priority / Volatility | Must / Medium |

**Main flow**

1. The employee enters a search term — a name, a department or an office.
2. The employee may narrow the result set by worker category, one of the four closed values (CON-009).
3. The portal queries Active Directory over LDAP for the six declared attributes.
4. The portal joins the portal-owned worker category (CON-021).
5. If a category filter is set, the portal narrows the result set to that category (CON-015).
6. The portal renders each entry with name, job title, department, office, email, extension and worker category.
7. The employee sees the results.

**Alternative flows**

- **A1 — Job title or extension empty.** The field renders blank; the row still renders and the employee is still found. This is the R001 case and the stand-in directory must carry it (CON-031).
- **A2 — Network unreachable.** The portal shows a no-connection message instead of stale or partial results. Nothing is cached, so there is nothing to fall back to. See UC-014.
- **A3 — No match.** The employee sees an empty result set, not an error.
- **A4 — Worker has no category.** The entry still appears and the category field renders blank (CON-016); no default value is invented. When a category filter is applied the entry does not match it, because the filter selects one of the four values and blank is not one of them. With no filter applied the entry appears.

**Business rules enforced**

CON-003 (read-only from AD, no local copy), CON-009 (the closed four-value list the filter offers),
CON-015 (the category is a directory column that also filters, and drives no access decision),
CON-016 (a worker with no category still appears, with the field blank), CON-020 (corporate data
only, no private personal information), CON-021 (category stored as a link, never a duplicate of the
employee).

**CON-015's two halves, stated separately.** The *permissive* half: the worker category is rendered as
a directory column and the result set is filterable by it. The *prohibitive* half: it drives no access
decision — no authorization, no visibility rule, no withholding of an entry. The filter narrows a
result set the employee may already see in full; it never removes an entry the employee would
otherwise be entitled to see. This is the position the Software Architecture Document takes for
COMP-005, and the two artifacts now read the same way.

```plantuml
@startuml
title UC-011 Search Employee Directory - LDAP read, the category filter and the R001 empty-attribute case

|Employee|
start
:Enter a search term - name, department or office;
:Optionally narrow by worker category
 (Full-time, Part-time, Contractor, Intern) (CON-009);

|Portal|
:Query Active Directory over LDAP (CON-003);
note right
  Read-only. No local copy, no cache,
  no sync (CON-003, CON-021).
end note

|Active Directory|
:Return matching entries with the six
declared attributes;
note right
  name, job title, department, office,
  email, extension (FR-011).
end note

|Portal|
if (network reachable?) then (yes)
  :Join the portal-owned worker category (CON-021);
  if (category filter set?) then (yes)
    :Narrow the result set to that category;
    note right
      CON-015 permissive half: the category is a
      directory column that also filters. A display
      filter over a result set the employee may
      already see in full - not an access decision.
    end note
  else (no)
    :Render the full result set;
  endif
  :Render each entry with seven fields;
  if (job title or extension empty?) then (yes)
    :Render the field blank;
    note right
      R001: the attribute may not be filled
      consistently across the 3 offices.
      The row still renders and the employee
      is still found.
    end note
  else (no)
    :Render the field value;
  endif
  |Employee|
  :See the results;
  stop
else (no)
  |Portal|
  :Show a no-connection message (FR-014);
  note right
    No stale or partial results.
    Nothing is cached, so there is
    nothing to fall back to.
  end note
  |Employee|
  :See the no-connection message;
  stop
endif
@enduml
```

### Remaining use cases — outline

The RequirementsSpecifier details these in Elaboration. Each entry states the actor goal, the trigger,
the observable outcome and the rules it binds — which is what Inception owes and what the detailing
pass needs.

| UC | Actor goal | Trigger | Observable outcome | Rules bound |
|---|---|---|---|---|
| UC-002 View Own Clocking History | See my own hours for the current month | Employee opens their history | The employee's own effective pairs for the current month, resolved over supersession, and no one else's | CON-011, CON-012 |
| UC-003 View All Employee Clockings | See everyone's clockings | HR opens the clocking view | Every employee's effective pairs, resolved over supersession, filterable by employee and date | CON-011, CON-012, MECH-02 |
| UC-005 Correct or Insert Clocking | Fix a clocking an employee forgot | HR corrects or inserts a clocking | A new audited event row naming the row it supersedes and carrying the previous value; the original is never overwritten or deleted | CON-013, CON-017, MECH-02, MECH-03 |
| UC-006 Publish News | Announce something to the company | HR submits a news item | The item is visible to employees, with author and timestamp audited | CON-010, CON-014, CON-018; news-category list (FR-006), MECH-02, MECH-03 |
| UC-007 Edit Published News | Correct a published item | HR edits a published item | The item shows the new content; the edit is audited with who and when | CON-010, CON-014, CON-018, MECH-02, MECH-03 |
| UC-008 Unpublish News | Withdraw an item without destroying it | HR unpublishes an item | The item is hidden from employees and still present in the database | CON-014, CON-019, MECH-02, MECH-03 |
| UC-010 Read and Filter News | Read the news that matters to me | Employee opens the main page | News sorted by date, filterable by category, with the featured item in a banner; read-only | CON-014; news-category list (FR-010) |
| UC-012 Assign or Clear Worker Category | Record what kind of worker someone is | HR sets or clears a category from the directory screen | The category is stored as a link and the change is audited; the only write the portal makes about a person | CON-009, CON-015, CON-016, CON-021, MECH-02, MECH-03 |
| UC-013 Retry Clocking Through a Network Drop | Not lose my clocking to a short outage | The POST fails while the network is down | The press is retried for up to 5 minutes and the press time is preserved; duplicates rejected by idempotency key | CON-036, CON-011 |
| UC-014 Recognize Directory Unavailable | Know the directory is unreachable rather than see wrong data | The network is unreachable during a directory search | A no-connection message; no stale or partial results | CON-003, CON-020 |
| UC-015 Recognize News Unavailable | Know the news is unreachable rather than see wrong data | The network is unreachable while reading news | A no-connection message; no stale or partial results | — (nothing is cached, so no rule is at stake) |

**The two closed lists are not interchangeable.** UC-010 filters news by the four **news categories**
(General, HR, IT, Events) declared by FR-010 and FR-006. The four **worker categories** (Full-time,
Part-time, Contractor, Intern) declared by CON-009 belong to UC-004, UC-011 and UC-012, and CON-015
confines them to the directory column — which also filters — and the export column. A worker category
appearing in UC-010's rules, or in any access decision, is a defect.

**Two detailing notes for the RequirementsSpecifier.**

- **UC-005 and UC-003 are one workflow seen from two sides.** A correction made in UC-005 is what
  UC-003 displays and what UC-004 exports as `Corrected = Y`. They are separate use cases because they
  are separate actor goals, but the correction event row is the shared element — detail it once.
- **UC-013, UC-014 and UC-015 are exception paths, not goals.** Detail them as alternative flows of
  UC-001, UC-011 and UC-010 respectively, and keep the extension use case as the traceable anchor for
  FR-013, FR-014 and FR-015. Do not give them a main flow of their own.

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
