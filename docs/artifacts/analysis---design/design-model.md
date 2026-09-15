## Document Control
| Field | Value |
|---|---|
| Phase | Elaboration |
| Status | Draft |
| Milestone Target | End-of-Elaboration (Lifecycle Architecture) — NOT YET ACHIEVED |

## Design Overview

This Design Model is co-authored: the **Designer** owns the Domain Model, Use-Case Realizations,
Design Packages and Classes, Interface Contracts, Persistent Data Classes, and Capsules/Protocols/Signals
sections; the **Database Designer** contributes the persistent-data detail; the **User Interface Designer**
owns the **Boundary Classes and Navigation Map** section (this contribution) and the UI Patterns.

This Elaboration Iter-1 contribution by the User Interface Designer delivers the **use-case storyboards**:
the user-interface realization of the critical use-case flows, for stakeholder validation against the
custom design reference (`docs/inputs/employee-portal-design.html`, CON-008). The User-Interface Prototype
optional artifact is **not triggered** this iteration (no UX-critical trigger fired per the Development
Case §5.2), so the interaction design — navigation topology, per-UC storyboard swimlanes, and Salt
wireframes — lives here in the Design Model's Boundary Classes and Navigation Map section.

## Domain Model

*Owned by the Designer — pending Elaboration contribution. The candidate persistent entities are
sketched in the Software Architecture Document (Data View): Clocking, Clocking correction/insertion
audit, News, News audit, Worker category mapping, Category audit.*

## Use-Case Realizations

*Owned by the Designer — pending Elaboration contribution. The storyboards below are the UI-layer
realization of UC-001, UC-008, UC-003, and UC-004; the Designer's class-level realizations follow.*

## Design Packages and Classes

*Owned by the Designer — pending Elaboration contribution.*

## Interface Contracts

*Owned by the Designer — pending Elaboration contribution.*

## Persistent Data Classes

*Owned by the Designer / Database Designer — pending Elaboration contribution.*

## Boundary Classes and Navigation Map

> **Contribution by the User Interface Designer (Elaboration Iter-1).** These storyboards are the
> user-interface realization of the critical use-case flows — the direct translation of each use
> case's flow of events into observable screen sequences. Every screen, transition, and wireframe
> traces to the custom design reference (`docs/inputs/employee-portal-design.html`, CON-008) — the
> authoritative visual layer. The design tokens (brand-900 `#0B3D5C` header, accent `#17A398`
> clock-in, danger `#C0392B` clock-out, warn `#E6A817` featured banner), the topbar + sidebar shell,
> the card grid, the category chips, and the person-card directory layout are all taken verbatim
> from that reference.

### Navigation Topology (screen state machine)

The formal definition of every screen in the portal and the conditions under which navigation
transitions fire. Every screen is a state; every user action causing a screen change is a directed
edge with a guard condition. HR-only screens are gated by AD group membership (NFR-005).

```plantuml
@startuml
hide empty description
[*] --> Login : open portal
Login --> Home : Keycloak OIDC success (CON-006)
Login --> Login : auth failure (retry)

state "Home (clocking widget + featured news)" as Home
state "Clocking History" as Hist
state "News (read/filter)" as News
state "Directory (search)" as Dir
state "Publish News" as Pub
state "Edit News" as Edit
state "Clocking Report (CSV)" as Rep
state "Manage Directory (category)" as Mgr
state "Correct/Insert Clocking" as Corr

Home --> Hist : "My clocking history"
Home --> News : "News"
Home --> Dir : "Directory"
Home --> Pub : "Publish news" [HR only]
Home --> Rep : "Clocking report" [HR only]
Home --> Mgr : "Manage directory" [HR only]
Home --> Login : "Sign out"

News --> Edit : "Edit" [HR only]
News --> Pub : "Publish" [HR only]
Dir --> Mgr : "Assign/Clear category" [HR only]
Hist --> Corr : "Correct/Insert" [HR only]
Rep --> Hist : "back"

Pub --> News : "published"
Edit --> News : "saved"
Mgr --> Dir : "saved"
Corr --> Hist : "saved"

note right of Home
  Clocking button toggles In (green) / Out (red)
  per current status (UC-001).
end note

note right of Pub
  HR-only screens gated by AD group
  membership (NFR-005).
end note
@enduml
```

**Navigation completeness check:** every screen is reachable from Home; the only terminal state is
`Login` (via "Sign out"); no dead-end screens — every HR action screen returns to its parent list
(Pub/Edit → News, Mgr → Dir, Corr → Hist, Rep → Hist). The offline-retry path (AC-005) and the
"no connection" message for directory/news are transient states rendered within Home/News/Dir, not
separate screens.

### Storyboard — UC-001 Clock In/Out (primary screen)

```plantuml
@startuml
|Employee|
start
:Opens portal (corporate browser);
|System (UI)|
:Keycloak OIDC redirect → login;
:Load main screen;
if (Open clocking?) then (yes)
  :Render "Clock Out" (red)\n+ "Present since HH:MM" chip;
else (no)
  :Render "Clock In" (green);
endif
|Employee|
:Presses clock button;
|System (UI)|
:Client stamps press time + idempotency key (CON-021);
:POST /clocking;
if (Network OK?) then (yes)
  if (Duplicate key?) then (yes)
    :Return existing result (CON-021);
  else (no)
    :Persist clocking (UTC, CON-014);
    :Show confirmation;
    :Flip button state;
    :Refresh history table;
  endif
else (no)
  :Hold press in localStorage;
  :Retry ≤ 5 min (AC-005);
  if (> 5 min?) then (yes)
    :Show "report to HR" message;
  endif
endif
stop
@enduml
```

### Storyboard — UC-008 Search Directory

```plantuml
@startuml
|Employee|
start
:Opens Directory;
:Enters search term (name/department/office);
|System (UI)|
:Read 6 AD fields on demand (CON-007);
:Read worker category from portal mapping;
:Filter matches;
if (Match?) then (yes)
  :Render person cards\n(name, title, dept, office, email, ext, category);
else (no)
  :Render "no match" message;
endif
|Employee|
:Views result (≤ 10 s — AC-003);
stop
@enduml
```

### Storyboard — UC-003 Publish News

```plantuml
@startuml
|HR Administrator|
start
:Opens "Publish news";
:Enters title, body, date, category;
if (Mark featured?) then (yes)
  :Checks "Featured";
endif
:Submits;
|System (UI)|
:Validate required fields;
if (Valid?) then (yes)
  if (Featured?) then (yes)
    :Un-feature previous item (CON-015);
  endif
  :Persist with author + timestamp (NFR-004);
  :Show confirmation;
  :Item appears newest-first;
else (no)
  :Show validation error;
endif
stop
@enduml
```

### Storyboard — UC-004 Read & Filter News

```plantuml
@startuml
|Employee|
start
:Opens main page;
|System (UI)|
:Load published news (newest first);
if (Featured item?) then (yes)
  :Render featured banner at top;
else (no)
  :No banner;
endif
|Employee|
:Optionally filters by category (General/HR/IT/Events);
|System (UI)|
if (Filter?) then (yes)
  :Re-list matching category;
else (no)
  :Show all;
endif
|Employee|
:Reads news (read-only);
stop
@enduml
```

### Wireframes — primary screens (Salt)

**Home (clocking widget + featured news):**

```plantuml
@startsalt
{
  {T
  + Employee Portal · Cuba Corp                    | MT · Miguel Torres · Engineering · Havana | Sign out
  }
  {
    {S
    + Home
    + Clock In/Out
    + News
    + Directory
    --
    + HR Administrator
    + Publish news
    + Clocking report
    + Manage directory
    }
    |
    {
      {^"Good morning, Miguel"
      "Monday, June 22 · 08:14 · Corporate network"
      }
      {
        {T
        + Today's clocking
        ++ Present since 08:02
        }
        {^"08:14"
        [ ■ Clock Out ]
        "Clock-in recorded today at 08:02. Press \"Clock Out\" when your shift ends."
        }
      }
      {
        {T
        + Featured
        }
        {^"★ HR — New summer schedule starting July 1"
        "Compressed hours 7:00–15:00 Mon–Fri."
        "View all news →"
        }
      }
    }
  }
}
@endsalt
```

**Directory (person cards):**

```plantuml
@startsalt
{
  {T
  + Employee directory
  }
  {
    {^"Search by name…" | "All departments" | "All offices" | [ Search ]
    }
    {
      {T
      + LG · Laura Gómez · HR Director
      ++ Department | HR
      ++ Office | Havana
      ++ Email | l.gomez@cubacorp.cu
      ++ Extension | 1201
      }
      {T
      + MT · Miguel Torres · Software Engineer
      ++ Department | Engineering
      ++ Office | Havana
      ++ Email | m.torres@cubacorp.cu
      ++ Extension | 1450
      }
      {T
      + AR · Ana Ramírez · IT Analyst
      ++ Department | IT
      ++ Office | Santiago
      ++ Email | a.ramirez@cubacorp.cu
      ++ Extension | 2310
      }
    }
  }
}
@endsalt
```

**Clocking history (table):**

```plantuml
@startsalt
{
  {T
  + My clocking history — June 2026
  ++ [ ⬇ Export CSV (HR) ]
  }
  {
    {r
    Date | Clock In | Clock Out | Hours | Status
    Mon Jun 22 | 08:02 | — | — | In progress
    Fri Jun 19 | 07:58 | 17:03 | 9h 05m | Complete
    Thu Jun 18 | 08:10 | 17:00 | 8h 50m | Complete
    Wed Jun 17 | 08:05 | 16:58 | 8h 53m | Complete
    }
  }
}
@endsalt
```

**Publish news (HR form):**

```plantuml
@startsalt
{
  {T
  + Publish news
  }
  {
    {^"Title"
    "Body"
    "Date"
    "Category" | "General"
    "☐ Featured"
    [ Publish ]
    }
  }
}
@endsalt
```

### Storyboard coverage and validation notes

| UC | Storyboard | Wireframe | Notes |
|---|---|---|---|
| UC-001 Clock In/Out | ✓ swimlane | ✓ Home + history | Button toggles In/Out; offline-retry (AC-005) is a transient state, not a screen |
| UC-008 Search Directory | ✓ swimlane | ✓ Directory | AD gap (R001) renders blank field; ≤ 10 s lookup (AC-003) |
| UC-003 Publish News | ✓ swimlane | ✓ Publish form | Featured checkbox triggers CON-015 un-feature |
| UC-004 Read & Filter News | ✓ swimlane | ✓ Home (banner) | Featured banner + category chips; read-only |

The remaining UCs (UC-002, UC-005…UC-007, UC-009…UC-012) reuse the same screens and interaction
patterns already storyboarded: UC-002/UC-011/UC-012 operate on the Clocking History screen;
UC-005/UC-006/UC-007 operate on the News screen; UC-009/UC-010 operate on the Directory screen.
Their flows are fully specified in the Use-Case Model's Use-Case Specifications section with
activity diagrams; no new screen is introduced by them, so no additional storyboard is required.

**Validation feedback (this iteration):** storyboards are presented to stakeholders for validation
against the custom design reference (CON-008). Feedback is captured in the Review Record at the
end of this iteration and folded into the next iteration's storyboards.

## Capsules, Protocols and Signals

*Owned by the Designer — pending Elaboration contribution.*

## Traceability

| Element | Traces From | Link Type | Traces To |
|---|---|---|---|
| Navigation Topology (screens) | UC-001…UC-012, CON-008 | Derives | Boundary Classes (Designer, pending) |
| Storyboard UC-001 | UC-001, FR-001, CON-021, AC-005 | Derives | Clocking subsystem (SAD) |
| Storyboard UC-008 | UC-008, FR-008, CON-007, R001 | Derives | Directory subsystem (SAD) |
| Storyboard UC-003 | UC-003, FR-003, CON-015, NFR-004 | Derives | News subsystem (SAD) |
| Storyboard UC-004 | UC-004, FR-004, CON-015 | Derives | News subsystem (SAD) |
| Wireframes (Home/Directory/History/Publish) | CON-008 (custom design reference) | Derives | Implementer (Construction) |
