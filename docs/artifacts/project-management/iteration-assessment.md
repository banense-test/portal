## Document Control
- **Phase:** Inception
- **Status:** Draft — under review
- **Milestone Target:** End of Inception (not yet achieved)
- **Iteration:** 2, Cycle 1
- **Owner:** ProjectManager
- **Date:** 2026-10-07
## Iteration Objectives Reached

The iteration's objectives were met. The milestone was not. Those are two different statements and this assessment keeps them apart: the objectives were to produce the artifact scope and the risk record and to assess readiness, and all of them were produced; the LCO verdict is the ReviewCoordinator's and it is that the iteration is required again.

| # | Objective | Verdict | Evidence |
|---|---|---|---|
| O-1 | Establish the requirements baseline the whole project is accountable to. | **Met with variance** | Vision, Use-Case Model and Supplementary Specification persisted and reviewed; twelve declared requirements map one-to-one to twelve use cases. Three Minor findings open: Vision#F1, Use-Case Model#F1, Supplementary Specification#F1. |
| O-2 | Identify and classify the project's risks, with a strategy and an owner for each, and retire the candidates whose mechanism has no actor. | **Met** | Risk List persisted; R001 to R010 classified with probability, impact, exposure, magnitude, strategy, owner, mitigation, contingency and an observable indicator; eleven candidates retired with their reason. No finding from any lens. |
| O-3 | Compose the coarse roadmap and this iteration's fine plan. | **Met with variance** | Iteration Plan persisted; seven iterations, no work item sized, human gates reported apart from agent time. Five findings open on it: Iteration Plan#F1 and #F2 (Major), #F1, #F3 and #F4 (Minor). |
| O-4 | Reach a first-cut architecture that confronts the highest-magnitude technical risks. | **Met** | Software Architecture Document persisted; R001, R003, R004 and R008 addressed. No finding from any lens. |
| O-5 | Assess LCO readiness. | **Met** | The ReviewCoordinator's verdict is recorded: LCO — iteration REQUIRED (scope incomplete). The milestone is not achieved. |

```plantuml
@startuml
title Iteration objectives — met, met with variance, not met (Portal, Inception 1)

skinparam classAttributeIconSize 0

class "O-1 Requirements baseline" as O1 <<MET_WITH_VARIANCE>> {
  Vision, Use-Case Model, Supplementary Specification
  persisted and reviewed
  12 declared requirements to 12 use cases, one-to-one
  Open: Vision#F1, Use-Case Model#F1,
  Supplementary Specification#F1
}

class "O-2 Risks identified and classified" as O2 <<MET>> {
  Risk List persisted
  R001 to R010 classified with strategy, owner,
  mitigation, contingency, indicator
  Retired candidates recorded with their reason
  No finding from any lens
}

class "O-3 Coarse roadmap and fine plan" as O3 <<MET_WITH_VARIANCE>> {
  Iteration Plan persisted
  Open: Iteration Plan#F1 Major, #F2 Major,
  #F1 Minor, #F3 Minor, #F4 Minor
}

class "O-4 First-cut architecture" as O4 <<MET>> {
  Software Architecture Document persisted
  R001, R003, R004, R008 addressed
  No finding from any lens
}

class "O-5 LCO readiness assessed" as O5 <<MET>> {
  The ReviewCoordinator's verdict is recorded:
  LCO iteration REQUIRED
  The milestone is NOT achieved
}

class "Phase objectives" as PH <<phase>> {
  Define Project Scope — met
  Identify Critical Risks — met
  Tailor Development Process — met with variance
  Establish Feasibility — met with variance
}

O1 --> PH
O2 --> PH
O3 --> PH
O4 --> PH
O5 --> PH

note bottom of O5
  The objective was to assess readiness and
  record the verdict. It was met. The verdict
  itself is the ReviewCoordinator's and it is
  that the milestone is not achieved.
end note
@enduml
```

**The phase objectives against the iteration objectives.** Define Project Scope is O-1. Identify Critical Risks is O-2. Tailor Development Process is O-3 plus the Development Case, which carries one Major finding (Development Case#F1). Establish Feasibility is O-4 and O-5. No phase objective was left unaddressed.

## Adherence to Plan

All nine fine-plan work items W-1 to W-9 were executed, in the planned order, each by its planned owner. The critical chain ran sequentially as planned and ended at the human gate. The plan's forecast discipline held: no work item carried a size and no spend figure was quoted anywhere, because no phase had closed.

```plantuml
@startuml
title Inception 1 — critical chain as executed, with the measured actual (Portal)

|ProcessEngineer|
start
:Development Case — tailoring, classification, optional triggers, version policy;
note right
  Measured actual for this iteration:
  6,891,971 tokens
  agent elapsed time 1:17:17.4186317
  Seven sequential agent stretches
  from iteration start to the gate.
end note

|SystemAnalyst|
:Vision — problem statement, stakeholders, features, constraints;
:Use-Case Model — 12 use cases surveyed, 5 detailed;

|RequirementsSpecifier|
:Supplementary Specification — FURPS+ classification, cross-cutting mechanisms;

|SoftwareArchitect|
:Software Architecture Document — first cut, architectural mechanisms;

|ProjectManager|
:Risk List — R001 to R010 classified;
:Iteration Plan — coarse roadmap and fine plan;

|Reviewer|
:Artifact review — 11 findings across 8 artifacts;

|ReviewCoordinator|
:LCO verdict — iteration REQUIRED;

|Stakeholder|
:Human gate — LCO sanction;
note right
  Measured queue time 0:00:00.
  Reported apart from agent time.
  Never added to it.
end note
stop
@enduml
```

### Measured actuals — the first this project has

No phase had closed before this iteration, so no forecast existed and none was invented. Inception 1 is now the first closed phase, and these measured values replace every assumed share in every forecast made from here on. The two currencies are reported side by side and are never added.

| Quantity | Measured | Goal — the decision it enables |
|---|---|---|
| Token spend | 6,891,971 | Forecast Inception 2's spend. This is the first measured actual; it replaces the rubber profile's assumed share for Inception. |
| Agent elapsed time | 1:17:17.4186317 | Forecast the next iteration's agent time. |
| Human queue time | 0:00:00 | Detect whether a human gate has become the critical path. Excludes the end-of-iteration approval gate, which is not measured. |
| Artifacts produced | 9 | Check the Development Case's CORE set is being produced at the rate the plan assumes. |
| Agent invocations | 11 | Check the role profile against actual participation — the profile is a plan, and this is the first observation of it. |
| User interactions | 11 | Detect whether the stakeholder is on the critical path. |
| Average quality score | 10.0 | Detect a quality trend across iterations. **Not a substitute for the finding ledger** — eleven findings are open while this figure reads 10.0, so the figure does not measure review outcome and is not read as if it did. |

**No budget is set and none is proposed.** CON-034 declares no budget or cap on token spend and none is to be set by the team. Declared scope is never cut or deferred to fit an estimate.

### Variance against the plan

Six variances. Each is recorded with its root cause and the adjustment it forces in Inception 2, in the same breath — a variance recorded without its correction is left open for the next iteration's reviewers to find.

| # | Planned | Actual | Root cause | Adjustment in Inception 2 |
|---|---|---|---|---|
| V-1 | Exit criteria X-1 to X-5 assumed the iteration closes the milestone. | The verdict is LCO — iteration REQUIRED. The milestone is not achieved. | The plan treated the LCO verdict as an outcome of the iteration rather than as a gate that can refuse. The plan had no Inception 2 to carry a refusal. | Add Inception 2 to the coarse roadmap with a fine plan whose work items are the closure of every open finding, and re-assess X-1 to X-5 there. Iteration Plan#F2. |
| V-2 | The role profile marked ManagementReviewer as non-participating in I1, E2 and C3. | The management lens executed at this gate and raised two Major findings. | The profile was built from the discipline intensity matrix without checking which roles own the lifecycle milestone review. | Add ManagementReviewer to the role profile for I1, E2 and C3, with the verdict at LCO, LCA and IOC. Iteration Plan#F1. |
| V-3 | The milestone table listed LCO, LCA, IOC and PR only. | No Project Approval Review was conducted and none is scheduled. | The review-event framework was not reconciled against the milestone sequence when the roadmap was composed. | Schedule the Project Approval Review ahead of the LCO re-assessment, or record the determination that it does not apply with its basis. Iteration Plan#F3. |
| V-4 | The human-gate table reported "None declared" ceilings on the LCO and PR gates. | The 14-day bound is the process bound on any human gate, not a per-gate declaration. | The bound was read as a declaration to be made or withheld per gate, rather than as the process rule that applies to every gate. | Report the 14-day process bound on all three human gates, with measured queue time apart from agent time. Iteration Plan#F4. |
| V-5 | The roadmap chart asserted "lasts 1 day" per iteration. | The caption declared the axis ordinal and the plan declared no duration measured. | The gantt diagram type requires a duration, so the chart asserted one the plan disclaims. | Replace the roadmap chart with a duration-free representation, or state the nominal unit inside the chart itself. Iteration Plan#F1 (Minor). |
| V-6 | The plan quoted no spend figure, because no phase had closed. | The measured actual now exists: 6,891,971 tokens, agent 1:17:17.4186317, human queue 0:00:00. | Not a variance — the plan's forecast rule firing for the first time. | Build the Inception 2 forecast from this measured actual. No assumed share survives it. |

```plantuml
@startuml
title Variance and adjustment — Inception 1 plan against the iteration's facts (Portal)

skinparam classAttributeIconSize 0

class "PlannedWorkItem" as PWI <<plan>> {
  + id : W-1 .. W-9
  + owner : role
  + exitEvidence : text
}

class "ExecutedStretch" as EXE <<actual>> {
  + role : role
  + artifact : name
  + measuredTokens : 6891971
  + measuredAgentTime : 1:17:17.4186317
}

class "Variance" as VAR <<record>> {
  + id : V-1 .. V-6
  + planned : text
  + actual : text
  + rootCause : text
  + adjustment : text
}

class "Finding" as FND <<record>> {
  + key : artifact#Fn
  + severity : Critical Major Minor
  + owner : role
}

class "Adjustment" as ADJ <<plan>> {
  + target : Inception 2
  + workItem : text
  + owner : role
}

PWI --> EXE : executed as
EXE --> VAR : measured against
FND --> VAR : forces
VAR --> ADJ : corrected by

note bottom of VAR
  A variance recorded without its correction
  is left open for the next iteration's
  reviewers to find. Recorded with it, it
  is closed work.
end note

note bottom of ADJ
  Every adjustment lands in Inception 2.
  None cuts or defers declared scope.
end note
@enduml
```

**No adjustment cuts or defers declared scope.** Every one of the six is a correction to the plan's own structure or to a statement about observable state. Declared scope is the stakeholder's to change, not the plan's.

## Use Cases and Scenarios Implemented

**None.** Inception 1 produces no executable increment, so no use case is implemented and no scenario is executed. This is the correct state for the iteration, not a shortfall: the iteration's output is the artifact scope and the risk record.

| UC | Source | This iteration | Implemented | Realization |
|---|---|---|---|---|
| UC-002 | FR-002 | Detailed | No | None — no executable increment exists |
| UC-004 | FR-004 | Detailed | No | None |
| UC-005 | FR-005 | Detailed | No | None |
| UC-010 | FR-010 | Detailed | No | None |
| UC-011 | FR-011 | Detailed | No | None |
| UC-001, UC-003, UC-006, UC-007, UC-008, UC-009, UC-012 | FR-001, FR-003, FR-006 to FR-009, FR-012 | Surveyed | No | None |

**Scenarios named for the TestDesigner.** The alternative flows that carry a risk or an invariant are the ones that must be covered from Elaboration 2: UC-002 A1 (duplicate press), A2 (network unreachable), A3 (clock-out with no open pair); UC-004 A1 (clock-out missing), A2 (day with no clocking), A3 (no category); UC-005 A1 (insertion for a day with no clocking), A2 (employee attempts a correction); UC-010 A1 (clearing the flag on the featured item), A2 (no item featured); UC-011 A1 (empty attribute), A2 (no category), A3 (network unreachable), A4 (no match). None was executed this iteration.

## Results Relative to Evaluation Criteria

### (a) This iteration's own exit criteria

| # | Exit criterion | Verdict | Evidence |
|---|---|---|---|
| X-1 | The requirements baseline is complete and reviewed: twelve declared requirements as twelve use cases, one-to-one, with no use case lacking a declared source. | **Met with variance** | Vision, Use-Case Model and Supplementary Specification persisted and reviewed; twelve to twelve, no gap and no surplus. Three Minor findings open: Vision#F1, Use-Case Model#F1, Supplementary Specification#F1. |
| X-2 | Every risk is classified with a strategy and an owner, and every accepted risk names the basis of its acceptance. | **Met** | Risk List persisted; R001 to R010 each carry strategy, owner, mitigation, contingency and an observable indicator; each accepted risk names its CON-024 basis. No finding from any lens. |
| X-3 | The coarse roadmap and this iteration's fine plan are composed, with no work item sized in a unit this system does not measure. | **Met with variance** | Iteration Plan persisted; no work item carries a size; the two currencies are reported apart. Five findings open on it: Iteration Plan#F1 and #F2 (Major), #F1, #F3 and #F4 (Minor). |
| X-4 | The first-cut architecture confronts the highest-magnitude technical risks rather than deferring them. | **Met** | Software Architecture Document persisted, addressing R001, R003, R004 and R008. No finding from any lens. |
| X-5 | LCO readiness is assessed and the verdict recorded. | **Met** | The ReviewCoordinator's verdict is recorded: LCO — iteration REQUIRED (scope incomplete). |

### (b) Declared acceptance criteria

All six are accounted for. **None is addressed this iteration** — no executable increment exists, so no acceptance criterion is closable. Each is deferred to a named iteration with the evidence that will close it.

| AC | Criterion | This iteration | Deferred to | Evidence that will close it |
|---|---|---|---|---|
| AC-001 | The performance criterion is the full page load as the employee experiences it, including the clocking page's script. | Not addressed — no executable exists. | Construction 1 | A measured full page load on the corporate network, browser request to page displayed and usable. |
| AC-002 | An employee can clock in and out without help from HR or the development team. | Not addressed — no executable exists. | Construction 1 | UC-002 exercised end to end with no assistance. |
| AC-003 | An HR Administrator can publish a news item without technical assistance. | Not addressed — no executable exists. | Construction 2 | UC-006 exercised end to end with no assistance. |
| AC-004 | Any employee finds a colleague's phone/email in under 10 seconds. | Not addressed — no executable exists. | Construction 2 | UC-011 exercised against the stand-in directory; re-verified against the real AD after the Elaboration gate. |
| AC-005 | 80% of employees complete at least one clocking with no prior training. | Not addressed — no executable exists. | Transition 1 | Adoption measured against the declared population of 200 after go-live. |
| AC-006 | A clocking made while the corporate network is down for up to 5 minutes is not lost. | Not addressed — no executable exists. | Construction 1 | UC-002 A2 exercised with the network down for the full window. |

## Test Results

**No test was executed.** No executable increment exists, so no test case was authored, no scenario was run and no pass rate exists to report. None is invented.

The Test Evaluation Summary's mission verdict is that the requirements baseline is **verifiable** — every declared requirement, acceptance criterion and non-functional requirement has a stated, observable verification method, and no requirement was found untestable. That verdict is met on its own scope, which was verifiability, not verification.

**SCM signal, read directly this iteration.** Build on `main`: `ci-run-37583334371` — success, 2026-10-07 06:45:58Z to 06:47:38Z. The repository carries scaffolding only — a solution, two empty projects, a CI workflow, a README and the mandatory design reference. No productive code is present, which is consistent with Inception scope.

**One correction the Test Evaluation Summary owes.** That artifact cites a different run id and window and reads entry criterion E-6 as unmet on the ground that no workflow file is committed. The observed build is green and the workflow is committed, so E-6 is met. That is Test Evaluation Summary#F1, owned by the TestManager; this assessment records the observed value and does not correct another role's artifact.

**Defect register.** No defect is recorded. No test was executed, so there is no deviation from declared behaviour to record. A defect register with no entries is the correct state for this iteration — it is not evidence of quality and is not reported as such.

## External Changes

| Change | Recorded as |
|---|---|
| The stakeholder refused the LCO sanction. | Stakeholder sanction: REFUSED. The gate is held, not opened. The remedy is another iteration (CON-026), and the stakeholder named it: the end of Iteration 2. |
| The stakeholder directed that every finding be closed, minor ones included, before the next phase. | The closure of all eleven open findings is a condition on the LCO re-assessment, and Inception 2 is the iteration that carries it. This is the substance of variance V-1. |
| STK-001 confirmed as Laura Gómez, HR Director and project sponsor, granting risk acceptance under CON-024 and sanctioning the milestone. | The `[DERIVED — from "HR Director (project sponsor)"]` marker on STK-001 is retired by that answer. No artifact carries the marker, so no artifact edit arises. |
| No Change Request was raised. | No scope change. No new declared input. The declared scope is unchanged and is not cut or deferred by anything in this assessment. |
| No external system was contacted. | The real Keycloak and the real Active Directory were not touched, which is the declared working method (CON-035). |

## Rework Required

Eleven findings are open: 0 Critical, 5 Major, 6 Minor. Every one is correctable within Inception and none requires a Change Request — each restores an artifact's agreement with the declared scope, with observable state, or with the gate structure, and none changes declared scope.

| Finding | Severity | Owner | Rework | Iteration |
|---|---|---|---|---|
| Iteration Plan#F2 | Major | ProjectManager | Add Inception 2 to the coarse roadmap with a fine plan closing every open finding; re-assess X-1 to X-5 there. | Inception 2 |
| Iteration Plan#F1 | Major | ProjectManager | Add ManagementReviewer to the role profile for I1, E2 and C3, with the verdict at LCO, LCA and IOC. | Inception 2 |
| Development Case#F1 | Major | ProcessEngineer | Rewrite the S1 tool assessment and the gap table against the repository; remove the CI workflow from the Elaboration checkpoint's outstanding conditions. | Inception 2 |
| Test Evaluation Summary#F1 | Major | TestManager | Replace the cited run id and window with the observed build; correct the reading of E-6 to met. | Inception 2 |
| Test Evaluation Summary#F2 | Major | TestManager, with SystemAnalyst as trace steward | Register the artifact's upstream links in the trace repository so its declared coverage is machine-verifiable. | Inception 2 |
| Iteration Plan#F3 | Minor | ProjectManager | Schedule the Project Approval Review ahead of the LCO re-assessment, or record the determination that it does not apply with its basis. | Inception 2 |
| Supplementary Specification#F1 | Minor | RequirementsSpecifier | Reconcile the audit mechanism's include list with UC-010's audit step. | Inception 2 |
| Use-Case Model#F1 | Minor | SystemAnalyst | Reverse the UC-011 to Active Directory association so the portal is the initiating end. | Inception 2 |
| Vision#F1 | Minor | SystemAnalyst | Reconcile A-1 with CON-035 and A-3. | Inception 2 |
| Iteration Plan#F1 | Minor | ProjectManager | Remove the duration from the roadmap chart, or state the nominal unit inside the chart. | Inception 2 |
| Iteration Plan#F4 | Minor | ProjectManager | Report the 14-day process bound on all three human gates, with measured queue time apart from agent time. | Inception 2 |

**Rework is not measured in a human-team unit.** No phase had closed before this iteration, so no measured actual existed; the first one now does. Rework performed in Inception 2 is reported in tokens and in measured elapsed time, split into agent time and human queue time, and the two are never added.

**Two artifacts require no rework.** The Software Architecture Document and the Risk List carry no finding from any lens and are approved. Silence is the verdict.

**Closure discipline.** A finding is closed only by the lens that emitted it. The seven findings of the Reviewer's lens are closed by the Reviewer; the four of the ManagementReviewer's lens by the ManagementReviewer. A statement in this assessment that a finding is resolved does not close it.

## Traceability

| Element | Traces From | Link Type | Traces To |
|---|---|---|---|
| Iteration Assessment | Iteration Plan | Refines | Risk List |
| Iteration Assessment | R001, R002, R003, R004, R005, R006, R007, R008, R009, R010 | Refines | Risk List |
| Iteration Assessment | UC-001, UC-002, UC-003, UC-004, UC-005, UC-006, UC-007, UC-008, UC-009, UC-010, UC-011, UC-012 | Refines | Use-Case Model |
| Iteration Assessment | AC-001, AC-002, AC-003, AC-004, AC-005, AC-006 | Refines | Test Case |
| Iteration Assessment | NFR-001, NFR-002, NFR-003, NFR-004, NFR-005 | Refines | Supplementary Specification |
| Iteration Assessment | CON-023, CON-024, CON-026, CON-034 | Refines | Development Case |
| Iteration Assessment | BG-001, BG-002, BG-003 | Refines | Vision |
| Iteration Assessment | `ci-run-37583334371` | DependsOn | — |

**Reading the table.** `Traces From` is the artifact or declared input this assessment is accountable to — the plan it assesses, the risks it carries forward, the use cases and criteria it reports on, and the constraints that govern its own measurement and risk policy. `Traces To` is the artifact that will carry the elements this assessment specifies: the Risk List, whose entries this assessment carries forward unchanged, and the Test Case artifact, which is empty this iteration because no use-case realization exists to test against. The `ci-run-37583334371` row is the observed build the Test Results section rests on.

**No business-level element appears in this table.** There is no `BUC-NNN` and no `BR-NNN` to trace, because the Business Modeling discipline is inactive for the whole project (Development Case T-1) and no such element was created. The absence is the verdict, not a gap.
