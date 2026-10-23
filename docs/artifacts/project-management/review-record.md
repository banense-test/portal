## Document Control
### Reviewer lens
<!-- review: Inception I2 -->

- **Phase:** Inception
- **Status:** Draft — iteration 2, technical lens review complete
- **Milestone Target:** End of Inception (not yet achieved)

### Business Reviewer lens
<!-- review: Inception I2 -->

<!-- review: Inception I2 -->

- **Phase:** Inception
- **Status:** Draft — iteration 2, business modeling lens review complete
- **Milestone Target:** End of Inception (not yet achieved)

### Management Reviewer lens
<!-- review: Inception I2 -->

- **Phase:** Inception
- **Status:** Draft — iteration 2, LCO review held, sanction refused
- **Milestone Target:** End of Inception (not yet achieved)

### Review Coordinator lens
<!-- review: Inception I1 -->

<!-- review: Inception I1 -->

- **Phase:** Inception
- **Status:** Draft — iteration 1, consolidation complete; LCO milestone not achieved
- **Milestone Target:** End of Inception (not yet achieved)

## Review Scope and Criteria
### Reviewer lens
<!-- review: Inception I2 -->

**Review type:** Technical review, LCO lifecycle milestone, Inception iteration 2. Checklist-driven against the artifact type of each item reviewed.

**Scope.** All ten persisted artifacts, plus the trace graph and the SCM state. Nine were evaluated against their checklists; the Iteration Assessment is not judged — it is authored after this review and its absence or lag is never a finding.

| Artifact | Checklist applied | Result |
|---|---|---|
| Vision | Requirements: traceable, testable, unambiguous, no unsourced quantitative claim | Pass |
| Use-Case Model | Requirements: UC well-formed, one per declared process, no cross-cutting mechanism as a UC, rule binding correct, traceability | **Fail** — 1 Major |
| Supplementary Specification | Requirements: every constraint carried and bound, mechanisms not UCs, two closed lists kept apart | **Fail** — 1 Minor |
| Software Architecture Document | Architecture: every subsystem maps to a volatile requirement, constraint conformance, invariants enforceable, traceability one edge per row | **Fail** — 1 Major |
| Risk List | Project Management: declared identifiers and magnitudes preserved, CON-024 respected, every risk treated and traced | Pass |
| Iteration Plan | Project Management: plan derived from the artifact set, risk retirement named against its event, every AC has a gate | Pass |
| Test Evaluation Summary | Test: coverage against use cases, measurement method per NFR, observable SCM state cited as observed | Pass |
| Development Case | DC baseline conformance (§1.2) and optional trigger justification | Pass |
| Iteration Assessment | Not judged — authored after this review | N/A |
| Review Record | This artifact | N/A |

**SCM state.** No open pull request exists, so no PR required a disposition. The build on `main` is green; it carries no product evidence, because the repository holds inputs and artifacts only.

**Trace graph.** 42 business roots, 180 nodes. No `FR-NNN`, `NFR-NNN` or `UC-NNN` is a leaf — every declared requirement is realized and every use case is carried by a component. Four `SUSPECT → System Analyst` edges are reported: `COMP-002 → UC-001`, `UC-002`, `UC-003`, `UC-005`. They are the trace-graph evidence for the Use-Case Model finding below and are recorded there rather than as a separate defect.

**Closure of prior findings.** Seven findings of this lens from iteration 1 were reconciled before any new defect was recorded. All seven are Resolved; none is Deferred or Rejected. The two `Iteration Plan` findings owned by the Management Reviewer lens are not this lens's to close and remain with that lens.

```plantuml
@startsalt
{
  {# Compliance criterion | Vision | UCM | SuppSpec | SAD | RiskList | IterPlan | TES | DevCase }
  { Every element traces to declared input | Pass | Pass | Pass | Pass | Pass | Pass | Pass | Pass }
  { No phantom or invented identifier | Pass | Pass | Pass | Pass | Pass | Pass | Pass | Pass }
  { Cross-cutting mechanism not modelled as a UC | n/a | Pass | Pass | Pass | n/a | n/a | n/a | Pass }
  { Scope markers on derived elements | Pass | Pass | Pass | Pass | Pass | Pass | Pass | Pass }
  { UML present and formally valid | Pass | Pass | Pass | Pass | Pass | Pass | Pass | Pass }
  { Observable SCM state cited as observed | n/a | n/a | n/a | n/a | n/a | n/a | Pass | Pass }
  { Criteria can fail | Pass | n/a | Pass | n/a | n/a | Pass | Pass | Pass }
  { Traceability table one edge per row | n/a | Pass | n/a | Pass | Pass | n/a | n/a | n/a }
  { Internal consistency with upstream | Pass | FAIL | Pass | FAIL | Pass | Pass | Pass | Pass }
  { DC baseline conformance | n/a | n/a | n/a | n/a | n/a | n/a | n/a | Pass }
  { Optional trigger justification | n/a | n/a | n/a | n/a | n/a | n/a | n/a | Pass }
  { No FR, NFR or UC left as a leaf | Pass | Pass | Pass | Pass | Pass | Pass | Pass | Pass }
}
@endsalt
```

**What the two Fail cells have in common.** Both are artifacts that were not re-based onto a decision another artifact changed. The Software Architecture Document chose a new clocking shape in ADR-010 and the Use-Case Model still describes the old one; the Iteration Plan re-based the roadmap onto eight iterations and the Software Architecture Document still names the old iteration numbers. Neither is a defect of the artifact's own reasoning — each is a defect of the artifact's currency, which is the class of defect a milestone review exists to catch before the next phase builds on it.

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
<!-- review: Inception I1 -->

<!-- review: Inception I1 -->

**Review point:** LCO, consolidation. This block holds the coordination of the milestone review — the review process framework, the review calendar, the consolidated finding ledger, the effectiveness metrics and the verdict. It does not re-evaluate the artifacts: the three lenses evaluated them and their findings are the evidence.

**Lens participation in this review:**

| Lens | Participant | Status |
|---|---|---|
| Technical | Reviewer | EXECUTED — 8 of 8 artifacts, 7 findings |
| Business | BusinessReviewer | EXECUTED — 8 of 8 artifacts, 1 finding |
| Management | ManagementReviewer | EXECUTED — 8 of 8 artifacts, 2 findings |

All three lenses executed. No lens is recorded as inactive, and the milestone decision rests on all three.

**Review process framework — seven review types, each bound to the workflow activity that triggers it:**

```plantuml
@startuml
title Review process framework - seven review types and the workflow activity that triggers each

start
:Workflow activity completes;
if (Which activity?) then (Project Approval)
  :Project Approval Review\nscope feasibility against Vision and Risk List\nheld INSIDE the LCO milestone review;
elseif (Project Planning)
  :Project Planning Review\nDevelopment Case tailoring and Iteration Plan roadmap\nheld INSIDE the LCO milestone review;
elseif (Plan for Next Iteration)
  :Iteration Plan Review\nbefore the iteration begins;
elseif (Manage Iteration - mid)
  :PRA Review\nprogress, risk and assessment;
elseif (Manage Iteration - exit criteria)
  :Iteration Evaluation Criteria Review\nverifies exit criteria before closing;
elseif (Manage Iteration - close)
  :Iteration Acceptance Review\nformal acceptance of the iteration deliverables;
elseif (Close-Out Phase)
  :Lifecycle Milestone Review\nLCO, LCA, IOC or PR - sanction to proceed;
else (Project close-out)
  :Project Acceptance Review\nfinal project-level acceptance;
endif
:Entry criteria enforced\nartifacts in target state, reviewers assigned,\nagenda and criteria distributed 48h ahead;
:Review event executed\nfindings recorded with severity, owner, deadline;
:Exit criteria enforced\nall Critical and Major findings owned and dated,\nReview Record signed and archived;
:Finding Tracker updated;
stop

note right
  A PRA Review never substitutes for a
  milestone review. They answer different
  questions: project health versus
  sanction to proceed.
end note
@enduml
```

**Review calendar — Inception iteration 1, review events against the iteration timeline:**

```plantuml
@startuml
title Review calendar - Inception iteration 1, review events against the iteration timeline

|#AntiqueWhite|Iteration 1 - Inception|
start
:Iteration opens;
:Artifacts produced\nDevelopment Case, Vision, Use-Case Model,\nSupplementary Specification, Software Architecture Document,\nRisk List, Iteration Plan, Test Evaluation Summary;

|#LightBlue|Review events|
:Technical lens review\nReviewer - 8 of 8 artifacts;
:Business lens review\nBusinessReviewer - 8 of 8 artifacts;
:Management lens review\nManagementReviewer - 8 of 8 artifacts;
:Consolidation\nReviewCoordinator - one ledger, one verdict;

|#AntiqueWhite|LCO milestone review|
:Project Approval Review\nheld inside LCO - scope feasibility;
:Project Planning Review\nheld inside LCO - DC tailoring and roadmap;
:LCO Lifecycle Milestone Review\nsanction question put to STK-001;
if (Sanction granted?) then (Yes)
  |#PaleGreen|Elaboration|
  :Phase transition sanctioned;
  :Iteration 2 opens\nIteration Plan Review scheduled;
  stop
else (No)
  |#MistyRose|Iteration 2 - Inception|
  :LCO not achieved;
  :Findings corrected by their owners;
  :Re-review of corrected artifacts;
  :LCO gate re-presented;
  stop
endif

note right
  Review events are triggered by artifact
  completion, not by calendar dates. If the
  iteration slips, the review slips with it.
end note
@enduml
```

The Project Approval Review and the Project Planning Review were held inside the LCO milestone review, not as separate events — the Management Reviewer's block records both. The LCO Lifecycle Milestone Review is the Inception exit gate and it was held: the sanction question was put to STK-001 and refused.

**Finding lifecycle — the state machine every finding in this ledger is subject to:**

```plantuml
@startuml
title Finding lifecycle - from record to verified closure

[*] --> Open : record_artifact_finding\nseverity, owner, deadline assigned
Open --> Assigned : owner accepts the finding
Assigned --> InProgress : corrective action started
InProgress --> Resolved : owner confirms the correction
Resolved --> Verified : emitting lens verifies\nthe corrective action is adequate
Verified --> Closed : resolve_artifact_finding\nby the emitting lens only
Resolved --> InProgress : correction inadequate
Open --> Escalated : deadline missed
Assigned --> Escalated : deadline missed
InProgress --> Escalated : deadline missed
Escalated --> InProgress : Project Manager intervenes
Closed --> [*]

note right of Escalated
  Escalation within 1 business day of the
  deadline miss. More than 10% of findings
  overdue means the review process has
  become ceremonial.
end note

note right of Verified
  Only the lens that emitted a finding may
  close it. A Review Record sentence saying
  "resolved" is not a resolution.
end note

note bottom of Open
  A Critical finding always escalates to the
  stakeholder. No auto-iteration while any
  Critical finding is unresolved.
end note
@enduml
```

**Reviewer pool and expertise mapping — who reviews what, by artifact domain:**

| Artifact | Primary lens | Contributing lens | Expertise required |
|---|---|---|---|
| Development Case | Reviewer | ManagementReviewer | Process tailoring, baseline conformance |
| Vision | Reviewer | BusinessReviewer, ManagementReviewer | Requirements traceability, business representation |
| Use-Case Model | Reviewer | BusinessReviewer | Use-case modelling, business-rule binding |
| Supplementary Specification | Reviewer | BusinessReviewer | NFR and constraint coverage, interface contracts |
| Software Architecture Document | Reviewer | BusinessReviewer, ManagementReviewer | Architecture, schema satisfiability, constraint conformance |
| Risk List | Reviewer | ManagementReviewer | Risk governance, identifier preservation |
| Iteration Plan | Reviewer | ManagementReviewer | Planning, risk retirement, acceptance-criterion gating |
| Test Evaluation Summary | Reviewer | ManagementReviewer | Test strategy, coverage executability, SCM evidence |

**Entry and exit criteria applied to this review event:**

| Criterion | Applied |
|---|---|
| Entry — artifacts in target state, not draft | 8 of 8 persisted before any lens reviewed |
| Entry — reviewers assigned with matched expertise | Per the pool table above |
| Entry — evaluation criteria distributed in advance | Each lens states the checklists it applied |
| Exit — every Critical and Major finding has an owner and a deadline | 6 Major, all owned; see Resolutions and Actions |
| Exit — Review Record signed and archived | This block, committed |

**Consolidated finding ledger — three lenses, one ledger:**

```plantuml
@startuml
title Consolidated finding ledger - three lenses, one ledger, Inception iteration 1

package "Lenses that executed" {
  class "Reviewer\nTechnical lens\n7 findings: 4 Major, 3 Minor" as L1
  class "BusinessReviewer\nBusiness lens\n1 finding: 1 Minor" as L2
  class "ManagementReviewer\nManagement lens\n2 findings: 2 Major" as L3
}

package "Consolidated ledger - 10 findings" {
  class "Use-Case Model#F1\nMajor - SystemAnalyst" as F1
  class "Software Architecture Document#F1\nMajor - SoftwareArchitect" as F2
  class "Software Architecture Document#F2\nMinor - SoftwareArchitect" as F3
  class "Iteration Plan#F1 (Reviewer)\nMajor - ProjectManager" as F4
  class "Iteration Plan#F1 (Management)\nMajor - ProjectManager" as F5
  class "Iteration Plan#F2 (Management)\nMajor - ProjectManager" as F6
  class "Test Evaluation Summary#F1\nMajor - TestManager" as F7
  class "Test Evaluation Summary#F2\nMinor - TestManager" as F8
  class "Vision#F1 (Reviewer)\nMinor - SystemAnalyst" as F9
  class "Vision#F1 (Business)\nMinor - SystemAnalyst" as F10
}

package "Artifacts with no finding" {
  class "Development Case" as OK1
  class "Supplementary Specification" as OK2
  class "Risk List" as OK3
}

L1 --> F1
L1 --> F2
L1 --> F3
L1 --> F4
L1 --> F7
L1 --> F8
L1 --> F9
L2 --> F10
L3 --> F5
L3 --> F6

note bottom of F1
  CONFLICT RESOLVED: the Business Reviewer
  confirmed this defect but did not re-record
  it. One logical defect, one ledger entry.
  No duplicate to triage.
end note

note bottom of F4
  CONFLICT RESOLVED: three findings sit on
  the Iteration Plan from two lenses. They are
  distinct defects - fine-plan completeness,
  risk-retirement claim, AC-004 gate - and are
  consolidated into one owner's action list,
  not merged into one finding.
end note

note bottom of F9
  CONFLICT RESOLVED: the Management Reviewer's
  distribution diagram states 3 Minor but
  enumerates 4. The finding ledger holds 4.
  The ledger is authoritative; the diagram
  undercounted.
end note

note bottom of OK1
  Development Case, Supplementary Specification
  and Risk List carry zero findings across all
  three lenses.
end note
@enduml
```

**Cross-lens conflicts and their resolution:**

| Conflict | Resolution |
|---|---|
| The Business Reviewer confirmed `Use-Case Model#F1` but did not re-record it | Correct handling. One logical defect, one ledger entry. The Business Reviewer's confirmation is recorded in its block; the finding stays owned by the Reviewer lens, which is the only lens that may close it. |
| Three findings sit on the Iteration Plan from two lenses (`#F1` Reviewer, `#F1` and `#F2` Management) | Not merged. They are three distinct defects — fine-plan completeness, the R001 retirement claim, and the AC-004 gate. They are consolidated into one owner's action list so the ProjectManager triages one list, not three. |
| The Management Reviewer's defect-distribution diagram states "6 Major, 3 Minor" but enumerates four Minor entries | The finding ledger holds 4 Minor. The ledger is authoritative; the diagram undercounted by one. The consolidated total is 6 Major, 4 Minor, 0 Critical. |
| The Reviewer lens reports 4 Major / 3 Minor; the Business lens 0 Major / 1 Minor; the Management lens 2 Major / 0 Minor | Sums to 6 Major / 4 Minor / 0 Critical, matching the ledger exactly. No lens overstates or understates its own count. |

**Review effectiveness — current metrics only.** This is the first review event of the project. No prior iteration or cycle exists, so no trend is computed and none is implied; trend analysis begins at the second review event.

```plantuml
@startuml
title Review effectiveness - current metrics only, Inception iteration 1 (first review event, no prior data)

package "Coverage" {
  class "Planned artifacts: 8" as C1
  class "Formally reviewed: 8" as C2
  class "Review coverage: 100%" as C3 <<Measured>>
  class "Lenses executed: 3 of 3" as C4 <<Measured>>
}

package "Defect density" {
  class "Findings recorded: 10" as D1
  class "Artifacts carrying a finding: 5 of 8" as D2
  class "Density: 1.25 findings per artifact" as D3 <<Measured>>
  class "Major: 6, Minor: 4, Critical: 0" as D4 <<Measured>>
}

package "Defect removal efficiency" {
  class "Defects found in review: 10" as E1
  class "Defects found in test: 0" as E2
  class "DRE: not computable" as E3 <<NotMeasurable>>
}

package "Rework effort" {
  class "Findings requiring rework: 10" as R1
  class "Effort in hours: not measured" as R2 <<NotMeasurable>>
}

C1 --> C3
C2 --> C3
D1 --> D3
D2 --> D3
E1 --> E3
E2 --> E3
R1 --> R2

note bottom of E3
  No test has been executed in Inception, so
  there is no test-found defect count to divide
  by. DRE is not zero and not 100% - it is
  undefined at this gate. It becomes computable
  in the first iteration that executes tests.
end note

note bottom of R2
  Effort is measured in tokens and elapsed time,
  neither of which is recorded per finding. No
  hour figure is invented to fill the cell.
end note

note bottom of D3
  First review event of the project. No prior
  iteration or cycle exists, so no trend is
  computed and none is implied. Trend analysis
  begins at the second review event.
end note
@enduml
```

**Interpretation of the metrics.** Coverage is complete — every planned artifact was reviewed by all three lenses, so no artifact reached the milestone gate unreviewed. Defect density of 1.25 findings per artifact is concentrated: five artifacts carry all ten findings, and three carry none. The concentration is informative rather than alarming — the three clean artifacts (Development Case, Supplementary Specification, Risk List) are the ones whose content is largely inherited from declared inputs, while the five carrying findings are the ones where the team made design and planning decisions. The two artifacts with the highest-value defects are the Software Architecture Document and the Iteration Plan, which is where an LCO gate should be looking. Defect removal efficiency and rework effort are not measurable at this gate and no figure is invented for either.

## Findings
### Reviewer lens
<!-- review: Inception I2 -->

Three findings this milestone: 0 Critical, 2 Major, 1 Minor. Each is recorded in the finding ledger against its artifact; this entry states the defect, its location and its remediation.

#### Use-Case Model

**`Use-Case Model#F2` — Major.** The UC-001 postcondition still describes the single-row clocking model that ADR-010 replaced. It states that exactly one clocking record exists for the employee for today. Under ADR-010 a complete pair is two append-only rows — one ClockIn and one ClockOut — and an HR correction adds a third; the effective pair is a query over supersession, not a record. The postcondition is false after the second press.

The trace graph reports the same defect independently: the `COMP-002` Realizes edges to UC-001, UC-002, UC-003 and UC-005 are marked `SUSPECT → System Analyst`. The changed end is COMP-002, whose responsibility ADR-010 redefined, and it has not been reviewed against the use cases it realizes.

*Remediation.* Restate the postcondition in ADR-010's terms: after a Clock In press one ClockIn event row exists for the employee-day; after a Clock Out press a ClockOut event row exists for the same `WorkDate`; the effective pair is the two rows no other row supersedes. Confirm UC-002, UC-003 and UC-005 read the same shape — UC-005's outline already says a new audited record with the original never overwritten, which is consistent, so state it explicitly. Then clear the four suspect traces by declaring the Use-Case Model reviewed against ADR-010.

#### Software Architecture Document

**`Software Architecture Document#F3` — Major.** The architectural-significance table has not been re-based onto the eight-iteration roadmap. It assigns the four architecturally significant use cases to "Elaboration iteration 2" and the remaining six ranks to "Elaboration iteration 3". Under the current roadmap iteration 2 is this Inception correction iteration and Elaboration is iterations 3 and 4, so "Elaboration iteration 2" names an iteration that designs nothing. The Iteration Plan places the design of UC-001, UC-004, UC-009 and UC-011 in iteration 3, so the two artifacts disagree about when the architecture is designed. The Test Evaluation Summary performed this re-base for its coverage plan; the Software Architecture Document is the one artifact that did not receive it.

*Remediation.* Re-base the "Design in" column: ranks 1 to 4 to Elaboration iteration 3, ranks 5 to 10 to Elaboration iteration 4, matching the Iteration Plan's roadmap and its use-case table. Check the rest of the document for the same stale numbering in the same pass.

#### Supplementary Specification

**`Supplementary Specification#F1` — Minor.** The constraint grouping is internally inconsistent and does not match the declared categories. The "Environmental constraints" table lists CON-005 and CON-031, both declared Technical in the scope. The constraint map diagram disagrees with the table on CON-005 — the diagram places it in "Platform and technology" while the table places it in "Environmental" — and places CON-031 in its "Environment" package. A reader cannot tell whether the grouping is the declared category or the team's own, and the two representations of the same 36 constraints do not agree.

*Remediation.* Either group by the declared category, moving CON-005 and CON-031 to the platform/technical group in both the table and the diagram, or retitle the tables so they state they group by what each constraint decides rather than by its declared category, and make the diagram use the same grouping. Either resolution is acceptable; the defect is that the table and the diagram disagree and neither matches the declared category.

```plantuml
@startuml
title Portal - Inception iteration 2 defect distribution: severity by artifact

package "Major - 2 findings" {
  class "Use-Case Model\n1 Major\nUC-001 postcondition vs ADR-010" as M1
  class "Software Architecture Document\n1 Major\nsignificance table not re-based" as M2
}

package "Minor - 1 finding" {
  class "Supplementary Specification\n1 Minor\nconstraint grouping inconsistent" as N1
}

package "Clean this pass - 0 findings" {
  class "Vision" as C1
  class "Risk List" as C2
  class "Iteration Plan" as C3
  class "Test Evaluation Summary" as C4
  class "Development Case" as C5
}

package "Not judged this pass" {
  class "Iteration Assessment\nauthored after this review" as X1
}

package "Closed this pass - 7 prior findings" {
  class "Vision#F1" as R1
  class "Use-Case Model#F1" as R2
  class "Iteration Plan#F1 (Reviewer)" as R3
  class "Software Architecture Document#F1" as R4
  class "Software Architecture Document#F2" as R5
  class "Test Evaluation Summary#F1" as R6
  class "Test Evaluation Summary#F2" as R7
}

note bottom of M1
  Both Major findings are the same class of
  defect: an artifact that was not re-based
  onto a decision another artifact changed.
end note
@enduml
```

```plantuml
@startuml
title Portal - Inception iteration 2: where the two Major findings sit

package "Use-Case Model - SystemAnalyst" {
  class "UC-001 Clock In and Clock Out" as UC001
  class "UC-002, UC-003, UC-005" as UCREST
}

package "Software Architecture Document - SoftwareArchitect" {
  class "ADR-010 append-only clocking event log" as ADR010
  class "Architectural significance table" as SIG
}

package "Iteration Plan - ProjectManager" {
  class "Eight-iteration roadmap" as ROAD
}

note right of UC001
  FINDING Major
  Postcondition says "exactly one
  clocking record". Under ADR-010 a
  complete pair is two rows and a
  correction is a third.
end note

note right of UCREST
  Suspect traces COMP-002 -> UC-001,
  UC-002, UC-003, UC-005: the changed
  component has not been reviewed
  against the use cases it realizes.
end note

note right of SIG
  FINDING Major
  "Design in: Elaboration iteration 2"
  and "Elaboration iteration 3".
  The roadmap has Elaboration at
  iterations 3 and 4.
end note

UC001 ..> ADR010 : contradicts
UCREST ..> ADR010 : not yet reviewed against
SIG ..> ROAD : not re-based onto
@enduml
```

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

**Three of the four open Major findings sit in one artifact.** The Use-Case Model carries the concentration, and two of its three are the same defect class: a rule or a decision another artifact changed, not carried through to the use case that must enforce it. That is the pattern the Development Case's new authoring checks are written to catch, which is why the Development Case revision is not a cosmetic change and why its absence from the fine plan is a Major finding rather than a Minor one.

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
<!-- review: Inception I1 -->

<!-- review: Inception I1 -->

**Consolidated ledger: 10 findings — 0 Critical, 6 Major, 4 Minor.** Every entry below is copied from `read_artifact_findings` for the artifact named. The coordinator does not re-evaluate the artifacts; the defect statements are the lenses' and are cited by key.

| # | Key | Artifact | Severity | Emitting lens | Owner | Defect |
|---|---|---|---|---|---|---|
| 1 | `Use-Case Model#F1` | Use-Case Model | Major | Reviewer | SystemAnalyst | The worker-category rule cluster (CON-009, CON-015, CON-016, CON-021) is bound to UC-010 Read and Filter News, and CON-015 is listed among UC-010's rules. CON-015 states the worker category is used in exactly two places — a directory column that also filters, and a CSV export column. UC-010 filters news by the four news categories, a different closed list governed by FR-010 and FR-006. |
| 2 | `Software Architecture Document#F1` | Software Architecture Document | Major | Reviewer | SoftwareArchitect | The Data View schema cannot satisfy CON-012 and CON-013 at the same time. `Clocking` holds ClockInUtc and ClockOutUtc in one row, so recording a Clock Out is an in-place UPDATE that CON-013 forbids; the Invariants table resolves CON-013 with "a correction is a new row" but enforces CON-012 with a unique index on (EmployeeId, WorkDate), which rejects that row. The correction record carries no previous-value column, which CON-013 and NFR-005 require. |
| 3 | `Iteration Plan#F1` (Reviewer) | Iteration Plan | Major | Reviewer | ProjectManager | The fine plan omits two artifacts this iteration produced. W1–W7 cover seven artifacts but not the Software Architecture Document or the Test Evaluation Summary, both persisted and both CORE. The critical chain has no Analysis and Design or Test lane, and the role profile marks SoftwareArchitect and TestManager inactive in iteration 1, contradicting the existence of both artifacts. |
| 4 | `Iteration Plan#F1` (Management Reviewer) | Iteration Plan | Major | ManagementReviewer | ProjectManager | The plan asserts R001 is retired in Elaboration iteration 2 by the stand-in directory carrying empty job-title and extension entries. Building the fixture is not retiring the risk: the SAD's own retirement criterion is a passing directory search and export against that fixture, and the Test Evaluation Summary executes UC-011 in iteration 6 and UC-004 in iteration 4 with no test role active in iteration 2. The highest-magnitude risk (exposure 9) is not retired until Construction. |
| 5 | `Iteration Plan#F2` (Management Reviewer) | Iteration Plan | Major | ManagementReviewer | ProjectManager | AC-004 is assigned verification in iteration 7, the iteration in which its own measure begins to elapse, so the criterion can never be verified at the gate it is assigned to. AC-004 is a population measure over 200 employees; the three-month adoption window (BG-003) that begins in iteration 7 cannot have produced its result by the end of iteration 7. One of five declared acceptance criteria has no gate at which it can close. |
| 6 | `Test Evaluation Summary#F1` | Test Evaluation Summary | Major | Reviewer | TestManager | The quality-signal table cites CI run `39932821851` (09:34:14Z to 09:35:04Z); the build observed on `main` is run `39933356092` (09:38:42Z to 09:39:34Z). A run identifier and two timestamps are observable SCM state, so a stale citation reads downstream as a verified observation. The conclusion holds; the citation does not. |
| 7 | `Software Architecture Document#F2` | Software Architecture Document | Minor | Reviewer | SoftwareArchitect | The Traceability table conflates two link types in one row: rows for COMP-001 to COMP-007 declare Realizes in the Link Type column while the Traces To column holds DependsOn targets. A reader cannot tell which link type the Traces To entries carry. |
| 8 | `Test Evaluation Summary#F2` | Test Evaluation Summary | Minor | Reviewer | TestManager | NFR-001 is assigned to Iteration 3, which the Iteration Plan scopes as Elaboration design only with no implementation. The stated method — every use case exercised unauthenticated and refused — cannot be executed against use cases that are designed but not built. |
| 9 | `Vision#F1` (Reviewer) | Vision | Minor | Reviewer | SystemAnalyst | The success-criteria table presents BG-001 as measurable — "50% reduction against the current manual baseline" — but no baseline is declared in the scope and none has been measured. The denominator is an inference the Vision adds; BG-001 names no baseline. The criterion cannot be verified as written. |
| 10 | `Vision#F1` (Business Reviewer) | Vision | Minor | BusinessReviewer | SystemAnalyst | In the Features tables the success-criterion column is self-referential for two features: the FR-014 row cites "FR-014" and the FR-015 row cites "FR-015" as their own success criterion. Every other row cites an independent measure. A criterion that restates the requirement identifier cannot be tested. |

**Artifacts carrying no finding across all three lenses:** Development Case, Supplementary Specification, Risk List.

**Defect distribution by artifact and owner:**

```plantuml
@startuml
title Consolidated defect distribution - by artifact and by owner, Inception iteration 1

package "By artifact" {
  class "Iteration Plan\n3 Major" as A1
  class "Software Architecture Document\n1 Major, 1 Minor" as A2
  class "Test Evaluation Summary\n1 Major, 1 Minor" as A3
  class "Vision\n2 Minor" as A4
  class "Use-Case Model\n1 Major" as A5
  class "Development Case\n0" as A6
  class "Supplementary Specification\n0" as A7
  class "Risk List\n0" as A8
}

package "By owner" {
  class "ProjectManager\n3 Major" as O1
  class "SoftwareArchitect\n1 Major, 1 Minor" as O2
  class "TestManager\n1 Major, 1 Minor" as O3
  class "SystemAnalyst\n1 Major, 2 Minor" as O4
}

A1 --> O1
A2 --> O2
A3 --> O3
A4 --> O4
A5 --> O4

note bottom of O1
  The Iteration Plan carries the most
  findings and the only three-Major
  concentration. It is the artifact that
  decides whether the LCO gate can be
  re-presented.
end note

note bottom of A6
  Three artifacts clean across all three
  lenses. Their content is largely inherited
  from declared inputs; the five carrying
  findings are where the team made design
  and planning decisions.
end note
@enduml
```

**Severity distribution and the gate consequence:**

```plantuml
@startuml
title Severity distribution and gate consequence - Inception iteration 1

package "Critical - 0" {
  class "None recorded" as C0
}

package "Major - 6" {
  class "Blocks the LCO gate" as M0
  class "Use-Case Model#F1" as M1
  class "Software Architecture Document#F1" as M2
  class "Iteration Plan#F1 (Reviewer)" as M3
  class "Iteration Plan#F1 (Management)" as M4
  class "Iteration Plan#F2 (Management)" as M5
  class "Test Evaluation Summary#F1" as M6
}

package "Minor - 4" {
  class "Does not block the gate;\ncorrected or deferred with a reason" as N0
  class "Software Architecture Document#F2" as N1
  class "Test Evaluation Summary#F2" as N2
  class "Vision#F1 (Reviewer)" as N3
  class "Vision#F1 (Business)" as N4
}

M1 --> M0
M2 --> M0
M3 --> M0
M4 --> M0
M5 --> M0
M6 --> M0
N1 --> N0
N2 --> N0
N3 --> N0
N4 --> N0

note bottom of C0
  No Critical finding: no declared exclusion
  is crossed, no phantom use case, no invented
  identifier, no scope expansion beyond the
  fifteen declared requirements, and no
  artifact claims a milestone or an acceptance
  criterion is closed.
end note

note bottom of M0
  Six open Major findings. The stakeholder
  refused the LCO sanction and required every
  finding corrected. The gate cannot be
  re-presented until all six are closed and
  re-verified by their emitting lenses.
end note
@enduml
```

**Findings the coordinator raises on the review process itself.** These are process observations, not artifact defects, and they are not in the ledger above because the ledger holds artifact findings only.

| Observation | Consequence |
|---|---|
| The Management Reviewer's defect-distribution diagram states "6 Major, 3 Minor" while enumerating four Minor entries | A counting error in a review artifact. The ledger holds 4 Minor and the consolidated total uses the ledger. No artifact finding is raised — the diagram is inside the Review Record, which is this record, and the correction is made here. |
| The Business Reviewer confirmed `Use-Case Model#F1` without re-recording it | Correct process. One logical defect, one ledger entry, one owner. Duplicating it would have made the SystemAnalyst triage the same defect twice. |
| All three lenses reviewed all 8 artifacts | Coverage is complete. No artifact reached the gate unreviewed, and no lens reviewed a subset. |
| No lens closed a finding belonging to another lens | The ownership invariant held. No cross-lens closure was attempted. |

## Resolutions and Actions
### Reviewer lens
<!-- review: Inception I2 -->

**Prior findings of this lens, reconciled this iteration.** Seven were open at the start of iteration 2. Each was verified against the corrected artifact content and closed through `resolve_artifact_finding`. None is Deferred, none is Rejected, none is left open.

| Finding | Severity | Verified against | Resolution |
|---|---|---|---|
| `Vision#F1` | Minor | Success-criteria table — BG-001 row now reads "Not yet measurable", names STK-001 as the baseline source, and records the 50% reduction as a post-launch comparison | Resolved |
| `Use-Case Model#F1` | Major | Business-rule binding diagram — `R_CAT` binds UC-004 and UC-012 only; `R_NCAT` carries the news-category list to UC-006 and UC-010; UC-010's rules cell no longer cites CON-015 | Resolved |
| `Iteration Plan#F1` | Major | Fine plan W1–W9 includes W5 Software Architecture Document and W6 Test Evaluation Summary with exit conditions; critical chain carries Analysis and Design and Test lanes; both roles Active in the iteration 1 column | Resolved |
| `Software Architecture Document#F1` | Major | ADR-010 — append-only `ClockingEvent`, partial unique index on `(EmployeeId, WorkDate, EventKind)` where `SupersedesId IS NULL`, `PreviousValueUtc` column, Invariants table names the enforcing index per row | Resolved |
| `Software Architecture Document#F2` | Minor | Traceability table — one row per link type, `Traces To` empty on every Realizes and Derives row, separate DependsOn rows | Resolved |
| `Test Evaluation Summary#F1` | Minor | Quality-signals table — cites run `39940062277`, started 2026-10-23 10:34:26Z, completed 10:35:16Z, with the caveat retained | Resolved |
| `Test Evaluation Summary#F2` | Minor | Quality-attribute plan — NFR-001 split into NFR-001a (claim mapping, iteration 3) and NFR-001b (refusal assertion, iterations 5, 6, 7) | Resolved |

**Not this lens's to close.** `Iteration Plan#F1` and `Iteration Plan#F2` as recorded by the Management Reviewer remain with that lens. The actor handler rejects cross-lens closure, correctly: a lens that did not emit a finding cannot certify its correction.

**Open actions this milestone.** Three, all assigned, none deferred.

| Action | Owner | Closes | Exit condition |
|---|---|---|---|
| Restate the UC-001 postcondition in ADR-010's append-only terms; confirm UC-002, UC-003 and UC-005 read the same shape; clear the four `COMP-002` suspect traces | SystemAnalyst | `Use-Case Model#F2` | The postcondition describes two event rows and a supersession query, not one record; no `SUSPECT → System Analyst` edge remains on COMP-002 |
| Re-base the architectural-significance "Design in" column onto the eight-iteration roadmap | SoftwareArchitect | `Software Architecture Document#F3` | Ranks 1–4 read Elaboration iteration 3 and ranks 5–10 read Elaboration iteration 4, matching the Iteration Plan |
| Make the constraint grouping consistent between the table and the diagram, and state whether it follows the declared category | RequirementsSpecifier | `Supplementary Specification#F1` | The table and the diagram group the same 36 constraints the same way, and the grouping's basis is stated |

**What the corrections established.** The seven closures are not cosmetic. ADR-010 is the substantive one: it resolves a contradiction that would have surfaced as an unimplementable schema the moment Elaboration tried to baseline it, and it does so by making CON-013 hold by construction rather than by convention. The Iteration Plan's risk-retirement table now names the event that retires R001 rather than the fixture that makes it retirable, which is the claim an LCO gate exists to test. The Vision's BG-001 row now records an unmeasured criterion as unmeasured instead of presenting it as measurable.

**What the corrections did not establish.** A correction is not a closure, and a closure is not a pass. The two Major findings recorded this milestone are both consequences of the corrections themselves — ADR-010 changed the clocking shape and the Use-Case Model did not follow; the roadmap changed and the Software Architecture Document did not follow. That is the normal cost of a correction iteration and it is why the gate is re-presented rather than assumed.

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
<!-- review: Inception I1 -->

<!-- review: Inception I1 -->

**Prior findings reconciled:** none. This is the first review event of the project. `read_artifact_findings` returned an empty list for the Development Case, the Supplementary Specification and the Risk List, and returned only open findings — no resolution object — for the other five artifacts. No finding existed to close, so no closure was due from this lens.

**Stakeholder input already obtained — not re-asked.** The Management Reviewer put the LCO sanction question to STK-001 with the verdict leaning and all six open Major defects inside it. The answer was "No", with the instruction that every finding must be corrected. That answer is the stakeholder's input for the next pass and it is folded in below as the stakeholder finding. It is not put back to the stakeholder as a fresh question: the question has been asked and answered, and re-asking it would re-open a decision already made.

**Stakeholder finding:** every finding in this ledger is to be corrected. No finding is deferred, and no declared scope is cut or deferred to fit a schedule — CON-023 forbids it and the remedy for a milestone that does not pass is another iteration.

**Consolidated action list — prioritized by gate impact, one list per owner:**

| Priority | Action | Finding | Artifact | Owner | Closes at |
|---|---|---|---|---|---|
| 1 | Resolve the CON-012 / CON-013 schema contradiction: state how a pair is recorded across two presses under CON-013, make the unique index match the chosen shape, add a PreviousValue column to the correction record, and make each Invariants row name the index that enforces it | `Software Architecture Document#F1` | Software Architecture Document | SoftwareArchitect | LCO gate re-presentation |
| 2 | Restate the R001 retirement claim to match the evidence chain — either move the UC-011 and UC-004 test executions earlier or state plainly that R001 stays open until Construction and record what that means for the LCA gate | `Iteration Plan#F1` (Management Reviewer) | Iteration Plan | ProjectManager | LCO gate re-presentation |
| 3 | Split AC-004 into its learnability check (testable in the iteration that implements UC-001) and its post-launch population measure (BG-003 window, HR as owner), and assign each to a point where it can close | `Iteration Plan#F2` (Management Reviewer) | Iteration Plan | ProjectManager | LCO gate re-presentation |
| 4 | Add the Software Architecture Document and the Test Evaluation Summary to the fine plan with exit conditions, place them in the critical chain, and mark SoftwareArchitect and TestManager active in iteration 1 | `Iteration Plan#F1` (Reviewer) | Iteration Plan | ProjectManager | LCO gate re-presentation |
| 5 | Rebind the worker-category rule cluster away from UC-010 and bind the news-category closed list to UC-010 instead, sourced from FR-010 and FR-006 | `Use-Case Model#F1` | Use-Case Model | SystemAnalyst | LCO gate re-presentation |
| 6 | Replace the cited CI run with the observed build, or state the build status without a run identifier | `Test Evaluation Summary#F1` | Test Evaluation Summary | TestManager | LCO gate re-presentation |
| 7 | Split the conflated Traceability rows by link type — one row for Realizes with Traces To empty, one for DependsOn | `Software Architecture Document#F2` | Software Architecture Document | SoftwareArchitect | LCO gate re-presentation |
| 8 | Make NFR-001's execution iteration match where the behaviour exists, or split the row into an Elaboration claim-mapping check and a Construction refusal assertion | `Test Evaluation Summary#F2` | Test Evaluation Summary | TestManager | LCO gate re-presentation |
| 9 | Mark the BG-001 row as not yet measurable and record that HR must supply the current manual baseline, or state the measure as a post-launch comparison HR performs | `Vision#F1` (Reviewer) | Vision | SystemAnalyst | LCO gate re-presentation |
| 10 | Replace the self-referential success criteria on the FR-014 and FR-015 feature rows with an independent measure | `Vision#F1` (Business Reviewer) | Vision | SystemAnalyst | LCO gate re-presentation |

**Prioritization rationale.** Priority 1 is the only finding that would cost a re-baseline if carried forward: Elaboration would baseline a schema that cannot satisfy two declared invariants, and the defect surfaces as an unimplementable design rather than as a document error. Priorities 2 and 3 are the two findings that decide the milestone: they are the plan's own claims about risk retirement and acceptance-criterion gating, and a plan that answers "Yes" to a risk-retirement question on the strength of a fixture is the exact claim an LCO gate exists to refuse. Priority 4 is a completeness defect in the same artifact and is corrected in the same pass. Priorities 5 and 6 are Major but local — each is a single correction inside one artifact with no propagation beyond it. Priorities 7 to 10 are Minor: they do not block the gate, but the stakeholder required every finding corrected, so none is deferred.

**Action ownership and load:**

```plantuml
@startuml
title Consolidated action list - owner, load and gate impact, Inception iteration 1

package "ProjectManager - 3 Major" {
  class "P2 R001 retirement claim\nIteration Plan#F1 (Management)" as P2
  class "P3 AC-004 two-part gate\nIteration Plan#F2 (Management)" as P3
  class "P4 Fine plan completeness\nIteration Plan#F1 (Reviewer)" as P4
}

package "SoftwareArchitect - 1 Major, 1 Minor" {
  class "P1 CON-012 / CON-013 schema\nSoftware Architecture Document#F1" as P1
  class "P7 Traceability row split\nSoftware Architecture Document#F2" as P7
}

package "SystemAnalyst - 1 Major, 2 Minor" {
  class "P5 Worker-category rebinding\nUse-Case Model#F1" as P5
  class "P9 BG-001 baseline\nVision#F1 (Reviewer)" as P9
  class "P10 FR-014 / FR-015 criteria\nVision#F1 (Business)" as P10
}

package "TestManager - 1 Major, 1 Minor" {
  class "P6 CI run citation\nTest Evaluation Summary#F1" as P6
  class "P8 NFR-001 iteration\nTest Evaluation Summary#F2" as P8
}

class "Gate: LCO re-presentation\nall 10 closed and re-verified" as G

P1 --> G
P2 --> G
P3 --> G
P4 --> G
P5 --> G
P6 --> G
P7 --> G
P8 --> G
P9 --> G
P10 --> G

note bottom of G
  Closure is by the emitting lens only, via
  resolve_artifact_finding. A Review Record
  sentence saying "resolved" is not a
  resolution and does not clear the gate.
end note

note bottom of P2
  The ProjectManager carries the heaviest
  load: three Major findings on one artifact.
  They are distinct defects and are corrected
  in one pass over the Iteration Plan.
end note
@enduml
```

**Closure protocol for this action list.** Each action closes only when the emitting lens calls `resolve_artifact_finding` after verifying the corrective action is adequate. The coordinator does not close findings and does not accept a narrative claim of resolution in place of the tool call. The six Major findings must all be closed before the LCO gate is re-presented; the four Minor findings must be closed or explicitly deferred with a reason, and the stakeholder's instruction is that they be corrected.

**Escalation status.** No finding has missed a deadline, because no deadline has yet elapsed — the action list was issued at this review event. No escalation notice is due. No Critical finding exists, so no Critical escalation to the stakeholder is required. The stakeholder was nevertheless consulted, because the LCO sanction is theirs to give and it was refused.

**Review debt position at this gate:** 10 open findings, 0 overdue, 0 escalated. The 0% overdue rate is not a sign of health — it is the reading of a ledger issued moments ago. It becomes meaningful at the next review event, when the first deadlines have had a chance to elapse.

## Disposition
### Reviewer lens
<!-- review: Inception I2 -->

**Disposition: Approved with Changes.**

The technical position of the artifact set is materially stronger than at iteration 1. Seven findings of this lens were corrected and verified, and the corrections are substantive rather than cosmetic. ADR-010 resolves the schema contradiction that would have made CON-012 and CON-013 unsatisfiable together, and it does so by making CON-013 hold by construction — an append-only event log with a partial unique index that constrains the originals and admits every superseding row. The Iteration Plan now names the event that retires R001 rather than the fixture that makes it retirable, which is the claim an LCO gate exists to test. The Vision records BG-001 as unmeasured instead of presenting it as measurable. The Test Evaluation Summary's coverage plan is re-based onto the roadmap it is measured against, and NFR-001 is split so neither half is assigned to an iteration that cannot execute it.

Two Major findings remain, and both are defects of currency rather than of reasoning. The Use-Case Model's UC-001 postcondition still describes the single-row clocking model ADR-010 replaced, and the trace graph reports the same defect independently through four `SUSPECT → System Analyst` edges on COMP-002. The Software Architecture Document's architectural-significance table still names "Elaboration iteration 2", an iteration that under the current roadmap designs nothing. Neither invalidates the phase's conclusions; both would mislead the role that reads them next, which is why they are Major and not Minor.

One Minor finding: the Supplementary Specification's constraint grouping disagrees between its table and its diagram and matches neither the declared category.

**No Critical finding.** No declared exclusion is crossed anywhere in the set. No identifier is invented — every `FR-`, `NFR-`, `CON-`, `AC-`, `BG-`, `STK-` and `R` identifier cited is one the work order assigned. No scope is expanded beyond the fifteen declared requirements: the fifteen use cases map one to one onto them, and the three extension use cases are declared requirements modelled as exception paths rather than invented goals. No cross-cutting mechanism is promoted to a use case — authentication, authorization, audit and directory read are mechanisms in the Supplementary Specification, included by the use cases that depend on them. No artifact claims a milestone is achieved or an acceptance criterion is closed.

**What this disposition is not.** It is not a sanction to advance. The milestone verdict belongs to the ReviewCoordinator and the sanction to the stakeholder; this lens reports the technical state of the artifacts and nothing more. It is also not a claim that the two Major findings are tolerable — they are correctable within this iteration and they should be corrected before the gate is re-presented, because the role that reads each of them next is the role that would act on the stale version.

**Traceability position.** The trace graph carries 42 business roots and 180 nodes. No `FR-NNN`, `NFR-NNN` or `UC-NNN` is a leaf: every declared requirement is realized by a use case and every use case is carried by at least one component. The four `SUSPECT → System Analyst` edges are the only trace defect and are recorded as evidence inside `Use-Case Model#F2` rather than as a separate finding, because they and the postcondition are one defect seen from two directions.

**SCM position.** No open pull request, so no PR required a disposition. The build on `main` is green and carries no product evidence — the repository holds inputs and artifacts only, and a green build on such a repository proves the pipeline runs, not that anything works.

```plantuml
@startuml
title Portal - Inception iteration 2 technical position at the LCO gate

package "Closed this iteration - 7 findings of this lens" {
  class "Vision#F1\nBG-001 recorded as unmeasured" as C1
  class "Use-Case Model#F1\nworker-category cluster rebound" as C2
  class "Iteration Plan#F1\nfine plan complete, roles Active" as C3
  class "SAD#F1\nADR-010 append-only clocking log" as C4
  class "SAD#F2\ntraceability rows split by link type" as C5
  class "TES#F1\nCI run cited as observed" as C6
  class "TES#F2\nNFR-001 split by executable half" as C7
}

package "Open this iteration - 2 Major, 1 Minor" {
  class "Use-Case Model#F2\nUC-001 postcondition vs ADR-010\n+ 4 suspect traces" as O1
  class "SAD#F3\nsignificance table not re-based" as O2
  class "SuppSpec#F1\nconstraint grouping inconsistent" as O3
}

package "Gate position" {
  class "0 Critical" as G1
  class "2 Major" as G2
  class "1 Minor" as G3
  class "No exclusion crossed\nNo identifier invented\nNo scope expanded" as G4
}

C1 --> G1
C2 --> G1
C3 --> G1
C4 --> G1
C5 --> G1
C6 --> G1
C7 --> G1
O1 --> G2
O2 --> G2
O3 --> G3

note bottom of G2
  Both Major findings are artifacts not
  re-based onto a decision another artifact
  changed. Neither invalidates the phase's
  conclusions; both would mislead the role
  that reads them next.
end note

note bottom of G4
  The three conditions that would make a
  finding Critical are all absent from
  the set.
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
