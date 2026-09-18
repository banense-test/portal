## Document Control

| Field | Value |
|---|---|
| Artifact | Branching Strategy — Portal (Employee Portal, Cuba Corp) |
| Phase | Inception |
| Status | Draft — published for review; milestone NOT YET ACHIEVED |
| Milestone Target | End-of-Inception (LCO) — not marked complete by this file |
| Iteration / Cycle | 1 / 1 |
| Owner | ConfigurationManager |
| Date | 2026-09-18 |
| Governing process | Development Case (Inception) — Business Modeling INACTIVE; Architectural Proof-of-Concept trigger FIRED (delta D2) |
| Nature of this file | Documentation / configuration-as-code. Committed DIRECT to `main` via `scm_commit_files`. Never opened as a pull request. |

**What this file is.** The project's configuration management strategy, expressed as code: the configuration-item identification scheme, the branch topology, the baseline pedigree and its pre-tag gate, the change-control interface, the audit procedures and the tooling. It is the workspace hierarchy the Integrator, Implementer and Reviewer work inside.

**What this file is not.** It is not a status report and not an audit findings document. Status and measurement data are queries over the branch / PR / tag / Issue graph, read from dashboards. The ConfigurationManager upserts no status artifact.

**Why it is committed direct to `main`.** This file is documentation. A pull request would gate a Markdown change behind a Reviewer with nothing actionable to inspect, and would withhold the file from the Integrator, Implementer and Reviewer until the PR was handled. PRs are for source code; docs are commits.

## Configuration Item Identification Scheme

Every configuration item is identified by a stable scheme, so that a change can be traced to the item it touched and a baseline can be audited against it.

```plantuml
@startuml
title Portal — Configuration Item Identification Scheme

skinparam classAttributeIconSize 0

class "ConfigurationItem" as CI {
  + ciType : CIType
  + identifier : String
  + namingPattern : String
  + authority : AgentRole
  + baseline : BaselineTag
}

enum "CIType" as CIT {
  SourceCode
  ArtifactDocument
  BuildConfig
  Branch
  BaselineTag
  ChangeRequest
}

class "SourceCode" as SRC {
  + path : src/Portal.Domain/...
  + pattern : <Solution>/<Project>/<Type>.cs
}

class "ArtifactDocument" as DOC {
  + path : docs/<artifact>.md
  + pattern : canonical artifact name
}

class "BuildConfig" as BLD {
  + path : .github/workflows/*.yml
  + pattern : <purpose>.yml
}

class "Branch" as BR {
  + pattern1 : feature/En-<risk-id>[-<mechanism>]
  + pattern2 : feature/Cn-<uc-id>-<subject>
  + pattern3 : iteration/En | iteration/Cn
  + pattern4 : hotfix/<issue-id>
  + pattern5 : chore/<subject>
}

class "BaselineTag" as TAG {
  + pattern : baseline-{phase}{n}-v{x}
  + phase : elaboration | construction | transition
}

class "ChangeRequest" as CR {
  + pattern : Issue #<n>
  + state : cr:new -> cr:approved -> cr:complete
}

CI --> CIT
CI <|-- SRC
CI <|-- DOC
CI <|-- BLD
CI <|-- BR
CI <|-- TAG
CI <|-- CR

note bottom of TAG
  x starts at 1. A re-tag (v2, v3) is justified
  ONLY after a rollback or a post-baseline
  critical fix on the iteration branch.
end note

note bottom of CR
  The CR state machine is the ChangeControlManager's.
  The ConfigurationManager references Issue #<n>
  as a trace endpoint and never mints a CR id.
end note
@enduml
```

| CI type | Identifier | Naming pattern | Authority |
|---|---|---|---|
| Source code | file path | `src/<Solution>/<Project>/<Type>.cs` — the four projects fixed by the SAD Implementation View (`Portal.Web`, `Portal.Api`, `Portal.Domain`, `Portal.Infrastructure`) | Implementer |
| Artifact document | canonical artifact name | `docs/<artifact>.md` | the artifact's primary owner |
| Build configuration | file path | `.github/workflows/<purpose>.yml` | Implementer / Integrator |
| Branch | branch name | the five patterns in *Branch Topology* | Integrator (integration branches), Implementer (feature branches) |
| Baseline tag | tag name | `baseline-{phase}{n}-v{x}` | ConfigurationManager |
| Change request | `Issue #<n>` | GitHub issue, `cr:*` labels | ChangeControlManager |

**Element identifiers are not configuration items.** `COMP-001`..`COMP-011`, `INT-001`..`INT-010`, `ADR-001`..`ADR-007`, `UC-001`..`UC-003`, `FR-001`..`FR-014`, `NFR-001`..`NFR-004`, `CON-001`..`CON-024`, `R001`..`R006`, `AC-001`..`AC-005` are model elements owned by their authority roles. They are referenced, never re-minted here.

## Branch Topology

The topology is the workspace hierarchy: developer → integration → release. It is deliberately small — three use cases, one internal Windows Server (CON-007), 200 employees (CON-008).

```plantuml
@startuml
title Portal — Branch Topology (workspace hierarchy as code)

skinparam componentStyle rectangle
skinparam packageStyle rectangle

package "Long-lived" as LL {
  component "main\nprotected; only the Integrator writes\nbaseline tags land here" as MAIN
}

package "Integration workspaces — one per iteration" as INT {
  component "iteration/E1\nElaboration integration workspace" as IE1
  component "iteration/C1\nConstruction integration workspace" as IC1
}

package "Elaboration — evolutionary architectural mechanism" as ELAB {
  component "feature/E1-R001-ldap-read\nreal LDAP reader (R001, single-mechanism)" as FE1
}

package "Construction — use-case realizations" as CON {
  component "feature/C1-uc001-clocking" as FC1
  component "feature/C1-uc002-news" as FC2
  component "feature/C1-uc003-directory" as FC3
}

package "Transition — hotfixes" as TR {
  component "hotfix/<issue-id>\nfrom main, express review" as HF
}

package "Non-functional maintenance" as CH {
  component "chore/<subject>\nCI config, branching strategy" as CHORE
}

MAIN <-- IE1 : iteration/E1 -> main\nat LAM close (PR, Architect review)
MAIN <-- IC1 : iteration/C1 -> main\nat IOC (PR, Architect review)
IE1 <-- FE1 : feature/E1-* based on iteration/E1
IC1 <-- FC1
IC1 <-- FC2
IC1 <-- FC3
MAIN <-- HF : hotfix merged to main\n+ patch baseline tag
MAIN <-- CHORE : direct commit\n(no PR)

note right of MAIN
  Only the Integrator writes iteration/* and main.
  No other role pushes there.
end note

note bottom of ELAB
  No samples/poc/ and no ephemeral poc/* branch.
  The mechanism is built in src/ and kept.
end note
@enduml
```

### Naming conventions

| Pattern | Phase | Base branch | Purpose |
|---|---|---|---|
| `feature/E{n}-{risk-id}[-{mechanism}]` | Elaboration | `iteration/E{n}` | Evolutionary architectural mechanism. Built in `src/`, integrated like a feature. |
| `feature/C{n}-{uc-id}-{subject}` | Construction | `iteration/C{n}` | Use-case realization. |
| `iteration/E{n}` | Elaboration | `main` | Integration workspace for the iteration. |
| `iteration/C{n}` | Construction | `main` | Integration workspace for the iteration. |
| `hotfix/{issue-id}` | Transition | `main` | Post-release fix; express review; merged to `main` with a patch baseline tag. |
| `chore/{subject}` | any | `main` | Non-functional repository maintenance — CI config, this file. |

**Cross-phase invariants.**

1. **Only the Integrator writes `iteration/*` and `main`.** No other role pushes there. Feature branches are the Implementer's; integration branches and `main` are the Integrator's.
2. **`ready-for-review` is the Implementer → Code Reviewer handoff label.** A branch carrying it and no pull request is a branch waiting for one.
3. **A baseline tag freezes only an APPROVED + CI-green commit.** See *Baseline Pedigree*.
4. **No `samples/poc/` directory and no ephemeral `poc/*` branch exists.** The Elaboration mechanism is evolutionary: it is built in `src/` and becomes the Construction baseline.

### Per-phase model

**Inception — documentation only.** No implementation code. The declared scope is a closed set of fourteen functional requirements (FR-001..FR-014) and the Development Case records `business-process-led = false`, so no feasibility mechanism is required. No `feature/I*` branch is created. **Inception produces no baseline tag** — the phase token set is {elaboration, construction, transition}, and the LCO milestone is recorded by the review, not by a tag.

**Elaboration — evolutionary architectural mechanism.** The Development Case fired the Architectural Proof-of-Concept trigger on R001 (delta D2), with mode `single-mechanism`. The mechanism is the **real** LDAP reader, built in `src/` on `feature/E1-R001-ldap-read` based on `iteration/E1`. It is not throwaway sample code. The Code Reviewer opens and reviews the mechanism PR as production; the Integrator merges the APPROVED mechanism into `iteration/E1`. R003 and R004 are `analysis-only` — no branch, no prototype; they are discharged in the Design Model. At LAM close the Integrator opens `iteration/E1 → main` and the Deliver bookend merges the reviewed baseline.

**Construction — feature branches.** UC realizations on `feature/C{n}-{uc-id}-{subject}` based on `iteration/C{n}`. The Code Reviewer reviews; the Integrator merges APPROVED into `iteration/C{n}` and opens `iteration/C{n} → main` at IOC.

**Transition — hotfixes.** `hotfix/{issue-id}` from `main`, express review, merged to `main` with a patch baseline tag.

## Baseline Pedigree

A baseline tag is written **only** when the iteration-close PR has consolidated review state `APPROVED` **and** post-merge CI on `main` is green. A tag that freezes a red build or an unreviewed commit is a defect, not a baseline.

```plantuml
@startuml
title Portal — Baseline Pedigree: the pre-tag gate

[*] --> IterationWork : iteration opens
IterationWork --> ClosePR : Integrator opens\niteration/Cn -> main
ClosePR --> ReviewGate : scm_get_pull_request_review_state
state ReviewGate <<choice>>
ReviewGate --> MergeGate : APPROVED
ReviewGate --> Escalate : NONE or CHANGES_REQUESTED
MergeGate --> Baseline : main CI green
MergeGate --> Escalate : main CI red
Escalate --> SCMIssue : scm_create_issue\nseverity:blocker + nature:defect
SCMIssue --> [*] : HALT — no tag written
Baseline --> [*] : scm_create_tag\nbaseline-{phase}{n}-v{x}

note right of MergeGate
  scm_merge_pull_request, then
  scm_get_build_status("main").
  Both gates are read BEFORE any tag.
end note

note bottom of Baseline
  The tag message is the audit record:
  PR number, head SHA, review id,
  CI run URL, notable findings.
end note
@enduml
```

```plantuml
@startuml
title Portal — Iteration-Close Gate Sequence (pre-tag audit)

start
:Integrator opens iteration-close PR\niteration/Cn -> main;
:CM reads consolidated review state\nscm_get_pull_request_review_state;
if (state == APPROVED?) then (no)
  :scm_create_issue\nseverity:blocker + nature:defect\n+ gate:review;
  :HALT — no tag written;
  stop
else (yes)
endif
:Integrator merges the APPROVED PR;
:CM reads post-merge CI\nscm_get_build_status("main");
if (CI == green?) then (no)
  :scm_create_issue\nseverity:blocker + nature:defect\n+ gate:ci;
  :HALT — no tag written;
  stop
else (yes)
endif
:CM writes the audit record\nPR number, head SHA, review id, CI run URL;
:scm_create_tag\nbaseline-{phase}{n}-v{x};
stop
@enduml
```

### Baseline tag naming

| Tag | Written at | Phase token |
|---|---|---|
| `baseline-elaboration-E{n}-v{x}` | LAM close — `iteration/E{n} → main` merged | `elaboration` |
| `baseline-construction-C{n}-v{x}` | IOC — `iteration/C{n} → main` merged | `construction` |
| `baseline-transition-T{n}-v{x}` | release / hotfix merged to `main` | `transition` |

`{x}` starts at `1`. A re-tag (`v2`, `v3`) is justified **only** after an explicit rollback or a post-baseline critical fix applied to the iteration branch. Routine iteration work targets the **next** iteration's tag, never a re-tag of the previous one. One baseline per iteration close — never mid-iteration.

### Tag message contract

The tag message is the audit statement. It is terse, factual and Git-native, and it carries:

- the iteration-close PR number and the head commit SHA it points at;
- the Architect approval review id;
- the `main` CI run URL at tag time;
- any notable findings — naming violations, deferred items, re-tag justification.

A tag message reading `"baseline"` alone is a defect: it claims a pedigree it does not evidence.

### Gate dependency — CI must exist before the first baseline

The second gate reads `scm_get_build_status("main")`. The Development Case records the CI workflow as **UNVERIFIED** in its S1 tool inventory (2026-09-17), with the Implementer / Integrator as content owner and the target "verified before the first Construction iteration". The first baseline this strategy writes is `baseline-elaboration-E1-v1` at LAM close, which precedes that target — so the gate is satisfiable, but only if the workflow exists by then.

Until it does, the second gate **cannot be read**, and an unreadable gate is a **failed** gate, not a waived one: no tag is written. The ConfigurationManager does not author the CI workflow — it is not a CM deliverable, and the Development Case assigns it to the Implementer / Integrator — but it does refuse to tag without it. This dependency is named here so that the gate's validity is auditable rather than assumed.

## Change Control Interface

The Change Request state machine and the CCB decisions belong to the **ChangeControlManager**. The ConfigurationManager does not triage CRs and does not evaluate impact. It consumes the CCM-triaged outcome indirectly, through the branch and the PR that outcome authorises.

```plantuml
@startuml
title Portal — Change Control Interface: CR to branch to baseline

[*] --> CRNew : scm_create_issue\ncr:new
CRNew --> CRAssessed : CCM triages\nimpact analysis
CRAssessed --> CRAssessed : cr:approved | cr:rejected | cr:deferred
CRAssessed --> BranchAuthorized : cr:approved
BranchAuthorized --> FeatureBranch : feature/Cn-<uc-id>-<subject>\nbased on iteration/Cn
FeatureBranch --> ReadyForReview : scm_add_label\nready-for-review
ReadyForReview --> PR : Code Reviewer opens PR
PR --> Merged : APPROVED + merged by Integrator
Merged --> Baseline : next iteration-close baseline
Baseline --> [*]

note right of CRAssessed
  The CR state machine and the CCB decision
  belong to the ChangeControlManager.
  The ConfigurationManager consumes the
  outcome via the branch and PR it authorises.
end note
@enduml
```

**Boundary.** The ConfigurationManager references a change request as `Issue #<n>` — an observed process fact. It never mints a `CR-NNN` identifier: that family is not in the element-ID table, and a composed citation is worth less than none.

## Audit Procedures

Two audits run at every iteration close, before the tag is written.

| Audit | Question it answers | Procedure |
|---|---|---|
| **FCA** — functional configuration audit | Does the tagged commit meet the requirements the iteration claimed? | Verify the approval chain: each feature PR carries a Code Reviewer approval; the iteration-close PR carries the Architect approval. Verify the iteration's use cases are covered by the merged feature branches. The ConfigurationManager verifies the **approval chain**, not the use cases directly. |
| **PCA** — physical configuration audit | Does the tag point at the commit that was actually approved? | Compare the tag's target SHA against the head SHA of the APPROVED iteration-close PR. A mismatch is a defect. |
| **Naming sweep** | Does every branch conform to the canonical patterns? | `scm_list_branches_with_label` sweep; non-conforming branches are surfaced as issues, never auto-renamed. |

```plantuml
@startuml
title Portal — CM Tooling and Audit Surface

skinparam componentStyle rectangle
skinparam packageStyle rectangle

package "SCM tooling — the CM instrument panel" as TOOLS {
  component "scm_commit_files\nconfig-as-code, direct to main" as T1
  component "scm_create_branch\nfeature/*, iteration/*, hotfix/*" as T2
  component "scm_create_pull_request\nIntegrator opens iteration-close PR" as T3
  component "scm_get_pull_request_review_state\nGATE 1 — consolidated review" as T4
  component "scm_merge_pull_request\nIntegrator merges APPROVED only" as T5
  component "scm_get_build_status\nGATE 2 — post-merge CI on main" as T6
  component "scm_create_tag\nbaseline-{phase}{n}-v{x}" as T7
  component "scm_create_issue\ngate failures, naming violations" as T8
  component "scm_list_branches_with_label\nnaming-convention sweep" as T9
}

package "Audit procedures" as AUD {
  component "FCA — functional configuration audit\napproval chain + AC coverage" as A1
  component "PCA — physical configuration audit\ntag tree == approved PR head SHA" as A2
  component "Naming sweep\nnon-conforming branch -> Issue" as A3
}

package "Status surface — read-only, no artifact" as DASH {
  component "Dashboards\nGrafana / Metabase" as D1
  component "Branch / PR / tag / Issue graph" as D2
}

T1 --> T7 : config-as-code precedes baseline
T3 --> T4 : gate 1 read
T4 --> T5 : APPROVED only
T5 --> T6 : gate 2 read
T6 --> T7 : green only
T4 --> T8 : not APPROVED
T6 --> T8 : red
T9 --> T8 : naming violation
A1 --> T4
A2 --> T7
A3 --> T9
D1 --> D2 : queries directly
D2 --> T7
D2 --> T8

note right of T7
  A tag is written ONLY when both gates pass.
  Either gate fails -> Issue + HALT.
end note

note bottom of DASH
  The CM upserts NO status report artifact.
  Status is a query over the graph, kept
  queryable by consistent labels, branch
  names and tag names.
end note
@enduml
```

### Escalation discipline

Any gate failure yields an SCM issue with `severity:blocker` + `nature:defect` and a kind label (`gate:review`, `gate:ci`). A gate never fails silently.

```plantuml
@startuml
title Portal — Naming-Convention Violation Escalation

start
:CM sweeps branches\nscm_list_branches_with_label;
if (branch name matches a canonical pattern?) then (yes)
  :no action — convention holds;
  stop
else (no)
endif
:CM files an SCM issue\nscm_create_issue;
note right
  Labels: severity:minor
          nature:defect
          naming-violation
  The CM does NOT auto-rename the branch:
  renaming rewrites history another role
  is working on.
end note
:CM records the violation in the next\ntag message as a notable finding;
stop
@enduml
```

| Failure | Labels | Action |
|---|---|---|
| Iteration-close PR not `APPROVED` | `severity:blocker`, `nature:defect`, `gate:review` | Issue filed; **no tag written**; HALT until the Architect reviews. |
| `main` CI red after merge | `severity:blocker`, `nature:defect`, `gate:ci` | Issue filed; **no tag written**; HALT until green. |
| Non-conforming branch name | `severity:minor`, `nature:defect`, `naming-violation` | Issue filed; branch **not** renamed; recorded as a notable finding in the next tag message. |

## Status and Measurement

Status and measurement data — progress, aging, distribution, trends — flow to dashboards (Grafana / Metabase) that query the branch / PR / tag / Issue graph directly. The ConfigurationManager **upserts no status report artifact**. What it does is keep that graph queryable: consistent labels, consistent branch naming, consistent tag naming. A dashboard is only as good as the conventions it queries.

## Traceability

| Element | Traces From | Link Type | Traces To |
|---|---|---|---|
| Configuration item identification scheme | CON-001, CON-002, CON-003, CON-004, CON-007 | Derives | Implementation Model |
| Branch topology — `main` / `iteration/*` / `feature/*` / `hotfix/*` / `chore/*` | CON-011, CON-016 | Derives | Software Architecture Document |
| Elaboration mechanism branch `feature/E{n}-{risk-id}[-{mechanism}]` | R001, R003, R004, R006 | Derives | Architectural Proof-of-Concept |
| Construction feature branch `feature/C{n}-{uc-id}-{subject}` | FR-001, FR-002, FR-003, FR-004, FR-005, FR-006, FR-007, FR-008, FR-009, FR-010, FR-011, FR-012, FR-013, FR-014 | Derives | Design Model |
| Baseline tag `baseline-{phase}{n}-v{x}` | CON-011, NFR-004 | Derives | Release Notes |
| Pre-tag gate — APPROVED + CI green | NFR-004, AC-001, AC-002, AC-003, AC-004, AC-005 | Derives | Test Evaluation Summary |
| Change-control interface — CR to branch to baseline | CON-016 | Derives | Change Request |
| Naming-convention sweep and escalation | CON-011 | Derives | Change Request |
| Status surface — dashboards over the graph, no artifact | CON-011 | Derives | Iteration Plan |

**Not traced, and why.** `STK-001`..`STK-004` and `BG-001`..`BG-003` are consumed by the Vision and drive no configuration-management decision. `R002` (adoption) and `R005` (gate queue time) are Project Management concerns carried in the Risk List and the Iteration Plan; R005's 14-day gate ceiling is a planning constraint, not a branching one. `CON-005`, `CON-006`, `CON-008`, `CON-009`, `CON-010`, `CON-012`, `CON-013`, `CON-014`, `CON-015`, `CON-017`, `CON-018`, `CON-019`, `CON-020`, `CON-021`, `CON-022`, `CON-023`, `CON-024` and `NFR-001`..`NFR-003` are architectural and business-rule constraints discharged by the Software Architecture Document and the Design Model; they do not shape the branch topology, so no row is duplicated here.
