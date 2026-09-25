## Document Control

- **Phase:** Inception
- **Status:** Draft — iteration 3
- **Milestone Target:** Lifecycle Objectives (LCO) — end of Inception. NOT YET ACHIEVED.

## Iteration Objectives

Iteration 3 is the third Inception iteration. It is a mini-project, not a requirements phase: it delivers the one increment Inception still owes — the stand-in environment that gates every use case — and it corrects the nine findings the LCO review recorded, including the minor ones. It is closed by the LCO gate.

| # | Objective | Evidence that closes it |
|---|---|---|
| 1 | Deliver the stand-in environment (CON-028) — the one LCO exit criterion not met at Iter-1 or Iter-2 close | A test OIDC issuer and a test directory carrying the declared attributes, including entries whose job title or extension is empty and entries with no worker-category link, recorded in the Development Case's post-iteration environment verification |
| 2 | Deliver the guideline files the Development Case references | `CONTRIBUTING.md` and the lint configuration exist; the CI pipeline builds and tests on `main` |
| 3 | Correct every finding the LCO review recorded, including the minor ones | The nine-finding ledger: each finding's corrective action applied in the artifact that owns it |
| 4 | Carry R004's re-assessment into the plan as a hard gate | The stand-in environment is the first work item, the Integrator is the single accountable owner, and no work item that exercises a use case against the stand-in starts before it is delivered |
| 5 | Re-plan the coarse roadmap from the measured actuals of both closed Inception iterations | The roadmap in this plan is derived from Iter-1's and Iter-2's measured token spend and elapsed time, not from a theoretical capacity |
| 6 | Make the plan's exit-criteria verdicts honest at the point of writing | Every layer (b) criterion carries a verdict of MET or NOT MET, never an open item |

**What this iteration does NOT do.** It does not implement a use case, does not verify an acceptance criterion, and does not close a milestone. The LCO verdict belongs to the ReviewCoordinator and the ManagementReviewer; this plan produces the evidence they rule on.

## Plan and Milestones

### Coarse roadmap — milestone sequence and iteration boundaries

Eight iterations, distributed [3, 2, 2, 1] across Inception, Elaboration, Construction and Transition. The count is re-planned at every iteration from the measured spend and elapsed time of the phases that have closed (CON-027) — never from a theoretical capacity. Inception now takes three iterations, not the two the previous plan projected.

**Why the profile is bent this way.** Inception takes three iterations because the stand-in boundary that gates every use case has now failed to be delivered twice, and R004's treatment has been replaced by a hard gate. The declared baseline is also unusually rich (9 FRs, 5 NFRs, 32 constraints, 6 acceptance criteria), and the corrective pass on the review findings is real work: Iter-2 closed 18 findings and generated 9 new ones. Elaboration takes two iterations because the architecture baseline must be established *and* the CON-028 human validation feedback from Infrastructure with HR must arrive before LCA closes. Construction is compressed to two iterations because the scope is genuinely small — nine use cases, two entities the portal owns (clockings, news) plus one link table, no data migration (CON-030), no distributed topology, and a stack pinned by CON-022/CON-023/CON-024 so there is no architectural exploration to fund. Transition is one iteration because there is no user training programme (AC-005 requires no prior training) and no data migration, but the handover to Infrastructure (CON-029) is real work.

**The measured shape, against the assumed one.** Iteration 1 spent 6,918,081 tokens in 8:35:00.7478289 of elapsed agent time. Iteration 2 spent 12,066,256 tokens in 2:03:51.5597976 — 1.74 times the tokens in a quarter of the elapsed time. The spend rose because the iteration read the accumulated artifact surface and re-read it to close 18 findings; the elapsed time fell because the work was corrective rather than generative. This measured shape, not the rubber profile's assumed distribution, is the input to this plan. It does not resemble the assumed shape, and the measured shape wins.

```plantuml
@startgantt
title Portal - iteration sequence and human gates (UNANCHORED: no project start date, no calendar dates)
[Iter-1 Inception] lasts 1 day
[Iter-2 Inception] lasts 1 day
[Iter-2 Inception] starts at [Iter-1 Inception]'s end
[Iter-3 Inception] lasts 1 day
[Iter-3 Inception] starts at [Iter-2 Inception]'s end
[LCO] happens at [Iter-3 Inception]'s end
[Iter-4 Elaboration] lasts 1 day
[Iter-4 Elaboration] starts at [LCO]'s end
[Human validation gate - Infrastructure + HR] lasts 14 days
[Human validation gate - Infrastructure + HR] starts at [Iter-4 Elaboration]'s start
[Iter-5 Elaboration] lasts 1 day
[Iter-5 Elaboration] starts at [Iter-4 Elaboration]'s end
[LCA] happens at [Human validation gate - Infrastructure + HR]'s end
[Iter-6 Construction] lasts 1 day
[Iter-6 Construction] starts at [LCA]'s end
[Iter-7 Construction] lasts 1 day
[Iter-7 Construction] starts at [Iter-6 Construction]'s end
[IOC] happens at [Iter-7 Construction]'s end
[Iter-8 Transition] lasts 1 day
[Iter-8 Transition] starts at [Iter-7 Construction]'s end
[PR] happens at [Iter-8 Transition]'s end
note bottom
  Iteration bars carry a 1-day placeholder for ORDERING ONLY:
  no iteration duration has been measured, so none is stated.
  The human gate runs IN PARALLEL with Iter-4 and Iter-5 - the
  team's work does not wait on it, every use case is built and
  tested against the stand-ins (CON-028). LCA closes when both
  the architecture baseline is stable and the validation feedback
  has arrived. The gate's 14 days are days of QUEUE TIME, reported
  apart from agent time and never added to it.
end note
@endgantt
```

| Milestone | Closes at | The decision it gates | Evidence the reviewers rule on |
|---|---|---|---|
| LCO — Lifecycle Objectives | End of Iter-3 (Inception) | Do the stakeholders agree on the scope, is the project viable, are the initial risks identified? | Vision, Use-Case Model, Supplementary Specification, Development Case, Risk List, this Iteration Plan |
| LCA — Lifecycle Architecture | End of Iter-5 (Elaboration) | Is the architecture baseline stable enough to build on? | Software Architecture Document, Design Model, and the CON-028 validation feedback from Infrastructure with HR |
| IOC — Initial Operational Capability | End of Iter-7 (Construction) | Is the product complete enough to operate? | AC-001, AC-004 and AC-006 verified; all nine use cases implemented and tested |
| PR — Product Release | End of Iter-8 (Transition) | Is the product ready for handover to Infrastructure (CON-029)? | AC-002, AC-003 and AC-005 verified; Release Notes; User Documentation |

| Iteration | Phase | Objective | Use cases | Exit criteria |
|---|---|---|---|---|
| Iter-1 | Inception | Agreed scope, process configuration, initial risk register | UC-001, UC-002, UC-008 detailed; UC-003..UC-007, UC-009 outlined | Closed: 5 of 6 met; exit criterion 5 (stand-in environment) NOT MET |
| Iter-2 | Inception | Deliver the stand-in environment and the guideline files; correct the 18 findings | UC-001, UC-002, UC-008 | Closed: 5 of 6 met; exit criterion 5 NOT MET for the second time; 18 findings closed, 9 recorded |
| Iter-3 | Inception | Deliver the stand-in environment under the hard gate; deliver the guideline files; correct the nine findings | UC-001, UC-002, UC-008 | The six objectives above; LCO readiness assessed |
| Iter-4 | Elaboration | Establish the architecture baseline; design the remaining six use cases | UC-003..UC-007, UC-009 | LCA: the architecture is stable enough to build on |
| Iter-5 | Elaboration | Close the architecture baseline on the CON-028 validation feedback | UC-001, UC-002, UC-008 | LCA: the validation feedback has arrived and the baseline holds against it |
| Iter-6 | Construction | Build and test the clocking and news increments | UC-001..UC-007 | AC-001, AC-002, AC-003, AC-006 verified |
| Iter-7 | Construction | Build and test the directory increment; harden; reach IOC | UC-008, UC-009 | AC-004 verified; all nine use cases implemented and tested |
| Iter-8 | Transition | Hand over to Infrastructure; make adoption measurable | all nine | AC-005 measurable from the recorded clockings; PR |

**The human gate is not an iteration, and it is not on the team's path.** The CON-028 validation of the real Keycloak and real AD is performed by Infrastructure with HR, outside the team's control. It runs in parallel with Iter-4 and Iter-5: the team's work does not wait on it, because every use case is built and tested against the stand-ins. It is bounded at 14 days of queue time, after which the process suspends (Development Case measurement policy). It is reported in days of queue time, apart from agent time, and the two are never added into one figure. If it delays a milestone, the remedy is another iteration (CON-021) — never a cut to declared scope.

### Fine plan — Inception iteration 3 work items

No work item below carries a size. This system measures exactly two quantities — tokens and elapsed time — and a work item sized in hours, days, weeks or person-anything would be a unit nothing here produces. The order below is the critical chain, not a schedule.

**The hard gate.** Work item 1 is a gate, not a position in a list. No work item that exercises a use case against the stand-in starts until the stand-in environment is delivered and recorded. The corrective work on the nine open findings is not gated by it: those findings are defects in records and tables, and correcting them does not require the stand-in. The gate exists because R004's treatment has failed twice as a sequencing statement, and sequencing alone is not a treatment.

| # | Work item | Owner (agent role) | Predecessor | Evidence that closes it |
|---|---|---|---|---|
| 1 | Stand-in environment (CON-028): test OIDC issuer and test directory, including the worker-category link | Integrator, accountable | — | A test directory carrying the declared attributes, including entries whose job title or extension is empty and entries with no category link; recorded in the Development Case's post-iteration environment verification |
| 2 | Post-iteration environment verification and iteration-preparation checkpoint | ProcessEngineer | 1 | A record taken at the gate, against observable state, for each item the checkpoint names |
| 3 | `CONTRIBUTING.md` and lint configuration | ConfigurationManager, Implementer | — | The guideline files the Development Case references exist |
| 4 | Risk List: treatment column re-headed, every row refreshed, R004's re-assessment carried | ProjectManager | — | This register states each risk's treatment state at the current iteration |
| 5 | Iteration Plan: coarse roadmap re-planned from the measured actuals; fine plan for Iter-3 | ProjectManager | 4 | This artifact |
| 6 | Iteration Assessment: Iter-2 outcome recorded | ProjectManager | 4, 5 | The assessment records the iteration's outcome given the reviewers' verdict |
| 7 | Use-Case Model: constraints-and-risks table re-read against the Risk List; realizing-component table reconciled; UC-008's category filter recorded | SystemAnalyst | 4 | The SUSPECT edges clear; the tables match the registered graph |
| 8 | Vision and Supplementary Specification: the `NFR-003` row names `COMP-002` | SystemAnalyst, RequirementsSpecifier | — | Both rows state the downstream element the Software Architecture Document registers |
| 9 | Development Case: the open SCM issue row records all three issues | ProcessEngineer | — | The row agrees with the tracker |
| 10 | Test Evaluation Summary: defect count and CI run refreshed | TestManager | — | The three places that carry the count agree with the tracker |
| 11 | LCO review | ReviewCoordinator, ManagementReviewer, Reviewer, BusinessReviewer | 1..10 | The LCO verdict — the reviewers' ruling, not the Project Manager's |

```plantuml
@startuml IP_Iter3_CriticalChain
title Portal - Inception iteration 3: critical chain, sequential agent stretches from iteration start to the LCO gate
|Environment|
start
:Stand-in environment (CON-028): test OIDC issuer + test directory;
note right
  FIRST work item, single accountable owner:
  the Integrator. R004's treatment failed
  twice as a sequencing statement; it is
  now a gate the iteration cannot close
  without. Exit criterion 5.
end note
:Development Case: post-iteration environment verification + iteration-preparation checkpoint;
note right
  The record taken AT the gate, against
  observable state. It is the control that
  produces R004's evidence.
end note
|Implementation|
:CONTRIBUTING.md and lint configuration;
note right
  R009's remaining scope. The CI half is
  retired against the green run on main.
end note
|Project Management|
:Risk List: treatment column re-headed, every row refreshed, R004 re-assessment carried;
:Iteration Plan: coarse roadmap re-planned from the measured actuals of Iter-1 and Iter-2;
:Iteration Assessment: Iter-2 outcome recorded;
|Requirements|
:Use-Case Model, Vision, Supplementary Specification: the open findings corrected;
|Test|
:Test Evaluation Summary: defect count and CI run refreshed;
|Review|
:LCO gate: ReviewCoordinator + ManagementReviewer + Reviewer + BusinessReviewer;
note right
  Exit criterion 5 (stand-in environment) is
  the criterion that gates every use case.
  Its verdict is stated as MET or NOT MET at
  the point the plan is written.
end note
stop
@enduml
```

## Resources
### Agent role profile

Planning here means selecting which agent roles execute in each iteration. The 25-role IARI roster is fixed and no role is merged (Development Case). BusinessProcessAnalyst and BusinessReviewer are **not active** in any iteration: Business Modeling is inactive because business-process-led = false.

| Agent role | Iter-1 Inception | Iter-2 Inception | Iter-3 Inception | Iter-4 Elaboration | Iter-5 Elaboration | Iter-6 Construction | Iter-7 Construction | Iter-8 Transition |
|---|---|---|---|---|---|---|---|---|
| SystemAnalyst | Execute | Execute | Execute | Execute | Consult | — | — | Consult |
| RequirementsSpecifier | Execute | Execute | Execute | Execute | Execute | Consult | Consult | — |
| SoftwareArchitect | Execute | Execute | Consult | Execute | Execute | Consult | Consult | Consult |
| Designer | Execute | Consult | Consult | Execute | Execute | Execute | Execute | — |
| DatabaseDesigner | — | — | — | Execute | Execute | Execute | Execute | — |
| UserInterfaceDesigner | Consult | Consult | Consult | Execute | Execute | Execute | Execute | — |
| CapsuleDesigner | — | — | — | Consult | Consult | Consult | Consult | Consult |
| Implementer | Execute | Execute | Execute | Execute | Execute | Execute | Execute | Consult |
| Integrator | Execute | Execute | Execute | Execute | Execute | Execute | Execute | Execute |
| TestManager | Consult | Execute | Execute | Execute | Execute | Execute | Execute | Execute |
| TestDesigner | — | — | — | Execute | Execute | Execute | Execute | Consult |
| TestAnalyst | — | — | — | Execute | Execute | Execute | Execute | Execute |
| Tester | — | — | — | Execute | Execute | Execute | Execute | Execute |
| DeploymentManager | — | — | — | Consult | Consult | Consult | Execute | Execute |
| TechnicalWriter | — | — | — | Consult | Consult | Execute | Execute | Execute |
| ConfigurationManager | Execute | Execute | Execute | Execute | Execute | Execute | Execute | Execute |
| ChangeControlManager | — | — | — | Consult | Consult | Execute | Execute | Execute |
| ProcessEngineer | Execute | Execute | Execute | Execute | Execute | Consult | Consult | Execute |
| ProjectManager | Execute | Execute | Execute | Execute | Execute | Execute | Execute | Execute |
| Reviewer | Execute | Execute | Execute | Execute | Execute | Execute | Execute | Execute |
| ReviewCoordinator | Execute | Execute | Execute | Execute | Execute | Execute | Execute | Execute |
| ManagementReviewer | Execute | Execute | Execute | Execute | Execute | Execute | Execute | Execute |
| CodeReviewer | — | — | — | Consult | Consult | Execute | Execute | Consult |
| BusinessProcessAnalyst | Not active — Business Modeling inactive | — | — | — | — | — | — | — |
| BusinessReviewer | Not active — Business Modeling inactive | — | — | — | — | — | — | — |

**Parallelism discipline.** Adding agent roles to a phase increases coordination overhead — context conflicts and artifact contention — without proportional benefit. Iter-3 adds no role to the roster: the same roles that executed Iter-2 execute Iter-3, with the environment work moved to the front of the chain and given a single accountable owner. When the project is behind, the lever is another iteration to finish the declared scope, never more agents in parallel and never a cut to declared scope.

### Two currencies, reported apart

| Currency | What it measures | Iter-1 (measured actual) | Iter-2 (measured actual) | Iter-3 (measured actual) |
|---|---|---|---|---|
| Agent work | Tokens consumed, and the elapsed time the system measures | 6,918,081 tokens; 8:35:00.7478289 elapsed agent time | 12,066,256 tokens; 2:03:51.5597976 elapsed agent time | Not yet measured — the iteration has not closed |
| Human gate | Days of queue time waiting for a person | 0:00:00 measured, excluding the end-of-iteration approval gate, which is not measured | 0:00:00 measured, excluding the end-of-iteration approval gate, which is not measured | The CON-028 validation of the real Keycloak and AD by Infrastructure with HR has not yet opened; it opens in Elaboration, ceiling 14 days, then the process suspends |

The two are never summed into one figure and never converted into one another. There is no token budget on this project and none is to be set (CON-027): each iteration's measured spend is recorded and used to forecast the next, and declared scope is never cut or deferred to fit an estimate.

**What the measured actuals changed in this plan.** The previous plan projected two Inception iterations. Two closed iterations have now measured 18,984,337 tokens and 10:38:52.3076265 of elapsed agent time, and the one criterion Inception owes is still undelivered. The roadmap is therefore re-planned to three Inception iterations, and the fine plan is built only for Iter-3. No forecast is invented from a theoretical capacity, and no work item carries a size: this system measures tokens and elapsed time, and a work item sized in hours, days, weeks or person-anything would be a unit nothing here produces.

## Use Cases and Scenarios Addressed

| UC | Name | Priority | Volatility | This iteration | Scenarios carried |
|---|---|---|---|---|---|
| UC-001 | Clock In and Clock Out | Must | High | Specification carried; exercised against the stand-in OIDC issuer | Main flow; A1 network unavailable (AC-006); A2 pair already complete (CON-011); A3 open at midnight (CON-010); A4 HR views all clockings |
| UC-002 | Export Monthly Clocking Report | Must | Medium | Specification carried; exercised against the stand-in directory | Main flow; A1 day with no clocking; A2 missing clock-out; A3 corrected day; A4 no worker category (CON-015); A5 blank FullName (R002) |
| UC-008 | Search Employee Directory | Must | High | Specification carried; exercised against the stand-in directory, including the worker-category filter | Main flow; A1 empty job title or extension (R002); A2 no category (CON-015); A3 network unavailable; A4 no match; A5 category filter over the closed list of four (CON-013, CON-014) |
| UC-003 | Correct or Insert a Clocking | Must | Low | Outline | A1 no reason supplied; A2 no self-service correction |
| UC-004 | Read Internal News | Must | Low | Outline | A1 no item featured (CON-009); A2 network unavailable |
| UC-005 | Publish News | Must | Low | Outline | A1 featuring un-features the previous (CON-009); A2 featuring is never automatic |
| UC-006 | Edit Published News | Should | Low | Outline | A1 featured-flag change (CON-009) |
| UC-007 | Unpublish News | Should | Low | Outline | A1 the featured item is un-featured; A2 no hard delete (CON-017) |
| UC-009 | Assign or Clear Worker Category | Should | Low | Outline | A1 category cleared (CON-015); A2 fifth value refused (CON-014); A3 no employee field is editable (CON-005) |

**Why these three are detailed and the other six are not.** UC-001, UC-002 and UC-008 are the architecturally significant use cases. UC-001 forces the client-timestamp and idempotency decisions (AC-006) and the page-level script (CON-023). UC-008 forces the LDAP read merged with the portal-owned category link (CON-005, CON-016), must survive empty attributes (R002), and now filters by worker category (CON-013) — the one part of the directory that cannot be exercised against AD at all, because the category is the only field the portal owns. UC-002 forces the exact export contract of FR-003. The remaining six are outlined; the RequirementsSpecifier details them in Elaboration. Detailing them now would be planning beyond the horizon.

**What Iter-3 does with them.** No use case is implemented. The three detailed use cases are exercised against the stand-in environment — the test OIDC issuer and the test directory — which is what makes them buildable and testable in Elaboration. That exercise is the delivery of exit criterion 5, not an implementation.

## Evaluation Criteria

### Layer (a) — every declared acceptance criterion, accounted for

Every AC-NNN in the declared scope is listed. None is absent. This iteration verifies none of them: Inception produces the baseline, not a running system. Each is deferred to the named iteration whose increment closes it, and each carries a registered trace edge to the use case that carries it.

| AC | Criterion | Disposition | Carried by | Evidence that closes it |
|---|---|---|---|---|
| AC-001 | Full page load as the employee experiences it, including the clocking page's script, under 3 seconds | Deferred to Iter-6 (Construction) | UC-001 | A measured full page load on the corporate network against the running clocking page |
| AC-002 | An employee can clock in and out without help from HR or the development team | Deferred to Iter-6 (Construction) | UC-001 | An end-to-end clocking performed against the built increment |
| AC-003 | An HR Administrator can publish a news item without technical assistance | Deferred to Iter-6 (Construction) | UC-005 | An HR publish performed against the built increment |
| AC-004 | Any employee finds a colleague's phone/email in under 10 seconds | Deferred to Iter-7 (Construction) | UC-008 | A directory search performed against the built increment |
| AC-005 | 80% of employees complete at least one clocking with no prior training | Deferred to Iter-8 (Transition), and not closable by any test the team runs | UC-001 | Adoption counted from the clockings the portal records. The 3-month window extends beyond PR; the measurement is the stakeholder's |
| AC-006 | A clocking made while the corporate network is down for up to 5 minutes is not lost | Deferred to Iter-6 (Construction) | UC-001 | The localStorage retry, the client-supplied timestamp and the idempotency key exercised against the built increment |

### Layer (b) — this iteration's own exit criteria, each with its verdict

Each criterion carries a verdict of MET or NOT MET at the point this plan is written. A criterion whose evidence does not exist is recorded as NOT MET, never as an open item.

| # | Exit criterion | Verdict at Iter-3 start | Evidence that closes it |
|---|---|---|---|
| 1 | Stakeholders agree on the scope | **MET** | The Vision's declared scope and the Use-Case Model's nine use cases are the agreed baseline; no element outside the declared scope |
| 2 | The project is viable | **MET** | The stack is pinned by CON-022/CON-023/CON-024; the OIDC client is already registered (CON-003) so login is testable from day one; no technical unknown requires empirical validation (Development Case: Architectural Proof-of-Concept NOT FIRED) |
| 3 | Initial risks identified and classified | **MET** | Risk List: R001..R009 with probability, impact, magnitude, strategy, owner, mitigation and contingency. R001's P and I are recorded as unconfirmed estimates and no band is anchored on them; the bands are anchored on R002's and R003's declared exposures |
| 4 | The process configuration governs the project | **MET** | Development Case: Business Modeling inactive, no OPTIONAL trigger fired, version policy recorded |
| 5 | The stand-in environment is available (CON-028) | **NOT MET** | No artifact evidences the test OIDC issuer or the test directory. This is the criterion that gates every use case: CON-028 forbids building or testing against the real Keycloak or the real AD, so with no stand-in no use case can be built or tested and R004 remains untreated. It has failed at two consecutive closes and is the first work item of this iteration, under a hard gate |
| 6 | The build is verifiable (CON-026) | **MET** | The CI pipeline builds and tests on `main`; the build is green (run `36095051721`) |

**LCO readiness.** Criteria 1, 2, 3, 4 and 6 are met. **Criterion 5 is NOT MET at the point this plan is written** — it is the one criterion that gates every use case, it has now failed twice, and it is the first work item of this iteration under a hard gate. The LCO gate is therefore not passable until criterion 5's evidence exists. The LCO verdict is the ReviewCoordinator's and the ManagementReviewer's; this plan does not pre-empt it, and it does not present an unexecuted work item as an open item.

## Traceability
| Element | Traces From | Link Type | Traces To |
|---|---|---|---|
| Iteration Plan | FR-001, FR-003, FR-008 | Refines | UC-001, UC-002, UC-008 |
| Iteration Plan | CON-027 | DependsOn | R007 |
| Iteration Plan | CON-021, CON-028 | DependsOn | R005 |
| Iteration Plan | CON-028 | DependsOn | R004 |
| Iteration Plan | — | Refines | AC-001, AC-002, AC-003, AC-004, AC-005, AC-006 |
| AC-001 | NFR-001 | Refines | UC-001 |
| AC-002 | FR-001 | Refines | UC-001 |
| AC-003 | FR-005 | Refines | UC-005 |
| AC-004 | FR-008 | Refines | UC-008 |
| AC-005 | BG-003 | Refines | UC-001 |

The Development Case governs this plan: it fixes the active disciplines, the CORE artifact set, the agent role profile and the measurement policy. It is an artifact, not a trace-graph element, so no edge is registered on it; the governance is stated here and in Resources. The declared acceptance criteria AC-001..AC-006 are accounted for in Evaluation Criteria layer (a) and deferred to the iterations named there; each carries a registered edge to the use case that carries it, so the criterion-to-use-case mapping exists in the graph and not only as prose.

**Re-read against UC-008's change.** UC-008 now filters the directory by worker category (CON-013). This plan's end changed: the stand-in directory that work item 1 delivers must carry the worker-category link, because the category filter is the one part of UC-008 that cannot be exercised against AD at all. The change is declared in turn.

**Trace endpoints.** `FR-001`..`FR-009`, `NFR-001`..`NFR-005`, `AC-001`..`AC-006`, `CON-001`..`CON-032`, `BG-001`..`BG-003`, `STK-001`..`STK-004` and `R001`..`R009` are declared identifiers, copied exactly from the work order. `UC-001`..`UC-009` are the System Analyst's use-case identifiers. `LCO`, `LCA`, `IOC` and `PR` are the milestones this plan sequences. `run 36095051721` is an observed SCM fact, cited as returned by the `scm_*` tools. The findings cited above are the reviewers' `<artifact>#<key>` handles; a finding is not an element and no edge is registered on one.

**No element of this role is minted.** The Project Manager produces no `UC-NNN`, `CLS-NNN`, `COMP-NNN`, `TC-NNN` or `INT-NNN`; those families belong to other authorities. The objectives table, the milestone table, the iteration table, the work-item table and the agent role profile are sections of this plan, not trace-graph elements, so no edge is registered on them.

**Milestone not declared.** This plan produces the evidence the reviewers rule on. It does not declare the LCO milestone, the iteration or the phase as completed.

