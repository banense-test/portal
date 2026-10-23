## Document Control
- **Phase:** Inception
- **Status:** Draft — iteration 2, submitted for review
- **Milestone Target:** End of Inception (not yet achieved)

## Test Scope
### Evaluation Mission — Inception iteration 1

The Evaluation Mission is the agreement with the stakeholders on the purpose, focus and acceptable
outcome of the test effort for this iteration. It is stated before any test is designed, and the
iteration is judged against it — not against a coverage percentage.

| Element | Statement |
|---|---|
| **Purpose** | Establish a test position the project can be held to: what will be tested, against what, at which level, and what evidence will count as proof. Inception produces no working software, so the mission is to make the test effort *decidable* in Elaboration and Construction, not to prove the system works |
| **Focus** | The four architecturally significant use cases detailed this iteration — UC-001, UC-004, UC-009, UC-011 — and the four risks that decide whether the test effort can succeed at all: R001, R004, R006, R008 |
| **Acceptable outcome** | Every one of the 15 use cases has a named test level and a named iteration in which it is executed; the stand-in fixture requirement that retires R001 is recorded as a test obligation, not a convention; the defect record and the quality signals are named; the test framework gap is carried as an Elaboration obligation with an owner |
| **Not the outcome** | A pass rate. No test is executed this iteration and none can be. A mission that claimed otherwise would be reporting a result that does not exist |

**Why the mission is scoped this way.** The declared scope is constraint-dense — 36 constraints
against 15 requirements — so the stakeholder has already fixed most behaviour. The test effort's
value is therefore *conformance evidence*: proving the system does exactly what CON-001 to CON-036
say, and proving it against the stand-ins that CON-031 makes the team's entire integration surface.
That is a different mission from exploratory testing, and it is the one this project needs.

### Test effort workflow

```plantuml
@startuml
title Portal - Test effort workflow: Evaluation Mission per iteration

|Test Manager|
start
:Read the iteration's increment from the Iteration Plan;
:State the Evaluation Mission for this iteration;
note right
  Purpose, focus, acceptable outcome.
  Agreed with the stakeholders before
  any test is designed.
end note

|Test Analyst|
:Derive test ideas from the use cases in scope;
note right
  Coverage is measured against UC-NNN,
  not against code.
end note

|Test Designer|
:Design TC-NNN test cases;
:Build the stand-in fixtures the cases need;
note right
  CON-031: the directory stand-in must carry
  entries with empty job title and extension.
  Without them R001 is retired untested (R004).
end note

|Tester|
:Execute against the stand-ins;
:Record the result per TC-NNN;

|Test Manager|
if (defect found?) then (yes)
  |Configuration Management|
  :Raise an SCM issue;
  note right: The issue tracker is the authoritative defect record.
  |Test Manager|
  :Track the defect to closure;
else (no)
endif

|Test Manager|
:Re-run the regression set for every prior iteration;
note right
  Regression is mandatory per iteration.
  An iteration without it accumulates
  undiscovered defect debt.
end note
:Assess the mission against its stated outcome;
if (mission met?) then (yes)
  :Record the verdict in the Test Evaluation Summary;
  :Recommend the increment to the milestone gate;
else (no)
  :Record the shortfall and the evidence;
  :Recommend another iteration;
  note right
    CON-023: the remedy for a missed
    outcome is another iteration,
    never a scope cut.
  end note
endif
stop
@enduml
```

### Coverage plan — use-case driven

Coverage is measured against the use cases, not against lines of code. Every one of the 15 declared
use cases has a named test level and a named iteration of execution, and every execution iteration
below is the iteration in which the Iteration Plan implements that use case. None is unassigned and
none is assigned to an iteration where the behaviour does not yet exist.

| UC | Source | Risk it carries | Test level | Executed in |
|---|---|---|---|---|
| UC-001 Clock In and Clock Out | FR-001 | R002 (adoption), R008 (client clock) | Component + acceptance | Iteration 5 |
| UC-002 View Own Clocking History | FR-002 | — | Component | Iteration 5 |
| UC-003 View All Employee Clockings | FR-003 | — | Component | Iteration 5 |
| UC-004 Export Monthly Clocking Report as CSV | FR-004 | R006 (column contract), R001 (empty FullName) | Component + contract | Iteration 5 — with the empty-attribute case executed in iteration 3 |
| UC-005 Correct or Insert Clocking | FR-005 | — | Component + audit | Iteration 5 |
| UC-006 Publish News | FR-006 | — | Component + acceptance | Iteration 6 |
| UC-007 Edit Published News | FR-007 | — | Component + audit | Iteration 6 |
| UC-008 Unpublish News | FR-008 | — | Component + audit | Iteration 6 |
| UC-009 Feature or Un-feature News | FR-009 | — | Component + invariant | Iteration 6 |
| UC-010 Read and Filter News | FR-010 | — | Component | Iteration 6 |
| UC-011 Search Employee Directory | FR-011 | R001 (empty attributes), R004 (fixture) | Component + acceptance | Iteration 7 — with the empty-attribute case executed in iteration 3 |
| UC-012 Assign or Clear Worker Category | FR-012 | — | Component + audit | Iteration 7 |
| UC-013 Retry Clocking Through a Network Drop | FR-013 | R008 (client clock) | Component + fault injection | Iteration 5 |
| UC-014 Recognize Directory Unavailable | FR-014 | — | Component + fault injection | Iteration 7 |
| UC-015 Recognize News Unavailable | FR-015 | — | Component + fault injection | Iteration 6 |

**The three extension use cases are tested as exception paths, not as goals.** UC-013, UC-014 and
UC-015 are the network-failure behaviour of UC-001, UC-011 and UC-010. They are executed by injecting
the failure into the parent use case's test, and they are reported separately because each carries its
own declared requirement and its own acceptance criterion (AC-005 for UC-013).

**Two scenarios execute in iteration 3, ahead of their capability area.** UC-011 A1 (empty attribute)
and UC-004 A5 (empty directory attribute) are the cases that retire R001. They need no production
code beyond the directory read path and the export derivation, so they run in the iteration that
builds the stand-ins. The full use-case tests for UC-004 and UC-011 remain in Construction with the
rest of their capability areas. This is the sequencing the Iteration Plan's risk retirement table
records, and the test effort follows it rather than the other way round.

### Coverage plan — architecture-centric quality attributes

The non-functional requirements in the Supplementary Specification define the second dimension of the
mission. Each is measured by the method the requirement itself names — not by a substitute the team
finds convenient — and in an iteration where the behaviour being measured exists.

| NFR | Requirement | How it is measured | Executed in |
|---|---|---|---|
| NFR-001a | Authenticated access — the session supplies the identity | The stand-in OIDC issuer's claim mapping is verified to supply sAMAccountName and AD group membership, and the two AD-group levels resolve to HR and to employee. This is a claim-mapping check against the stand-in, not a use-case test | Iteration 3 |
| NFR-001b | Authenticated access — every portal function requires it | Every use case implemented in the iteration is exercised unauthenticated and must be refused, and exercised with the wrong AD group and must be refused where CON-008 reserves the function to HR | Iterations 5, 6, 7 — each against the use cases that iteration implements |
| NFR-002 | Page load under 3 seconds | Full page load the employee experiences, browser request to page displayed and usable, including the clocking page's script. Server response time is not accepted as a substitute | Iteration 5 for the clocking page; iteration 7 across all pages |
| NFR-003 | Availability Monday–Friday 7:00–19:00 | Fault tolerance within the corporate network, observed inside the declared window. No 24/7 target is tested, and no redundancy beyond the network is expected | Iteration 7, confirmed in iteration 8 |
| NFR-004 | Clock in/out response under 1 second | The one operation with a sub-second target, measured on the clocking POST | Iteration 5 |
| NFR-005 | Audit trail for compliance | The five audited actions are asserted at the database, read directly — not through a screen, because no audit view screen exists. The previous value and the free-text reason are columns, not an opaque blob | Iteration 5 for clocking corrections; iteration 6 for news publication, edit and unpublish; iteration 7 for the worker-category change |

**NFR-001 is split because its two halves become executable at different points.** The claim mapping
is a property of the stand-in and can be verified the moment the stand-in exists — iteration 3. The
refusal assertion is a property of each use case and cannot be executed before that use case is
implemented. Assigning the whole requirement to one iteration would either test nothing or claim a
result that does not exist; splitting it puts each half where it can actually run.

**NFR-005 is tested at the database, and that is the point.** The audit trail is read directly from
the database by people outside the portal. A test that asserts an audit row exists through the
application proves less than a test that reads the row and checks the actor, the timestamp, the
previous value and the reason are legible without the application.

### Test levels across the lifecycle

Testing is distributed across all four phases. Deferring it to Construction is the single most
expensive planning error available on this project, because R001 is retired by a test that must run
in the iteration that builds the stand-ins.

| Phase | What is tested | Evidence produced |
|---|---|---|
| Inception (iterations 1–2) | Nothing is executed. The mission, the coverage plan, the fixture obligation and the quality signals are established | This document |
| Elaboration (iterations 3–4) | The stand-ins themselves; the empty-attribute case of UC-011 and UC-004, which retires R001; the NFR-001 claim mapping; the two High-volatility contracts (FR-004 export, FR-009 single-featured invariant) | Executed results for the R001 retirement case; Test Cases designed for all 15 use cases; stand-in fixtures verified to carry the empty-attribute entries |
| Construction (iterations 5–7) | Every use case against the stand-ins, capability area by capability area, with the regression set re-run each iteration | Executed TC-NNN results; SCM issues for every failure |
| Transition (iteration 8) | The declared acceptance criteria AC-001 to AC-005 against the deployed portal, and handover readiness for Infrastructure (CON-032) | Acceptance evidence; release recommendation |

### Test infrastructure and resources

Every resource below is justified against the mission. Nothing is provisioned because it is customary.

```plantuml
@startuml
title Portal - Test surface: what the test effort runs against (CON-031)

package "Team-controlled stand-ins - the entire integration surface" {
  component "Test OIDC issuer\nplaceholder issuer, client id, secret" as OIDC
  component "Test directory over LDAP\nsix declared attributes\n+ entries with empty job title\n+ entries with empty extension" as LDAP
  component "PostgreSQL 18\nlocal test instance" as DB
}

package "Portal under test" {
  component "Razor Pages frontend\nCON-026" as UI
  component "REST API\n.NET 10, CON-025" as API
}

package "Never touched by the team" {
  component "Real Keycloak\nCON-031" as RKC
  component "Real Active Directory\nCON-022, CON-031" as RAD
}

package "Quality signals" {
  component "Hosted CI\nbuild + test, never deploys\nCON-029" as CI
  component "SCM issue tracker\nauthoritative defect record" as ISS
}

UI --> API
API --> OIDC : MECH-01
API --> LDAP : MECH-04
API --> DB
CI --> UI : build and test
CI --> API : build and test
CI --> ISS : failure raises an issue
RKC ..> OIDC : replaced by, at deployment
RAD ..> LDAP : replaced by, at deployment

note bottom of LDAP
  The empty-attribute entries are mandatory.
  A stand-in without them retires R001
  without testing it (R004).
end note

note bottom of RAD
  Validation against the real systems is
  human work by Infrastructure with HR
  (CON-031). It is not team test work
  and is not scheduled here.
end note
@enduml
```

| Resource | Justification against the mission | State |
|---|---|---|
| Test OIDC issuer stand-in | NFR-001 is a portal-wide mechanism included by all 15 use cases. Without a stand-in issuer no use case can be exercised at all, and CON-031 forbids using the real Keycloak | Required — built in iteration 3 |
| Test directory stand-in over LDAP | UC-011 and UC-004 read six attributes from AD. The stand-in must carry entries with empty job title and empty extension, or R001 is retired untested (R004) | Required — built in iteration 3 |
| Local PostgreSQL 18 | NFR-005 is asserted at the database, and CON-013/CON-014 are schema-level rules. A test cannot prove "never overwritten" without a real store | Required — Infrastructure installs per CON-027 |
| Hosted CI (build and test) | The regression set must run every iteration. CON-029 fixes the provider and forbids deployment from CI | Available — build green on `main` |
| SCM issue tracker | The authoritative defect record. Defect metrics are read from it, never compiled by hand | Available — one issue recorded |
| Test framework | Not declared by the stakeholder. The Development Case records it as a gap for the Test Manager to close in Elaboration | **Gap — closes in iteration 3** |
| Real Keycloak and real AD | Not a test resource. Validation against them is human work by Infrastructure with HR (CON-031) and is not scheduled by the team | Out of the team's test surface |

**No performance test environment is provisioned.** NFR-002 and NFR-004 are measured on the corporate
network against the deployed application, and scale is explicitly non-binding at 200 employees. A
load-testing rig would be a resource with no decision behind it.

### Entry and exit criteria

Criteria are per iteration and measurable. They are not "when QA is satisfied".

| Gate | Criterion |
|---|---|
| **Entry to test execution** (from iteration 3 onward) | The stand-ins are running and the directory stand-in is verified to carry the empty job-title and empty extension entries; the hosted CI build is green; the test framework is selected and the test projects are discovered by the CI glob |
| **Entry to a Construction iteration's use-case tests** | The use cases in that iteration's scope are implemented and reachable through the portal; the stand-ins are the only external dependency in play |
| **Exit from an iteration's test effort** | Every use case in that iteration's scope has been executed against the stand-ins; the regression set for all prior iterations has been re-run; every failure is recorded as an SCM issue; the Evaluation Mission for that iteration is assessed as met or not met |
| **Exit is not** | A 100% pass rate. The criterion is that the mission is met and the evidence supports it. A known defect with a recorded issue and an accepted treatment does not block the mission; an unrecorded one does |
| **Regression** | Mandatory every iteration. The set grows by the use cases closed in the previous iteration and is never reduced to make room for new work |

### Evaluation Mission — Inception iteration 2

The Evaluation Mission is the agreement with the stakeholders on the purpose, focus and acceptable
outcome of the test effort for this iteration. It is stated before any test is designed, and the
iteration is judged against it — not against a coverage percentage.

| Element | Statement |
|---|---|
| **Purpose** | Keep the test position decidable and make it follow the plan it is measured against. Inception produces no working software, so the mission is to make the test effort *decidable* in Elaboration and Construction, not to prove the system works |
| **Focus** | The four architecturally significant use cases detailed in iteration 1 — UC-001, UC-004, UC-009, UC-011 — and the four risks that decide whether the test effort can succeed at all: R001, R004, R006, R008. This iteration adds one obligation: every execution iteration in the coverage plan must be the iteration in which the behaviour it tests exists |
| **Acceptable outcome** | Every one of the 15 use cases has a named test level and an execution iteration that matches the eight-iteration roadmap; every NFR is measured by the method the requirement itself names, in an iteration where the behaviour exists; the stand-in fixture requirement that retires R001 is recorded as a test obligation with the iteration in which it is executed; the defect record and the quality signals are named and read from the SCM at the moment of writing |
| **Not the outcome** | A pass rate. No test is executed this iteration and none can be. A mission that claimed otherwise would be reporting a result that does not exist |

**Why the mission is scoped this way.** The declared scope is constraint-dense — 36 constraints
against 15 requirements — so the stakeholder has already fixed most behaviour. The test effort's
value is therefore *conformance evidence*: proving the system does exactly what CON-001 to CON-036
say, and proving it against the stand-ins that CON-031 makes the team's entire integration surface.
That is a different mission from exploratory testing, and it is the one this project needs.

**What iteration 2 corrects in the test position.** Two defects were recorded against this document
at the LCO review. The cited CI run was not the build observed on `main`, so an observable SCM fact
was stated as a verified observation when it was a stale one. And NFR-001 was assigned to an
Elaboration iteration scoped as design only, so its stated method — exercising every use case
unauthenticated and requiring refusal — could not have been executed there. Both are corrected
below, and the coverage plan is re-based onto the eight-iteration roadmap the Iteration Plan now
carries.

### Acceptance criteria verification

Every declared acceptance criterion has a point at which it can close. AC-004 is verified in two
parts at two different points, because it fuses a learnability check with a population measure whose
window opens at go-live.

| AC | Criterion | Verified by | Verified in |
|---|---|---|---|
| AC-001 | An employee can clock in and out without help from HR or the development team | UC-001 executed end to end against the stand-ins, with the confirmation observed | Iteration 5 |
| AC-002 | An HR Administrator can publish a news item without technical assistance | UC-006 executed as an HR-group user, with no console or database step | Iteration 6 |
| AC-003 | Any employee finds a colleague's phone/email in under 10 seconds | UC-011 timed from search entry to the result row showing phone and email | Iteration 7 |
| AC-004a | Learnability half — an employee completes at least one clocking with no prior training | A small untrained-user check in the iteration that implements UC-001 | Iteration 5 |
| AC-004b | Population half — 80% of employees complete at least one clocking within three months of launch | The BG-003 adoption reading, owned by STK-001. Not a gate on any iteration | Post-Project-Acceptance |
| AC-005 | A clocking made while the corporate network is down for up to 5 minutes is not lost | UC-013 executed with the network injected down for the full 5 minutes, then restored; the recorded timestamp is the press time, not the receipt time | Iteration 5 |

**AC-004b is not an iteration gate and this document does not treat it as one.** A population measure
whose window opens at go-live cannot be verified by the iteration in which the window opens. It is
recorded here with its owner and its point of closure so that the project's accountability to it is
visible, and it is not assigned to a gate that could never close on it.

### Test execution sequence across the roadmap

```plantuml
@startuml
title Portal - Test execution sequence across the eight-iteration roadmap

|Iteration 3 - Elaboration|
start
:Build the stand-in OIDC issuer and the stand-in directory;
:Verify the directory stand-in carries entries with empty job title and empty extension;
note right: R004 - the fixture inspection
:Execute UC-011 A1 and UC-004 A5 against the stand-in;
note right
  R001 is retired here, by a passing
  directory search and export - not by
  the fixture existing.
end note
:Verify the stand-in OIDC claim mapping supplies sAMAccountName and AD group membership;
note right: NFR-001a, Elaboration half

|Iteration 4 - Elaboration|
:Design test cases for all 15 use cases;
:Receive the CON-031 human validation feedback;
note right: R003 closes here

|Iteration 5 - Construction|
:Execute UC-001, UC-002, UC-003, UC-004, UC-005, UC-013;
:Assert NFR-004 on the clocking POST;
:Assert NFR-001b refusal on every use case implemented this iteration;
:Measure NFR-002 on the clocking page, script included;
:Assert NFR-005 at the database for clocking corrections;
:Run the AC-004a untrained-user check;

|Iteration 6 - Construction|
:Execute UC-006, UC-007, UC-008, UC-009, UC-010, UC-015;
:Assert NFR-001b refusal on every use case implemented this iteration;
:Assert NFR-005 at the database for news publication, edit and unpublish;
:Re-run the iteration 5 regression set;

|Iteration 7 - Construction|
:Execute UC-011, UC-012, UC-014;
:Assert NFR-001b refusal on every use case implemented this iteration;
:Assert NFR-005 at the database for the worker-category change;
:Measure NFR-002 across all pages;
:Measure NFR-003 within the declared window;
:Run the full regression set - all 15 use cases;

|Iteration 8 - Transition|
:Verify AC-001, AC-002, AC-003, AC-005 against the deployed portal;
:Confirm NFR-003 in the operating window;
:Hand over to Infrastructure (CON-032);
note right
  AC-004b is not an iteration gate:
  the BG-003 window opens at go-live
  and closes after Project Acceptance,
  owned by STK-001.
end note
stop
@enduml
```

## Test Summary
### What was executed this iteration

**No test was executed in Inception iteration 2, and none could be.** The iteration produces no
working software: no code, no stand-ins, no test cases. Reporting a pass rate here would be reporting
a result that does not exist.

| Measure | Value | Basis |
|---|---|---|
| Test cases designed | 0 | Test Case is an Elaboration artifact; the four detailed use cases are the input to it |
| Test cases executed | 0 | No code exists to execute against |
| Use cases with a named test level and an execution iteration matching the roadmap | 15 of 15 | Coverage plan above |
| Non-functional requirements with a named measurement method and an iteration where the behaviour exists | 5 of 5 | Quality-attribute plan above |
| Acceptance criteria with a point at which they can close | 5 of 5, with AC-004 split into two parts | Acceptance criteria verification above |
| Stand-in fixture obligations recorded | 1 | The empty job-title and empty extension entries (R001, R004), executed in iteration 3 |
| Test framework selected | No | Recorded gap; closes in iteration 3 |

### Quality signals observed

These are read from the project's SCM at the moment of writing, not compiled by hand.

| Signal | Value | Source |
|---|---|---|
| Hosted CI build on `main` | Success — run `39940062277`, started 2026-10-23 10:34:26Z, completed 10:35:16Z | `scm_get_build_status` |
| Issues in the tracker | One — `Issue #1`, recorded against a documentation artifact, not against the portal | `scm_list_issues`, state `all` |

**How to read the green build.** It is a real signal and a weak one. The repository currently holds
project inputs and artifacts, not the portal; a green build proves the pipeline runs, not that
anything works. Its value this iteration is that the CI path CON-029 requires is live and that the
first red build will mean something. It is not evidence about the product.

**How to read the one issue.** It is a documentation-staleness defect in the branching strategy
document, raised by review rather than by a test. It is not a product defect and it does not bear on
the test position. It is cited here because the tracker is the authoritative defect record and a
defect count that omitted it would be a count compiled by hand.

### Coverage achieved against the mission

| Mission element | Achieved | Evidence |
|---|---|---|
| Every use case has a named test level and an execution iteration | Yes | Coverage plan — 15 of 15, re-based onto the eight-iteration roadmap |
| Every execution iteration is one in which the behaviour exists | Yes | Coverage plan and quality-attribute plan; NFR-001 split into a claim-mapping check and a per-iteration refusal assertion |
| Every NFR has a named measurement method | Yes | Quality-attribute plan — 5 of 5 |
| Every acceptance criterion has a point at which it can close | Yes | AC-004 split into a learnability check at iteration 5 and a post-Project-Acceptance population measure owned by STK-001 |
| The R001 fixture obligation is recorded as a test obligation with its execution iteration | Yes | Test infrastructure table; entry criterion; iteration 3 in the execution sequence |
| The defect record and quality signals are named and read from the SCM | Yes | SCM issue tracker; hosted CI run `39940062277` |
| The test framework gap has an owner and an iteration | Yes | Test Manager, iteration 3 |
| Test execution evidence | **No — and not expected this iteration** | No code exists |

## Defects and Incidents
### Defect record

The SCM issue tracker is the authoritative defect record. A defect that exists only in a conversation
or a document does not exist, and a defect count compiled by hand is not a metric.

| Measure | Value | Source |
|---|---|---|
| Issues in the tracker | 1 | `scm_list_issues`, state `all` |
| Product defects raised by test execution | 0 | No test has been executed |
| Defects raised by review | 1 — `Issue #1`, documentation staleness in the branching strategy document | `scm_list_issues` |
| Defects closed | 0 | `scm_list_issues`, state `all` |
| Incidents (build failures, environment outages) | 0 | CI build success on `main`, run `39940062277` |

**Zero product defects is the correct reading of this iteration, not a quality achievement.** No test
was executed, so no product defect could be found. The number becomes meaningful from iteration 3
onward, when the stand-ins exist and the first test cases run.

**The one recorded issue is not a product defect and is not counted as one.** It was raised by review
against a documentation artifact. It is reported because the tracker is the authoritative record and
omitting it would make this table a hand-compiled count.

### Defect lifecycle

```plantuml
@startuml
title Portal - Defect lifecycle in the SCM issue tracker

[*] --> Open : test execution fails a TC-NNN\nor a review records a finding
Open --> Triaged : severity and owner assigned
Triaged --> InProgress : fix started
InProgress --> ReadyForRetest : fix pushed, CI build green
ReadyForRetest --> Closed : the failing TC-NNN passes\nand the regression set passes
ReadyForRetest --> Reopened : the failing TC-NNN still fails
Reopened --> InProgress : fix restarted
Triaged --> Deferred : not a defect of this increment
Deferred --> [*] : carried to the next iteration
Closed --> [*]

note right of Open
  The SCM issue tracker is the
  authoritative defect record.
  No defect exists outside it.
end note

note right of ReadyForRetest
  CI build status is the gate:
  a fix is not retestable until
  the hosted CI build is green
  (CON-029: build and test only,
  never deploys).
end note
@enduml
```

**A defect is closed by a passing test, not by a merged fix.** The transition from `ReadyForRetest` to
`Closed` requires the failing test case to pass and the regression set to pass with it. A fix that
breaks a previously passing use case reopens the defect rather than closing it.

### Defect severity scale

| Severity | Meaning on this project | Example |
|---|---|---|
| Critical | A declared exclusion is crossed, or a business rule is violated wherever the change comes from | A category read in an authorization decision (CON-015); a second featured item (CON-010); a news item hard-deleted (CON-014) |
| Major | A declared requirement is not met, or an acceptance criterion cannot be satisfied | The export omits a row for a missing clock-out (FR-004); the directory hides an employee whose extension is empty (R001) |
| Minor | A departure from the authoritative UI reference (CON-034) that does not block a use case | Spacing or colour differing from `docs/inputs/employee-portal-design.html` |
| Cosmetic | Presentation only, no requirement at stake | A label wording that is not fixed by any constraint |

**The Critical band is deliberately narrow and specific.** On a project with 13 declared exclusions,
the most damaging defect is not a crash — it is a feature the stakeholder excluded appearing in the
product. That is why the exclusion list is the first thing the severity scale names.

## Conclusions
### Mission verdict — Inception iteration 1

**The Evaluation Mission for this iteration is MET.** The test effort is now decidable: every use case
has a test level and an iteration, every non-functional requirement has a measurement method, the
fixture obligation that retires R001 is recorded as a test obligation rather than a convention, and
the defect record and quality signals are named and live.

This verdict is about the *test position*, not about the product. No product evidence exists, and the
verdict does not claim any.

### What the verdict rests on

| Basis | Strength |
|---|---|
| 15 of 15 use cases assigned a test level and an execution iteration | Strong — the coverage plan is complete against the declared scope |
| 5 of 5 NFRs assigned the measurement method the requirement itself names | Strong — no substitute metric was accepted |
| R001's fixture obligation recorded as an entry criterion, not a guideline | Strong — R004 is the risk that R001 is retired untested, and the criterion is what prevents it |
| Defect record and CI signal named and observed | Adequate — the pipeline is live; it carries no product evidence yet |
| Test framework selected | **Absent** — carried as an Elaboration obligation with an owner |

### Recommendation

**Proceed to Elaboration.** The test effort has no blocking gap for this phase. The one open item —
the test framework — is an Elaboration obligation, not an Inception one, and the Development Case
already records it as a toolchain gap to close before Implementation intensity rises.

### Obligations this document places on the next iteration

| Obligation | Owner | Why it cannot slip |
|---|---|---|
| Select the test framework and confirm the CI glob discovers the test projects | Test Manager | Without it no test case can run, and R007 records the consequence of the gap surviving into Construction |
| Verify the directory stand-in carries entries with empty job title and empty extension | Test Designer, checked by CodeReviewer | This is the only mechanism that retires R001. A stand-in without them makes every directory test pass while the risk stays live (R004) |
| Design test cases for the four detailed use cases — UC-001, UC-004, UC-009, UC-011 | Test Analyst, Test Designer | These carry the client-timestamp contract, the export column contract, the single-featured invariant and the LDAP read — the four places a wrong decision is expensive to reverse |
| Assert the FR-004 export contract column by column, including the empty clock-out row and decimal hours computed from recorded times | Test Designer | R006 records the misread derivation as the failure mode; the contract is consumed outside the portal and a change to it is invisible to the portal's own tests |
| Assert NFR-005 at the database, not through the application | Test Designer | No audit view screen exists, so a test that reads through the application proves less than the requirement demands |

### What this document does not claim

- It does not claim the Inception milestone is achieved. That verdict belongs to the ReviewCoordinator.
- It does not claim any acceptance criterion is closed. AC-001 to AC-005 are verified by working
  software, which does not exist yet.
- It does not claim the product is tested. It claims the test effort is defined, resourced and
  decidable.
