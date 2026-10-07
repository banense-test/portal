## Document Control
### Reviewer lens
- **Phase:** Inception
- **Status:** Draft — under review
- **Milestone Target:** End of Inception (not yet achieved)
- **Iteration:** 1, Cycle 1
- **Owner:** Reviewer
- **Date:** 2026-10-07

### Business Reviewer lens
- **Phase:** Inception
- **Status:** Draft — under review
- **Milestone Target:** End of Inception (not yet achieved)
- **Iteration:** 1, Cycle 1
- **Owner:** BusinessReviewer
- **Date:** 2026-10-07

## Review Scope and Criteria
### Reviewer lens
#### Iteration 1

**Review type.** Technical review, checklist-driven, at the Lifecycle Objectives review point. The evaluative lens is FEASIBILITY and LCO EXIT CRITERIA, not completion: Inception 1 produces no executable increment, so no completion lens applies and no acceptance criterion is closable.

**Artifacts in scope.** All eight artifacts persisted this iteration: Development Case, Vision, Use-Case Model, Supplementary Specification, Software Architecture Document, Risk List, Iteration Plan, Test Evaluation Summary.

**Checklists applied.** Per artifact type, and recorded item by item in the compliance matrix below.

| Artifact | Checklist applied |
|---|---|
| Development Case | DC Baseline Conformance (roster, CORE catalog, ownership, artifact universe, intensity) + Optional Trigger Justification against each §5.2 condition + tool-baseline verification against the repository |
| Vision | Requirements quality: complete, consistent, unambiguous, traceable, no unsourced quantitative claim; scope adherence against the declared input |
| Use-Case Model | Use-case quality: one-to-one with declared requirements, `Source: FR-NNN` on every use case, no phantom use case, no cross-cutting mechanism as a use case, no per-actor split, UML formal correctness |
| Supplementary Specification | FURPS+ coverage of every declared NFR, AC and CON; cross-cutting mechanisms specified and not promoted to use cases; threshold quantification |
| Software Architecture Document | Architecture quality: every subsystem traces to a declared element, no layer- or feature-named subsystem, one seam per High-volatility area, external-system placement, invariants as constraints, no invented technology |
| Risk List | Risk quality: declared risks preserved, team risks numbered per CON-023, strategy and owner per risk, acceptance basis named, no human-team unit |
| Iteration Plan | Plan quality: objectives carry exit evidence, no unmeasured unit, human gate bounded as a risk, two currencies never summed, all acceptance criteria accounted for |
| Test Evaluation Summary | Verifiability: every declared requirement has an observable verification method, no execution claimed, SCM signals read and recorded |

**Upstream consumption.** Every artifact was read in full before any finding was recorded. The declared scope in the Work Order was read as the ceiling. The trace graph was projected from the Business level (43 roots, 141 nodes) and read against each artifact's declared traceability. The SCM was read directly: build status on `main`, the issue tracker in all states, the open pull-request list, the branches awaiting review, and the repository tree.

**SCM evidence read this iteration.**

| Signal | Observed |
|---|---|
| Build, branch `main` | `ci-run-37583334371` — success, 2026-10-07 06:45:58Z to 06:47:38Z |
| Open pull requests | None |
| Branches labelled `ready-for-review` | None |
| Issues, all states | None |
| Repository tree | `.github/workflows/ci.yml` (sha `0c2fd7cf47eeab68d19420fe3897d209258bd074`), `Portal.sln` (sha `f554bf5bc04df43103677206c7727fcc62ea2bc4`), `src/Portal.Web/Portal.Web.csproj`, `tests/Portal.Tests/Portal.Tests.csproj`, `README.md`, `docs/inputs/employee-portal-design.html` (sha `715d4f73d6ef4de18c46242258bc17a67f51ba6f`). `CONTRIBUTING.md` and `.editorconfig` absent. |

**Pull-request disposition.** No open pull request exists, so every pull request has reached a terminal disposition vacuously and no disposition call was required. The repository carries scaffolding only — a solution, two empty projects, a CI workflow, a README and the mandatory design reference. No productive code is present, which is consistent with Inception scope. No scope-ahead branch exists.

**Entry criteria.** Met. All eight artifacts are complete and stable, no section is a placeholder, the upstream artifacts each artifact depends on are persisted, and the checklists were prepared before the artifacts were read.

### Business Reviewer lens
#### Iteration 1

**Review type.** Business Modeling lens, at the Lifecycle Objectives review point. The evaluative lens is LCO EXIT CRITERIA applied to the business dimension: is the business modeling contribution to this milestone correct, complete and sufficient — and, where the discipline is inactive, is that inactivity EARNED rather than assumed.

**Scenario assessment (stated first, per the decision heuristics).** Of the six business modeling scenarios, none applies. The engagement is not Organization Chart, Domain Modeling, One Business Many Systems, Generic Business Model, New Business or Revamp. The declared scope names three system use cases over a data-capture and information-publishing intranet; there is no business process to decompose, no business actor outside the organization, no business entity model and no business rules engine. The correct scenario outcome is **no business modeling scenario applies**, and the discipline is INACTIVE.

**Independence of the verdict.** The ProcessEngineer's classification (`isBusinessProcessLed = false`, DC T-1) was not accepted on its face. It was re-derived from the declared scope and from the eight persisted artifacts, against the four DC §4 tests: (a) a business actor external to the organization — none, both roles are inside Cuba Corp; (b) an end-to-end process delivering value to that actor — none, the three declared processes are independent system interactions; (c) business workers and business entities realizing it — none; (d) a business rules engine or workflow engine — none, the invariants are database constraints (ADR-003). All four tests return NONE. The verdict is earned.

**Artifacts in scope.** All eight artifacts persisted this iteration, read in full: Development Case, Vision, Use-Case Model, Supplementary Specification, Software Architecture Document, Risk List, Iteration Plan, Test Evaluation Summary. The Review Record was read for the Reviewer's technical-lens block and for prior BusinessReviewer findings.

**Checklist applied.** The Business Modeling checklist, item by item, with N/A recorded where the discipline is inactive — an N/A is a recorded evaluation, not a skipped one.

| # | Checklist item | Result |
|---|---|---|
| 1 | Scenario selection correct and explicit | Pass — no scenario applies; verdict re-derived independently |
| 2 | BUC completeness (actor-initiated, value-delivering, end-to-end) | N/A — no BUC exists, correctly |
| 3 | BUC realization adequacy (workers and entities) | N/A — no realization expected or required |
| 4 | Derivation bridge (worker to system actor, entity to analysis class) | N/A — no business worker or entity exists to map |
| 5 | Resource planning compliance (one resource per worker) | N/A — no worker, no entity, no resource allocation |
| 6 | Same modeling technique at business level (business stereotypes) | N/A — no business-level model; no software stereotype misapplied at business level |
| 7 | Stakeholder representation coverage | Pass — STK-001 to STK-004 all represented |
| 8 | Business rules as formal constraints (ID, source, attachment, testable) | Pass — CON-007 to CON-016 and CON-043 each carry an ID and a named bearing |
| 9 | UML presence and richness | Pass — eight artifacts, each carrying validated PlantUML |
| 10 | Scope adherence — no business-modeling scope creep | Pass — zero BUC, zero BR-NNN, zero business stereotype |

**Business Modeling artifact coverage.**

```plantuml
@startuml
title Business Modeling artifact coverage — LCO Inception 1 (Portal)

skinparam classAttributeIconSize 0
skinparam packageStyle rectangle

package "Business Modeling artifact set — expected only when the discipline is ACTIVE" as BM {
  class "Business Use-Case Model\nBUC-NNN, business actors,\nbusiness workers, business entities" as A1 <<ABSENT>> {
    Verdict: NOT APPLICABLE
    Discipline inactive per DC T-1
    DC 4 business-process-led = false
  }
  class "Business Rules document\nBR-NNN with source and\nworker or entity attachment" as A2 <<ABSENT>> {
    Verdict: NOT APPLICABLE
    CON-007 to CON-016 and CON-043 are
    stakeholder-declared constraints,
    not BPA-authored business rules
  }
  class "Business Object Model\nclass diagram, worker and\nentity realizations" as A3 <<ABSENT>> {
    Verdict: NOT APPLICABLE
    No business entity model in scope
  }
  class "Business Glossary\nspecialist vocabulary" as A4 <<ABSENT>> {
    Verdict: NOT APPLICABLE
    Optional trigger NOT FIRED
  }
}

package "System-level artifacts present — Requirements, A and D, Test, PM, Environment" as SYS {
  class "Vision" as V <<PRESENT>>
  class "Use-Case Model\nUC-001 to UC-012, system actors" as U <<PRESENT>>
  class "Supplementary Specification" as S <<PRESENT>>
  class "Software Architecture Document" as D <<PRESENT>>
  class "Risk List" as R <<PRESENT>>
  class "Iteration Plan" as I <<PRESENT>>
  class "Test Evaluation Summary" as T <<PRESENT>>
  class "Development Case\nT-1 Business Modeling INACTIVE" as C <<PRESENT>>
}

package "Gate evaluation" as GATE {
  class "DC 4 trigger\nbusiness-process-led" as G1 <<gate>> {
    Value: false
    No process modelled, automated
    or orchestrated
  }
  class "DC 4 trigger\nBM sections in any artifact" as G2 <<gate>> {
    Value: 0
    No BUC, no business worker,
    no business entity, no BR-NNN
  }
  class "Business Reviewer verdict" as G3 <<verdict>> {
    BR-OK-INACTIVE
    Discipline NOT APPLICABLE
  }
}

G1 --> G3
G2 --> G3
A1 -[hidden]- A2
A2 -[hidden]- A3
A3 -[hidden]- A4
V -[hidden]- U
U -[hidden]- S
S -[hidden]- D
D -[hidden]- R
R -[hidden]- I
I -[hidden]- T
T -[hidden]- C
BM -[hidden]- SYS
SYS -[hidden]- GATE

note bottom of BM
  Zero of four expected BM artifacts exist.
  This is the CORRECT state for a
  non-business-process-led engagement,
  not a defect: the discipline is inactive
  by the Development Case tailoring
  decision T-1.
end note

note bottom of SYS
  None of the eight artifacts carries a
  business-modeling section. No
  business actor, business worker,
  business entity or business use case
  stereotype appears anywhere.
end note
@enduml
```

**Trigger evaluation — the evidence the INACTIVE verdict rests on.**

```plantuml
@startuml
title DC 4 trigger evaluation — candidate business-process signals, LCO Inception 1 (Portal)

skinparam classAttributeIconSize 0
skinparam packageStyle rectangle

package "Candidate signals examined in the declared scope" as CAND {
  class "Three processes named\nclocking, news, directory" as S1 <<candidate>> {
    Declared as three USE CASES
    FR-001 to FR-012
    Each is a system interaction,
    not an end-to-end business process
  }
  class "Business rules present\nCON-007 to CON-016, CON-043" as S2 <<candidate>> {
    Declared by the STAKEHOLDER
    as constraints, not authored
    by a BPA as BR-NNN
  }
  class "Two organizational roles\nHR and Employee" as S3 <<candidate>> {
    System actors of the portal
    CON-018 two authorization levels
    No business worker, no
    organizational unit modelled
  }
  class "External systems\nKeycloak, Active Directory" as S4 <<candidate>> {
    Supporting actor of UC-011 only
    CON-030, CON-032
    Not business actors
  }
  class "Closed value lists\nCON-015, CON-043" as S5 <<candidate>> {
    Fixed enumerations of four values
    System rules, not a
    business rules engine
  }
  class "Offline retry CON-040" as S6 <<candidate>> {
    One client-side POST retry
    One action, one queue, one entity
    No workflow to orchestrate
  }
}

package "DC 4 test — is a business process modelled, automated or orchestrated?" as TEST {
  class "Business actor outside\nthe organization" as T1 <<test>> {
    Result: NONE
    Both roles are inside Cuba Corp
  }
  class "End-to-end process\ndelivering value to that actor" as T2 <<test>> {
    Result: NONE
    Three independent system
    interactions, no process chain
  }
  class "Business workers and\nbusiness entities to realize it" as T3 <<test>> {
    Result: NONE
    No worker, no entity model
  }
  class "Business rules engine\nor workflow engine" as T4 <<test>> {
    Result: NONE
    Invariants are DB constraints
    ADR-003
  }
}

package "Verdict" as V {
  class "business-process-led" as V1 <<verdict>> {
    FALSE
    DC 4 trigger not fired
  }
  class "Business Modeling discipline" as V2 <<verdict>> {
    INACTIVE
    DC T-1
  }
  class "Business Reviewer lens" as V3 <<verdict>> {
    BR-OK-INACTIVE
    No findings, no recommendations
  }
}

S1 --> T1
S2 --> T4
S3 --> T1
S4 --> T1
S5 --> T4
S6 --> T2
T1 --> V1
T2 --> V1
T3 --> V1
T4 --> V1
V1 --> V2
V2 --> V3

note bottom of CAND
  Six candidate signals were examined.
  Each resolves to a system-level
  construct already owned by the
  Requirements or Analysis and Design
  discipline, not to a business process.
end note

note bottom of TEST
  All four DC 4 tests return NONE.
  The trigger condition does not hold
  against the project's real facts.
end note

note bottom of V
  The INACTIVE verdict is EARNED by
  evaluation, not assumed from the
  ProcessEngineer's claim. The
  classification was independently
  re-derived from the declared scope
  and the eight persisted artifacts.
end note
@enduml
```

**Upstream consumption.** The declared scope in the Work Order was read as the ceiling. All eight persisted artifacts were read in full. The Development Case's classification verdicts, tailoring decisions T-1 to T-7, optional-trigger table and intensity statement were read against the DC §4 trigger conditions. The Review Record was read for the Reviewer's technical-lens block and for prior BusinessReviewer findings.

**Entry criteria.** Met. All eight artifacts are complete and stable, no section is a placeholder, and the checklist was prepared before the artifacts were read.

## Findings
### Reviewer lens
#### Iteration 1

Seven findings: three Major, four Minor, no Critical. Two artifacts carry no finding and are Approved from this lens.

```plantuml
@startuml
title Compliance matrix — LCO technical lens, Inception 1 (Portal)

skinparam classAttributeIconSize 0
skinparam classFontStyle bold
skinparam classBackgroundColor #FFFFFF

class "Development Case" as DC <<artifact>> {
  DC-1 Delta only, baseline not restated
  DC-2 25-role roster not redefined
  DC-3 16 CORE artifacts, none omitted
  DC-4 CORE ownership not reassigned
  DC-5 No artifact outside CORE + OPTIONAL
  DC-6 Optional triggers audited, none fired
  DC-7 Intensity equals canonical matrix
  DC-8 Tool baseline matches the repository
}

class "Vision" as VIS <<artifact>> {
  V-1 Problem statement traces to declared scope
  V-2 STK-001 to STK-004 complete
  V-3 Features equal the 12 declared FR, no surplus
  V-4 CON-001 to CON-043 complete
  V-5 NFR, BG and AC complete
  V-6 No unsourced quantitative claim
  V-7 Assumptions reconciled with CON-035
  V-8 UML present
}

class "Use-Case Model" as UCM <<artifact>> {
  U-1 12 use cases to 12 declared FR, one-to-one
  U-2 Every use case carries Source: FR-NNN
  U-3 No phantom use case, no quotation in source slot
  U-4 No cross-cutting mechanism as a use case
  U-5 No use case split per actor
  U-6 5 architecturally significant use cases detailed
  U-7 Actor association direction correct
  U-8 UML present
}

class "Supplementary Specification" as SS <<artifact>> {
  S-1 FURPS+ home for every declared NFR, AC and CON
  S-2 Cross-cutting mechanisms specified, not use cases
  S-3 Audit change classes equal NFR-001's three
  S-4 Thresholds quantified where declared
  S-5 No invented threshold
  S-6 Mechanism include lists match the use-case specs
  S-7 UML present
}

class "Software Architecture Document" as SAD <<artifact>> {
  A-1 Every subsystem maps to a declared UC, FR or CON
  A-2 No subsystem named after a layer or a feature
  A-3 Each High-volatility area owns a seam
  A-4 Keycloak inside the network, not a cloud node
  A-5 No Keycloak deployment work
  A-6 AD read-only, no local copy of the employee
  A-7 Invariants enforced as database constraints
  A-8 No technology or version invented
  A-9 UML present, 4+1 views
}

class "Risk List" as RL <<artifact>> {
  R-1 R001 and R002 preserved with declared P and I
  R-2 Team risks numbered from R003 in order raised
  R-3 Every risk has strategy, owner, mitigation, contingency
  R-4 Acceptance basis named for each accepted risk
  R-5 CON-025 exclusions not registered
  R-6 No human-team unit, no velocity
  R-7 Early-warning indicator observable
  R-8 UML present
}

class "Iteration Plan" as IP <<artifact>> {
  I-1 Objectives carry exit evidence
  I-2 No work item sized in an unmeasured unit
  I-3 Human gate bounded as a risk, not an estimate
  I-4 Two currencies never summed
  I-5 All 6 AC accounted for, none closed
  I-6 No calendar date projected
  I-7 Roadmap chart carries no duration
  I-8 UML present
}

class "Test Evaluation Summary" as TES <<artifact>> {
  T-1 Every declared requirement has a verification method
  T-2 No test executed, none claimed
  T-3 Test Plan omission declared with trigger basis
  T-4 Entry criteria stated with status
  T-5 SCM signals read and recorded
  T-6 SCM signal reconciles with the SCM
  T-7 Traceability registered in the graph
  T-8 UML present
}

note bottom of DC
  DC-8 FAIL — the S1 tool assessment and the gap
  table contradict the repository.
end note

note bottom of TES
  T-5 FAIL — the cited run id and window do not
  match the observed build.
  T-6 FAIL — the reading drawn from it is false.
  T-7 FAIL — no link is registered in the graph.
end note

note bottom of UCM
  U-7 FAIL — AD is drawn as the initiating end.
end note

note bottom of SS
  S-6 FAIL — the audit include list omits UC-010.
end note

note bottom of VIS
  V-7 FAIL — A-1 is not reconciled with CON-035.
end note

note bottom of IP
  I-7 FAIL — the gantt asserts a one-day duration.
end note

note bottom of SAD
  All items PASS. No finding recorded.
end note

note bottom of RL
  All items PASS. No finding recorded.
end note

DC -[hidden]- VIS
VIS -[hidden]- UCM
UCM -[hidden]- SS
SS -[hidden]- SAD
SAD -[hidden]- RL
RL -[hidden]- IP
IP -[hidden]- TES
@enduml
```

```plantuml
@startuml
title Defect distribution — severity x artifact, LCO technical lens, Inception 1 (Portal)

skinparam classAttributeIconSize 0
skinparam packageStyle rectangle

package "Critical — 0" as CRIT {
  class "none" as C0 <<empty>> {
    No LCO gate blocker found.
    No scope hallucination.
    No phantom use case.
    No baseline redefinition.
  }
}

package "Major — 3" as MAJ {
  class "Development Case" as M1 <<artifact>> {
    F1 Tool baseline contradicts the repository:
    CI workflow, solution and two projects
    are committed and the build is green.
  }
  class "Test Evaluation Summary" as M2 <<artifact>> {
    F1 SCM signal does not reconcile:
    cited run id and window are not the
    observed build; the reading is false.
    F2 Traceability not registered in the graph.
  }
}

package "Minor — 4" as MIN {
  class "Use-Case Model" as N1 <<artifact>> {
    F1 AD drawn as the initiating end
    of the UC-011 association.
  }
  class "Supplementary Specification" as N2 <<artifact>> {
    F1 Audit include list omits UC-010,
    which audits the change itself.
  }
  class "Vision" as N3 <<artifact>> {
    F1 A-1 not reconciled with CON-035.
  }
  class "Iteration Plan" as N4 <<artifact>> {
    F1 Gantt asserts a one-day duration
    the plan declares unmeasured.
  }
}

package "Clean — 2 artifacts, silence is the verdict" as CLEAN {
  class "Software Architecture Document" as K1 <<artifact>> {
    No finding. 10 subsystems, 10 interfaces,
    6 ADRs, 4+1 views, all traced.
  }
  class "Risk List" as K2 <<artifact>> {
    No finding. R001 to R010 classified,
    CON-024 acceptance basis named.
  }
}

package "Suggestion — 0" as SUG {
  class "none" as S0 <<empty>>
}

note bottom of MAJ
  Both Major findings are factual errors about
  observable state, not design disagreements.
  Neither blocks the LCO gate: the architecture,
  the requirements baseline and the risk record
  are sound. They must be corrected before the
  Elaboration checkpoint is used as a gate.
end note

note bottom of CLEAN
  An artifact with no finding is Approved from
  this lens. Silence is the verdict.
end note

CRIT -[hidden]- MAJ
MAJ -[hidden]- MIN
MIN -[hidden]- CLEAN
CLEAN -[hidden]- SUG
@enduml
```

#### Development Case — Major

**F1 — The tool baseline contradicts the repository.** The section "Organization and tool assessment (S1, 2026-10-07)" states the repository holds the design reference "and nothing else. No CI workflow file, no `CONTRIBUTING.md`, no lint or analyzer configuration, and no open Change Requests." The gap table repeats it: "CI workflow under the hosted provider | Absent — gap". The SCM contradicts this. `.github/workflows/ci.yml` is committed at sha `0c2fd7cf47eeab68d19420fe3897d209258bd074`; `Portal.sln` is committed with two projects, `src/Portal.Web/Portal.Web.csproj` and `tests/Portal.Tests/Portal.Tests.csproj`; and a build ran on `main` (`ci-run-37583334371`). The two other gap claims — `CONTRIBUTING.md` and the lint/analyzer configuration — are correct. The consequence is operational: the Elaboration iteration-preparation checkpoint demands "CI workflow committed and green on an empty build" as an outstanding condition, and that condition is already satisfied, so the checkpoint as written would send Elaboration to close a gap that does not exist.

*Remediation.* Rewrite the S1 tool assessment and the gap table against the repository: record the CI workflow as present, the solution and the two scaffolding projects as present, and keep only `CONTRIBUTING.md` and the lint/analyzer configuration as open gaps. Remove "CI workflow committed and green on an empty build" from the Elaboration checkpoint's outstanding conditions, or restate it as already satisfied. The tailoring decisions T-1 to T-7, the classification verdicts, the optional-trigger table and the intensity statement are unaffected and stand.

*Evidence.* DC: "The repository holds the mandatory UI design reference at `docs/inputs/employee-portal-design.html` (CON-038) and nothing else. No CI workflow file..." against `scm_get_file_content('.github/workflows/ci.yml')` sha `0c2fd7cf47eeab68d19420fe3897d209258bd074`; `scm_get_file_content('Portal.sln')` sha `f554bf5bc04df43103677206c7727fcc62ea2bc4`; `scm_get_build_status(main)` `ci-run-37583334371`.

#### Test Evaluation Summary — Major

**F1 — The recorded SCM quality signal does not reconcile with the SCM, and the conclusion drawn from it is false.** The table cites "`ci-run-37581397618` — build and test completed, 2026-10-07 06:25:16Z to 06:26:16Z" and reads it as "No workflow file is committed, so this run is not the per-push build-and-test the regression rule needs (CON-033, E-6)." The run observed on `main` is `ci-run-37583334371`, 2026-10-07 06:45:58Z to 06:47:38Z; the cited run id and window do not match it. The inference is false independently of which run was read: `.github/workflows/ci.yml` is committed and triggers on `push` and on `pull_request`, so the run IS the per-push build-and-test. Entry criterion E-6 is met, not unmet, and the CI workflow appears wrongly in the three conditions of "Recommendation — Proceed to Elaboration" and in "Carried into Elaboration".

*Remediation.* Re-read the build status and the workflow file, replace the cited run id and window with the observed values, and correct the reading: E-6 is met. Remove the CI workflow from the three conditions in "Recommendation — Proceed to Elaboration" and from "Carried into Elaboration", leaving the two genuine gaps — the test stand-ins and the test conventions in `CONTRIBUTING.md`.

*Evidence.* TES: "`ci-run-37581397618` — build and test completed, 2026-10-07 06:25:16Z to 06:26:16Z" and "No workflow file is committed" against `scm_get_build_status(main)` = `ci-run-37583334371`, 2026-10-07 06:45:58Z to 06:47:38Z; `scm_get_file_content('.github/workflows/ci.yml')` present with `on: push` and `on: pull_request`.

**F2 — The declared traceability is not registered in the trace repository.** The Traceability table declares `Refines` links to Test Case, Risk List, Development Case, Use-Case Model, Vision and Supplementary Specification, and `DependsOn` links to the Software Architecture Document, and the "Coverage" paragraph claims twelve requirements, six acceptance criteria, five non-functional requirements and ten risks are each accounted for. The graph carries none of it: `model_get_upstream('Test Evaluation Summary')` returns no links, and the artifact does not appear anywhere in the Business-level trace tree, which lists Development Case, Vision, Use-Case Model, Supplementary Specification, Risk List, Iteration Plan, Software Architecture Document and Test Case. The coverage the summary claims therefore cannot be verified from the graph.

*Remediation.* Register the Test Evaluation Summary's upstream links in the trace repository — NFR-001 to NFR-005, AC-001 to AC-006, UC-001 to UC-012, R001 to R010, FR-001 to FR-012, CON-021/CON-033/CON-035/CON-040/CON-041, COMP-001 to COMP-010 and INT-001 to INT-010 — so the declared coverage is machine-verifiable. If the registration belongs to the SystemAnalyst as steward of the trace repository, raise it to that role rather than leaving the artifact unlinked.

*Evidence.* `model_get_upstream(projectId, 'Test Evaluation Summary')` returns "No trace links found for 'Test Evaluation Summary' (direction: upstream)"; the Business-level trace tree contains no Test Evaluation Summary node.

#### Use-Case Model — Minor

**F1 — Active Directory is drawn as the initiating end of the association to UC-011.** The Use-Case Diagram carries `AD --> UC011`, which asserts that the external system initiates the use case. The portal initiates the LDAP read; AD never initiates anything. The Actors table already describes AD correctly as "External system, supporting", so the diagram and the table disagree about the direction of initiation.

*Remediation.* Draw the association from UC-011 to Active Directory, or use a directed association whose arrow sits at AD, and keep AD as a supporting actor in the Actors table. The justification for modelling AD as a supporting actor — a live read of a system of record the portal does not own — is sound and needs no change.

*Evidence.* Use-Case Model, Use-Case Diagram: `AD --> UC011`; Actors table: "Active Directory | External system, supporting".

#### Supplementary Specification — Minor

**F1 — The audit mechanism's include list omits UC-010, while UC-010's own specification audits the change.** The cross-cutting mechanism table lists the audit trail as "Included by UC-005, UC-006, UC-008, UC-009, UC-012", and the mechanism diagram draws no AUDIT edge from U10. UC-010's main flow step 5 reads "The portal audits the change." Two statements about the same change class disagree, and NFR-001 is a mandatory audit requirement, so a downstream implementer has no single answer for whether the featuring path writes an audit record.

*Remediation.* Reconcile the two. Either add UC-010 to the audit mechanism's include list and draw the AUDIT edge from U10, or remove the audit step from UC-010 and state there that featuring is audited through UC-006 or UC-008. Keep the existing NFR-001 reasoning that featuring is not a fourth change class.

*Evidence.* Supplementary Specification, cross-cutting mechanism table: "Audit trail ... Included by UC-005, UC-006, UC-008, UC-009, UC-012"; Use-Case Model, UC-010 main flow step 5: "The portal audits the change."

#### Vision — Minor

**F1 — Assumption A-1 is not reconciled with CON-035.** A-1 reads "The portal's OIDC client is already registered in Keycloak and the credentials are with the development team, so login can be tested from day one." It does not say which issuer "tested from day one" means, while CON-035 requires the team to build and test against stand-ins and never against the real Keycloak, and A-3 in the same table states the stand-in rule. A downstream role can read A-1 as authorising team testing against the real Keycloak, which CON-035 forbids.

*Remediation.* State in A-1 that the registered client and its credentials exist for the human validation gate performed by Infrastructure with HR, and that team testing is against the stand-in OIDC issuer per CON-035 and A-3. The declared stakeholder statement is faithfully recorded; only the reconciliation is missing.

*Evidence.* Vision, Assumptions and Dependencies: A-1 against A-3 ("The team builds and tests against stand-ins it controls") and CON-035.

#### Iteration Plan — Minor

**F1 — The roadmap chart asserts durations the plan itself declares unmeasured.** The `@startgantt` block gives every iteration "lasts 1 day" and chains them end to end, while the caption states "The axis is ordinal, not calendar: one bar is one iteration and its width is a nominal unit, not a duration" and "No project start date is set and no calendar date is projected from an estimate." A reader who reads the chart and not the caption sees a seven-day project, which is a duration in a unit this system does not measure.

*Remediation.* Replace the gantt with a sequence or activity diagram that carries no duration, or state the nominal unit inside the chart itself — in its title or a note — so the chart cannot be read as a schedule. The milestone sequence, the iteration boundaries and the human-gate treatment are correct and need no change.

*Evidence.* Iteration Plan, Plan and Milestones: "[I1 Inception 1] lasts 1 day" ... "[T1 Transition 1] lasts 1 day" against the caption "The axis is ordinal, not calendar".

#### Software Architecture Document — no finding

No defect recorded. Every subsystem traces to a declared use case, requirement or constraint; no subsystem is named after a layer or a feature; each `Volatility: High` area owns a seam (`COMP-002` behind `INT-002`, `COMP-004` behind `INT-004`); Keycloak is placed inside the corporate network and no Keycloak deployment work is planned; AD is read-only with no local copy of the employee; the three invariants are enforced as database constraints; and no technology or version is invented. Approved from this lens.

#### Risk List — no finding

No defect recorded. R001 and R002 are preserved with their declared probability and impact; R003 to R010 are numbered in the order raised per CON-023; every risk carries a strategy, an owner, a mitigation, a contingency and an observable early-warning indicator; every accepted risk names its CON-024 basis; the CON-025 exclusions are not registered; and no human-team unit or velocity appears. Approved from this lens.

#### Traceability compliance — this iteration

```plantuml
@startuml
title Traceability compliance — declared scope to artifact, findings annotated (Portal, Inception 1)

skinparam classAttributeIconSize 0
skinparam packageStyle rectangle

package "Declared input — 12 FR, 5 NFR, 6 AC, 43 CON, 3 BG, 2 R" as DECL {
  class "FR-001 to FR-012" as FR <<declared>>
  class "NFR-001 to NFR-005" as NFR <<declared>>
  class "AC-001 to AC-006" as AC <<declared>>
  class "CON-001 to CON-043" as CON <<declared>>
  class "BG-001 to BG-003" as BG <<declared>>
  class "R001, R002" as R <<declared>>
}

package "Business level — requirements baseline" as BIZ {
  class "Vision" as VIS <<artifact>>
  class "Use-Case Model" as UCM <<artifact>>
  class "Supplementary Specification" as SS <<artifact>>
  class "Risk List" as RL <<artifact>>
  class "Iteration Plan" as IP <<artifact>>
  class "Development Case" as DC <<artifact>>
}

package "Logical level — candidate architecture" as LOG {
  class "Software Architecture Document" as SAD <<artifact>>
  class "COMP-001 to COMP-010" as COMP <<element>>
  class "INT-001 to INT-010" as INT <<element>>
}

package "Code level" as CODE {
  class "Test Evaluation Summary" as TES <<artifact>>
  class "Test Case" as TC <<artifact>> {
    Empty this iteration.
    No use-case realization exists.
  }
}

FR --> UCM : Refines
NFR --> SS : Refines
AC --> VIS : Refines
CON --> SS : Refines
BG --> VIS : Refines
R --> RL : Refines

UCM --> SAD : Derives
SS --> SAD : Refines
VIS --> UCM : Refines
RL --> IP : Refines
DC --> IP : Refines

SAD --> COMP : Derives
COMP --> INT : DependsOn
SAD --> TC : Refines
TES --> TC : Refines

note right of UCM
  FINDING Minor F1
  AD drawn as the initiating end
  of the UC-011 association.
end note

note right of SS
  FINDING Minor F1
  Audit include list omits UC-010.
end note

note right of VIS
  FINDING Minor F1
  A-1 not reconciled with CON-035.
end note

note right of IP
  FINDING Minor F1
  Gantt asserts a one-day duration.
end note

note right of DC
  FINDING Major F1
  Tool baseline contradicts the repository.
end note

note right of TES
  FINDING Major F1, F2
  SCM signal does not reconcile;
  traceability not registered in the graph.
end note

note bottom of SAD
  No finding. Every subsystem traces to a
  declared UC, FR or CON. No «LEAF» at
  Business level: all 12 FR reach a use case.
end note

note bottom of RL
  No finding. R001 to R010 each carry a
  strategy, an owner, a mitigation, a
  contingency and an observable indicator.
end note

note bottom of TC
  «LEAF» by design, not by defect: the Test
  Case artifact is empty because no use-case
  realization exists in Inception. The
  Iteration Plan defers test authoring to
  Elaboration 2.
end note

DECL -[hidden]- BIZ
BIZ -[hidden]- LOG
LOG -[hidden]- CODE
@enduml
```

**What the graph shows.** Every one of the twelve declared requirements reaches a use case — no `«LEAF»` at the Business level, so no requirement is unrealized. Every use case reaches a component in the Software Architecture Document. No `«SUSPECT → role»` edge exists anywhere in the tree, so no role is holding an unreviewed change. The `Test Case` node is a `«LEAF»` by design: the artifact is empty because no use-case realization exists in Inception, and the Iteration Plan defers test authoring to Elaboration 2.

**What the graph does not show.** The Test Evaluation Summary is absent from the tree entirely, which is finding F2 above. Its declared coverage of twelve requirements, six acceptance criteria, five non-functional requirements and ten risks is asserted in prose and unverifiable from the graph.

**Coverage of the declared input.** All twelve FR, five NFR, six AC, forty-three CON, three BG and two declared risks are cited by at least one artifact. No artifact cites an identifier outside the declared families. No artifact quotes the stakeholder in place of citing an identifier.

### Business Reviewer lens
#### Iteration 1

**Zero findings from this lens.** No Critical, Major, Minor or Info finding is recorded against any artifact. The Business Modeling discipline is inactive and its inactivity is correct; there is no business-modeling defect to report. An artifact with no finding is Approved from this lens.

**Scoring — criterion by criterion.**

```plantuml
@startuml
title Business Reviewer scoring — LCO Inception 1 (Portal)

skinparam classAttributeIconSize 0
skinparam packageStyle rectangle

package "Criteria evaluated — N/A where the discipline is inactive" as CRIT {
  class "Scenario selection\ncorrect and explicit" as C1 <<criterion>> {
    Score: 10 / 10
    DC 4 verdict false, independently
    re-derived from declared scope
    and the eight persisted artifacts
  }
  class "BUC completeness test\nactor-initiated, value, end-to-end" as C2 <<criterion>> {
    Score: N/A
    No BUC exists. Correct: the three
    declared processes are system
    use cases, not business use cases
  }
  class "BUC realization adequacy\nworkers and entities" as C3 <<criterion>> {
    Score: N/A
    No realization expected in Inception
    and none required by an inactive
    discipline
  }
  class "Derivation bridge\nworker to system actor mapping" as C4 <<criterion>> {
    Score: N/A
    No business worker exists to map.
    The system actors are declared
    directly: STK-001, STK-004
  }
  class "Resource planning compliance\none resource per worker" as C5 <<criterion>> {
    Score: N/A
    No business worker, no business
    entity, no resource allocation
  }
  class "Same modeling technique\nat business level" as C6 <<criterion>> {
    Score: N/A
    No business-level model exists.
    No software stereotype was
    misapplied at business level
  }
  class "Stakeholder representation\ncoverage" as C7 <<criterion>> {
    Score: 9 / 10
    All four declared STK represented.
    No organizational part in declared
    scope is unmodelled
  }
  class "Business rules as formal\nconstraints" as C8 <<criterion>> {
    Score: 9 / 10
    CON-007 to CON-016 and CON-043 are
    stakeholder-declared, each with an
    ID and a bearing. Source is the
    declared constraint itself
  }
  class "UML presence and richness" as C9 <<criterion>> {
    Score: 9 / 10
    Eight artifacts, each carrying
    validated PlantUML. No prose-only
    model anywhere
  }
  class "Scope adherence\nno BM scope creep" as C10 <<criterion>> {
    Score: 10 / 10
    Zero BUC, zero BR-NNN, zero
    business stereotype. No undeclared
    business process was invented
  }
}

package "Aggregate" as AGG {
  class "Weighted verdict" as A1 <<verdict>> {
    Applicable criteria: 5
    Mean: 9.4 / 10
    N/A criteria: 5 of 10
  }
  class "Disposition" as A2 <<verdict>> {
    BR-OK-INACTIVE
    Discipline NOT APPLICABLE
    per DC 4
  }
  class "Findings emitted" as A3 <<verdict>> {
    Critical: 0
    Major: 0
    Minor: 0
    Info: 0
  }
}

C1 --> A1
C7 --> A1
C8 --> A1
C9 --> A1
C10 --> A1
A1 --> A2
A2 --> A3

note bottom of CRIT
  Five of ten criteria are N/A because
  the discipline is inactive. Scoring
  them would be a false defect: the
  anti-pattern of applying New Business
  standards to a non-BPL engagement.
end note

note bottom of AGG
  No finding is emitted. An artifact with
  no finding is Approved from this lens.
  The INACTIVE verdict is the verdict.
end note
@enduml
```

**Criterion justification.**

| Criterion | Score | Justification |
|---|---|---|
| Scenario selection | 10/10 | No business modeling scenario applies. The verdict was re-derived independently against the four DC §4 tests, all of which return NONE. The ProcessEngineer's claim was audited, not accepted. |
| BUC completeness | N/A | No business use case exists. The three declared processes (FR-001 to FR-012) are system use cases over a data-capture and publishing intranet, each initiated by a system actor inside the organization. Modelling them as BUCs would be a false artifact. |
| BUC realization adequacy | N/A | No realization is expected in Inception, and none is required by an inactive discipline. Penalizing their absence would be the anti-pattern of applying New Business standards to a non-BPL engagement. |
| Derivation bridge | N/A | There is no business worker to map to a system actor and no business entity to map to an analysis class. The system actors are declared directly (STK-001, STK-004) and the candidate analysis classes are derived from the use cases by the SoftwareArchitect (COMP-001 to COMP-010). The bridge this criterion guards does not exist because the business level does not exist. |
| Resource planning compliance | N/A | No business worker and no business entity exist, so no resource allocation can violate the single-resource principle. |
| Same modeling technique at business level | N/A | No business-level model exists, so no software stereotype (`<<entity>>`, `<<service>>`, `<<controller>>`) was misapplied at the business level. The system-level models use system stereotypes correctly. |
| Stakeholder representation coverage | 9/10 | All four declared stakeholders are represented: STK-001 and STK-004 as system actors, STK-003 as the operator of the external systems and of the portal in production, STK-002 as a supporting clarifier. No organizational part named in the declared scope is unmodelled. The score is not 10 because the coverage is bounded by the declared scope — no independent organizational survey was performed, and none is warranted for a 200-employee intranet with four declared stakeholders. |
| Business rules as formal constraints | 9/10 | CON-007 to CON-016 and CON-043 each carry a unique identifier, a named bearing on the use cases that must honour them, and a testable condition (at most one pair per day, at most one featured item, a closed list of four values, a field that may be empty). Their source is the declared constraint itself, which is the stakeholder's own statement — the strongest available attribution. They are not BPA-authored `BR-NNN` rules, and they do not need to be: the discipline that would author them is inactive. |
| UML presence and richness | 9/10 | All eight artifacts carry validated PlantUML. No artifact is a prose-only model. The Use-Case Model carries a use-case diagram and five activity and sequence diagrams; the Software Architecture Document carries all four-plus-one views; the Supplementary Specification carries a FURPS+ classification diagram and a mechanism-inclusion diagram. |
| Scope adherence | 10/10 | Zero business use cases, zero `BR-NNN` business rules, zero business stereotypes. No undeclared business process was invented, and no declared system use case was promoted to a business use case. The business dimension of the scope guard is clean. |

**Business-volatility annotation — the one business duty that survived the INACTIVE verdict.** The architecture-centric pillar of this lens requires that volatile business areas be explicitly annotated, because volatility that is not flagged will not be encapsulated. That duty would normally fall to the Business Process Analyst. Here it was discharged by the SystemAnalyst in the Vision's Features table — FR-004 (the export column contract and the empty-not-zero rule) and FR-010 (the featuring policy) are both marked `Volatility: High` — and consumed by the SoftwareArchitect, who gave each its own subsystem and interface (`COMP-002` behind `INT-002`, `COMP-004` behind `INT-004`, ADR-002) and recorded the encapsulation as R006. The annotation exists, it is correct, and it reached the architecture. No finding.

**Traceability compliance — this iteration.**

```plantuml
@startuml
title Traceability compliance — business dimension, LCO Inception 1 (Portal)

skinparam classAttributeIconSize 0
skinparam packageStyle rectangle

package "Declared input — the ceiling" as DECL {
  class "FR-001 to FR-012\n12 system use cases" as FR <<declared>>
  class "NFR-001 to NFR-005" as NFR <<declared>>
  class "CON-001 to CON-043" as CON <<declared>>
  class "STK-001 to STK-004" as STK <<declared>>
  class "BG-001 to BG-003" as BG <<declared>>
  class "AC-001 to AC-006" as AC <<declared>>
  class "R001, R002" as R <<declared>>
}

package "Business level — expected only when BM is ACTIVE" as BIZ {
  class "BUC-NNN" as BUC <<ABSENT>>
  class "BR-NNN" as BR <<ABSENT>>
  class "business actor, worker, entity" as BE <<ABSENT>>
}

package "System level — present and traced" as SYS {
  class "Vision" as VIS <<artifact>>
  class "Use-Case Model" as UCM <<artifact>>
  class "Supplementary Specification" as SS <<artifact>>
  class "Software Architecture Document" as SAD <<artifact>>
  class "Risk List" as RL <<artifact>>
  class "Iteration Plan" as IP <<artifact>>
  class "Test Evaluation Summary" as TES <<artifact>>
  class "Development Case" as DC <<artifact>>
}

FR --> UCM : Refines
NFR --> SS : Refines
CON --> SS : Refines
STK --> VIS : Refines
BG --> VIS : Refines
AC --> VIS : Refines
R --> RL : Refines
UCM --> SAD : Derives
SS --> SAD : Refines
VIS --> UCM : Refines
RL --> IP : Refines
DC --> IP : Refines

note bottom of BIZ
  Zero nodes. This is the correct state:
  the business level does not exist because
  no business process is in declared scope.
  No «LEAF» and no «SUSPECT» edge exists
  at the business level, because no
  business-level element was created.
end note

note bottom of SYS
  Every declared identifier is cited by at
  least one artifact. No artifact cites an
  identifier outside the declared families.
  No artifact quotes the stakeholder in
  place of citing an identifier.
end note

note bottom of DECL
  The declared scope is the ceiling. No
  element of the business dimension was
  added beyond it, and none was needed.
end note

DECL -[hidden]- BIZ
BIZ -[hidden]- SYS
@enduml
```

**What the graph shows.** The business level is empty by design, not by omission. Every declared identifier — twelve FR, five NFR, forty-three CON, four STK, three BG, six AC and two declared risks — is cited by at least one system-level artifact. No artifact cites an identifier outside the declared families. No `«SUSPECT → role»` edge exists at the business level, because no business-level element was created to carry one.

**What the graph does not show.** The business dimension has no traceability obligation to discharge: with no BUC, no business worker and no business entity, there is no business element whose upstream or downstream link could be missing. The traceability compliance check for this lens is therefore satisfied vacuously and correctly.

**Cross-lens note.** Seven findings are on record against this iteration's artifacts, all emitted by the Reviewer's technical lens: Development Case#F1 (Major), Test Evaluation Summary#F1 and #F2 (Major), Use-Case Model#F1, Supplementary Specification#F1, Vision#F1 and Iteration Plan#F1 (Minor). None is a business-modeling finding and none is mine to close. They are recorded here only so the milestone verdict is read against the complete finding set.

## Resolutions and Actions
### Reviewer lens
#### Iteration 1

**No prior finding of this lens exists.** This is the first review pass of the project: `read_artifact_findings` returned an empty list for all eight artifacts, so no closure, deferral or rejection was available to record and no `resolve_artifact_finding` call was emitted. The closure state is consistent with the finding ledger.

**Open actions.** Seven findings are open, each with a named owner and a concrete remediation. None is a Critical finding, so none blocks the LCO gate; the three Major findings must be corrected before the Elaboration iteration-preparation checkpoint is used as a gate.

| Finding | Severity | Owner | Action | Blocks LCO |
|---|---|---|---|---|
| Development Case#F1 | Major | ProcessEngineer | Rewrite the S1 tool assessment and the gap table against the repository; remove the CI workflow from the Elaboration checkpoint's outstanding conditions. | No |
| Test Evaluation Summary#F1 | Major | TestManager | Replace the cited run id and window with the observed build; correct the reading of E-6 to met; remove the CI workflow from the recommendation and the carried-forward list. | No |
| Test Evaluation Summary#F2 | Major | TestManager, with SystemAnalyst as trace steward | Register the artifact's upstream links in the trace repository so its declared coverage is machine-verifiable. | No |
| Use-Case Model#F1 | Minor | SystemAnalyst | Reverse the UC-011 to Active Directory association so the portal is the initiating end. | No |
| Supplementary Specification#F1 | Minor | RequirementsSpecifier | Reconcile the audit mechanism's include list with UC-010's audit step. | No |
| Vision#F1 | Minor | SystemAnalyst | Reconcile A-1 with CON-035 and A-3. | No |
| Iteration Plan#F1 | Minor | ProjectManager | Remove the duration from the roadmap chart, or state the nominal unit inside the chart. | No |

**No action is deferred to a later iteration.** All seven are correctable within Inception 1 and none requires a Change Request: each restores the artifact's agreement with the declared scope or with observable state, and none changes declared scope.

### Business Reviewer lens
#### Iteration 1

**No prior finding of this lens exists.** This is the first review pass of the project from the Business Reviewer lens. `read_artifact_findings` returned an empty list for all eight artifacts and for the Review Record, so no closure, deferral or rejection was available to record and no `resolve_artifact_finding` call was emitted. The closure state is consistent with the finding ledger.

**No action is open from this lens.** Zero findings were emitted, so there is nothing to remediate, defer or carry forward. The Business Modeling discipline is inactive for the whole project (DC T-1) and no business-modeling work item exists to schedule.

**No action is deferred to a later iteration.** The INACTIVE verdict is not a deferral: it is a determination that the discipline does not apply to this engagement. It is re-evaluated each iteration against the DC §4 trigger conditions, and a Change Request that introduced a business process into scope would re-open it.

**Cross-lens actions are not mine to own.** The seven open findings recorded by the Reviewer's technical lens carry their own owners and remediations in that lens's block. This lens neither duplicates nor closes them.

| Finding | Severity | Owner | Action | Blocks LCO |
|---|---|---|---|---|
| (none from this lens) | — | — | — | — |

## Disposition
### Reviewer lens
#### Iteration 1

**Disposition from this lens: Approved with Changes.**

**Basis.** The requirements baseline is sound and complete. Twelve declared requirements map one-to-one to twelve use cases, each carrying its `Source: FR-NNN`; no phantom use case exists; no cross-cutting mechanism was promoted to a use case; no use case was split per actor. The candidate architecture is sound: ten subsystems, ten interfaces, six architecture decision records, all four-plus-one views, every subsystem traced to a declared element, and the two `Volatility: High` areas each isolated behind a seam. The risk record is sound: R001 to R010 classified with strategy, owner, mitigation, contingency and an observable indicator, and every accepted risk naming its CON-024 basis. The Development Case's tailoring is baseline-conformant: the roster is not redefined, no CORE artifact is omitted, no ownership is reassigned, no artifact outside the CORE plus OPTIONAL universe is listed, the intensity equals the canonical matrix, and all six optional triggers were audited against their §5.2 conditions and none fired.

**Why not Approved.** Three Major findings are open. Two of them are factual errors about observable state — the Development Case's tool baseline and the Test Evaluation Summary's SCM signal — and the third is an unregistered traceability claim. Each is a statement a downstream role would act on and be misled by: the Elaboration checkpoint would be used to close a gap that does not exist, and the Test Evaluation Summary's coverage would be taken as verified when the graph does not carry it.

**Why not Rejected.** No Critical finding exists. No scope hallucination, no phantom use case, no baseline redefinition, no ownership reassignment, no invented technology, no fabricated quantitative claim, no unsourced financial figure. The defects are corrections to statements about observable state, not defects in the requirements, the architecture or the risk treatment.

**LCO exit criteria, from this lens.** The technical artifacts collectively satisfy the LCO conditions: the scope is agreed and complete with no open scope question, the initial risks are identified and classified, and the architecture is first-cut and confronts the highest-magnitude technical risks rather than deferring them. The three Major findings are corrections to be made within this iteration, not conditions the project cannot meet.

**This is the Reviewer's technical-lens disposition on the artifacts. The LCO milestone verdict is the ReviewCoordinator's, and the milestone is not achieved until that verdict is recorded.**

## Traceability
### Reviewer lens
| Element | Traces From | Link Type | Traces To |
|---|---|---|---|
| Review Record | Development Case, Vision, Use-Case Model, Supplementary Specification, Software Architecture Document, Risk List, Iteration Plan, Test Evaluation Summary | Refines | — |
| Development Case#F1 | Development Case | Refines | — |
| Test Evaluation Summary#F1 | Test Evaluation Summary | Refines | — |
| Test Evaluation Summary#F2 | Test Evaluation Summary | Refines | — |
| Use-Case Model#F1 | Use-Case Model | Refines | — |
| Supplementary Specification#F1 | Supplementary Specification | Refines | — |
| Vision#F1 | Vision | Refines | — |
| Iteration Plan#F1 | Iteration Plan | Refines | — |
| Review Record | FR-001, FR-002, FR-003, FR-004, FR-005, FR-006, FR-007, FR-008, FR-009, FR-010, FR-011, FR-012 | Refines | — |
| Review Record | NFR-001, NFR-002, NFR-003, NFR-004, NFR-005 | Refines | — |
| Review Record | AC-001, AC-002, AC-003, AC-004, AC-005, AC-006 | Refines | — |
| Review Record | R001, R002 | Refines | — |
| Review Record | `ci-run-37583334371` | DependsOn | — |

**Reading the table.** `Traces From` is the artifact or declared input this review is accountable to. The `Traces To` end is empty: the Review Record is a terminal quality-gate artifact, and the elements it feeds — the corrected artifacts and the ReviewCoordinator's milestone verdict — are produced by other roles after this review. The `ci-run-37583334371` row is the observed build the SCM-evidence section rests on.

