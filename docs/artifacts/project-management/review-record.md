## Document Control
- **Phase:** Inception
- **Status:** Draft — LCO technical review, iteration 1
- **Milestone Target:** Lifecycle Objectives (LCO) — end of Inception. NOT YET ACHIEVED.

### Business Reviewer lens

- **Phase:** Inception
- **Status:** Draft — LCO business review, iteration 1
- **Milestone Target:** Lifecycle Objectives (LCO) — end of Inception. NOT YET ACHIEVED.

### Management Reviewer lens

- **Phase:** Inception
- **Status:** LCO milestone review — verdict recorded, iteration 1
- **Milestone Target:** Lifecycle Objectives (LCO) — end of Inception. NOT YET ACHIEVED.

## Review Scope and Criteria
### Reviewer lens

**Review type.** Technical review (peer-led, checklist-driven, findings documented). Not a formal Fagan inspection: no reader paraphrase step and no separate recorder role.

**Review point.** Lifecycle milestone — LCO. The evaluative lens is **exit criteria**, not completion: do the artifacts collectively satisfy the conditions for phase transition? No completion lens is applied, because Inception produces a baseline and not a running system.

**Artifacts reviewed (8 of 8).** Development Case, Vision, Use-Case Model, Supplementary Specification, Risk List, Iteration Plan, Software Architecture Document, Test Evaluation Summary.

**Upstream consumption.** Every artifact was read in full before any finding was recorded. The traceability tree was projected from the Business level (47 roots, 150 nodes) and used as the completeness instrument, never the artifacts' own prose.

**Checklists applied, per artifact type.**

| Artifact | Checklist applied |
|---|---|
| Development Case | DC Baseline Conformance (§1.2) against the IARI baseline in force; Optional Trigger Justification against each §5.2 condition; intensity against the canonical matrix |
| Vision | Scope adherence against the declared scope; stakeholder coverage; unsourced-figure check; UML presence; trace endpoints |
| Use-Case Model | One UC per declared FR; `Source: FR-NNN` per use case; no cross-cutting mechanism as a UC; multi-actor process as one UC; UML presence |
| Supplementary Specification | NFR coverage; business rules as rules; cross-cutting mechanisms as entries with `<<include>>`; no invented identifier in the trace graph |
| Risk List | Declared risks preserved with identifier and magnitude; team risks numbered per CON-020; acceptance citing CON-021; mitigation and contingency present |
| Iteration Plan | Every declared acceptance criterion accounted for; no fabricated duration; human gate bounded and reported apart; roadmap justified against the risk profile |
| Software Architecture Document | Every High-volatility use case mapped to a component; no layer- or feature-named subsystem; CON-025 placement; no fabricated measurement; invariants enforced in the schema |
| Test Evaluation Summary | Acceptance-verification plan per criterion; stand-in boundary stated; no fabricated result; SCM evidence current |

**Entry criteria.** All eight artifacts present and in Draft; the Development Case present and carrying tailoring content, so it governs this review. No artifact was found to be a placeholder mid-review.

**SCM evidence (Construction/Transition rule applied at LCO as a reality check).**

| Evidence | Observed value |
|---|---|
| Open pull requests | none — `scm_list_pull_requests(open)` returned none |
| Branches awaiting review | none — `scm_list_branches_with_label("ready-for-review")` returned none |
| Build on `main` | success — run `36050339100` |
| Open issues | `Issue #1` |

**Pull-request disposition.** Zero open pull requests and zero branches awaiting review, so no PR reached a terminal disposition this pass. This is consistent with Inception scope: RUP Ch.4 places no implementation activity in Inception, and no scaffolding PR was raised either. No productive code, no scope-ahead branch, and no defective diff was found to dispose.

**Scope of this lens.** This is the generic Reviewer lens — the technical review of the artifacts produced this iteration. The Management Reviewer's lens and the Business Reviewer's lens are separate blocks in this same Review Record and are not written here.

### Business Reviewer lens

**Review type.** Business Modeling quality gate — scenario-appropriateness assessment and derivation-readiness check. Not a Fagan inspection: no reader paraphrase step and no separate recorder role.

**Review point.** Lifecycle milestone — LCO. The evaluative lens is **exit criteria**: does the Business Modeling discipline's contribution satisfy the conditions for phase transition? The Business Modeling discipline is INACTIVE on this project, so the lens applied is the **inactivity justification** lens, not the artifact-quality lens.

**Scenario assessment (Heuristic 1 — assessed FIRST, before any artifact was read).** The six RUP business modeling scenarios were evaluated against the declared scope. **None applies.** The project builds one web application for one organisation against declared system requirements (`FR-001`..`FR-009`); no business process is modelled, re-engineered or reused. No scenario-appropriate standard can therefore be applied to a business-model artifact, because no such artifact is required. Applying New Business or Revamp standards here would manufacture false defects — the anti-pattern the discipline's own heuristics warn against.

```plantuml
@startuml BR_ScenarioSelection
title Business Modeling scenario selection - six scenarios evaluated, LCO Inception iteration 1
skinparam classAttributeIconSize 0

class "Which BM scenario applies?" as Q <<decision>>

class "1. Organization Chart" as S1 <<scenario>> {
  condition : org structure is the deliverable
  verdict : NOT APPLICABLE
}
class "2. Domain Modeling" as S2 <<scenario>> {
  condition : business entities modelled for a system
  verdict : NOT APPLICABLE
}
class "3. One Business Many Systems" as S3 <<scenario>> {
  condition : one business model feeds several systems
  verdict : NOT APPLICABLE
}
class "4. Generic Business Model" as S4 <<scenario>> {
  condition : reusable model across organisations
  verdict : NOT APPLICABLE
}
class "5. New Business" as S5 <<scenario>> {
  condition : a new business is being created
  verdict : NOT APPLICABLE
}
class "6. Revamp" as S6 <<scenario>> {
  condition : existing business processes re-engineered
  verdict : NOT APPLICABLE
}

class "No scenario applies" as NONE <<verdict>> {
  basis : DC-4 business-process-led = FALSE
  consequence : BM discipline INACTIVE
}

Q --> S1
Q --> S2
Q --> S3
Q --> S4
Q --> S5
Q --> S6
S1 --> NONE
S2 --> NONE
S3 --> NONE
S4 --> NONE
S5 --> NONE
S6 --> NONE

note bottom of NONE
  The project builds one web application for one
  organisation against declared system requirements
  (FR-001..FR-009). No business process is modelled,
  re-engineered or reused, so no scenario's condition
  holds and no scenario-appropriate standard can be
  applied to an artifact that does not exist.
  Applying New Business or Revamp standards here
  would manufacture false defects.
end note
@enduml
```

**DC §4 classification, independently re-verified.** `get_dc_classification` returned `isBusinessProcessLed: false`, classified 2026-09-24, with all four criteria evaluated and none fired. I re-verified each criterion against the declared scope rather than accepting the verdict:

| DC §4 criterion | Recorded verdict | Independent re-verification |
|---|---|---|
| (a) project re-engineers or automates a business process | NOT FIRED | Confirmed. The portal replaces three manual artefacts (Excel clocking sheets, mass emails, PDF phone list) with a web application. No HR process is re-engineered and no process model is produced. |
| (b) business actors and business workers are modelled | NOT FIRED | Confirmed. The declared scope names system actors (Employee, HR Administrator) and external systems (AD, Keycloak). No business actor and no business worker is declared anywhere. |
| (c) a Business Use-Case Model is an input or an output | NOT FIRED | Confirmed. The declared scope supplies system use cases `UC01`/`UC02`/`UC03` and `FR-001`..`FR-009` directly. No BUC is declared or required. |
| (d) the stakeholder declared business processes rather than system requirements | NOT FIRED | Confirmed. The stakeholder declared system requirements, system invariants (`CON-009`..`CON-019`) and acceptance criteria (`AC-001`..`AC-006`), all system-level. |

**Business Modeling artifact inventory — the evidence for the inactivity verdict.** The gate is not the classification alone; it is the classification *plus* the observed absence of every business-model artifact. Both hold.

```plantuml
@startuml BR_DC4Gate
title DC-4 business-process-led gate and Business Modeling artifact inventory - LCO, Inception iteration 1
skinparam classAttributeIconSize 0

class "DC-4 classification" as DC4 <<decision>> {
  business-process-led : FALSE
  classifiedAtUtc : 2026-09-24
}

class "4(a) re-engineers or automates a business process" as C1 <<criterion>> {
  verdict : NOT FIRED
}
class "4(b) business actors and business workers modelled" as C2 <<criterion>> {
  verdict : NOT FIRED
}
class "4(c) a Business Use-Case Model is input or output" as C3 <<criterion>> {
  verdict : NOT FIRED
}
class "4(d) stakeholder declared business processes" as C4 <<criterion>> {
  verdict : NOT FIRED
}

class "Business Use-Case Model" as BUC <<artifact>> {
  expected : NO
  present : NO
}
class "Business Object Model (workers, entities)" as BOM <<artifact>> {
  expected : NO
  present : NO
}
class "Business rules section" as BR <<artifact>> {
  expected : NO
  present : NO
}
class "Glossary (business-domain terms)" as GL <<artifact>> {
  expected : NO
  present : NO
}

class "Vision" as V <<artifact>> {
  BPL signal in prose : NONE
}
class "Use-Case Model" as UCM <<artifact>> {
  BUC / worker / entity sections : 0
}
class "Supplementary Specification" as SS <<artifact>> {
  business-domain specialist terms : 0
}

DC4 --> C1
DC4 --> C2
DC4 --> C3
DC4 --> C4
C1 --> BUC
C2 --> BOM
C3 --> BUC
C4 --> BR
V --> DC4
UCM --> DC4
SS --> DC4

note bottom of BUC
  Zero BM artifacts expected, zero present.
  The Business Reviewer lens has nothing to review:
  no BUC, no business actor, no business worker,
  no business entity, no business-rule section,
  no business-domain glossary term.
end note
@enduml
```

**Artifacts read in full before any finding was recorded (upstream consumption).** Vision, Use-Case Model, Supplementary Specification, Review Record (existing Reviewer lens blocks), plus the DC §4 classification. The Development Case, Risk List, Iteration Plan, Software Architecture Document and Test Evaluation Summary were not read: none can carry a business-model section, and the Business Modeling discipline's artifact surface is exhausted by the three read.

**Checklists applied.** The Business Modeling checklist (Heuristic 1.2) was applied item by item and every item recorded Pass or N/A. N/A is not a defect: the Development Case does not require a business-model artifact of the BPA this phase, so a finding against a non-required artifact would be a false defect.

**Entry criteria.** The Development Case is present and carries tailoring content, so it governs this review. The DC §4 classification is recorded. No business-model artifact was expected and none was found to be a placeholder mid-review.

**Scope of this lens.** This is the Business Reviewer lens — the business-modeling quality gate. The generic Reviewer's technical lens and the Management Reviewer's lens are separate blocks in this same Review Record and are not written here.

## Findings
### Reviewer lens

**Summary.** 11 findings: 0 Critical, 1 Major, 10 Minor. One artifact — the Use-Case Model — is clean and carries no finding. No Critical finding was recorded, so no finding of this lens escalates to the stakeholder.

**Compliance matrix.** Every checklist item evaluated, recorded Pass or Fail. A Fail is a finding.

```plantuml
@startuml RR_ComplianceMatrix
title Compliance matrix - LCO technical review, Inception iteration 1
skinparam classAttributeIconSize 0
skinparam classFontSize 11

class "Vision" as V <<artifact>> {
  Scope adherence, no creep : Pass
  STK-001 to STK-004 covered : Pass
  FR-001 to FR-009 one per feature : Pass
  NFR, AC, BG, CON coverage : Pass
  Unsourced figures : none
  UML present : Pass
  Trace endpoints are elements : Fail
  Diagram boundary consistency : Fail
}

class "Use-Case Model" as UCM <<artifact>> {
  UC-001 to UC-009 one per FR : Pass
  Source FR-NNN per use case : Pass
  No cross-cutting mechanism as UC : Pass
  Multi-actor process is one UC : Pass
  UML present : Pass
  Trace edges registered : Pass
}

class "Supplementary Specification" as SS <<artifact>> {
  NFR-001 to NFR-005 covered : Pass
  CON-009 to CON-019 as rules : Pass
  Cross-cutting mechanisms as entries : Pass
  No invented id in trace graph : Pass
  UML present : Pass
  Trace endpoints are elements : Fail
}

class "Development Case" as DC <<artifact>> {
  Roster of 25 unchanged : Pass
  CORE ownership unchanged : Pass
  CORE 16 complete : Pass
  No artifact outside the universe : Pass
  No role merge : Pass
  Optional triggers audited : Pass
  Intensity per canonical matrix : Fail
  Environment record current : Fail
}

class "Risk List" as RL <<artifact>> {
  R001 to R003 preserved : Pass
  Team risks numbered per CON-020 : Pass
  Acceptance cites CON-021 : Pass
  Mitigation and contingency present : Pass
  Premise current : Fail
}

class "Iteration Plan" as IP <<artifact>> {
  AC-001 to AC-006 accounted : Pass
  No fabricated duration : Pass
  Human gate bounded at 14 days : Pass
  Roadmap justified by risk profile : Pass
  Gate off the team path : Fail
  AC trace edges registered : Fail
}

class "Software Architecture Document" as SAD <<artifact>> {
  High-volatility UC to component : Pass
  No layer or feature naming : Pass
  CON-025 Keycloak in-network : Pass
  No fabricated measurement : Pass
  Invariants enforced in schema : Pass
  Correction model complete : Fail
  Trace table matches graph : Fail
}

class "Test Evaluation Summary" as TES <<artifact>> {
  AC verification plan : Pass
  Stand-in boundary stated : Pass
  No fabricated results : Pass
  SCM evidence current : Fail
}

V --> UCM
UCM --> SS
SS --> SAD
DC --> IP
RL --> IP
SAD --> TES
IP --> TES

note bottom of V
  Pass = the checklist item is satisfied.
  Fail = a finding is recorded against this artifact.
  No Critical finding was recorded in this review.
end note
@enduml
```

**Defect distribution.**

```plantuml
@startuml RR_DefectDistribution
title Defect distribution - severity x artifact (LCO technical review, Inception iteration 1)
skinparam classAttributeIconSize 0

class "Development Case" as DC <<artifact>> {
  Critical : 0
  Major : 0
  Minor : 2
}

class "Vision" as V <<artifact>> {
  Critical : 0
  Major : 0
  Minor : 2
}

class "Use-Case Model" as UCM <<artifact>> {
  Critical : 0
  Major : 0
  Minor : 0
}

class "Supplementary Specification" as SS <<artifact>> {
  Critical : 0
  Major : 0
  Minor : 1
}

class "Risk List" as RL <<artifact>> {
  Critical : 0
  Major : 0
  Minor : 1
}

class "Iteration Plan" as IP <<artifact>> {
  Critical : 0
  Major : 0
  Minor : 2
}

class "Software Architecture Document" as SAD <<artifact>> {
  Critical : 0
  Major : 0
  Minor : 2
}

class "Test Evaluation Summary" as TES <<artifact>> {
  Critical : 0
  Major : 1
  Minor : 0
}

note bottom of TES
  Totals: Critical 0, Major 1, Minor 10.
  One artifact (Use-Case Model) is clean.
  No Critical finding: no scope creep, no phantom
  use case, no baseline redefinition, no missing
  required artifact, no fabricated figure.
end note
@enduml
```

**Annotated review map.** Where each finding sits, and which LCO exit criterion the artifact evidences.

```plantuml
@startuml RR_AnnotatedMap
title Annotated review map - artifacts, findings and the LCO exit criteria they evidence
skinparam classAttributeIconSize 0

class "Vision" as V <<artifact>>
class "Use-Case Model" as UCM <<artifact>>
class "Supplementary Specification" as SS <<artifact>>
class "Development Case" as DC <<artifact>>
class "Risk List" as RL <<artifact>>
class "Iteration Plan" as IP <<artifact>>
class "Software Architecture Document" as SAD <<artifact>>
class "Test Evaluation Summary" as TES <<artifact>>

class "C1 Scope agreed" as C1 <<criterion>>
class "C2 Project viable" as C2 <<criterion>>
class "C3 Risks identified" as C3 <<criterion>>
class "C4 Process governs" as C4 <<criterion>>
class "C5 Stand-in environment" as C5 <<criterion>>
class "C6 Build verifiable" as C6 <<criterion>>

V --> C1
UCM --> C1
SS --> C1
SAD --> C2
DC --> C4
RL --> C3
IP --> C3
IP --> C5
IP --> C6
TES --> C6

note right of V
  2 Minor
  - trace endpoints are document sections
  - diagram draws Keycloak to UC-001 only
end note

note right of DC
  2 Minor
  - environment-readiness record stale
  - Environment narrative vs canonical matrix
end note

note right of SAD
  2 Minor
  - trace table vs registered graph
  - correction model incomplete
end note

note right of IP
  2 Minor
  - human gate serialized ahead of Iter-3
  - AC-002 to AC-005 carry no trace edge
end note

note right of TES
  1 Major
  - asserts the tracker holds no issues
end note

note bottom of C5
  C5 is not evidenced by any artifact: the
  Development Case records the stand-in
  environment as not ready. C6 is met by the
  green build on main despite the stale record.
end note
@enduml
```

**Findings.**

| Key | Artifact | Severity | Finding | Recommendation |
|---|---|---|---|---|
| `Development Case#F1` | Development Case | Minor | The Environment readiness verification table records the CI pipeline as not ready, and the Tailoring Overview and Environment narrative repeat the gap. The pipeline exists and builds — run `36050339100` on `main` is green. The record contradicts observable SCM state. | Record the CI pipeline as present and green on `main`, citing the observed run. Keep the gap open only for the genuinely absent items: `CONTRIBUTING.md`, lint configuration, stand-in environment. |
| `Development Case#F2` | Development Case | Minor | The Disciplines and Intensity table records Environment as "one-time at project start … recurring thereafter" in the delta column. The canonical matrix assigns Environment a level per phase. The row states a recurrence pattern where the matrix states a level, so it does not confirm the matrix it claims to confirm. | State the Environment row as per canonical matrix with the level per phase; move the one-time/recurring narrative to the Environment discipline section, where it already appears. |
| `Vision#F1` | Vision | Minor | The Traceability table's Traces To column names document sections — "Use-Case Model", "Supplementary Specification", "Risk List" — rather than trace-graph elements. A document section is not an element, so these rows register no edge. | Replace the section names with the element identifiers the row feeds — `UC-001`..`UC-009`, `NFR-001`..`NFR-005`, `R001`..`R003` — and register one edge per row. |
| `Vision#F2` | Vision | Minor | The Product Overview boundary diagram draws Keycloak to `UC-001` only, while the Use-Case Model's diagram of the same boundary draws Keycloak to all nine use cases. Two diagrams of one boundary disagree. | Draw Keycloak to all nine use cases, or state in the note that the single edge is a drawing simplification of the login mechanism that reaches every use case. |
| `Supplementary Specification#F1` | Supplementary Specification | Minor | The Traceability table's Traces To column names document sections — "Test Case", "Design Model", "Software Architecture Document", "Iteration Assessment", "Release Notes", "Risk List" — rather than elements. The registered graph shows this artifact as a leaf, so the downstream edges the table claims are not registered. | Name the element identifiers in Traces To, or state that the downstream artifacts do not yet exist and the edges will be registered when their elements are minted. Extend the existing label-scope note to the Traces To column. |
| `Risk List#F1` | Risk List | Minor | `R009`'s premise is that the CI pipeline definition is not in place, so the first build cannot be verified. The pipeline exists and builds — run `36050339100` on `main` is green. The risk as stated is partly retired and its mitigation claims work already done. | Restate `R009` to cover only the guideline files that are genuinely absent, or record the CI half as retired with the observed run as evidence, and adjust the mitigation. |
| `Iteration Plan#F1` | Iteration Plan | Minor | The roadmap gantt serializes the human validation gate ahead of Iter-3, placing the gate on the critical path. The plan's own text states the opposite: the team's work does not wait on the gate and every use case is built and tested against the stand-ins. | Draw the gate in parallel with Iter-2 and Iter-3 rather than in series before Iter-3, so the diagram matches the stated discipline. |
| `Iteration Plan#F2` | Iteration Plan | Minor | The Evaluation Criteria table accounts for all six acceptance criteria and defers each to a named iteration, but only `AC-001` and `AC-006` carry a registered trace edge. `AC-002`, `AC-003`, `AC-004` and `AC-005` have no outgoing edge, so the criterion-to-use-case mapping exists only as prose. | Register the missing edges — `AC-002` and `AC-005` to `UC-001`, `AC-003` to `UC-005`, `AC-004` to `UC-008`. |
| `Software Architecture Document#F1` | Software Architecture Document | Minor | The Traceability table declares edges not registered in the trace graph and, for `COMP-003`, lists `UC-001` on both sides of the row. A component realizes the use case it fulfils; it is not derived from it. The table also claims `COMP-001` reaches `UC-001`, `UC-002` and `UC-008`, while the graph registers only `COMP-001` to `UC-004`. | Reconcile the table with the registered edges: drop `UC-001` from the Traces From side of the `COMP-003` row, and either register the `COMP-001` edges or remove them from the table. |
| `Software Architecture Document#F2` | Software Architecture Document | Minor | The key-abstractions class diagram gives `Clocking` mutable `clockInUtc` and `clockOutUtc` fields plus a `corrected` flag, while the Data View states the clocking row is never updated in place (CON-012). The model does not state which value FR-003's ClockIn and ClockOut columns read when a correction exists, so the export contract is ambiguous against the correction model. | State that `Clocking`'s time fields are immutable and that the effective value is resolved from the correction chain, and name the resolution rule the export applies when a day carries one or more corrections. |
| `Test Evaluation Summary#F1` | Test Evaluation Summary | **Major** | The artifact asserts that the SCM issue tracker holds no issues and reports no defect — in the Test Summary evidence table, the Defects and Incidents section and the Conclusions table. The tracker holds `Issue #1`, labelled `severity:minor`, `nature:defect`, `configuration-record`. The claim is false against observable SCM state and would let the milestone verdict conclude that no defect exists. | Correct the three places to record `Issue #1` as the open defect and state the defect count as one. The artifact's own rule — a defect is an SCM issue and its identifier is the issue number — already supports this; the evidence block was not refreshed. |

**Traceability compliance.** The traceability tree was projected from the Business level and used as the completeness instrument. Result: 47 roots, 150 nodes, **no `SUSPECT` edge and no `UNKNOWN LABEL`**. No `«LEAF»` at Business level — every declared requirement and acceptance criterion reaches at least one downstream element, so no requirement is unrealized. The defects found are in the artifacts' own traceability *tables*, which declare edges the graph does not carry (`Vision#F1`, `Supplementary Specification#F1`, `Software Architecture Document#F1`) or omit edges the graph should carry (`Iteration Plan#F2`). The graph itself is sound; the tables are not reconciled with it.

**Scope-adherence result.** No scope creep was found. Nine use cases, one per declared `FR-001`..`FR-009`; every use case carries a `Source: FR-NNN` line citing a declared requirement; no phantom use case; no cross-cutting mechanism modelled as a use case — OIDC login, authorization, LDAP read, audit write and the clocking retry are all Supplementary Specification entries with `<<include>>` from their dependent use cases. No `[DERIVED]` marker was found in any artifact, so no silent derivation promotion exists to flag. No unsourced quantitative claim was found: the artifacts state declared targets and explicitly record that no measurement exists yet.

**DC baseline conformance result.** The Development Case does not redefine the 25-role roster, does not reassign CORE ownership, does not omit a CORE artifact, does not list an artifact outside the CORE + OPTIONAL universe, and does not merge two roles. Business Modeling is declared INACTIVE with the correct trigger condition (`business-process-led = false`). All six OPTIONAL triggers were audited against their §5.2 conditions and none was found over-triggered — each NOT-FIRED verdict holds against the project's real facts. The two findings against this artifact are a stale environment record and an intensity-row wording defect, not a baseline violation.

### Business Reviewer lens

**Summary.** **0 findings: 0 Critical, 0 Major, 0 Minor.** No business-model artifact exists to carry a defect, and none is required by the Development Case. No finding of this lens escalates to the stakeholder.

**Compliance matrix.** Every Business Modeling checklist item evaluated and recorded Pass or N/A. N/A is the correct verdict for an item whose subject does not exist and is not required — it is not a Fail, and it is not a finding.

```plantuml
@startuml BR_ComplianceMatrix
title Business Reviewer compliance matrix - LCO, Inception iteration 1
skinparam classAttributeIconSize 0

class "Business Modeling checklist" as BM <<checklist>> {
  Scenario selection explicit : N/A - BM inactive
  BUC completeness test : N/A - no BUC
  BUC realization adequacy : N/A - no BUC
  Derivation bridge (worker to system actor) : N/A - no worker
  Resource planning compliance : N/A - no worker or entity
  Business-level UML stereotypes : N/A - no business model
  Diagram coverage at business level : N/A - no business model
  Stakeholder representation coverage : Pass - STK-001..STK-004
  Business rules as formal constraints : Pass - CON-009..CON-019
  Business goals measurable : Pass - BG-001..BG-003
}

class "Verdict" as VD <<verdict>> {
  Findings recorded : 0
  Critical : 0
  Escalation to stakeholder : none
  Disposition : BR-OK-INACTIVE
}

BM --> VD

note bottom of BM
  N/A is not a defect: the DC-4 classification records
  business-process-led = FALSE, so no business-model
  artifact is required of the BPA this phase. A finding
  against an artifact the Development Case does not
  require would be a false defect.
end note
@enduml
```

**Checklist detail — the three items that are NOT N/A.** Three Business Modeling checklist items have a subject that exists in this project even though the discipline is inactive. Each was evaluated on its merits and each passes.

| Checklist item | Verdict | Evidence |
|---|---|---|
| Stakeholder representation coverage | **Pass** | All four declared stakeholders are represented in the Vision's Stakeholder Summary with role, interest, influence and the needs the product must satisfy: `STK-001` Laura Gómez (HR Director, sponsor), `STK-002` Miguel Torres (Software Engineer), `STK-003` Infrastructure Team (operates AD and Keycloak), `STK-004` Cuba Corp Employees (200 people, 3 offices). No significant organisational part relevant to the declared scope is unrepresented. The Infrastructure Team is correctly modelled as a stakeholder and not as a use-case actor — it operates the portal in production (`CON-029`) and performs no in-portal administration. |
| Business rules as formal constraints | **Pass** | `CON-009`..`CON-019` are declared as `[BusinessRule]` constraints and each is attached to the element it constrains: `CON-009` to the news feature set (`FR-005`, `FR-006`, `FR-007`), `CON-010`/`CON-011`/`CON-012` to clocking (`FR-001`, `FR-002`, `FR-003`), `CON-013`/`CON-014`/`CON-015`/`CON-016` to the worker category (`FR-008`, `FR-009`), `CON-017` to news retention (`FR-007`), `CON-018`/`CON-019` to the audit (`NFR-004`). Each is testable and each carries its source. They are system invariants, not business-process definitions — which is precisely why they do not trigger Business Modeling. |
| Business goals measurable | **Pass** | `BG-001` (50% reduction in HR management time, measured against the current manual processes), `BG-002` (100% of new clockings out of Excel), `BG-003` (80% of 200 employees within 3 months) each carry a numeric target and a stated basis of measurement. |

**Derivation-readiness assessment (the Business-to-System Derivation Readiness Gate).** The gate is **not applicable, and correctly so** — it is not "failed". The gate asks whether a business model is a sound foundation for the System Analyst to derive system use cases from. Here the derivation never passes through a business model: the stakeholder declared the system use cases directly (`UC01` Clock In/Out, `UC02` Read News, `UC03` Employee Directory) alongside `FR-001`..`FR-009`, and the Use-Case Model realises them one-for-one. There is no business worker whose automation disposition must be annotated, because no business worker exists; there is no business entity needing a candidate analysis-class annotation, because no business entity exists. The bridge is not broken — it is not needed.

**Traceability compliance.** The traceability tree was projected from the Business level and used as the completeness instrument. Result: **no `SUSPECT` edge and no `UNKNOWN LABEL`**; no `«LEAF»` at Business level — every declared requirement and acceptance criterion reaches at least one downstream element. No business-level element (`BUC-NNN`, `BR-NNN`, `OBJ-NNN`) appears in the graph, which is the expected shape for a project with Business Modeling inactive. The defects the generic Reviewer lens found are in the artifacts' own traceability *tables* (`Vision#F1`, `Supplementary Specification#F1`), not in the graph, and they are that lens's findings to close — not mine.

**Scope-adherence result.** No scope creep was found in the business dimension. Nine use cases, one per declared `FR-001`..`FR-009`; no phantom use case; no cross-cutting mechanism modelled as a use case — OIDC login, authorization, LDAP read, audit write and the clocking retry are all Supplementary Specification entries with `<<include>>` from their dependent use cases. No `[DERIVED]` marker was found in any artifact, so no silent derivation promotion exists to flag. No unsourced quantitative claim was found: the artifacts state declared targets and explicitly record that no measurement exists yet.

**Prior findings of this lens.** None. This is the first review pass of the Business Reviewer lens on this project: `read_artifact_findings` returned an empty list for the Use-Case Model and no finding with `reviewerRole: BusinessReviewer` on any artifact. The three findings that do exist — `Vision#F1`, `Vision#F2`, `Supplementary Specification#F1` — carry `reviewerRole: Reviewer` and belong to that lens; the ownership invariant forbids me from closing them, and no `resolve_artifact_finding` call was emitted this pass.

## Resolutions and Actions
### Reviewer lens

**Prior findings of this lens.** None. This is the first review pass of the Reviewer lens on this project: `read_artifact_findings` returned an empty list for all eight artifacts, so no prior finding of this lens exists to close, defer or reject. No `resolve_artifact_finding` call was emitted this pass.

**Actions arising from this pass.** Each action is the finding's Recommendation; its status is that finding's Resolution. No action identifier is minted.

| Finding | Owner | Action | Blocking? |
|---|---|---|---|
| `Test Evaluation Summary#F1` | TestManager | Record `Issue #1` as the open defect in the three places that assert none exists; state the defect count as one | No — the artifact's mission verdict is unaffected, but the evidence block must not contradict the tracker |
| `Development Case#F1` | ProcessEngineer | Refresh the Environment readiness record to show the CI pipeline present and green on `main` | No |
| `Development Case#F2` | ProcessEngineer | State the Environment intensity row per canonical matrix; move the recurrence narrative to the Environment section | No |
| `Risk List#F1` | ProjectManager | Restate `R009` to cover only the absent guideline files, or record the CI half as retired | No |
| `Iteration Plan#F1` | ProjectManager | Draw the human validation gate in parallel with Iter-2 and Iter-3 | No |
| `Iteration Plan#F2` | ProjectManager | Register the missing acceptance-criterion edges | No |
| `Vision#F1` | SystemAnalyst | Replace section names in Traces To with element identifiers | No |
| `Vision#F2` | SystemAnalyst | Align the boundary diagram with the Use-Case Model's | No |
| `Supplementary Specification#F1` | RequirementsSpecifier | Name element identifiers in Traces To, or state the downstream elements do not yet exist | No |
| `Software Architecture Document#F1` | SoftwareArchitect | Reconcile the traceability table with the registered edges | No |
| `Software Architecture Document#F2` | SoftwareArchitect | State the clocking time fields as immutable and name the export's correction-resolution rule | No |

**Carry-over.** No finding of this lens is deferred and none is rejected. All 11 remain open for the next iteration of this Reviewer, which will reconcile them in its closure state before recording new defects.

### Business Reviewer lens

**Prior findings of this lens.** None. This is the first review pass of the Business Reviewer lens on this project. `read_artifact_findings` returned an empty list for the Use-Case Model, and no finding on any artifact carries `reviewerRole: BusinessReviewer`. No `resolve_artifact_finding` call was emitted this pass, and none was due.

**Cross-lens findings left untouched.** Three findings exist on artifacts I read. All three carry `reviewerRole: Reviewer` and are that lens's to close. The ownership invariant rejects a cross-lens close attempt, so none was attempted.

| Finding | Lens | Severity | Status | Why this lens does not act |
|---|---|---|---|---|
| `Vision#F1` | Reviewer | Minor | Open | Traceability-table defect in the technical lens's checklist. Not a business-modeling defect. |
| `Vision#F2` | Reviewer | Minor | Open | Boundary-diagram consistency between two system-level diagrams. Not a business-modeling defect. |
| `Supplementary Specification#F1` | Reviewer | Minor | Open | Traceability-table defect in the technical lens's checklist. Not a business-modeling defect. |

**Actions arising from this pass.** None. Zero findings were recorded, so no action, owner or remediation exists to carry forward. No action identifier is minted — a remediation is the finding's Recommendation, and there is no finding.

**Carry-over.** Nothing is deferred and nothing is rejected. The Business Reviewer lens has no open finding and no outstanding action entering the next iteration.

**Condition that would re-activate this lens.** The lens re-activates if any of the following becomes true, and the Process Engineer's DC §4 classification is the trigger to watch:

| Condition | Effect |
|---|---|
| A Change Request introduces a business process to be re-engineered or automated | DC §4(a) fires; Business Modeling becomes ACTIVE; a Business Use-Case Model and its realizations become reviewable artifacts |
| A business actor or business worker is declared in scope | DC §4(b) fires; the BUC completeness test and the derivation bridge become applicable |
| A Business Use-Case Model becomes an input or an output of the work | DC §4(c) fires; the BUC-realization coverage gate becomes applicable |
| The stakeholder declares business processes rather than system requirements | DC §4(d) fires; the full Business Modeling checklist applies at Elaboration depth |
| A Glossary is triggered by specialist business-domain vocabulary | The business-terms review becomes applicable |

Until one of these holds, the Business Reviewer lens has no artifact surface and produces no finding.

## Disposition
### Reviewer lens

**Overall disposition: Approved with Changes.**

The artifacts are fit to carry the project into Elaboration, subject to the 11 findings above. No Critical finding was recorded, so nothing blocks the phase transition and no finding of this lens escalates to the stakeholder. The single Major finding is a factual error in one evidence block, not a defect in the baseline it reports.

**LCO exit criteria, assessed against the artifacts and the SCM.**

| # | Exit criterion | Verdict | Basis |
|---|---|---|---|
| 1 | Stakeholders agree on the scope | Met | Vision and Use-Case Model carry the declared scope with no creep: nine use cases, one per declared `FR-001`..`FR-009`, each citing its source requirement. No element outside the declared scope. |
| 2 | The project is viable | Met | The stack is pinned by CON-022/CON-023/CON-024; the OIDC client is already registered (CON-003) so login is testable from day one; the Development Case's Architectural Proof-of-Concept NOT-FIRED verdict holds — no technical risk requires empirical validation. |
| 3 | Initial risks identified and classified | Met | Risk List carries `R001`..`R009` with probability, impact, magnitude, strategy, owner, mitigation and contingency. `R001`..`R003` preserved with the declared identifiers and magnitudes; team risks numbered per CON-020; every acceptance cites CON-021. |
| 4 | The process configuration governs the project | Met | Development Case conforms to the IARI baseline: roster unchanged, CORE ownership unchanged, no artifact outside the universe, Business Modeling INACTIVE on the correct trigger, all six OPTIONAL triggers audited and none over-triggered. |
| 5 | The stand-in environment is available (CON-028) | **Not met** | The Development Case records the stand-in OIDC issuer and stand-in directory as not ready, and no artifact evidences them. This is the criterion that gates every use case, and it is iteration-1 environment work still outstanding. |
| 6 | The build is verifiable (CON-026) | Met | Run `36050339100` on `main` is green. The Development Case's record of this criterion is stale (`Development Case#F1`), but the criterion itself is satisfied by the observed build. |

**Reading of the verdict.** Criteria 1, 2, 3, 4 and 6 are met. Criterion 5 is not met: the stand-in environment is the project's principal process control and it does not yet exist. That is a gap in the iteration's own exit criteria, not a defect in any artifact — the Development Case and the Iteration Plan both name it correctly and assign it an owner. It is recorded here so the milestone verdict is taken on the evidence rather than on the artifacts' self-assessment.

**What this lens does not decide.** The LCO verdict belongs to the ReviewCoordinator and the ManagementReviewer. This block states the technical lens's disposition and the exit-criteria evidence; it does not close the milestone.

### Business Reviewer lens

**Verdict: [BR-OK-INACTIVE] — Discipline NOT APPLICABLE per DC §4**

DC §4 trigger evaluation: project does not exhibit business-process-led characteristics. No ERP / BPM / workflow-redesign / M&A signals found in Vision. No Business Use Cases / Workers / Entities sections present in Use-Case Model. No business-domain specialist terms in Glossary.

Conclusion: BPA + BR are correctly INACTIVE for this engagement. No findings, no recommendations. Downstream reviewers (MR, RC) may treat the BM discipline as out-of-scope for the LCO milestone.

**Basis of the verdict — the two conditions that must BOTH hold, and both do.**

| Condition | Observed | Evidence |
|---|---|---|
| No business-process-led signal in the Vision prose | Holds | The Vision describes a web application replacing three manual artefacts (Excel clocking sheets, mass emails, PDF phone list). No ERP, BPM, workflow-redesign or M&A signal. No business process is named as the subject of the work. |
| Zero Business Modeling sections in any artifact | Holds | Use-Case Model: 0 business use cases, 0 business workers, 0 business entities — its Actors section names system actors (Employee, HR Administrator) and external systems (Keycloak, Active Directory). Supplementary Specification: `CON-009`..`CON-019` are declared system invariants, not business-process definitions. Glossary: artifact does not exist; its §5.2 trigger is NOT FIRED. |

**What this verdict does NOT say.** It does not say the business dimension of the project is unexamined. Three Business Modeling checklist items have a live subject and each was evaluated and passed: stakeholder representation coverage (`STK-001`..`STK-004` all represented), business rules as formal constraints (`CON-009`..`CON-019`, each attached to the element it constrains and each testable), and business-goal measurability (`BG-001`..`BG-003`, each with a numeric target and a stated basis of measurement). The verdict is that no *business-model artifact* is required, not that no business thinking was done.

**What this verdict does NOT decide.** The LCO verdict belongs to the ReviewCoordinator and the ManagementReviewer. This block states the Business Modeling lens's disposition and the evidence for it; it does not close the milestone. The generic Reviewer lens's disposition (Approved with Changes, 11 findings, 0 Critical) and the Management Reviewer's lens are separate blocks in this same Review Record.

**Effect on the LCO exit criteria.** The Business Modeling discipline contributes no exit criterion of its own to LCO, because it is inactive. It therefore neither blocks nor advances the milestone. The criterion the generic Reviewer lens records as **Not met** — the stand-in environment (`CON-028`) — is an Environment-discipline gap and is outside this lens's scope; I record no finding on it and take no position on it.

**Escalation.** No Critical finding was recorded by this lens, so nothing escalates to the stakeholder via `REQUIRES_USER_INPUT`. No `[SCOPE_QUESTION]` is open in this block: the declared scope is complete and unambiguous for the business dimension, and no business value was invented.

## Traceability
| Element | Traces From | Link Type | Traces To |
|---|---|---|---|
| Review Record | Development Case, Vision, Use-Case Model, Supplementary Specification, Risk List, Iteration Plan, Software Architecture Document, Test Evaluation Summary | Refines | LCO |
| Reviewer lens — compliance matrix | Development Case, Vision, Use-Case Model, Supplementary Specification, Risk List, Iteration Plan, Software Architecture Document, Test Evaluation Summary | Refines | LCO |
| Reviewer lens — findings | Development Case#F1, Development Case#F2, Vision#F1, Vision#F2, Supplementary Specification#F1, Risk List#F1, Iteration Plan#F1, Iteration Plan#F2, Software Architecture Document#F1, Software Architecture Document#F2, Test Evaluation Summary#F1 | Refines | LCO |
| Reviewer lens — SCM evidence | Issue #1, run 36050339100 | Refines | LCO |
| Reviewer lens — disposition | AC-001, AC-002, AC-003, AC-004, AC-005, AC-006, CON-028, CON-026 | Refines | LCO |

### Reviewer lens

| Element | Traces From | Link Type | Traces To |
|---|---|---|---|
| Review Record | Development Case, Iteration Plan | Refines | AC-001, AC-002, AC-003, AC-004, AC-005, AC-006 |
| Reviewer lens — compliance matrix | Development Case, Iteration Plan | Refines | AC-001, AC-006 |
| Reviewer lens — findings | Development Case, Iteration Plan | Refines | AC-001, AC-006, CON-026, CON-028 |
| Reviewer lens — SCM evidence | Issue #1, run 36050339100 | Refines | AC-001, AC-006 |
| Reviewer lens — disposition | CON-026, CON-028 | Refines | AC-001, AC-002, AC-003, AC-004, AC-005, AC-006 |

`Development Case` and `Iteration Plan` are the two reviewed artifacts that are trace-graph elements; the remaining six are named in the Review Scope and Criteria block and carry no element identifier of their own. `Issue #1` and `run 36050339100` are observed SCM facts, cited as returned by the `scm_*` tools. The findings of this lens are cited by their `<artifact>#<key>` handles in the Findings block; a finding is not an element and no edge is registered on one.

### Business Reviewer lens

| Element | Traces From | Link Type | Traces To |
|---|---|---|---|
| Business Reviewer lens — scenario assessment | DC §4 classification (`business-process-led = false`) | Refines | LCO |
| Business Reviewer lens — DC §4 re-verification | DC §4 classification, Vision, Use-Case Model, Supplementary Specification | Refines | LCO |
| Business Reviewer lens — BM artifact inventory | Use-Case Model, Supplementary Specification | Refines | LCO |
| Business Reviewer lens — compliance matrix | Vision, Use-Case Model, Supplementary Specification | Refines | LCO |
| Business Reviewer lens — stakeholder coverage check | STK-001, STK-002, STK-003, STK-004 | Refines | LCO |
| Business Reviewer lens — business-rule audit | CON-009, CON-010, CON-011, CON-012, CON-013, CON-014, CON-015, CON-016, CON-017, CON-018, CON-019 | Refines | LCO |
| Business Reviewer lens — business-goal measurability check | BG-001, BG-002, BG-003 | Refines | LCO |
| Business Reviewer lens — derivation-readiness assessment | FR-001, FR-002, FR-003, FR-004, FR-005, FR-006, FR-007, FR-008, FR-009 | Refines | LCO |
| Business Reviewer lens — disposition | CON-028 | Refines | LCO |

**Trace endpoints.** `STK-001`..`STK-004`, `FR-001`..`FR-009`, `CON-009`..`CON-019`, `CON-028`, `BG-001`..`BG-003` and `AC-001`..`AC-006` are declared identifiers, copied exactly from the work order. `LCO` is the milestone this review serves. No `BUC-NNN`, `BR-NNN` or `OBJ-NNN` appears: those are the Business Process Analyst's element families, and no element of any of them exists on this project — which is the substance of the `BR-OK-INACTIVE` verdict, not an omission.

**Findings of this lens.** None. No `<artifact>#<key>` handle is cited because no finding was recorded. The three findings named in the Findings block — `Vision#F1`, `Vision#F2`, `Supplementary Specification#F1` — are the generic Reviewer lens's, cited there for the record of what this lens deliberately did not touch.

**Observed SCM facts.** None cited by this lens. The Business Modeling discipline produces no code, no build and no pull request, so no `scm_*` observation bears on this verdict. The SCM evidence in the Reviewer lens's block is that lens's instrument.

