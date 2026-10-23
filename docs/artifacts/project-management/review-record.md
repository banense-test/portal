## Document Control
### Reviewer lens
<!-- review: Inception I3 -->

- **Phase:** Inception
- **Status:** Draft — iteration 3, technical lens review complete
- **Milestone Target:** End of Inception (not yet achieved)

### Business Reviewer lens
<!-- review: Inception I3 -->

<!-- review: Inception I3 -->

- **Phase:** Inception
- **Status:** Draft — iteration 3, business modeling lens review complete
- **Milestone Target:** End of Inception (not yet achieved)

### Management Reviewer lens
<!-- review: Inception I2 -->

- **Phase:** Inception
- **Status:** Draft — iteration 2, LCO review held, sanction refused
- **Milestone Target:** End of Inception (not yet achieved)

### Review Coordinator lens
<!-- review: Inception I2 -->

- **Phase:** Inception
- **Status:** Draft — iteration 2, LCO milestone review consolidated; milestone not achieved
- **Milestone Target:** End of Inception (not yet achieved)

## Review Scope and Criteria
### Reviewer lens
<!-- review: Inception I3 -->

**Review type:** Technical review, LCO lifecycle milestone, Inception iteration 3. Checklist-driven against the artifact type of each item reviewed.

**Scope.** All ten persisted artifacts, plus the trace graph and the SCM state. Eight were evaluated against their checklists; the Iteration Assessment is not judged — it is authored after this review and its absence or lag is never a finding.

| Artifact | Checklist applied | Result |
|---|---|---|
| Vision | Requirements: traceable, testable, unambiguous, no unsourced quantitative claim | Pass |
| Use-Case Model | Requirements: UC well-formed, one per declared process, no cross-cutting mechanism as a UC, rule binding enforced by a flow, traceability | Pass |
| Supplementary Specification | Requirements: every constraint carried and bound, mechanisms not UCs, two closed lists kept apart, one set one source | Pass |
| Software Architecture Document | Architecture: every subsystem maps to a volatile requirement, constraint conformance, invariants enforceable, traceability one edge per row, iteration numbers current | Pass |
| Risk List | Project Management: declared identifiers and magnitudes preserved, CON-024 respected, every risk treated and traced, no suspect trace open | Pass |
| Iteration Plan | Project Management: plan derived from the artifact set, risk retirement named against its event, every AC has a gate, role profile agrees with the work items | **Fail** — 1 Minor |
| Test Evaluation Summary | Test: coverage against use cases, measurement method per NFR, observable SCM state cited as observed | **Fail** — 1 Major |
| Development Case | DC baseline conformance (§1.2), optional trigger justification, toolchain references current | **Fail** — 1 Minor |
| Iteration Assessment | Not judged — authored after this review | N/A |
| Review Record | This artifact | N/A |

**SCM state, read at the moment of writing.** No open pull request exists, so no PR required a disposition. The build on `main` is green — run `39958957391`, started 2026-10-23 13:09:58Z, completed 13:10:47Z. It carries no product evidence: the repository holds project inputs and artifacts, not the portal, so a green build proves the pipeline runs and nothing more. Three issues are open — `Issue #1`, `Issue #2` and `Issue #3`, all documentation staleness, all minor. Two of the three are against the Development Case and are the evidence for the finding recorded against it below.

**Trace graph.** 42 business roots, 180 nodes. No `FR-NNN`, `NFR-NNN` or `UC-NNN` is a leaf — every declared requirement is realized by a use case and every use case is carried by at least one component. **No `SUSPECT` edge is reported anywhere in the graph.** The four `SUSPECT → System Analyst` edges on `COMP-002` that iteration 2 recorded are cleared, which is the trace-graph evidence that the Use-Case Model was reviewed against ADR-010.

**Closure of prior findings.** Three findings of this lens were open at the start of this iteration. Each was verified against the current artifact content and closed through `resolve_artifact_finding` before any new defect was recorded. None is Deferred, none is Rejected, none is left open. `Iteration Plan#F3` belongs to the Management Reviewer lens and is not this lens's to close.

```plantuml
@startsalt
{
  {# Compliance criterion | Vision | UCM | SuppSpec | SAD | RiskList | IterPlan | TES | DevCase }
  { Every element traces to declared input | Pass | Pass | Pass | Pass | Pass | Pass | Pass | Pass }
  { No phantom or invented identifier | Pass | Pass | Pass | Pass | Pass | Pass | Pass | Pass }
  { Cross-cutting mechanism not modelled as a UC | n/a | Pass | Pass | Pass | n/a | n/a | n/a | Pass }
  { Scope markers on derived elements | Pass | Pass | Pass | Pass | Pass | Pass | Pass | Pass }
  { UML present and formally valid | Pass | Pass | Pass | Pass | Pass | Pass | Pass | Pass }
  { Criteria can fail | Pass | n/a | Pass | n/a | n/a | Pass | Pass | Pass }
  { Traceability table one edge per row | n/a | Pass | n/a | Pass | Pass | n/a | n/a | n/a }
  { No FR, NFR or UC left as a leaf | Pass | Pass | Pass | Pass | Pass | Pass | Pass | Pass }
  { No SUSPECT trace left open | n/a | Pass | n/a | Pass | Pass | n/a | n/a | n/a }
  { Internal consistency, within and with upstream | Pass | Pass | Pass | Pass | Pass | FAIL | Pass | Pass }
  { Observable SCM state cited as observed | n/a | n/a | n/a | n/a | n/a | n/a | FAIL | FAIL }
  { DC baseline conformance | n/a | n/a | n/a | n/a | n/a | n/a | n/a | Pass }
  { Optional trigger justification | n/a | n/a | n/a | n/a | n/a | n/a | n/a | Pass }
}
@endsalt
```

**What the three Fail cells have in common.** All three are a claim asserted rather than read against the set it describes. The Test Evaluation Summary states a run identifier and an issue count that were not read at the moment of writing. The Development Case states a toolchain component does not exist when it is committed and green. The Iteration Plan states that every work item has an Active owner while two of one work item's four owners are recorded as not working. None of the three disputes what a requirement says, and none is a defect of the artifact's reasoning — each is a defect of the artifact's currency, which is the class the Development Case's C2 and C6 authoring checks exist to catch.

**What this review confirms is now correct.** The three findings this lens carried into the iteration are genuinely corrected, and the corrections are substantive. The UC-001 postcondition now describes ADR-010's append-only event log and the four suspect traces are cleared. The Supplementary Specification groups all 36 constraints by their declared category in both the table and the diagram, and states the arithmetic that proves the set is complete. The Software Architecture Document's significance table names Elaboration iterations 4 and 5, matching the Iteration Plan's nine-iteration roadmap exactly.

### Business Reviewer lens
<!-- review: Inception I2 -->

<!-- review: Inception I2 -->

**Review point:** LCO, business modeling lens. The question applied is exit criteria — is the Business Modeling discipline correctly dispositioned, and does the artifact set carry the business-level content the downstream disciplines need.

**Scenario assessment — the governing decision.** The Development Case records `business-process-led = false` and I verified that classification independently rather than inheriting it. None of the six business modeling scenarios applies: no ERP or BPM suite is in scope, no workflow is re-engineered, no organizational restructuring is involved, no business actor or business worker is declared, and no business use case is declared. The stakeholder declared fifteen discrete administrative tasks directly as system use cases FR-001 to FR-015, replacing three manual artifacts. The disposition is correct and unchanged from iteration 1.

**Consequence for the standard applied.** Because no business model is owed, the criteria that presuppose one — BUC completeness, BUC realization adequacy, the business-to-system derivation bridge, resource planning compliance — are recorded N/A, not Fail. Applying them would be the wrong-scenario error. What I review is the business-level content that exists regardless of scenario: the business rules, stakeholder representation, volatility annotation, business-goal measurability, and scope adherence.

**Artifacts reviewed (9 of 9 persisted):** Development Case, Vision, Use-Case Model, Supplementary Specification, Software Architecture Document, Risk List, Iteration Plan, Test Evaluation Summary, Iteration Assessment. The Glossary is NOT TRIGGERED and is correctly absent. The Iteration Assessment is not judged — it is authored after this review.

```plantuml
@startsalt
{
  {# Business-lens criterion | Applied to | Result }
  { Scenario alignment - BM disposition correct and independently evidenced | DevCase, Vision, UCM | Pass }
  { Business rules - ID, source, attachment, testable condition | SuppSpec, UCM | FAIL }
  { Stakeholder representation coverage | Vision | Pass }
  { Volatility annotation - volatile policy reaches the architecture | Vision, SAD | Pass }
  { Business goals measurable, or marked unmeasured | Vision | Pass }
  { Scope adherence - no undeclared element, no invented identifier | All artifacts | Pass }
  { Diagram coverage - present, absent, structurally defective | UCM, SuppSpec, SAD | Pass }
  { BUC completeness test | UCM | N/A }
  { BUC realization adequacy | UCM | N/A }
  { Business-to-system derivation bridge | UCM | N/A }
  { Resource planning compliance | UCM | N/A }
}
@endsalt
```

**Closure of prior findings.** One finding of this lens from iteration 1 was reconciled before any new defect was recorded: `Vision#F1` (Minor), the two self-referential success-criterion cells. It is Resolved — the FR-014 and FR-015 rows now carry observable checks derived from the requirement text, and the section preamble states the rule that a cell never restates its own requirement identifier. No finding of this lens is Deferred or Rejected.

**What the business lens found this iteration.** The business-rule register is the strongest content in the set and it is where both new defects sit. Twelve of the thirteen declared `[BusinessRule]` constraints carry an identifier, a source, an attachment to the use cases that enforce them, and a testable condition — the four properties that make a rule auditable rather than a guideline. The two defects are attachment defects, not content defects: CON-012 is bound to UC-001 but the use case specifies no behaviour for the state the rule forbids, and CON-015's attachment is incomplete and contradicts the Software Architecture Document about whether the rule governs the directory search. A third, Minor, is that the register presents itself as complete and carries twelve of thirteen.

**Stakeholder representation is complete.** All four declared stakeholders appear with their needs and influence, and the negative-stakeholder analysis is honest: the one group whose workload changes without their consent is Infrastructure, and their constraint (CON-022) is declared and honoured rather than traded away. No organizational area relevant to the declared scope is unrepresented — the scope is three capability areas over one identity, and each is owned by a declared stakeholder.

**Volatility annotation did its job.** The three High-volatility features are flagged in the Vision and each owns a dedicated component in the Software Architecture Document — COMP-003 for the FR-004 export contract, COMP-004 for the FR-009 single-featured invariant, COMP-006 for the FR-012 category value set. The volatile business policy reached the architecture instead of stopping at a table, which is the test this criterion exists to apply.

**Business-goal measurability.** BG-001 is recorded as not yet measurable with STK-001 named as the supplier of the baseline; BG-002 and BG-003 are measurable against declared facts. A criterion whose denominator does not exist is recorded as unmeasured, never as met — that is the correct handling and it is the correction of the iteration-1 finding.

**Scope adherence.** No element in the set addresses a functional area the stakeholder did not declare. The fifteen use cases map one to one onto FR-001 to FR-015. No identifier is invented — every `FR-`, `NFR-`, `CON-`, `AC-`, `BG-`, `STK-` and `R` identifier cited is one the work order assigned. No declared exclusion is crossed. No cross-cutting mechanism is promoted to a use case: authentication, authorization, audit and directory read are mechanisms in the Supplementary Specification, included by the use cases that depend on them.

**Diagram coverage.** No business-level diagram is owed, so none is missing. The diagrams that exist at the business level — the use-case diagram with the organizational boundary, the business-rule binding diagram, the two-closed-lists diagram, the volatility map — are present and formally valid. The defect this lens records is not a missing diagram but a diagram whose edges disagree with a use case's own prose: the binding diagram denies the R_CAT cluster reaches UC-011, and CON-015 declares the directory column as one of its two permitted uses.

```plantuml
@startuml
title Portal - Business lens coverage map at LCO, Inception iteration 2

package "BM disposition - DC section 4, independently verified" {
  class "business-process-led = false\nno business actor, worker, entity or BUC\nin the declared scope" as BM <<BR-OK-INACTIVE>>
}

package "Business-lens criteria - applied" {
  class "Scenario alignment" as K1 <<Pass>>
  class "Business rules as formal constraints" as K2 <<FAIL>>
  class "Stakeholder representation coverage" as K3 <<Pass>>
  class "Volatility annotation reaches architecture" as K4 <<Pass>>
  class "Business goals measurable or marked unmeasured" as K5 <<Pass>>
  class "Scope adherence - no undeclared element" as K6 <<Pass>>
  class "Diagram coverage - present, absent, defective" as K7 <<Pass>>
}

package "Business-lens criteria - not applicable" {
  class "BUC completeness test" as K8 <<N/A>>
  class "BUC realization adequacy" as K9 <<N/A>>
  class "Business-to-system derivation bridge" as K10 <<N/A>>
  class "Resource planning compliance" as K11 <<N/A>>
}

package "Business rules - 13 declared BusinessRule constraints" {
  class "CON-009 to CON-020\n12 rules in the register\nID, attachment, testable condition" as R9 <<carried>>
  class "CON-008 two-level authorization\ncarried as MECH-02 only\nabsent from the register" as R8 <<misplaced>>
}

package "Findings this iteration" {
  class "Use-Case Model#F1\nMajor - CON-012 complete-pair case\nunaddressed in UC-001" as F1
  class "Use-Case Model#F2\nMajor - CON-015 attachment incomplete,\ncontradicts the SAD on the directory filter" as F2
  class "Supplementary Specification#F1\nMinor - CON-008 absent from\nthe business-rules register" as F3
}

BM --> K8
BM --> K9
BM --> K10
BM --> K11
R9 --> K2
R8 --> K2
K2 --> F1
K2 --> F2
K2 --> F3

note bottom of K8
  N/A is not Fail. No BUC is declared or owed,
  so the criteria that presuppose a business
  model are recorded N/A. Applying them would
  be the wrong-scenario error.
end note

note bottom of F1
  CON-012 is bound to UC-001, but the use case
  specifies no behaviour for the case the rule
  forbids: a complete pair already exists and
  the employee presses Clock In.
end note

note bottom of R8
  CON-008 is declared [BusinessRule] in the
  scope. It is enforced and attached, but the
  register that presents itself as the business
  rule register lists twelve of thirteen.
end note
@enduml
```

**Disposition: Approved with Changes.** No Critical finding. Two Major and one Minor, all correctable within this iteration, all in the business-rule attachment layer rather than in the requirements baseline. The Business Modeling discipline remains correctly inactive and no business artifact is owed, missing, or defective in a way this lens owns beyond the three findings above.

### Management Reviewer lens
<!-- review: Inception I2 -->

<!-- review: Inception I2 -->

**Review type:** Lifecycle Milestone Review — Lifecycle Objectives (LCO), end of Inception. Held at the close of Inception iteration 2, the correction iteration the stakeholder's refusal of the iteration-1 sanction required.

**Artifacts reviewed:** Development Case, Vision, Use-Case Model, Supplementary Specification, Software Architecture Document, Test Evaluation Summary, Risk List, Iteration Plan. The Iteration Assessment is not judged: the ProjectManager authors it after this review, given the verdict, and its absence at review time is not a defect.

**Criteria applied.** The seven LCO exit criteria, each answered against artifact evidence rather than against the plan's assertion of it. The management lens adds four checks the technical lenses do not run: whether the plan's claims survive their own evidence chain, whether every declared acceptance criterion has a point at which it can close, whether risk retirement is claimed only where evidence exists, and whether the Development Case conforms to the IARI baseline.

| # | LCO exit criterion | Result | Evidence |
|---|---|---|---|
| 1 | Stakeholders agree on the scope | Met | 15 FR, 5 NFR, 36 CON, 3 BG, 5 AC and 13 exclusions carried exactly as declared; the exclusions are published verbatim in the Vision as a checkable boundary. No lens recorded a scope finding in either iteration |
| 2 | Key risks identified and classified | Met | R001 to R008, each with probability, impact, exposure, magnitude, strategy, owner, mitigation, contingency and warning sign. R001 and R002 keep their declared identifiers and magnitudes, which CON-023 requires |
| 3 | The proposed approach is feasible | Met | Platform fixed by CON-001, CON-025, CON-026, CON-027; identity and directory external and read-only by CON-002, CON-003, CON-022; the team's integration surface is the stand-ins it controls by CON-031 |
| 4 | There is a plan to retire the highest-magnitude risk first | Met | R001 (exposure 9) is retired in Elaboration iteration 3 by executing the empty-attribute case of UC-011 and UC-004 against the stand-in. Verified against the Test Evaluation Summary's coverage plan and execution sequence, not accepted from the plan's assertion |
| 5 | Every declared acceptance criterion has a point at which it can close | Met | AC-001 to AC-005 each assigned a closing point; AC-004 split into AC-004a (iteration 5) and AC-004b (post-Project-Acceptance, owner STK-001) |
| 6 | The primary use cases are understood well enough to build from | **Not met** | UC-001 carries two open Major findings — its postcondition contradicts ADR-010, and CON-012 is bound to it but not enforced. UC-011 carries one open Major finding: CON-015's attachment contradicts the Software Architecture Document |
| 7 | The architecture is credible | **Not met** | The Use-Case Model and the Software Architecture Document disagree on whether CON-015 governs the directory search, and the SAD's architectural-significance table is not re-based onto the roadmap the Iteration Plan carries |

**Baseline conformance audit of the Development Case.** Checks (a) to (e) all pass: the 25-role roster is inherited unchanged with three roles idle by trigger and none removed; no CORE artifact is omitted; no primary ownership is reassigned; no artifact outside the CORE + OPTIONAL universe appears; no two roles are merged. All six OPTIONAL triggers are recorded NOT TRIGGERED and each verdict holds against its §5.2 condition — no distributed topology for a Deployment Model, fewer than ten entities and no migration for a Data Model, no formal or regulatory delivery for a Test Plan, and an authoritative stakeholder-supplied UI design that makes a prototype a competing source of truth. Discipline intensity is per the canonical matrix with no self-granted deviation, and Business Modeling is declared INACTIVE on the correct trigger. The measurement policy refuses to set a token budget, which CON-030 requires.

**Data verification.** No unsourced quantitative business claim appears in any artifact. The 200 employees, 3 offices, 50% reduction, 80% adoption and 3-month window are declared inputs. BG-001's missing denominator is now recorded as unmeasured with STK-001 named as its supplier rather than presented as a measurable criterion, which closes the iteration-1 finding. The one observable SCM fact cited — CI run `39940062277` — is cited as read at the moment of writing, and the Test Evaluation Summary states plainly that a green build on a repository holding only inputs and artifacts proves the pipeline runs, not that the product works.

```plantuml
@startuml
title Portal - LCO exit criteria compliance, Inception iteration 2

package "Met - 5 of 7" {
  class "1. Scope agreement\nMET\n15 FR, 5 NFR, 36 CON, 3 BG, 5 AC\n13 exclusions published verbatim" as C1
  class "2. Risks identified and classified\nMET\nR001-R008 with P, I, exposure, strategy,\nowner, mitigation, contingency, warning sign" as C2
  class "3. Feasibility\nMET\nPlatform fixed by CON-001/025/026/027;\nidentity and directory external, read-only;\nintegration surface is the team's stand-ins" as C3
  class "4. Plan to retire the highest-magnitude risk first\nMET\nR001 retired in Elaboration iteration 3\nby a passing test, not by a fixture" as C4
  class "5. Every acceptance criterion can close\nMET\nAC-004 split: AC-004a iteration 5,\nAC-004b post-acceptance owned by STK-001" as C5
}

package "Not met - 2 of 7" {
  class "6. Requirements understanding -\nfidelity of the primary use cases\nNOT MET\nUC-001 carries 2 open Major findings;\nUC-011 carries 1 open Major finding" as N1
  class "7. Credibility of the architecture\nNOT MET\nThe SAD and the Use-Case Model\ndisagree on whether CON-015\ngoverns the directory search" as N2
}

package "Gate consequence" {
  class "LCO verdict: No-Go\n0 Critical, 5 Major, 2 Minor open\nRemedy: another Inception iteration\nCON-023: never a scope cut" as G1
}

C1 --> G1
C2 --> G1
C3 --> G1
C4 --> G1
C5 --> G1
N1 --> G1
N2 --> G1

note bottom of G1
  The two criteria that fail are the two the
  LCO gate exists to test: that the primary
  use cases are understood well enough to
  build from, and that the architecture is
  credible. Both are correctable, neither is
  corrected.
end note
@enduml
```

### Review Coordinator lens
<!-- review: Inception I2 -->

**Milestone review event:** LCO — Lifecycle Objectives Review, Inception iteration 2. This is the second presentation of the same gate; the first was refused at iteration 1.

**Lens participation.** Recorded as executed or not executed, never inferred from the artifact.

| Lens | Participant | Status this review |
|---|---|---|
| Technical | Reviewer | EXECUTED — 3 findings recorded, 7 prior findings closed |
| Business | BusinessReviewer | EXECUTED — 3 findings recorded, 1 prior finding closed |
| Management | ManagementReviewer | EXECUTED — 1 finding recorded, 2 prior findings closed, verdict No-Go, sanction REFUSED |

All three lenses executed. No lens is INACTIVE for this review, so the milestone decision rests on the full three-lens position.

**Review types held inside this milestone event.** The Project Approval Review and the Project Planning Review are not separate events and are not work items for another role — they are held inside the LCO, as the RUP milestone review requires.

| Review type | Where it is held | What it examined |
|---|---|---|
| Project Approval Review | Inside the LCO — the Management Reviewer's sanction question to STK-001 | Scope feasibility against the Vision and the Risk List; the stakeholder answered No |
| Project Planning Review | Inside the LCO — the LCO readiness assessment in the Iteration Plan | Development Case tailoring and the eight-iteration roadmap, reviewed for feasibility and acceptability |
| Iteration Evaluation Criteria Review | Inside the LCO — exit criteria E1 to E7 | Whether the iteration's own exit criteria were met; 5 of 7 met |
| Iteration Acceptance Review | Inside the LCO — the three lens dispositions | Formal acceptance of the iteration's deliverables; not granted |
| PRA Review | Not held as a separate event | Project health is carried by the Management Reviewer's four-axis scorecard inside this record |
| Lifecycle Objectives Review | This event | The Inception exit gate |

**Entry criteria — verified before the review began.**

| Criterion | Position |
|---|---|
| Artifacts in target state, not draft | Met — all 10 artifacts persisted and readable |
| Reviewers assigned with matched expertise | Met — three lenses, each matched to its artifact domain |
| Agenda and evaluation criteria distributed in advance | Met — the LCO exit criteria are published in the Iteration Plan |
| Prior findings reconciled before new ones recorded | Met — 10 prior findings closed by their emitting lenses before this milestone's findings were recorded |

**Exit criteria — position at close.**

| Criterion | Position |
|---|---|
| Every finding has an owner, a severity and a deadline | Met — 7 open findings, all assigned in Resolutions and Actions |
| Review Record signed and archived | Met — this record, committed |
| 0 open Critical and 0 open Major findings | **Not met** — 0 Critical, 5 Major open |
| Stakeholder sanction granted | **Not met** — REFUSED |

**Scope of the review.** All 10 artifacts in the repository were read and reviewed by all three lenses. No artifact reached the gate unreviewed. The Iteration Assessment was authored after this review and is not judged by it.

```plantuml
@startuml
title Portal - Review cadence against the iteration roadmap

start
:Iteration 1 - Inception;
note right
  Iteration Plan Review, PRA Review,
  Iteration Evaluation Criteria Review and
  Iteration Acceptance Review are all held
  inside the LCO milestone review.
end note
:LCO Lifecycle Milestone Review;
note right
  Project Approval Review and Project
  Planning Review are held INSIDE this
  event, never as separate events.
  Outcome: sanction REFUSED.
end note
:Iteration 2 - Inception correction;
:LCO Lifecycle Milestone Review re-presented;
if (0 open Critical, 0 open Major,\nstakeholder sanction GRANTED?) then (yes)
  :Elaboration iterations 3 and 4;
  :LCA Lifecycle Architecture Review;
  :Construction iterations;
  :IOC Initial Operational Capability Review;
  :Transition iteration;
  :PR Product Release Review;
  :Project Acceptance Review;
  stop
else (no)
  :Another Inception correction iteration;
  stop
endif
@enduml
```

## Findings
### Reviewer lens
<!-- review: Inception I3 -->

Three findings this milestone: 0 Critical, 1 Major, 2 Minor. Each is recorded in the finding ledger against its artifact; this entry states the defect, its location and its remediation.

#### Test Evaluation Summary

**`Test Evaluation Summary#F3` — Major.** The quality-signals and defect-record tables cite observable SCM state that was not read at the moment of writing, and one figure is factually wrong. The CI build is cited as run `39940933643`, started 2026-10-23 10:41:58Z and completed 10:42:50Z; the build on `main` at the time of this review is run `39958957391`, started 13:09:58Z and completed 13:10:47Z. The issue count is stated as two — `Issue #1` and `Issue #2` — in both the quality-signals table and the defect-record table; the tracker holds three, the third being `Issue #3`. The omitted issue is a defect against the Development Case, so the artifact's own claim that the tracker is the authoritative defect record is undermined by a count that does not read it.

This is the third generation of the defect class the Development Case's C2 check ("Was this identifier read at the moment of writing?") and its "Observable state" guideline exist to catch. It is the same class as `Test Evaluation Summary#F1`, which was closed in iteration 2 on the strength of a corrected citation. The correction did not hold.

*Remediation.* Re-read `scm_get_build_status` and `scm_list_issues` at the moment of writing and replace both citations: the current run identifier with its start and completion timestamps, and the current issue count with all three issues named. State the count as read, not as remembered. Then record in the Development Case's authoring-check verdict that C2 did not prevent this recurrence — R009's escalation question is whether the checks work, and this is evidence bearing on it.

#### Development Case

**`Development Case#F1` — Minor.** The project tool and guideline reference table records `.github/workflows` (build and test CI) as "Not yet created — Elaboration", and the iteration preparation checkpoint states that `.github/workflows` does not yet exist. The build-and-test workflow is committed and green on `main` — run `39958957391`, completed 2026-10-23 13:10:47Z. Two open SCM issues record the same defect against this artifact: `Issue #2` and `Issue #3`. The Development Case is the artifact that governs what the team may rely on, and it currently tells the team a toolchain component is missing when it is present and working.

*Remediation.* Change the `.github/workflows` row's state from "Not yet created — Elaboration" to the fact: committed and green on `main`, with the run identifier read at the moment of writing. Remove `.github/workflows` from the iteration preparation checkpoint's list of things that do not yet exist, leaving `CONTRIBUTING.md` and the lint configuration as the open R007 gaps. Then close `Issue #2` and `Issue #3` against this correction.

#### Iteration Plan

**`Iteration Plan#F2` — Minor.** The iteration 3 fine plan's W11 names four owners — Reviewer, BusinessReviewer, ManagementReviewer, ReviewCoordinator — while the agent role profile marks BusinessReviewer Idle and ManagementReviewer "—" in the iteration 3 column. The plan's own prose asserts "every work item has an Active owner", and exit criterion E2 requires that every role that produces in an iteration is Active in that iteration's column. The claim is therefore false of the plan that makes it: two of W11's four owners are recorded as not working in the iteration.

This is the same defect class as `Iteration Plan#F3` — a completeness claim asserted rather than counted against the set it describes. It is Minor rather than Major because the work itself is correctly identified and owned by two Active roles; what is wrong is the owner list and the claim about it.

*Remediation.* Either activate ManagementReviewer in the iteration 3 column and give it the LCO sanction question as its work item — the LCO gate is re-presented this iteration and the sanction question is the Management Reviewer's to put to the stakeholder, as it was in iteration 2 — or remove ManagementReviewer and BusinessReviewer from W11's owner list and leave the Review Record work with Reviewer and ReviewCoordinator. Whichever is chosen, make the owner list and the role profile agree, and count the claim before writing it.

```plantuml
@startuml
title Portal - Inception iteration 3 technical lens: defect distribution by severity and artifact

package "Major - 1 finding" {
  class "Test Evaluation Summary\nF3 - SCM state cited from an earlier read\nrun 39940933643 and 2 issues, not the\nrun and 3 issues read at review" as M1 <<Major>>
}

package "Minor - 2 findings" {
  class "Development Case\nF1 - .github/workflows recorded as\nnot yet created; it is committed and green" as N1 <<Minor>>
  class "Iteration Plan\nF2 - W11 names four owners; two are\nrecorded not Active in iteration 3" as N2 <<Minor>>
}

package "Clean this pass - 0 findings" {
  class "Vision" as C1
  class "Use-Case Model" as C2
  class "Supplementary Specification" as C3
  class "Software Architecture Document" as C4
  class "Risk List" as C5
}

package "Not judged this pass" {
  class "Iteration Assessment\nauthored after this review" as X1
  class "Review Record\nthis artifact" as X2
}

package "Closed this pass - 3 prior findings of this lens" {
  class "Use-Case Model#F2\nUC-001 postcondition in ADR-010 terms" as R1
  class "Supplementary Specification#F1\nconstraint grouping by declared category" as R2
  class "Software Architecture Document#F3\nsignificance table re-based to 4 and 5" as R3
}

package "Open, not this lens's to close" {
  class "Iteration Plan#F3\nManagement Reviewer lens" as O1
}

M1 --> N1 : same class: a claim not read against its source
N1 --> N2 : same class: a completeness claim not counted

note bottom of M1
  Both Minor findings and the Major are one
  defect class: a claim asserted rather than
  read against the set it describes. It is the
  class the Development Case's C2 and C6 checks
  exist to catch, and C2 did not prevent the
  Test Evaluation Summary recurrence.
end note

note bottom of R1
  All three closures verified against the
  current artifact content, not against the
  author's account of the correction.
end note
@enduml
```

#### Artifacts with no finding from this lens

| Artifact | Position |
|---|---|
| Vision | The 13 declared exclusions are published verbatim as the control for R005. All four stakeholders, five acceptance criteria and both declared risks are carried. BG-001 is recorded as not yet measurable with STK-001 named as the baseline supplier, and the two self-referential success criteria carry observable checks derived from the requirement text. No unsourced quantitative claim appears |
| Use-Case Model | The finding this lens carried into the iteration is corrected and verified. UC-001's postcondition describes one ClockIn event row and one ClockOut event row with the effective pair resolved over supersession, and the same shape is stated explicitly for UC-002, UC-003 and UC-005. The four `COMP-002` suspect traces are cleared. Fifteen use cases, one per declared requirement, no phantom use case, no cross-cutting mechanism promoted to a use case, no per-actor split of a single declared process |
| Supplementary Specification | The finding this lens carried into the iteration is corrected and verified. All 36 constraints are grouped by their declared category in both the table and the diagram, the two representations agree row for row, and the section states the arithmetic that proves the set is complete. All 5 NFRs and all 36 constraints are accounted for; the four mechanisms are recorded as mechanisms with an include graph and never as use cases; INT-03 reproduces the FR-004 column contract exactly |
| Software Architecture Document | The finding this lens carried into the iteration is corrected and verified. The significance table names Elaboration iteration 4 for ranks 1 to 4 and iteration 5 for ranks 5 to 10, matching the Iteration Plan's roadmap, and the surrounding prose states the basis. The rest of the document was swept: no iteration number contradicts the roadmap. The three High-volatility requirements each own a dedicated component; CON-028 is satisfied with Keycloak inside the corporate network boundary; no cache is designed, consistent with FR-014 and FR-015; no scheduler exists, justified by CON-018 and CON-011 |
| Risk List | R001 and R002 carried with their declared identifiers and magnitudes, not renumbered or reclassified. R003 to R009 numbered in the order raised, each with a full treatment. CON-024 respected — Keycloak and AD availability are not registered, and R003 is correctly distinguished as the timing of the CON-031 human feedback loop. Every `Accept` cites the CON-023 grant and its condition. The five suspect traces raised by the UC-001 and UC-011 changes are re-verified and cleared with the reason each dependency still holds, and the trace graph confirms no suspect edge remains |

### Business Reviewer lens
<!-- review: Inception I2 -->

<!-- review: Inception I2 -->

Three findings this iteration: two Major, one Minor, no Critical. All three are business-rule attachment defects — the rule content is correct and the attachment to the use cases that enforce it is not.

**Reading the keys.** Findings are scoped per artifact and per lens, so `Use-Case Model#F1` and `#F2` in this block are this lens's findings and are distinct from the Reviewer lens's `Use-Case Model#F1` and `#F2` on the same artifact. The Reviewer lens's `#F2` is the UC-001 postcondition against ADR-010; this lens's `#F1` is CON-012's enforcement in the same use case. They are adjacent but not the same defect, and both must be corrected.

#### Use-Case Model

**`Use-Case Model#F1` (business lens) — Major — CON-012 is bound to UC-001 but not enforced by it.** The button logic in main-flow step 3 distinguishes only "a pair is open" from "a pair is not open", so once an employee has completed a pair for the day the portal renders Clock In again and step 6 records the press. Alternative flow A4 covers only the open-pair case. The complete-pair case is the one that produces a second pair, and it is unaddressed — as specified, UC-001 permits the exact state CON-012 declares impossible. Remediation: add an alternative flow for the complete-pair case, state step 3 in terms of the three states the rule creates (no pair, pair open, pair complete), and route the employee to HR under UC-005 per CON-017.

**`Use-Case Model#F2` (business lens) — Major — CON-015's attachment is incomplete and contradicts the Software Architecture Document.** CON-015 declares two permitted uses of the worker category: "a directory column that also filters" and "a CSV export column". The Use-Case Model binds the rule to UC-004 and UC-012 and explicitly denies it is bound to UC-011, which is the directory — in a paragraph that first states the rule "confines the worker category to the directory column and the export column". UC-011's main flow specifies no filter by worker category at all. The Software Architecture Document takes the opposite position, citing CON-015 as the basis for COMP-005 rendering the column and filtering the result set by it. Remediation: bind CON-015 to UC-011, state its permissive half (column plus filter) and its prohibitive half (no access decision) separately, add the filter to UC-011's flows, and align the outline table and the binding diagram.

#### Supplementary Specification

**`Supplementary Specification#F1` (business lens) — Minor — the business-rules register carries twelve of thirteen declared `[BusinessRule]` constraints.** The scope declares CON-008 through CON-020 as `[BusinessRule]`. The register presents itself as the business-rule register ("The twelve business rules below are invariants") and omits CON-008, the authorization rule. CON-008 is enforced and attached elsewhere as MECH-02, so the rule is not lost — but the register under-reports by one and asserts its own completeness. Remediation: add CON-008 as the thirteenth row with its enforcement point and a cross-reference to MECH-02, and correct the count; or state in the preamble that authorization is deliberately carried as a mechanism and name CON-008 as the one declared `[BusinessRule]` constraint treated that way.

```plantuml
@startuml
title Portal - Business lens defect distribution, Inception iteration 2

package "Use-Case Model - 2 Major" {
  class "F1 CON-012 complete-pair case\nbound but not enforced" as U1 <<Major>>
  class "F2 CON-015 attachment incomplete\ncontradicts the SAD" as U2 <<Major>>
}

package "Supplementary Specification - 1 Minor" {
  class "F1 CON-008 absent from the register\n12 of 13 declared BusinessRule" as S1 <<Minor>>
}

package "Defect class" {
  class "Attachment defect - 3 of 3\nThe rule content is correct.\nThe binding to the use cases\nthat enforce it is not." as D1
}

package "Severity position" {
  class "Critical: 0" as G1
  class "Major: 2" as G2
  class "Minor: 1" as G3
}

U1 --> D1
U2 --> D1
S1 --> D1
U1 --> G2
U2 --> G2
S1 --> G3

note bottom of D1
  No finding this iteration disputes what a rule
  says. Each disputes where it is bound, or
  whether the use case bound to it specifies the
  behaviour that enforces it.
end note

note bottom of G1
  No declared exclusion crossed, no identifier
  invented, no scope expanded beyond the fifteen
  declared requirements.
end note
@enduml
```

**What this lens did not find.** No business artifact is owed and missing. No BUC, business actor, business worker or business entity is absent that the Development Case requires — the discipline is correctly inactive and the absence is the correct state. No stakeholder is unrepresented. No business goal is presented as met when its denominator does not exist. No volatile business policy failed to reach the architecture. No element addresses an undeclared functional area.

### Management Reviewer lens
<!-- review: Inception I2 -->

<!-- review: Inception I2 -->

One new defect from this lens this milestone, Major, against the Iteration Plan. The other six open findings in the ledger belong to the Reviewer and Business Reviewer lenses; I confirm them as part of the milestone position and cite them by key rather than re-recording them, because one logical defect recorded twice is one defect the author has to triage twice.

#### Iteration Plan

**`Iteration Plan#F3` — Major.** The iteration 2 fine plan does not account for the Development Case, which this iteration produced. The plan's own exit criterion E1 states "Every artifact the iteration produces has a work item, an owner and an exit condition", and the fine plan carries W1 to W9 covering the Software Architecture Document, Use-Case Model, Vision, Test Evaluation Summary, Iteration Plan, Risk List, Review Record and Iteration Assessment — but not the Development Case. The Development Case was substantively revised this iteration: it now carries a process-improvement record tracing five iteration-1 findings to five document changes, a "Criteria that can fail" guideline, an "Observable state" guideline, a "Scope note for test tailoring" section, and the rule that a discipline at Medium or Low intensity is active rather than idle. The agent role profile marks ProcessEngineer Active in iteration 2, so the profile asserts work the fine plan does not contain.

This is the same defect class as `Iteration Plan#F1` (Reviewer) from iteration 1 — a fine plan that understates the iteration's work — recurring in the new plan. The consequence is that the plan cannot be checked against its own E1 criterion: the criterion is written to catch exactly this and the plan fails it.

*Remediation.* Add the Development Case as a work item in the iteration 2 fine plan with owner ProcessEngineer and an exit condition naming what the revision must achieve — for example "the five iteration-1 findings that are defects of a kind are each traced to a named change in this document, and the authoring checks that would have caught them are stated". Place it in the critical chain before the Review Record, since the Review Record verifies the corrected artifacts and the Development Case is one of them. Alternatively, if the Development Case revision is deliberately outside the plan's scope because it closes no named finding, state that explicitly in the fine plan's preamble and amend E1 so the criterion and the plan agree — a criterion the plan fails on its own content is worse than no criterion.

#### Open findings from the other lenses, confirmed

These are not mine to close and I do not re-record them. They are stated here because the milestone verdict depends on them and the stakeholder's sanction question carried them.

| Key | Artifact | Severity | Defect in one line |
|---|---|---|---|
| `Use-Case Model#F2` (Reviewer) | Use-Case Model | Major | The UC-001 postcondition still describes the single-row clocking model ADR-010 replaced; it is false after the second press |
| `Use-Case Model#F1` (Business) | Use-Case Model | Major | CON-012 is bound to UC-001 but not enforced — the complete-pair case is unaddressed, so the use case permits the state the rule forbids |
| `Use-Case Model#F2` (Business) | Use-Case Model | Major | CON-015's attachment contradicts the Software Architecture Document on whether the rule governs the directory search |
| `Software Architecture Document#F3` (Reviewer) | Software Architecture Document | Major | The architectural-significance table is not re-based onto the eight-iteration roadmap; it assigns design to an iteration that designs nothing |
| `Supplementary Specification#F1` (Reviewer) | Supplementary Specification | Minor | The constraint grouping disagrees with the declared categories and the table and diagram disagree with each other |
| `Supplementary Specification#F1` (Business) | Supplementary Specification | Minor | CON-008 is absent from the business-rules register, which presents itself as complete |

**Three of the five open Major findings sit in one artifact.** The Use-Case Model carries the concentration, and two of its three are the same defect class: a rule or a decision another artifact changed, not carried through to the use case that must enforce it. That is the pattern the Development Case's new authoring checks are written to catch, which is why the Development Case revision is not a cosmetic change and why its absence from the fine plan is a Major finding rather than a Minor one.

```plantuml
@startuml
title Portal - Finding ledger at the LCO gate, Inception iteration 2

package "Major - 5 open" {
  class "Use-Case Model#F2 (Reviewer)\nUC-001 postcondition describes the\nsingle-row model ADR-010 replaced" as M1
  class "Use-Case Model#F1 (Business)\nCON-012 bound to UC-001 but not\nenforced; complete-pair case unaddressed" as M2
  class "Use-Case Model#F2 (Business)\nCON-015 attachment contradicts\nthe Software Architecture Document" as M3
  class "Software Architecture Document#F3\nsignificance table not re-based onto\nthe eight-iteration roadmap" as M4
  class "Iteration Plan#F3 (Management)\nDevelopment Case has no work item\nin the iteration 2 fine plan" as M5
}

package "Minor - 2 open" {
  class "Supplementary Specification#F1 (Reviewer)\nconstraint grouping disagrees with\nthe declared categories" as N1
  class "Supplementary Specification#F1 (Business)\nCON-008 absent from the\nbusiness-rules register" as N2
}

package "Critical - 0 open" {
  class "None" as C0
}

package "Closed this iteration - 10" {
  class "Iteration Plan#F1 (Reviewer)" as R1
  class "Iteration Plan#F1 (Management)" as R2
  class "Iteration Plan#F2 (Management)" as R3
  class "Use-Case Model#F1 (Reviewer)" as R4
  class "Software Architecture Document#F1" as R5
  class "Software Architecture Document#F2" as R6
  class "Test Evaluation Summary#F1" as R7
  class "Test Evaluation Summary#F2" as R8
  class "Vision#F1 (Reviewer)" as R9
  class "Vision#F1 (Business)" as R10
}

note bottom of C0
  No Critical finding: no declared exclusion
  is crossed, no phantom use case, no invented
  identifier, no scope expansion beyond the
  fifteen declared requirements, and no
  artifact claims a milestone or an acceptance
  criterion is closed.
end note

note bottom of M3
  The only open finding that is a disagreement
  between two artifacts rather than a defect
  inside one. It is the one that most directly
  fails the LCO criterion on architecture
  credibility.
end note
@enduml
```

#### Artifacts with no finding from this lens

| Artifact | Position |
|---|---|
| Development Case | Baseline conformance (a)–(e) passes; all six OPTIONAL triggers audited against their §5.2 conditions and each NOT TRIGGERED verdict holds; intensity per the canonical matrix; Business Modeling inactive on the correct trigger; no token budget set, as CON-030 requires. The revision this iteration is a genuine process improvement — each of its five changes traces to a named iteration-1 finding |
| Vision | The 13 declared exclusions are published verbatim as the control for R005. All four stakeholders, five acceptance criteria and both declared risks are carried. BG-001 is now recorded as not yet measurable with STK-001 named as the baseline supplier, and the two self-referential success criteria are replaced with observable checks |
| Risk List | R001 and R002 carried with their declared identifiers and magnitudes, not renumbered or reclassified. R003 to R008 numbered in the order raised, each with a full treatment. CON-024 respected — Keycloak and AD availability are not registered, and R003 is correctly distinguished as the timing of the CON-031 human feedback loop. Every `Accept` cites the CON-023 grant and its condition; none is accepted on the Project Manager's own authority |
| Test Evaluation Summary | The Evaluation Mission is scoped to the test position and explicitly disclaims product evidence. 15 of 15 use cases and 5 of 5 NFRs assigned an execution iteration in which the behaviour exists. The stale CI citation is replaced with the run read at the moment of writing, and NFR-001 is split so neither half is assigned to an iteration that cannot execute it |
| Software Architecture Document | No finding from this lens beyond the Reviewer's `#F3`. The three High-volatility requirements each own a dedicated component; CON-028 is satisfied with Keycloak inside the corporate network boundary; no cache is designed, consistent with FR-014 and FR-015; no scheduler exists, justified by CON-018 and CON-011 |
| Supplementary Specification | No finding from this lens. All 5 NFRs and all 36 constraints are accounted for; the four mechanisms are recorded as mechanisms with an include graph and never as use cases; INT-03 reproduces the FR-004 column contract exactly |
| Use-Case Model | No finding from this lens. Fifteen use cases, one per declared requirement, no phantom use case, no cross-cutting mechanism promoted to a use case, no per-actor split of a single declared process. The open findings are the Reviewer's and the Business Reviewer's |

### Review Coordinator lens
<!-- review: Inception I2 -->

**Consolidated ledger: 7 open findings — 0 Critical, 5 Major, 2 Minor.** Every row is copied from `read_artifact_findings` for the artifact named. The coordinator does not re-evaluate the artifacts; the defect statements are the lenses' and are cited by key.

| # | Key | Artifact | Severity | Emitting lens | Owner | Defect |
|---|---|---|---|---|---|---|
| 1 | `Use-Case Model#F2` | Use-Case Model | Major | Reviewer | SystemAnalyst | The UC-001 postcondition still describes the single-row clocking model ADR-010 replaced. Under ADR-010 a complete pair is two append-only rows and a correction is a third; the effective pair is a query over supersession, not a record. The postcondition is false after the second press. The trace graph reports the same defect independently through four `SUSPECT → System Analyst` edges on COMP-002 |
| 2 | `Use-Case Model#F1` | Use-Case Model | Major | BusinessReviewer | SystemAnalyst | CON-012 is bound to UC-001 but not enforced by it. The button logic distinguishes only "a pair is open" from "a pair is not open", so once a pair is complete the portal renders Clock In again and records the press. Alternative flow A4 covers only the open-pair case. As specified, UC-001 permits the state CON-012 declares impossible |
| 3 | `Use-Case Model#F2` | Use-Case Model | Major | BusinessReviewer | SystemAnalyst | CON-015's attachment is incomplete and contradicts the Software Architecture Document. The Use-Case Model binds the rule to UC-004 and UC-012 and explicitly denies it is bound to UC-011, the directory, in a paragraph that first states the rule confines the category to the directory column and the export column. UC-011 specifies no filter by worker category. The SAD cites CON-015 as the basis for COMP-005 rendering the column and filtering by it |
| 4 | `Software Architecture Document#F3` | Software Architecture Document | Major | Reviewer | SoftwareArchitect | The architectural-significance table is not re-based onto the eight-iteration roadmap. It assigns the four significant use cases to "Elaboration iteration 2" and the remaining six ranks to "Elaboration iteration 3". Under the current roadmap iteration 2 is this Inception correction iteration and Elaboration is iterations 3 and 4, so the table names an iteration that designs nothing. The Iteration Plan places the design of UC-001, UC-004, UC-009 and UC-011 in iteration 3 |
| 5 | `Iteration Plan#F3` | Iteration Plan | Major | ManagementReviewer | ProjectManager | The iteration 2 fine plan does not account for the Development Case, which this iteration produced. Exit criterion E1 states every artifact the iteration produces has a work item, an owner and an exit condition; W1 to W9 cover eight artifacts but not the Development Case, which was substantively revised. The role profile marks ProcessEngineer Active in iteration 2, asserting work the fine plan does not contain. The plan fails its own E1 criterion |
| 6 | `Supplementary Specification#F1` | Supplementary Specification | Minor | Reviewer | RequirementsSpecifier | The constraint grouping is internally inconsistent and does not match the declared categories. The "Environmental constraints" table lists CON-005 and CON-031, both declared Technical. The constraint map diagram disagrees with the table on CON-005 and places CON-031 in its Environment package. The two representations of the same 36 constraints do not agree |
| 7 | `Supplementary Specification#F1` | Supplementary Specification | Minor | BusinessReviewer | RequirementsSpecifier | The business-rules register carries twelve of the thirteen declared `[BusinessRule]` constraints, omitting CON-008, the authorization rule. CON-008 is enforced elsewhere as MECH-02, so the rule is not lost, but the register presents itself as complete and under-reports by one |

**Findings closed this iteration — 10, by their emitting lenses.** These are not open and do not bear on the verdict; they are listed so the ledger's arithmetic is checkable.

| Key | Artifact | Severity | Emitting lens |
|---|---|---|---|
| `Vision#F1` | Vision | Minor | Reviewer |
| `Vision#F1` | Vision | Minor | BusinessReviewer |
| `Use-Case Model#F1` | Use-Case Model | Major | Reviewer |
| `Software Architecture Document#F1` | Software Architecture Document | Major | Reviewer |
| `Software Architecture Document#F2` | Software Architecture Document | Minor | Reviewer |
| `Iteration Plan#F1` | Iteration Plan | Major | Reviewer |
| `Iteration Plan#F1` | Iteration Plan | Major | ManagementReviewer |
| `Iteration Plan#F2` | Iteration Plan | Major | ManagementReviewer |
| `Test Evaluation Summary#F1` | Test Evaluation Summary | Major | Reviewer |
| `Test Evaluation Summary#F2` | Test Evaluation Summary | Minor | Reviewer |

**Artifacts carrying no finding across all three lenses:** Development Case, Risk List, Test Evaluation Summary, Vision, Iteration Assessment.

**Two findings share a key and are not duplicates.** `Use-Case Model#F2` appears twice because findings are scoped per artifact and per lens: the Reviewer's `#F2` is the UC-001 postcondition against ADR-010, the Business Reviewer's `#F2` is CON-015's attachment to UC-011. They are distinct defects with distinct remediations and both must be corrected. The same holds for `Supplementary Specification#F1`.

**Conflicts between lenses — resolved by the coordinator.**

| Conflict | Resolution |
|---|---|
| The Reviewer's `Use-Case Model#F2` and the Business Reviewer's `Use-Case Model#F1` both touch UC-001 and could be read as one defect | They are two: one restates the postcondition, the other adds a flow. Both are corrected in one pass over UC-001, but neither closes the other. Recorded as separate actions |
| The Business Reviewer's `Use-Case Model#F2` asserts CON-015 governs the directory search; the Use-Case Model denies it; the SAD implements it | Not a conflict to arbitrate — the declared constraint settles it. CON-015 names "a directory column that also filters" as one of exactly two permitted uses, so the Use-Case Model is the artifact that is wrong. The action is to bind the rule to UC-011, not to remove the filter from COMP-005 |
| The Reviewer's `Supplementary Specification#F1` and the Business Reviewer's `Supplementary Specification#F1` both concern the same section | Adjacent, not identical: one is the constraint grouping, the other the business-rules register count. Both are corrected in one pass over the Supplementary Specification |
| The Management Reviewer's `Iteration Plan#F3` offers two alternative resolutions | The coordinator selects the first: add the Development Case as a work item. Amending E1 to exclude the Development Case would weaken a criterion that is correct as written |

**No conflict required escalation to the stakeholder.** Every disagreement is settled by a declared constraint or by the artifact that owns the element.

```plantuml
@startuml
title Portal - Consolidated finding ledger at the LCO gate, Inception iteration 2

package "Open Major - 5" {
  class "Use-Case Model#F2 (Reviewer)\nUC-001 postcondition describes the\nsingle-row model ADR-010 replaced" as M1
  class "Use-Case Model#F1 (Business)\nCON-012 bound to UC-001 but not\nenforced; complete-pair case unaddressed" as M2
  class "Use-Case Model#F2 (Business)\nCON-015 attachment contradicts\nthe Software Architecture Document" as M3
  class "Software Architecture Document#F3\nsignificance table not re-based onto\nthe eight-iteration roadmap" as M4
  class "Iteration Plan#F3 (Management)\nDevelopment Case has no work item\nin the iteration 2 fine plan" as M5
}

package "Open Minor - 2" {
  class "Supplementary Specification#F1 (Reviewer)\nconstraint grouping disagrees with\nthe declared categories" as N1
  class "Supplementary Specification#F1 (Business)\nCON-008 absent from the\nbusiness-rules register" as N2
}

package "Open Critical - 0" {
  class "None" as C0
}

package "Closed this iteration - 10" {
  class "Vision#F1 (Reviewer)" as R1
  class "Vision#F1 (Business)" as R2
  class "Use-Case Model#F1 (Reviewer)" as R3
  class "Software Architecture Document#F1" as R4
  class "Software Architecture Document#F2" as R5
  class "Iteration Plan#F1 (Reviewer)" as R6
  class "Iteration Plan#F1 (Management)" as R7
  class "Iteration Plan#F2 (Management)" as R8
  class "Test Evaluation Summary#F1" as R9
  class "Test Evaluation Summary#F2" as R10
}

note bottom of M3
  The only open finding that is a disagreement
  between two artifacts rather than a defect
  inside one.
end note

note bottom of C0
  No declared exclusion crossed, no phantom
  use case, no invented identifier, no scope
  expansion beyond the fifteen declared
  requirements.
end note
@enduml
```

**Defect concentration.** Three of the five open Major findings sit in one artifact, the Use-Case Model, and two of those three are the same defect class: a rule or a decision another artifact changed, not carried through to the use case that must enforce it. That concentration is why the Use-Case Model is the critical path of the next iteration and why the Development Case's new authoring checks are load-bearing rather than cosmetic.

**Review effectiveness metrics — this milestone.**

| Metric | Value | Basis |
|---|---|---|
| Review coverage | 10 of 10 artifacts | Every artifact in the repository was read by all three lenses |
| Findings open at gate | 7 — 0 Critical, 5 Major, 2 Minor | `read_artifact_findings`, all 10 artifacts |
| Findings closed this iteration | 10 | Resolution objects present in the ledger |
| Closure rate | 10 of 17 findings raised across both iterations | 10 closed, 7 open |
| Defect density by artifact | Use-Case Model 3, Software Architecture Document 1, Iteration Plan 1, Supplementary Specification 2, five artifacts 0 | Open findings per artifact |
| Defect removal efficiency | Not computable at this gate | No test execution has occurred; Inception builds nothing, so there is no test-found defect count to compare against |
| Rework effort | Not measured in hours | This system measures tokens and elapsed time, not person-hours. Iteration 1 measured 6,756,727 tokens and 0:54:19.692 agent time with 0:00:00 human queue time, reported apart and never added |
| Overdue findings | 0 of 7 | The action list was issued at this review event; no deadline has elapsed |
| Escalations | 0 | No deadline missed, no Critical finding open |

**Interpretation.** Coverage is complete and closure is running at 59% across the two iterations, which is the expected shape of a correction iteration: the first pass raised 10 findings, 10 were closed, and the corrections themselves produced 7 new ones. The pattern is not declining rigor — it is the normal cost of a correction that changes a decision (ADR-010, the roadmap) which other artifacts had to follow. The signal to watch is whether the next iteration's corrections produce a third generation of the same defect class; if they do, the authoring checks are not working and the process needs correction, not another pass.

```plantuml
@startuml
title Portal - Finding lifecycle and closure protocol

[*] --> Open : record_artifact_finding\nby the emitting lens
Open --> Assigned : coordinator assigns\nowner and priority
Assigned --> Corrected : author corrects every\nsection the finding names
Corrected --> Verified : emitting lens re-reads\nthe corrected content
Verified --> Closed : resolve_artifact_finding\nby the emitting lens only
Closed --> [*]

Assigned --> Overdue : deadline missed
Overdue --> Escalated : written notice to\nthe Project Manager
Escalated --> Corrected : owner resumes

note right of Closed
  A Review Record sentence saying
  "resolved" is not a resolution.
  Only the tool call closes a finding.
end note

note bottom of Verified
  Cross-lens closure is rejected by the
  actor handler: a lens that did not emit
  a finding cannot certify its correction.
end note
@enduml
```

## Resolutions and Actions
### Reviewer lens
<!-- review: Inception I3 -->

**Prior findings of this lens, reconciled this iteration.** Three were open at the start of iteration 3. Each was verified against the corrected artifact content and closed through `resolve_artifact_finding`. None is Deferred, none is Rejected, none is left open.

| Finding | Severity | Verified against | Resolution |
|---|---|---|---|
| `Use-Case Model#F2` | Major | UC-001 postcondition row now reads "After a Clock In press one ClockIn event row exists for the employee-day; after a Clock Out press a ClockOut event row exists for the same `WorkDate`; the effective pair is the two rows no other row supersedes". Main flow step 2 resolves the effective pair over supersession. The "Clocking record shape" paragraph states the shape is the same in UC-002, UC-003 and UC-005, and each of those outline rows says "resolved over supersession". The trace graph reports no `SUSPECT` edge on any `COMP-002` Realizes link | Resolved |
| `Supplementary Specification#F1` | Minor | Design Constraints preamble states the grouping basis is the declared category and gives the arithmetic: Technical 9, Environmental 3, BusinessRule 13, Architectural 3, Operational 8 = 36. The Environmental table carries CON-006, CON-007, CON-028 only; the Technical table carries CON-001 to CON-005, CON-025 to CON-027 and CON-031; the diagram's "Technical - 9" and "Environmental - 3" packages hold the same members | Resolved |
| `Software Architecture Document#F3` | Major | Significance table reads "Elaboration iteration 4" for ranks 1 to 4 and "Elaboration iteration 5" for ranks 5 to 10, and the prose states the basis as the Iteration Plan's nine-iteration roadmap. The Iteration Plan's coarse roadmap places Elaboration at iterations 4 and 5 with UC-001, UC-004, UC-009 and UC-011 designed in iteration 4 — the same assignment. No stale "Elaboration iteration 2" or "iteration 3" value remains | Resolved |

**Not this lens's to close.** `Iteration Plan#F3`, recorded by the Management Reviewer lens, remains open with that lens. The actor handler rejects cross-lens closure, correctly: a lens that did not emit a finding cannot certify its correction.

**Open actions this milestone.** Three, all assigned, none deferred.

| Action | Owner | Closes | Exit condition |
|---|---|---|---|
| Re-read `scm_get_build_status` and `scm_list_issues` at the moment of writing; replace the run identifier and its timestamps and the issue count with the values read, naming all three issues | TestManager | `Test Evaluation Summary#F3` | The quality-signals and defect-record tables cite the run and the issue count as read at the moment of writing, and the count matches the tracker |
| Record `.github/workflows` as committed and green on `main` with the run identifier read at the moment of writing; remove it from the iteration preparation checkpoint's list of missing toolchain components; close `Issue #2` and `Issue #3` | ProcessEngineer | `Development Case#F1` | The tool and guideline reference table and the checkpoint agree that the CI workflow exists, and the two issues are closed against the correction |
| Make W11's owner list and the iteration 3 role profile agree — either activate ManagementReviewer for the LCO sanction question or reduce W11's owners to the roles recorded Active | ProjectManager | `Iteration Plan#F2` | Every work item's owners are Active in the iteration's column, and the plan's claim about it is counted rather than asserted |

**What the three closures established.** The corrections are substantive, not cosmetic. The UC-001 postcondition now describes the same clocking shape ADR-010 establishes, and the trace graph confirms it independently by clearing all four suspect edges — the artifact and the graph agree, which is the check that a narrative claim of resolution cannot satisfy. The Supplementary Specification's constraint grouping is now derived from one basis and states the arithmetic that proves completeness, so the two representations cannot drift without the count failing. The Software Architecture Document's significance table and the Iteration Plan's roadmap name the same iteration for the same use case, which is the cross-artifact agreement the LCO architecture criterion tests.

**What the three closures did not establish.** A correction is not a closure and a closure is not a pass. The three findings recorded this milestone are all of one class — a claim asserted rather than read against the set it describes — and one of them is a recurrence of a defect closed in iteration 2 on the strength of a corrected citation. That recurrence is the evidence R009 asks for: the C2 check did not prevent it, and the Development Case's own verdict table should record that rather than claim the checks are working.

```plantuml
@startuml
title Portal - Inception iteration 3 technical lens: closure and open position

package "Closed this iteration - 3 prior findings" {
  class "Use-Case Model#F2\nMajor\npostcondition in ADR-010 terms,\n4 suspect traces cleared" as C1
  class "Supplementary Specification#F1\nMinor\nconstraint grouping by declared category" as C2
  class "Software Architecture Document#F3\nMajor\nsignificance table re-based to 4 and 5" as C3
}

package "Open this iteration - 1 Major, 2 Minor" {
  class "Test Evaluation Summary#F3\nMajor\nSCM state cited from an earlier read" as O1
  class "Development Case#F1\nMinor\nCI workflow recorded as not yet created" as O2
  class "Iteration Plan#F2\nMinor\nW11 owners disagree with the role profile" as O3
}

package "Open, other lens" {
  class "Iteration Plan#F3\nManagement Reviewer lens" as X1
}

package "Gate position" {
  class "0 Critical" as G1
  class "1 Major" as G2
  class "2 Minor" as G3
  class "No exclusion crossed\nNo identifier invented\nNo scope expanded" as G4
}

C1 --> G1
C2 --> G1
C3 --> G1
O1 --> G2
O2 --> G3
O3 --> G3
G4 --> G1

note bottom of O1
  A recurrence of a defect closed in iteration 2
  on the strength of a corrected citation. This
  is the evidence R009 asks for: C2 did not
  prevent it.
end note

note bottom of G2
  The one Major is a currency defect, not a
  reasoning defect. It does not invalidate the
  test position; it makes the artifact's own
  claim to be reading the authoritative record
  untrue.
end note
@enduml
```

### Business Reviewer lens
<!-- review: Inception I2 -->

<!-- review: Inception I2 -->

| Finding | Severity | Owner | Action | Status |
|---|---|---|---|---|
| `Vision#F1` (business lens, iteration 1) | Minor | SystemAnalyst | Replace the two self-referential success-criterion cells with independent observable checks | **Resolved** — verified in the Features section; FR-014 and FR-015 now carry derived observable checks and the preamble states the rule |
| `Use-Case Model#F1` (business lens) | Major | SystemAnalyst | Add the complete-pair alternative flow to UC-001; state step 3 in terms of no pair / pair open / pair complete; route to HR under UC-005 per CON-017 | Open — this iteration |
| `Use-Case Model#F2` (business lens) | Major | SystemAnalyst | Bind CON-015 to UC-011; state the permissive half (column plus filter) and the prohibitive half (no access decision) separately; add the filter to UC-011's flows; align the outline table and the binding diagram with the SAD | Open — this iteration |
| `Supplementary Specification#F1` (business lens) | Minor | SystemAnalyst | Add CON-008 as the thirteenth register row with its enforcement point and a MECH-02 cross-reference, and correct the count; or state in the preamble that authorization is carried as a mechanism | Open — this iteration |

**No finding is deferred and no finding is rejected.** The stakeholder's instruction that every finding be corrected is honoured: all three new findings are assigned to the SystemAnalyst, who owns both affected artifacts, and none is deferred to a later phase. No declared scope is cut or deferred to fit a schedule (CON-023).

**Closure discipline.** `Vision#F1` was closed by `resolve_artifact_finding` before any new defect was recorded, in a state separate from the one that records new findings. The three new findings are recorded under keys the system minted this iteration; none re-records a persisting defect, because no defect of this lens from iteration 1 persists.

**Two of these findings sit on the same artifact as two findings of the Reviewer lens, and they are not duplicates.** The Reviewer lens's `Use-Case Model#F2` is the UC-001 postcondition describing a single clocking record where ADR-010 establishes an append-only event log. This lens's `Use-Case Model#F1` is CON-012's enforcement in the same use case — the complete-pair case the flow does not handle. Both are corrected in the same pass over UC-001, but they are distinct defects with distinct remediations: one restates the postcondition, the other adds a flow. The Reviewer lens's `Use-Case Model#F1` (the worker-category cluster bound to UC-010) is already Resolved; this lens's `Use-Case Model#F2` is the adjacent but different question of whether CON-015 reaches UC-011 at all.

**What the SystemAnalyst needs to know to act without asking a follow-up question.** The two Major findings are one class of defect seen twice: a rule is cited in a "Business rules enforced" list without the use case specifying the behaviour that enforces it. `Use-Case Model#F1` (business lens) is the sharper case — the rule is bound, the flow contradicts it. `Use-Case Model#F2` (business lens) is the wider case — the rule is bound to two of its three declared uses and the artifact denies the third, while the architecture implements it. Correcting both means making the binding diagram, the outline table, the use-case flows and the Software Architecture Document say the same thing about the same rule.

```plantuml
@startuml
title Portal - Business lens finding lifecycle at this gate

[*] --> VisionF1 : iteration 1, Minor
VisionF1 --> Resolved : corrected in the Features section\nverified against the current content
Resolved --> [*] : resolve_artifact_finding\nby this lens

[*] --> UCMF1 : iteration 2, Major
[*] --> UCMF2 : iteration 2, Major
[*] --> SuppF1 : iteration 2, Minor

UCMF1 --> Assigned : SystemAnalyst
UCMF2 --> Assigned : SystemAnalyst
SuppF1 --> Assigned : SystemAnalyst

Assigned --> Corrected : flows, tables and diagram\nmade to agree
Corrected --> Verified : this lens re-reads\nthe corrected sections
Verified --> [*] : resolve_artifact_finding\nby this lens only

note right of Resolved
  Closed before any new defect was
  recorded, in a state separate from
  the one that records findings.
end note

note bottom of Assigned
  No finding deferred, none rejected.
  CON-023 forbids cutting or deferring
  declared scope to fit a schedule.
end note
@enduml
```

### Management Reviewer lens
<!-- review: Inception I2 -->

<!-- review: Inception I2 -->

**Stakeholder sanction: REFUSED.** The stakeholder answered No to the LCO sanction question, knowing the verdict was No-Go and that 0 Critical, 5 Major and 2 Minor findings were open. Stakeholder acceptance, verbatim: "No". The instruction accompanying it, verbatim: "Ok let's fix & close all findings".

The refusal is the correct reading of the evidence and it is recorded as the gate outcome, not as a defect against any artifact. The remedy is another Inception iteration — never a scope cut (CON-023) and never more agent parallelism.

#### Findings of this lens closed this iteration

Both prior findings of this lens were against the Iteration Plan. Each was closed by `resolve_artifact_finding` after the correction was verified against the evidence chain rather than accepted from the plan's assertion of it.

| Key | Severity | What was wrong | What was verified before closing |
|---|---|---|---|
| `Iteration Plan#F1` (Management) | Major | The plan claimed R001 was retired in Elaboration iteration 2 by the stand-in directory carrying empty job-title and extension entries. Building a fixture is not retiring a risk | A "Risk retirement sequencing" section now separates mechanism from retiring event for all eight risks, and R001 is retired in iteration 3 by executing the empty-attribute case of UC-011 and UC-004. Verified against the Test Evaluation Summary: its coverage plan reads "UC-011 … Iteration 7 — with the empty-attribute case executed in iteration 3" and "UC-004 … Iteration 5 — with the empty-attribute case executed in iteration 3", its execution sequence places both cases in iteration 3, and the role profile activates Tester from iteration 3. The plan also states what the sequencing means for the LCA gate |
| `Iteration Plan#F2` (Management) | Major | AC-004, a population measure over 200 employees, was assigned verification in the iteration in which its own three-month window begins to elapse, so it could never close at the gate it was assigned to | Layer A now splits AC-004 into AC-004a, the learnability half, verified in iteration 5 by an untrained-user check in the iteration that implements UC-001, and AC-004b, the population half, recorded as a post-Project-Acceptance measure owned by STK-001 against BG-003 and explicitly not a gate on any iteration. The Test Evaluation Summary carries the same split, so the plan and the test position agree |

#### Findings of this lens opened this iteration

| Key | Severity | Owner | Action required |
|---|---|---|---|
| `Iteration Plan#F3` | Major | ProjectManager | Add the Development Case as a work item in the iteration 2 fine plan with owner ProcessEngineer and an exit condition naming what the revision must achieve, and place it in the critical chain before the Review Record — or state in the fine plan's preamble that the revision is deliberately outside the plan's scope and amend exit criterion E1 so the criterion and the plan agree |

#### Actions this review places on the next iteration

Every open finding is an action. The stakeholder's instruction is that all of them are fixed and closed, so none is deferred and none is rejected.

| # | Action | Owner | Closes |
|---|---|---|---|
| 1 | Restate the UC-001 postcondition in ADR-010's terms — one ClockIn event row after the first press, one ClockOut event row after the second, the effective pair being the two rows no other row supersedes — and confirm UC-002, UC-003 and UC-005 read the same shape | SystemAnalyst | `Use-Case Model#F2` (Reviewer) |
| 2 | Add an alternative flow to UC-001 for the complete-pair case and state the button logic in terms of the three states CON-012 creates — no pair, pair open, pair complete — routing the employee to HR under UC-005 per CON-017 | SystemAnalyst | `Use-Case Model#F1` (Business) |
| 3 | Bind CON-015 to UC-011, stating its permissive half (rendered column, filterable result set) and its prohibitive half (no access decision) separately, add the filter to UC-011's flows, and remove the sentence denying the binding — so the Use-Case Model and the Software Architecture Document read the same way | SystemAnalyst | `Use-Case Model#F2` (Business) |
| 4 | Re-base the architectural-significance table's "Design in" column onto the eight-iteration roadmap — ranks 1 to 4 to Elaboration iteration 3, ranks 5 to 10 to Elaboration iteration 4 — and check the rest of the document for the same stale numbering | SoftwareArchitect | `Software Architecture Document#F3` (Reviewer) |
| 5 | Add the Development Case work item to the iteration 2 fine plan, or amend exit criterion E1 to match the plan | ProjectManager | `Iteration Plan#F3` (Management) |
| 6 | Make the constraint grouping agree with the declared categories in both the table and the diagram, or retitle both so they state they group by what each constraint decides | RequirementsSpecifier | `Supplementary Specification#F1` (Reviewer) |
| 7 | Add CON-008 to the business-rules register as the thirteenth row with its enforcement point and a cross-reference to MECH-02, and correct the preamble count — or state in the preamble that authorization is deliberately carried as a mechanism | RequirementsSpecifier | `Supplementary Specification#F1` (Business) |

**Actions 1 to 3 are one pass, not three.** All three are in the Use-Case Model and two of them touch UC-001's flows. Correcting the postcondition without correcting the button logic would leave the use case internally inconsistent, and correcting the button logic without binding CON-015 to UC-011 would leave the Use-Case Model contradicting the architecture. The SystemAnalyst should make all three corrections in one revision and re-read the whole use case against ADR-010 before persisting.

**Action 3 is the one that decides the architecture criterion.** The LCO criterion on architecture credibility fails because two artifacts disagree about whether CON-015 governs the directory search. Either resolution is defensible on its own; what is not defensible is the disagreement surviving into Elaboration, where UC-011 is detailed and the filter is either built or silently dropped.

#### What this review does not ask for

- It does not ask for a Project Approval Review or a Project Planning Review held apart from this milestone review. Both are held inside it: the sanction question to the stakeholder is the approval, and the LCO readiness assessment in the Iteration Plan is the planning review.
- It does not ask for signatures from named persons. The stakeholder's answer to the sanction question is the documented acceptance, and it is recorded above.
- It does not ask for the Iteration Assessment to be updated before the milestone can close. The ProjectManager authors it after this review, given the verdict.
- It does not ask for the merge to `main`. The iteration baseline is the delivered capability; the merge is the Integrator's post-sanction step.
- It does not ask for a token budget. CON-030 forbids one, and the measured spend of iteration 1 is recorded in the Iteration Assessment and used to forecast.

### Review Coordinator lens
<!-- review: Inception I2 -->

**Stakeholder input already obtained — not re-asked.** The Management Reviewer put the LCO sanction question to STK-001 with the verdict leaning and every open Major defect inside it. The answer was No, with the instruction that every finding be fixed and closed. That answer is the stakeholder's input for the next pass and is folded in below as the stakeholder finding. It is not put back to the stakeholder as a fresh question: the question has been asked and answered, and re-asking it would re-open a decision already made.

**Stakeholder finding:** every finding in this ledger is to be corrected and closed. No finding is deferred and none is rejected. No declared scope is cut or deferred to fit a schedule — CON-023 forbids it, and the remedy for a milestone that does not pass is another iteration.

**Consolidated action list — prioritized by gate impact, one list per owner.** Every open finding is an action; there are 7 actions for 7 open findings.

| Priority | Action | Finding | Artifact | Owner | Closes at |
|---|---|---|---|---|---|
| 1 | Restate the UC-001 postcondition in ADR-010's terms — one ClockIn event row after the first press, one ClockOut event row after the second, the effective pair being the two rows no other row supersedes — and confirm UC-002, UC-003 and UC-005 read the same shape. Then clear the four `COMP-002` suspect traces by declaring the Use-Case Model reviewed against ADR-010 | `Use-Case Model#F2` (Reviewer) | Use-Case Model | SystemAnalyst | LCO gate re-presentation |
| 2 | Add an alternative flow to UC-001 for the complete-pair case, state the button logic in terms of the three states CON-012 creates — no pair, pair open, pair complete — and route the employee to HR under UC-005 per CON-017 | `Use-Case Model#F1` (Business) | Use-Case Model | SystemAnalyst | LCO gate re-presentation |
| 3 | Bind CON-015 to UC-011, stating its permissive half (rendered column, filterable result set) and its prohibitive half (no access decision) separately, add the filter to UC-011's flows, remove the sentence denying the binding, and align the outline table and the binding diagram with the SAD | `Use-Case Model#F2` (Business) | Use-Case Model | SystemAnalyst | LCO gate re-presentation |
| 4 | Re-base the architectural-significance "Design in" column onto the eight-iteration roadmap — ranks 1 to 4 to Elaboration iteration 3, ranks 5 to 10 to Elaboration iteration 4 — and check the rest of the document for the same stale numbering | `Software Architecture Document#F3` | Software Architecture Document | SoftwareArchitect | LCO gate re-presentation |
| 5 | Add the Development Case as a work item in the iteration 2 fine plan with owner ProcessEngineer and an exit condition naming what the revision must achieve, placed in the critical chain before the Review Record | `Iteration Plan#F3` | Iteration Plan | ProjectManager | LCO gate re-presentation |
| 6 | Make the constraint grouping agree with the declared categories in both the table and the diagram, or retitle both so they state they group by what each constraint decides | `Supplementary Specification#F1` (Reviewer) | Supplementary Specification | RequirementsSpecifier | LCO gate re-presentation |
| 7 | Add CON-008 to the business-rules register as the thirteenth row with its enforcement point and a cross-reference to MECH-02, and correct the preamble count | `Supplementary Specification#F1` (Business) | Supplementary Specification | RequirementsSpecifier | LCO gate re-presentation |

**Prioritization rationale.** Priorities 1 to 3 are one pass, not three: all three are in the Use-Case Model and two touch UC-001's flows. Correcting the postcondition without correcting the button logic would leave the use case internally inconsistent, and correcting the button logic without binding CON-015 to UC-011 would leave the Use-Case Model contradicting the architecture. They rank first because the Use-Case Model carries three of the five open Major findings and because two of the seven LCO exit criteria fail on it. Priority 4 is the other failing criterion — architecture credibility — and is a single correction inside one artifact. Priority 5 is a planning-completeness defect that makes the plan fail its own exit criterion. Priorities 6 and 7 are Minor: they do not block the gate, but the stakeholder required every finding corrected, so neither is deferred.

**Action 3 decides the architecture criterion.** The LCO criterion on architecture credibility fails because two artifacts disagree about whether CON-015 governs the directory search. Either resolution is defensible on its own; what is not defensible is the disagreement surviving into Elaboration, where UC-011 is detailed and the filter is either built or silently dropped. The declared constraint settles which artifact is wrong: CON-015 names "a directory column that also filters" as one of exactly two permitted uses, so the Use-Case Model is the artifact to correct.

**Action ownership and load:**

```plantuml
@startuml
title Portal - Consolidated action list, owner and gate impact, Inception iteration 2

package "SystemAnalyst - 3 Major" {
  class "P1 UC-001 postcondition vs ADR-010\nUse-Case Model#F2 (Reviewer)" as P1
  class "P2 CON-012 complete-pair flow\nUse-Case Model#F1 (Business)" as P2
  class "P3 CON-015 bound to UC-011\nUse-Case Model#F2 (Business)" as P3
}

package "SoftwareArchitect - 1 Major" {
  class "P4 Significance table re-based\nSoftware Architecture Document#F3" as P4
}

package "ProjectManager - 1 Major" {
  class "P5 Development Case work item\nIteration Plan#F3" as P5
}

package "RequirementsSpecifier - 2 Minor" {
  class "P6 Constraint grouping\nSupplementary Specification#F1 (Reviewer)" as P6
  class "P7 CON-008 register row\nSupplementary Specification#F1 (Business)" as P7
}

class "Gate: LCO re-presentation\nall 7 closed and re-verified" as G

P1 --> G
P2 --> G
P3 --> G
P4 --> G
P5 --> G
P6 --> G
P7 --> G

note bottom of G
  Closure is by the emitting lens only, via
  resolve_artifact_finding. A Review Record
  sentence saying "resolved" is not a
  resolution and does not clear the gate.
end note

note bottom of P1
  P1, P2 and P3 are one revision of one
  artifact. The SystemAnalyst carries the
  heaviest load and the critical path.
end note
@enduml
```

**Closure protocol.** Each action closes only when the emitting lens calls `resolve_artifact_finding` after verifying the corrective action is adequate. The coordinator does not close findings and does not accept a narrative claim of resolution in place of the tool call. All five Major findings must be closed before the LCO gate is re-presented; the two Minor findings must be closed or explicitly deferred with a reason, and the stakeholder's instruction is that they be corrected.

**Escalation status.** No finding has missed a deadline, because no deadline has yet elapsed — the action list was issued at this review event. No escalation notice is due. No Critical finding exists, so no Critical escalation to the stakeholder is required. The stakeholder was nevertheless consulted, because the LCO sanction is theirs to give and it was refused.

**Review debt position at this gate:** 7 open findings, 0 overdue, 0 escalated. The 0% overdue rate is not a sign of health — it is the reading of a ledger issued moments ago. It becomes meaningful at the next review event, when the first deadlines have had a chance to elapse.

**Review process observations.** These are process facts, not artifact defects, and they are not in the ledger.

| Observation | Consequence |
|---|---|
| All three lenses executed and all 10 artifacts were reviewed by each | Coverage is complete. No artifact reached the gate unreviewed and no lens reviewed a subset |
| No lens closed a finding belonging to another lens | The ownership invariant held. No cross-lens closure was attempted |
| The Business Reviewer confirmed the Reviewer's findings by key rather than re-recording them | Correct process. One logical defect, one ledger entry, one owner |
| The corrections of iteration 1 produced 7 new findings of the same class | The defect class is "a decision another artifact changed, not carried through". The Development Case's new authoring checks target it. If a third generation appears, the process needs correction rather than another pass |
| The Management Reviewer's `Iteration Plan#F3` offered two alternative resolutions | The coordinator selected the first — add the Development Case work item. Amending E1 to exclude it would weaken a criterion that is correct as written |

## Disposition
### Reviewer lens
<!-- review: Inception I3 -->

**Disposition: Approved with Changes.**

The technical position of the artifact set is materially stronger than at iteration 2, and the three findings this lens carried into the iteration are genuinely corrected rather than restated. The UC-001 postcondition now describes ADR-010's append-only event log — one ClockIn row, one ClockOut row, the effective pair resolved over supersession — and the trace graph confirms it independently by clearing all four `COMP-002` suspect edges. The Supplementary Specification groups all 36 constraints by their declared category in both the table and the diagram, states the arithmetic that proves the set is complete, and can no longer drift without the count failing. The Software Architecture Document's significance table names Elaboration iterations 4 and 5, matching the Iteration Plan's nine-iteration roadmap exactly.

One Major finding remains, and it is a defect of currency rather than of reasoning. The Test Evaluation Summary cites a CI run and an issue count that were not read at the moment of writing: the run it names is superseded and the count omits an issue. The test position itself is sound — 15 of 15 use cases and 5 of 5 NFRs assigned an execution iteration in which the behaviour exists, both R001 fixture obligations recorded with their execution iteration, the alternative flows that enforce CON-012 and CON-016 named as test obligations. What is wrong is the artifact's claim to be reading the authoritative record, and that claim is the one the Development Case's C2 check exists to make true.

Two Minor findings: the Development Case records the CI workflow as not yet created when it is committed and green, and the Iteration Plan's W11 owner list disagrees with its own role profile.

**No Critical finding.** No declared exclusion is crossed anywhere in the set. No identifier is invented — every `FR-`, `NFR-`, `CON-`, `AC-`, `BG-`, `STK-` and `R` identifier cited is one the work order assigned. No scope is expanded beyond the fifteen declared requirements: the fifteen use cases map one to one onto them, and the three extension use cases are declared requirements modelled as exception paths rather than invented goals. No cross-cutting mechanism is promoted to a use case — authentication, authorization, audit and directory read are mechanisms in the Supplementary Specification, included by the use cases that depend on them. No artifact claims a milestone is achieved or an acceptance criterion is closed.

**What this disposition is not.** It is not a sanction to advance. The milestone verdict belongs to the ReviewCoordinator and the sanction to the stakeholder; this lens reports the technical state of the artifacts and nothing more. It is also not a claim that the one Major finding is tolerable — it is correctable within this iteration and it should be corrected before the gate is re-presented, because the role that reads it next is the role that would act on the stale version.

**The recurrence is the finding that matters most.** `Test Evaluation Summary#F3` is the third generation of the "observable state cited from an earlier read" class, and the second against this artifact: `Test Evaluation Summary#F1` was closed in iteration 2 on the strength of a corrected citation, and the correction did not hold. R009 asks whether the authoring checks work, and its escalation path is that a third generation of a class the checks cover means the process needs correction rather than another pass. C2 covers this class and did not prevent it. The Development Case's verdict table should record that, and the Project Manager should read it as R009's warning sign firing rather than as a routine Minor.

**Traceability position.** The trace graph carries 42 business roots and 180 nodes. No `FR-NNN`, `NFR-NNN` or `UC-NNN` is a leaf: every declared requirement is realized by a use case and every use case is carried by at least one component. No `SUSPECT` edge is reported anywhere in the graph — the four that iteration 2 recorded are cleared, and the five the Risk List re-verified are cleared with the reason each dependency still holds. The trace position is clean.

**SCM position.** No open pull request, so no PR required a disposition. The build on `main` is green — run `39958957391`, completed 2026-10-23 13:10:47Z — and carries no product evidence, because the repository holds inputs and artifacts only. Three issues are open, all documentation staleness, all minor; two of them are the evidence for the Development Case finding above.

```plantuml
@startuml
title Portal - Inception iteration 3 technical lens: disposition and what it rests on

package "Corrected and verified - 3" {
  class "Use-Case Model\nUC-001 postcondition matches ADR-010\n4 suspect traces cleared" as P1 <<Pass>>
  class "Supplementary Specification\n36 constraints grouped by declared category\ntable and diagram agree" as P2 <<Pass>>
  class "Software Architecture Document\nsignificance table matches the roadmap" as P3 <<Pass>>
}

package "Open - 1 Major, 2 Minor" {
  class "Test Evaluation Summary#F3\nMajor - SCM state not read at writing" as F1 <<Major>>
  class "Development Case#F1\nMinor - CI workflow recorded as absent" as F2 <<Minor>>
  class "Iteration Plan#F2\nMinor - W11 owners vs role profile" as F3 <<Minor>>
}

package "Conditions absent - no Critical" {
  class "No declared exclusion crossed" as N1
  class "No identifier invented" as N2
  class "No scope expanded beyond 15 declared FRs" as N3
  class "No milestone or AC claimed closed" as N4
}

package "Disposition" {
  class "Approved with Changes\nfrom the technical lens only" as D1
  class "Not a sanction to advance\nThe milestone verdict is the\nReviewCoordinator's and the sanction\nthe stakeholder's" as D2
}

P1 --> D1
P2 --> D1
P3 --> D1
F1 --> D1
F2 --> D1
F3 --> D1
N1 --> D1
N2 --> D1
N3 --> D1
N4 --> D1
D1 --> D2

note bottom of F1
  The one Major is correctable within this
  iteration and should be corrected before the
  gate is re-presented: the role that reads it
  next is the role that would act on the stale
  version.
end note

note bottom of D2
  Two lenses reported Approved with Changes in
  iteration 2 and no lens approved the milestone.
  The distinction is load-bearing.
end note
@enduml
```

### Business Reviewer lens
<!-- review: Inception I2 -->

<!-- review: Inception I2 -->

**Disposition: Approved with Changes — from the business modeling lens only.**

The Business Modeling discipline is correctly inactive and the artifact set carries the business-level content the downstream disciplines need. No Critical finding. Two Major and one Minor, all in the business-rule attachment layer, all correctable within this iteration by the SystemAnalyst, who owns both affected artifacts.

**What this disposition is not.** It is not a sanction to advance. The milestone verdict belongs to the ReviewCoordinator and the sanction to the stakeholder; this lens reports the business modeling state of the artifacts and nothing more. It is also not a claim that the two Major findings are tolerable — they are correctable now and they should be corrected before the gate is re-presented, because each would mislead the role that reads it next. `Use-Case Model#F1` (business lens) would let a second clocking pair be recorded for one employee-day, which CON-012 declares impossible. `Use-Case Model#F2` (business lens) would let the declared directory filter be dropped when UC-011 is detailed in Elaboration, because the use case denies the rule that declares it.

**Business modeling position at this gate:**

| Criterion | Position | Basis |
|---|---|---|
| BM disposition | Correct and independently verified | `business-process-led = false`; five activation criteria tested, none met |
| Business artifacts owed | None | No BUC, business actor, business worker or business entity is required by the Development Case |
| Business artifacts missing | None | The Glossary is NOT TRIGGERED and correctly absent |
| Business rules | 12 of 13 carried with ID, attachment and testable condition; 2 attachment defects | `Use-Case Model#F1` (business lens), `Use-Case Model#F2` (business lens), `Supplementary Specification#F1` (business lens) |
| Stakeholder representation | Complete | All four declared stakeholders represented; negative-stakeholder analysis honest |
| Volatility annotation | Reached the architecture | Three High features each own a dedicated component |
| Business goals | Measurable or explicitly unmeasured | BG-001 unmeasured with STK-001 named as baseline supplier; BG-002 and BG-003 measurable |
| Scope adherence | Clean | 15 UCs to 15 declared FRs; no invented identifier; no exclusion crossed |

**Derivation readiness — the business lens's functional test.** The business-to-system derivation bridge is N/A because the system use cases were declared, not derived: the stakeholder declared FR-001 to FR-015 directly and the Use-Case Model maps one to one onto them. The bridge is not broken — it does not exist, and the Development Case correctly does not require it. What the Requirements discipline needs from the business level is the rule binding, and that is what the three findings correct.

**What must happen before the gate is re-presented.** The three findings corrected and re-verified by this lens. The remedy is another iteration — CON-023 forbids cutting or deferring declared scope to fit a schedule, and no scope is cut here. The cost axis is not assessable from this lens and no figure is invented to fill it: CON-030 declares no budget and forbids the team to set one.

```plantuml
@startuml
title Portal - Business modeling position at the LCO gate, Inception iteration 2

package "Discipline disposition" {
  class "Business Modeling\nINACTIVE per DC section 4" as BM <<BR-OK-INACTIVE>>
  class "BusinessProcessAnalyst\nidle by trigger" as BPA
  class "BusinessReviewer\nreviewed 9 of 9 artifacts" as BR
}

package "Business-level content - present and sound" {
  class "Business rules\n13 declared BusinessRule constraints" as C1
  class "Stakeholder representation\n4 of 4 declared" as C2
  class "Volatility annotation\n3 High features, 3 components" as C3
  class "Business goals\n1 unmeasured, 2 measurable" as C4
  class "Scope adherence\n15 UCs to 15 declared FRs" as C5
}

package "Business-level content - defective" {
  class "CON-012 enforcement\nUC-001 permits a second pair" as D1 <<Major>>
  class "CON-015 attachment\nUC-011 denies the rule the SAD applies" as D2 <<Major>>
  class "CON-008 register entry\n12 of 13 in the register" as D3 <<Minor>>
}

package "Gate position" {
  class "0 Critical" as G1
  class "2 Major" as G2
  class "1 Minor" as G3
  class "No exclusion crossed\nNo identifier invented\nNo scope expanded" as G4
}

BM --> BPA
BM --> BR
C1 --> D1
C1 --> D2
C1 --> D3
D1 --> G2
D2 --> G2
D3 --> G3
C2 --> G1
C3 --> G1
C4 --> G1
C5 --> G1
G4 --> G1

note bottom of BM
  Verified independently, not inherited.
  Five activation criteria tested against
  the artifact set; none is met.
end note

note bottom of G2
  Both Major findings are attachment defects.
  The rule content is correct in each case;
  the binding to the use cases that enforce
  it is not.
end note
@enduml
```

### Management Reviewer lens
<!-- review: Inception I2 -->

<!-- review: Inception I2 -->

**Verdict: No-Go.**

The Lifecycle Objectives milestone is **not achieved**. Five of the seven LCO exit criteria are met; two are not, and they are the two the gate exists to test — that the primary use cases are understood well enough to build from, and that the architecture is credible. Five Major findings and two Minor findings are open. No Critical finding is open.

**Stakeholder sanction: REFUSED.** The stakeholder answered No to the sanction question, knowing the verdict and the open defect count. Stakeholder acceptance, verbatim: "No". The instruction accompanying it, verbatim: "Ok let's fix & close all findings".

The refusal is the correct reading of the evidence. The project is not stopped: the remedy is another Inception iteration, which is the designed response to a gate that did not pass (CON-023). No declared scope is cut or deferred, and no role is added to compensate.

#### Four-axis health scorecard

| Axis | Rating | Basis |
|---|---|---|
| Scope | Green | 15 FR, 5 NFR, 36 CON, 3 BG and 5 AC carried exactly as declared; 13 exclusions published verbatim as a checkable boundary; zero scope findings in either iteration and zero exclusions crossed |
| Schedule | Amber | Inception is two iterations rather than one and the gate has not passed. The eight-iteration roadmap is re-based and internally consistent, and the CON-031 human gate is bounded at 14 days of queue time and has not yet elapsed. A second iteration is the designed remedy, not a schedule failure |
| Cost | Green | No token budget exists and none is set by the team, as CON-030 requires. Iteration 1 measured 6,756,727 tokens and 0:54:19.692 of agent time with 0:00:00 human queue time; the two clocks are reported apart and never added |
| Quality | **Red** | Five Major findings open, three of them in one artifact. Two LCO exit criteria fail. The defects are correctable and none disputes what a requirement says |

**One red axis is not a green project.** The quality axis is red for a specific and correctable reason: rules and decisions that another artifact changed were not carried through to the use cases that must enforce them. That is the defect class the Development Case's new authoring checks are written to catch, and it is why the Development Case revision is load-bearing rather than cosmetic.

```plantuml
@startuml
title Portal - Four-axis project health scorecard at the LCO gate

package "Scope - GREEN" {
  class "15 FR, 5 NFR, 36 CON, 3 BG, 5 AC\ncarried exactly as declared" as S1
  class "13 exclusions published verbatim\nas a checkable boundary" as S2
  class "0 scope findings in either iteration\n0 exclusions crossed" as S3
}

package "Schedule - AMBER" {
  class "Inception is 2 iterations, not 1\nThe LCO gate has not passed" as T1
  class "8-iteration roadmap, re-based\nand internally consistent" as T2
  class "CON-031 human gate bounded at\n14 days queue time, not yet elapsed" as T3
}

package "Cost - GREEN" {
  class "No token budget exists (CON-030)\nand none is set by the team" as C1
  class "Iteration 1 measured: 6,756,727 tokens,\n0:54:19.692 agent time, 0:00:00 human queue" as C2
  class "Two clocks reported apart,\nnever added" as C3
}

package "Quality - RED" {
  class "5 Major findings open\n0 Critical" as Q1
  class "3 of the 5 sit in one artifact:\nthe Use-Case Model" as Q2
  class "2 LCO exit criteria fail:\nuse-case fidelity, architecture credibility" as Q3
}

package "Verdict" {
  class "No-Go\nOne red axis is not a green project" as V1
}

S1 --> V1
S2 --> V1
S3 --> V1
T1 --> V1
T2 --> V1
T3 --> V1
C1 --> V1
C2 --> V1
C3 --> V1
Q1 --> V1
Q2 --> V1
Q3 --> V1

note bottom of Q3
  The red axis is quality, and it is red for a
  specific and correctable reason: rules and
  decisions that another artifact changed were
  not carried through to the use cases that
  must enforce them. No finding disputes what
  a requirement says.
end note

note bottom of T1
  Amber, not red. A second Inception iteration
  is the designed remedy for a gate that did
  not pass (CON-023), not a schedule failure.
end note
@enduml
```

#### Project health state

The project sits in the **No-Go** state: an LCO criterion fails, the sanction is not granted, and the remedy is another iteration. It is not in the Stopped state — the stakeholder refused the sanction, not the project, and instructed that the findings be fixed and closed.

```plantuml
@startuml
title Portal - Project health state machine at the LCO gate

[*] --> AtRisk

state Healthy {
  Healthy : All LCO criteria met
  Healthy : 0 open Major findings
  Healthy : Sanction available
}

state AtRisk {
  AtRisk : Criteria met but defects open
  AtRisk : Conditional sanction possible
}

state NoGo {
  NoGo : An LCO criterion fails
  NoGo : Sanction not granted
  NoGo : Remedy is another iteration
}

state Stopped {
  Stopped : No further iteration
}

Healthy --> AtRisk : a Major finding opens\nagainst a baseline artifact
AtRisk --> Healthy : every Major finding closed\nand re-verified by its lens
AtRisk --> NoGo : a Major finding survives\nthe iteration that was to close it
NoGo --> AtRisk : the defect is corrected\nand re-verified
NoGo --> Stopped : the stakeholder\nwithdraws the project

note right of NoGo
  Current state, Inception iteration 2.
  Two LCO criteria fail on five open
  Major findings. The project is not
  stopped: the remedy is another
  iteration, never a scope cut (CON-023).
end note
@enduml
```

#### Risk retirement trend

Zero of eight risks is retired by evidence at this gate, and that is the correct reading rather than a failure: Inception builds nothing, so no risk can be retired by a passing test. What the gate checks is that every risk names the event that retires it and that the plan does not claim retirement it has not earned. Both now hold — the second was `Iteration Plan#F1` (Management) and it is closed.

R001, the highest-magnitude risk at exposure 9, has a flat trend with no evidence yet. Its retiring event is named and sequenced: the empty-attribute case of UC-011 and UC-004 passing against the stand-in in Elaboration iteration 3. R002 and R008 are open by their nature — one a post-launch adoption measure, the other accepted under CON-023 and mitigated rather than retired.

```plantuml
@startuml
title Portal - Risk retirement trend at the LCO gate, iteration 2

package "High - exposure 9" {
  class "R001 AD attribute gaps\nP=3 I=3\nTrend: FLAT - mechanism planned,\nno evidence yet\nRetiring event: UC-011 A1 and UC-004 A5\npassing in Elaboration iteration 3" as R001
}

package "Significant - exposure 6" {
  class "R002 Clocking adoption\nP=3 I=2\nTrend: FLAT - post-launch measure\nRetiring event: BG-003 reading, STK-001" as R002
  class "R003 Human gate exceeds 14 days\nP=2 I=3\nTrend: NEW - gate not yet elapsed\nRetiring event: CON-031 feedback received" as R003
  class "R004 Stand-in omits empty entries\nP=2 I=3\nTrend: NEW - fixture not built\nRetiring event: CodeReviewer fixture inspection" as R004
  class "R005 Artifact crosses an exclusion\nP=2 I=3\nTrend: STABLE - 0 crossings found\nRetiring event: every review, every artifact" as R005
}

package "Moderate - exposure 4" {
  class "R006 Export contract misread\nP=2 I=2\nTrend: NEW - contract not built\nRetiring event: column-by-column test" as R006
  class "R007 Toolchain gaps\nP=2 I=2\nTrend: NEW - 4 gaps open\nRetiring event: gaps closed before Construction" as R007
  class "R008 Wrong client clock\nP=2 I=2\nTrend: ACCEPTED under CON-023\nRetiring event: none - mitigated, not retired" as R008
}

package "Retirement evidence at this gate" {
  class "Risks retired by evidence: 0 of 8" as E0
  class "Risks with a named retiring event: 8 of 8" as E1
  class "Retiring event is a passing test or an\nobserved reading: 6 of 8" as E2
}

R001 --> E0
R002 --> E0
R003 --> E0
R004 --> E0
R005 --> E0
R006 --> E0
R007 --> E0
R008 --> E0

note bottom of E0
  Zero retired is the correct reading at LCO:
  Inception builds nothing. What the gate
  checks is that every risk names the event
  that retires it, and that the plan does not
  claim retirement it has not earned. Both now
  hold - the iteration-1 defect was the second,
  and it is closed.
end note
@enduml
```

#### Conditions for the next LCO presentation

The gate re-opens when all seven actions in Resolutions and Actions are closed and re-verified by their emitting lenses. The conditions are stated as outcomes, not as activities, so the next review can check them:

1. UC-001's postcondition and its button logic describe the same clocking shape, and that shape is ADR-010's append-only event log. `Use-Case Model#F2` (Reviewer) and `Use-Case Model#F1` (Business) both close on this one revision.
2. CON-015 reads the same way in the Use-Case Model and the Software Architecture Document, and UC-011's flows contain the filter the rule declares. `Use-Case Model#F2` (Business) closes on this.
3. The Software Architecture Document's design iterations match the Iteration Plan's roadmap. `Software Architecture Document#F3` closes on this.
4. The Iteration Plan's fine plan and its exit criterion E1 agree about the Development Case. `Iteration Plan#F3` closes on this.
5. The Supplementary Specification's constraint grouping is internally consistent and its business-rules register is complete or states its own scope. Both Minor findings close on this.

**No condition requires new scope, a new artifact, or a new role.** Every one is a correction to an artifact that already exists, which is why the next iteration is a correction iteration and not a re-plan.

#### Review and sanction sequence

```plantuml
@startuml
title Portal - LCO review and sanction sequence, Inception iteration 2

|Management Reviewer|
start
:Load the planning and vision artifacts;
:Reconcile the two prior findings of this lens;
note right
  Iteration Plan#F1 and #F2.
  Both verified against the evidence
  chain, then closed.
end note
:Assess the seven LCO exit criteria;
:Consult the stakeholder;

|Stakeholder - STK-001|
:The sanction question carries the verdict
and every open Major defect;
:Answers No;

|Management Reviewer|
:Record "Stakeholder sanction: REFUSED";
:Record the instruction verbatim;
:Record the new finding of this lens;
:Issue the verdict - No-Go;

|ReviewCoordinator|
:LCO gate not passed;
:Iteration required;

|ProjectManager|
:Author the Iteration Assessment
given the verdict;
:Plan the next Inception iteration;
note right
  The remedy is another iteration.
  Never a scope cut (CON-023).
end note
stop
@enduml
```

### Review Coordinator lens
<!-- review: Inception I2 -->

**Milestone verdict: LCO NOT ACHIEVED. Iteration required.**

The verdict is anchored to the finding data, not to judgment. The evidence read at this gate:

| Evidence | Value | Source |
|---|---|---|
| Artifacts read | 10 | `read_artifact_findings` on every artifact in the repository |
| Artifacts unread | 0 | Same |
| Open Critical findings | 0 | Same |
| Open Major findings | 5 | Same |
| Open Minor findings | 2 | Same |
| Stakeholder sanction | REFUSED | Management Reviewer lens, this record |
| LCO exit criteria met | 5 of 7 | Iteration Plan, exit criteria E1 to E7 |

Two of the three conditions for advancing are false: five Major findings are open and the stakeholder refused the sanction. The milestone is therefore not achieved and the phase gate does not open.

**Why this is an iteration and not an escalation.** No Critical finding is open. Every open finding is a correction to an artifact that already exists — none requires new scope, a new artifact or a new role. The remedy is another Inception correction iteration, which is the designed response to a gate that did not pass (CON-023). No declared scope is cut or deferred, and no role is added to compensate.

**What the gate did establish.** Ten findings were closed this iteration by their emitting lenses, and the closures are substantive rather than cosmetic. ADR-010 resolves a schema contradiction that would have surfaced as an unimplementable design the moment Elaboration tried to baseline it, and it makes CON-013 hold by construction rather than by convention. The Iteration Plan now names the event that retires R001 rather than the fixture that makes it retirable. The Vision records BG-001 as unmeasured instead of presenting it as measurable. The Test Evaluation Summary's coverage plan is re-based onto the roadmap it is measured against.

**What the gate did not establish.** A correction is not a closure and a closure is not a pass. The two failing criteria are the two the gate exists to test: that the primary use cases are understood well enough to build from, and that the architecture is credible. Both fail on defects of currency — a decision another artifact changed, not carried through to the artifact that must follow it.

**Conditions for the next LCO presentation.** The gate re-opens when all seven actions in Resolutions and Actions are closed and re-verified by their emitting lenses. Stated as outcomes, so the next review can check them:

1. UC-001's postcondition and its button logic describe the same clocking shape, and that shape is ADR-010's append-only event log. `Use-Case Model#F2` (Reviewer) and `Use-Case Model#F1` (Business) both close on this one revision.
2. CON-015 reads the same way in the Use-Case Model and the Software Architecture Document, and UC-011's flows contain the filter the rule declares. `Use-Case Model#F2` (Business) closes on this.
3. The Software Architecture Document's design iterations match the Iteration Plan's roadmap. `Software Architecture Document#F3` closes on this.
4. The Iteration Plan's fine plan and its exit criterion E1 agree about the Development Case. `Iteration Plan#F3` closes on this.
5. The Supplementary Specification's constraint grouping is internally consistent and its business-rules register is complete or states its own scope. Both Minor findings close on this.

**No condition requires new scope, a new artifact or a new role.** Every one is a correction to an artifact that already exists, which is why the next iteration is a correction iteration and not a re-plan.

**Stakeholder position.** The sanction was refused with the instruction that every finding be fixed and closed. That instruction is the stakeholder's input for the next pass and is recorded in Resolutions and Actions as the stakeholder finding. It is not put back to the stakeholder as a fresh question: the question has been asked and answered this iteration, and re-asking it would re-open a decision already made.

**Lens dispositions carried into this verdict.**

| Lens | Disposition | Bearing on the verdict |
|---|---|---|
| Reviewer | Approved with Changes — 2 Major, 1 Minor open | The technical position is materially stronger than at iteration 1; the two Major findings are defects of currency, not of reasoning |
| BusinessReviewer | Approved with Changes — 2 Major, 1 Minor open | The business-rule content is correct; the attachment to the use cases that enforce it is not |
| ManagementReviewer | No-Go — sanction REFUSED | Quality axis red; two LCO exit criteria fail |

No lens approved the milestone. The two "Approved with Changes" dispositions are dispositions of the artifact set from a discipline's own position, not sanctions to advance, and both lenses state that explicitly.

```plantuml
@startuml
title Portal - LCO gate verdict, Inception iteration 2

package "Evidence read at the gate" {
  class "10 artifacts read\n0 unread" as E1
  class "0 open Critical" as E2
  class "5 open Major" as E3
  class "2 open Minor" as E4
  class "Stakeholder sanction: REFUSED" as E5
}

package "LCO exit criteria" {
  class "5 of 7 met" as X1
  class "Use-case fidelity - FAIL" as X2
  class "Architecture credibility - FAIL" as X3
}

package "Verdict" {
  class "LCO NOT ACHIEVED" as V1
  class "requiresIteration: true" as V2
  class "Remedy: another Inception\ncorrection iteration" as V3
}

E1 --> V1
E2 --> V1
E3 --> V1
E4 --> V1
E5 --> V1
X1 --> V1
X2 --> V1
X3 --> V1
V1 --> V2
V2 --> V3

note bottom of E2
  Zero Critical is what keeps the remedy an
  iteration rather than an escalation.
end note

note bottom of V3
  No declared scope is cut or deferred to
  fit a schedule (CON-023).
end note
@enduml
```
