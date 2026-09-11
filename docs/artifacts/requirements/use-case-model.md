## Document Control

| Field | Value |
|---|---|
| Project | Portal |
| Phase | Inception |
| Iteration | 2 |
| Status | Draft |
| Milestone Target | End-of-Inception review |

## Use-Case Diagram

```plantuml
@startuml Portal_System_Boundary
left to right direction
skinparam linetype ortho

rectangle "Employee Portal" {
  usecase "UC-001\nAssign Worker Category" as UC001
  usecase "UC-002\nClear Worker Category" as UC002
  usecase "UC-003\nClock In / Clock Out" as UC003
  usecase "UC-004\nView Own Clocking History" as UC004
  usecase "UC-005\nView All Employee Clockings" as UC005
  usecase "UC-006\nExport Monthly Clocking Report" as UC006
  usecase "UC-007\nCorrect or Insert Clocking" as UC007
  usecase "UC-008\nPublish News Item" as UC008
  usecase "UC-009\nEdit News Item" as UC009
  usecase "UC-010\nUnpublish News Item" as UC010
  usecase "UC-011\nBrowse and Filter News" as UC011
  usecase "UC-012\nSearch Corporate Directory" as UC012

  usecase "AUTH\nAuthenticate via Keycloak" as AUTH <<include>>
  usecase "AUTHZ\nAuthorize HR role" as AUTHZ <<include>>
  usecase "AUDIT\nAudit log action" as AUDIT <<include>>
}

actor "Employee" as Employee
actor "HR Administrator" as HR

Employee --> UC003
Employee --> UC004
Employee --> UC011
Employee --> UC012

HR --> UC001
HR --> UC002
HR --> UC005
HR --> UC006
HR --> UC007
HR --> UC008
HR --> UC009
HR --> UC010

actor "Keycloak" as Keycloak <<external system>>
actor "Active Directory" as AD <<external system>>

Keycloak -left-> AUTH : provides OIDC
AD -left-> UC012 : reads directory
AD -left-> UC001 : identifies employee
AD -left-> UC002 : identifies employee

note right of UC003
  Client-sent timestamp + idempotency key
  localStorage retry up to 5 minutes
end note

note bottom of UC012
  Read-only LDAP projection;
  worker category from portal DB
end note

note top of AUTH
  All use cases include Authentication
end note

UC001 ..> AUTH : <<include>>
UC002 ..> AUTH : <<include>>
UC003 ..> AUTH : <<include>>
UC004 ..> AUTH : <<include>>
UC005 ..> AUTH : <<include>>
UC006 ..> AUTH : <<include>>
UC007 ..> AUTH : <<include>>
UC008 ..> AUTH : <<include>>
UC009 ..> AUTH : <<include>>
UC010 ..> AUTH : <<include>>
UC011 ..> AUTH : <<include>>
UC012 ..> AUTH : <<include>>

UC001 ..> AUTHZ : <<include>>
UC002 ..> AUTHZ : <<include>>
UC005 ..> AUTHZ : <<include>>
UC006 ..> AUTHZ : <<include>>
UC007 ..> AUTHZ : <<include>>
UC008 ..> AUTHZ : <<include>>
UC009 ..> AUTHZ : <<include>>
UC010 ..> AUTHZ : <<include>>

UC001 ..> AUDIT : <<include>>
UC002 ..> AUDIT : <<include>>
UC007 ..> AUDIT : <<include>>
UC008 ..> AUDIT : <<include>>
UC009 ..> AUDIT : <<include>>
UC010 ..> AUDIT : <<include>>

@enduml
```

## Actors

| ID | Actor | Type | Description |
|---|---|---|---|
| A-001 | Employee | Human | Cuba Corp employee who clocks in/out, views own clocking history, browses news, and searches the corporate directory. Derived from STK-004. |
| A-002 | HR Administrator | Human | Member of the HR AD group who manages worker categories, oversees all clockings, exports reports, corrects clockings, and manages news. Derived from STK-001 (HR role) and NFR-006. |
| A-003 | Keycloak | External System | Existing OIDC provider for authentication and AD group claims. Derived from CON-004, CON-005, NFR-006. |
| A-004 | Active Directory | External System | Existing LDAP directory that is the system of record for employee attributes. Derived from CON-006, CON-010. |

## Use-Case Survey

| ID | Use Case | Primary Actor | Source | Priority | Volatility | Status |
|---|---|---|---|---|---|---|
| UC-001 | Assign Worker Category | HR Administrator | FR-001 | Must | Low | Outlined |
| UC-002 | Clear Worker Category | HR Administrator | FR-002 | Must | Low | Outlined |
| UC-003 | Clock In / Clock Out | Employee | FR-003, NFR-007 | Must | Low | Detailed (architecturally significant) |
| UC-004 | View Own Clocking History | Employee | FR-004 | Must | Low | Outlined |
| UC-005 | View All Employee Clockings | HR Administrator | FR-005 | Must | Low | Outlined |
| UC-006 | Export Monthly Clocking Report | HR Administrator | FR-006 | Must | Low | Outlined |
| UC-007 | Correct or Insert Clocking | HR Administrator | FR-007, CON-020 | Must | Low | Detailed (architecturally significant) |
| UC-008 | Publish News Item | HR Administrator | FR-008, CON-019 | Must | Medium | Detailed (architecturally significant) |
| UC-009 | Edit News Item | HR Administrator | FR-009, CON-019 | Must | Medium | Outlined |
| UC-010 | Unpublish News Item | HR Administrator | FR-010, CON-019 | Must | Medium | Outlined |
| UC-011 | Browse and Filter News | Employee | FR-011 | Must | Low | Outlined |
| UC-012 | Search Corporate Directory | Employee | FR-012, CON-010 | Must | Low | Detailed (architecturally significant) |

## Use-Case Specifications

### UC-003 Clock In / Clock Out

**Source:** FR-003, NFR-007
**Primary Actor:** Employee (A-001)
**Trigger:** Employee opens the portal main page and presses the Clock In or Clock Out button.
**Precondition:** Employee is authenticated via Keycloak OIDC.
**Postcondition:** A clocking event is recorded with the client-sent timestamp and an idempotency key; duplicates are rejected.

**Main Flow:**
1. System displays the main page with a button labeled "Clock In" if the employee has no open clocking, or "Clock Out" if a clocking is open.
2. Employee presses the button.
3. Browser captures the exact local timestamp of the button press (Europe/Madrid).
4. Browser generates a unique idempotency key for this button press. The key is scoped to the employee and the press timestamp (e.g., a UUID combined with the employee AD identifier and the client timestamp) so that the same physical action cannot be recorded twice.
5. Browser attempts to POST the event to the server.
6. Server validates the OIDC token and records the event with the client-sent timestamp and idempotency key.
7. Server returns a confirmation to the browser.
8. Browser displays the confirmation to the employee.

**Alternative Flows:**
- **A1 Network unavailable:** If the POST fails due to network outage, the browser stores the event (timestamp + idempotency key) in localStorage and retries the POST for up to 5 minutes. When the network returns, the retry succeeds and the stored entry is cleared.
- **A2 Duplicate detected:** If the server receives a request with an idempotency key it has already processed, it returns the existing response without creating a new record.
- **A3 Retry exhausted:** If the network outage exceeds 5 minutes, the browser stops retrying and instructs the employee to report the clocking to HR.

**Business Rules:**
- CON-021: All timestamps are stored in UTC and displayed in Europe/Madrid.
- NFR-007: Retry window is exactly 5 minutes.

**Volatility:** Low

**Activity Diagram:**

```plantuml
@startuml UC003_Clock_In_Out_Activity
start
:Employee opens portal main page;
if (Authenticated via Keycloak?) then (no)
  :Redirect to Keycloak OIDC login;
  :Return authenticated;
else (yes)
endif
:System shows Clock In or Clock Out button
based on open clocking state;
:Employee presses button;
:Browser captures client timestamp (Europe/Madrid);
:Browser generates idempotency key
(employee AD id + timestamp + UUID);
:Browser attempts POST to server;
if (Network available?) then (yes)
  :Server validates OIDC token;
  if (Idempotency key already processed?) then (yes)
    :Return existing response;
  else (no)
    :Record clocking with client timestamp;
    :Return confirmation;
  endif
  :Browser displays confirmation;
else (no)
  :Store event in localStorage;
  while (Retry elapsed < 5 minutes?) is (yes)
    :Wait and retry POST;
    if (Network returns?) then (yes)
      :Server records clocking;
      :Clear localStorage entry;
      :Display confirmation;
      stop
    else (no)
    endif
  endwhile (no)
  :Stop retrying;
  :Show message: report clocking to HR;
endif
stop
@enduml
```

---

### UC-006 Export Monthly Clocking Report

**Source:** FR-006
**Primary Actor:** HR Administrator (A-002)
**Trigger:** HR Administrator selects a month and requests CSV export.
**Precondition:** HR Administrator is authenticated and belongs to the HR AD group.
**Postcondition:** A CSV file is generated with the exact columns and timezone specified in FR-006.

**Main Flow:**
1. HR Administrator opens the all-clockings view.
2. HR Administrator selects a calendar month.
3. HR Administrator chooses "Export CSV".
4. System retrieves all clocking events for the month (00:00 first day to 23:59:59 last day, Europe/Madrid).
5. For each employee and date, system computes the effective ClockIn and ClockOut values. If corrections exist, the latest correction for that date is used; original records are never overwritten (CON-020).
6. System computes HoursWorked as the elapsed time between the effective ClockIn and ClockOut for that date, expressed in hours. If ClockOut is missing, HoursWorked is left blank.
7. System generates a CSV with columns in order: EmployeeId, FullName, WorkerCategory, Date, ClockIn, ClockOut, HoursWorked, Corrected.
8. System returns the file for download.

**Alternative Flows:**
- **A1 No clockings in month:** System generates a CSV containing only the header row.

**Business Rules:**
- FR-006: Exact column order and Europe/Madrid local time.
- CON-020: Original records are preserved; corrections create new audited entries.
- CON-021: All offices in Europe/Madrid.

**Volatility:** Low

---

### UC-007 Correct or Insert Clocking

**Source:** FR-007, CON-020
**Primary Actor:** HR Administrator (A-002)
**Trigger:** HR Administrator selects an employee and chooses to correct an existing clocking or insert a missing one.
**Precondition:** HR Administrator is authenticated and belongs to the HR AD group.
**Postcondition:** A new audited correction/insertion entry is created; the original record remains unchanged.

**Main Flow:**
1. HR Administrator navigates to the all-clockings view.
2. System displays clocking records for the selected period.
3. HR Administrator selects an employee and a date.
4. HR Administrator chooses "Correct" on an existing clocking or "Insert" for a missing one.
5. System presents a form with the current value (if correcting) or empty fields (if inserting).
6. HR Administrator enters the corrected/inserted timestamp(s) and a free-text reason.
7. System records a new correction entry containing: who made the change, when, the previous value, the new value, and the reason.
8. System updates the effective clocking view for that employee/date.
9. System confirms the correction to HR Administrator.

**Alternative Flows:**
- **A1 Missing original:** If the employee never clocked on the selected date, the "Correct" option is unavailable; only "Insert" is offered.
- **A2 Reason not provided:** System rejects the submission and prompts for a reason.

**Business Rules:**
- CON-020: Original records are never overwritten or deleted.
- NFR-004: Every correction is audited with author and timestamp.

**Volatility:** Low

**Activity Diagram:**

```plantuml
@startuml UC007_Correct_Insert_Clocking_Activity
start
:HR Administrator opens all-clockings view;
if (Authenticated and in HR AD group?) then (no)
  :Deny access;
  stop
else (yes)
endif
:System displays clocking records for selected period;
:HR Administrator selects employee and date;
if (Existing clocking for date?) then (yes)
  :Present "Correct" option;
  :HR Administrator chooses Correct;
  :System shows current value;
else (no)
  :Present "Insert" option;
  :HR Administrator chooses Insert;
  :System shows empty fields;
endif
:HR Administrator enters timestamp(s) and reason;
if (Reason provided?) then (no)
  :Reject submission and prompt for reason;
  stop
else (yes)
endif
:System creates new correction/insertion entry
with who, when, previous value, new value, reason;
:System updates effective clocking view;
:System confirms correction to HR Administrator;
stop
@enduml
```

---

### UC-008 Publish News Item

**Source:** FR-008, CON-019
**Primary Actor:** HR Administrator (A-002)
**Trigger:** HR Administrator chooses to publish a new internal news item.
**Precondition:** HR Administrator is authenticated and belongs to the HR AD group.
**Postcondition:** A published news item is visible to employees; at most one item is featured.

**Main Flow:**
1. HR Administrator opens the news management page.
2. System presents the publish form with fields: title, body, date, category (General, HR, IT, Events), and a "featured" checkbox.
3. HR Administrator fills the form and submits.
4. System validates the inputs.
5. If the "featured" flag is set, system clears the featured flag from any currently featured item.
6. System stores the news item with author and timestamp.
7. System confirms publication to HR Administrator.

**Alternative Flows:**
- **A1 Featured flag not set:** The item is published without changing the current featured item.
- **A2 Validation fails:** System returns the form with error messages.

**Business Rules:**
- CON-019: At most one news item is featured at any moment.
- NFR-004: Publication is audited with author and timestamp.

**Volatility:** Medium

**Activity Diagram:**

```plantuml
@startuml UC008_Publish_News_Item_Activity
start
:HR Administrator opens news management page;
if (Authenticated and in HR AD group?) then (no)
  :Deny access;
  stop
else (yes)
endif
:System presents publish form
(title, body, date, category, featured flag);
:HR Administrator fills form and submits;
if (Validation fails?) then (yes)
  :Return form with error messages;
  stop
else (no)
endif
if (Featured flag set?) then (yes)
  :Clear featured flag from current featured item;
else (no)
endif
:System stores news item with author and timestamp;
:System confirms publication;
stop
@enduml
```

---

### UC-009 Edit News Item

**Source:** FR-009, NFR-004, CON-019
**Primary Actor:** HR Administrator (A-002)
**Trigger:** HR Administrator selects a published news item and edits it.
**Precondition:** HR Administrator is authenticated and belongs to the HR AD group; the news item is published.
**Postcondition:** The news item is updated; edits are audited; the CON-019 invariant (at most one featured item) holds.

**Main Flow:**
1. HR Administrator opens the news management page.
2. System lists published news items.
3. HR Administrator selects an item and chooses "Edit".
4. System presents the edit form pre-filled with current values, including the current featured flag state.
5. HR Administrator modifies fields and submits.
6. System validates inputs.
7. If the featured flag is set on this item, system clears the featured flag from any other currently featured item so that this item becomes the sole featured item.
8. If the featured flag is cleared on the currently featured item, the banner disappears and no other item is automatically promoted.
9. System records the edit with author and timestamp.
10. System confirms the edit.

**Alternative Flows:**
- **A1 Validation fails:** System returns the form with error messages.
- **A2 Unpublish during edit:** If HR Administrator chooses to unpublish instead, UC-010 applies.

**Business Rules:**
- CON-019: At most one featured news item at any moment; featuring one item always un-features the previous one; unpublishing the featured item un-features it and does not promote another.
- NFR-004: Every edit is audited with author and timestamp.

**Volatility:** Medium

---

### UC-010 Unpublish News Item

**Source:** FR-010, NFR-004, CON-019
**Primary Actor:** HR Administrator (A-002)
**Trigger:** HR Administrator selects a published news item and unpublishes it.
**Precondition:** HR Administrator is authenticated and belongs to the HR AD group; the news item is published.
**Postcondition:** The item is hidden but retained; if it was featured, the banner disappears and no other item is promoted.

**Main Flow:**
1. HR Administrator opens the news management page.
2. System lists published news items.
3. HR Administrator selects an item and chooses "Unpublish".
4. System confirms the action.
5. If the item was featured, system clears the featured flag.
6. System marks the item as unpublished.
7. System records the unpublish action with author and timestamp.
8. System confirms the action to HR Administrator.

**Alternative Flows:**
- **A1 Already unpublished:** The "Unpublish" option is unavailable.

**Business Rules:**
- CON-019: Unpublishing the featured item un-features it; no automatic promotion.
- NFR-004: Unpublish is audited with author and timestamp.

**Volatility:** Medium

---

### UC-012 Search Corporate Directory

**Source:** FR-012, CON-010, CON-012
**Primary Actor:** Employee (A-001)
**Trigger:** Employee opens the directory page and enters search criteria.
**Precondition:** Employee is authenticated via Keycloak OIDC.
**Postcondition:** Directory results matching the criteria are displayed, with AD-sourced fields and portal-managed worker category.

**Main Flow:**
1. Employee navigates to the directory page.
2. System reads employee attributes from Active Directory over LDAP on demand.
3. System joins AD attributes with the portal-managed worker category stored in PostgreSQL.
4. System displays the directory list with columns: name, job title, department, office, email, extension phone number, and worker category.
5. Employee enters search/filter terms (name, department, office, or worker category).
6. System filters the displayed results.

**Alternative Flows:**
- **A1 AD attribute missing:** The corresponding field is displayed blank; the entry still appears.
- **A2 Worker category blank:** The category column is blank; the entry still appears.

**Business Rules:**
- CON-010: Employee data is read from AD on demand; no local copy of AD attributes.
- CON-012: AD-sourced fields are read-only in the portal.
- CON-017: Worker category is one of Full-time, Part-time, Contractor, Intern, or blank.

**Volatility:** Low

**Activity Diagram:**

```plantuml
@startuml UC012_Search_Corporate_Directory_Activity
start
:Employee opens directory page;
if (Authenticated via Keycloak?) then (no)
  :Redirect to Keycloak OIDC login;
  :Return authenticated;
else (yes)
endif
:System reads employee attributes from AD over LDAP on demand;
:System joins AD attributes with portal-managed worker category;
:System displays directory list;
:Employee enters search/filter terms
(name, department, office, worker category);
:System filters displayed results;
if (AD attribute missing?) then (yes)
  :Display field blank;
else (no)
endif
if (Worker category blank?) then (yes)
  :Display category column blank;
else (no)
endif
stop
@enduml
```

---

### UC-001 Assign Worker Category

**Source:** FR-001, NFR-005
**Primary Actor:** HR Administrator (A-002)
**Trigger:** HR Administrator selects an employee in the directory and assigns a worker category.
**Precondition:** HR Administrator is authenticated and belongs to the HR AD group; employee exists in Active Directory.
**Postcondition:** The employee's worker category is updated and audited.
**Main Flow:**
1. HR Administrator opens the directory page.
2. System displays directory entries with current worker category (blank if none).
3. HR Administrator selects an employee and chooses "Assign category".
4. System presents the closed list of categories: Full-time, Part-time, Contractor, Intern.
5. HR Administrator selects a category and confirms.
6. System records the assignment with author and timestamp.
**Alternative Flows:**
- **A1 Category already set:** The new assignment overwrites the previous value; both old and new values are recorded in the audit trail.
**Business Rules:**
- CON-017: Worker categories are a closed list of four values.
- NFR-005: Every category change is audited with author and timestamp.
**Volatility:** Low

### UC-002 Clear Worker Category

**Source:** FR-002, NFR-005
**Primary Actor:** HR Administrator (A-002)
**Trigger:** HR Administrator selects an employee in the directory and clears the worker category.
**Precondition:** HR Administrator is authenticated and belongs to the HR AD group; employee exists in Active Directory.
**Postcondition:** The employee's worker category is empty and the change is audited.
**Main Flow:**
1. HR Administrator opens the directory page.
2. System displays directory entries with current worker category.
3. HR Administrator selects an employee with a category and chooses "Clear category".
4. System confirms the action.
5. System clears the category and records the change with author, timestamp, and previous value.
**Alternative Flows:**
- **A1 No category set:** The "Clear category" option is unavailable.
**Business Rules:**
- NFR-005: Every category change is audited with author and timestamp.
**Volatility:** Low

### UC-004 View Own Clocking History

**Source:** FR-004
**Primary Actor:** Employee (A-001)
**Trigger:** Employee opens the clocking history page.
**Precondition:** Employee is authenticated via Keycloak OIDC.
**Postcondition:** The employee sees their own clockings for the current month.
**Main Flow:**
1. Employee navigates to the clocking history page.
2. System determines the current calendar month (Europe/Madrid).
3. System retrieves the employee's clocking events for that month.
4. System displays the list with date, clock-in, clock-out, and corrected indicator.
**Alternative Flows:**
- **A1 No clockings this month:** System displays an empty list with a message.
**Business Rules:**
- CON-021: Timestamps displayed in Europe/Madrid.
**Volatility:** Low

### UC-005 View All Employee Clockings

**Source:** FR-005
**Primary Actor:** HR Administrator (A-002)
**Trigger:** HR Administrator opens the all-clockings view.
**Precondition:** HR Administrator is authenticated and belongs to the HR AD group.
**Postcondition:** HR Administrator sees all employees' clockings for the selected period.
**Main Flow:**
1. HR Administrator navigates to the all-clockings view.
2. System displays a period selector (default current month).
3. System retrieves all clocking events for the selected period.
4. System displays the list with employee name, date, clock-in, clock-out, and corrected indicator.
**Alternative Flows:**
- **A1 No clockings in period:** System displays an empty list.
**Volatility:** Low

### UC-011 Browse and Filter News

**Source:** FR-011
**Primary Actor:** Employee (A-001)
**Trigger:** Employee opens the main page or news section.
**Precondition:** Employee is authenticated via Keycloak OIDC.
**Postcondition:** Published news is displayed newest-first; category filter works; featured banner appears if a featured item exists.
**Main Flow:**
1. Employee navigates to the main page / news section.
2. System retrieves published news items.
3. System displays the featured item in a banner at the top (if any).
4. System displays remaining published items sorted by date, newest first.
5. Employee selects a category filter (General, HR, IT, Events).
6. System filters the list to the selected category.
**Alternative Flows:**
- **A1 No featured item:** Banner area is not displayed.
- **A2 No news in category:** System displays an empty list message.
**Volatility:** Low

## Traceability

| Element | Traces From | Link Type | Traces To |
|---|---|---|---|
| UC-001 | FR-001, NFR-005 | Derives | F-001 |
| UC-002 | FR-002, NFR-005 | Derives | F-001 |
| UC-003 | FR-003, NFR-007 | Derives | F-002 |
| UC-004 | FR-004 | Derives | F-003 |
| UC-005 | FR-005 | Derives | F-004 |
| UC-006 | FR-006 | Derives | F-004 |
| UC-007 | FR-007, CON-020 | Derives | F-005 |
| UC-008 | FR-008, CON-019, NFR-004 | Derives | F-006 |
| UC-009 | FR-009, CON-019, NFR-004 | Derives | F-007 |
| UC-010 | FR-010, CON-019, NFR-004 | Derives | F-008 |
| UC-011 | FR-011 | Derives | F-009 |
| UC-012 | FR-012, CON-010 | Derives | F-010 |
