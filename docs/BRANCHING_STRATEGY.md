# Branching and Baseline Strategy — Portal

**Owner:** ConfigurationManager. **Status:** Inception, iteration 2.

This file is the configuration-management model of the project expressed as code. It defines what a
configuration item is, how branches and baselines are named, which gates a baseline must pass, who
decides a change, and how conformance is audited. It is documentation: it is committed direct to
`main`, never opened as a pull request.

## Configuration items

Six classes of configuration item are under version control. Everything the project produces falls
into one of them; anything that falls into none is not a configuration item and is not baselined.

```plantuml
@startuml
title Portal - Configuration items and their identification

package "CI-1 Source code - versioned by branch and commit" {
  [src/ .NET 10 solution\nCON-025] as SRC
  [Razor Pages views\nCON-026] as VIEWS
  [Migrations\nPostgreSQL 18, CON-027] as MIG
}

package "CI-2 Process artifacts - Markdown in SCM" {
  [16 CORE artifacts\nidentified by canonical name] as ART
  [Embedded PlantUML\ninside the artifact] as UML
}

package "CI-3 Configuration surface - placeholders only" {
  [OIDC issuer, client id, secret\nCON-031] as CFG_OIDC
  [LDAP host, bind account, base DN\nCON-031] as CFG_LDAP
}

package "CI-4 Test fixtures - the stand-ins" {
  [Test OIDC issuer] as STUB_OIDC
  [Test directory with empty\njob title and extension entries\nretires R001] as STUB_LDAP
}

package "CI-5 Build and CI definition" {
  [.github/workflows/ci.yml\nbuild and test only, never deploys\nCON-029] as CI
  [Portal.slnx and global.json\nsolution manifest and SDK pin] as MANIFEST
  [CONTRIBUTING.md and lint config\nnot yet created - Elaboration] as LINT
}

package "CI-6 Authoritative external input - read only" {
  [docs/inputs/employee-portal-design.html\nCON-034, never edited] as DESIGN
}

SRC --> MIG
VIEWS --> SRC
CFG_OIDC --> SRC : read at runtime, never in code
CFG_LDAP --> SRC : read at runtime, never in code
STUB_OIDC --> CFG_OIDC : substituted at deployment
STUB_LDAP --> CFG_LDAP : substituted at deployment
CI --> SRC : builds and tests
MANIFEST --> CI : the manifest CI builds
LINT --> SRC : governs
DESIGN --> VIEWS : authoritative for the visual layer
ART --> UML : contains

note bottom of CFG_OIDC
  Real values are Infrastructure's to insert
  at deployment. A real secret committed to
  the repository is a defect, not a shortcut.
end note

note bottom of MANIFEST
  Portal.slnx is a configuration item in its
  own right: a project missing from it compiles
  nothing, and a green build would then be a
  false statement about the code.
end note
@enduml
```

| CI class | Identification | Baseline unit |
|---|---|---|
| CI-1 Source code | file path + commit SHA | the commit the tag points to |
| CI-2 Process artifacts | canonical artifact name; every change is a commit | the commit the tag points to |
| CI-3 Configuration surface | key name in configuration; values are placeholders per CON-031 | the commit the tag points to |
| CI-4 Test fixtures | fixture path in the test tree | the commit the tag points to |
| CI-5 Build and CI definition | `.github/workflows/*`, `Portal.slnx`, `global.json`, `CONTRIBUTING.md`, lint config | the commit the tag points to |
| CI-6 Authoritative external input | `docs/inputs/employee-portal-design.html` | read-only; never edited, never re-baselined |

CI-3 and CI-4 are the pair that carries the project's integration risk. CON-031 makes the stand-ins
the team's entire integration surface, and the stand-in directory must carry entries whose job title
or extension is empty — those entries are what retire R001. A stand-in without them is a fixture
defect, not a test gap.

`Portal.slnx` is a configuration item in its own right, not a build detail. A project that exists
under `src/` or `tests/` but is absent from the manifest compiles nothing, and the build then reports
success about code it never read. The pipeline enforces the manifest against the source tree on every
run, so the manifest cannot drift silently.

## Branch topology

Three levels: work branches, integration workspaces, and `main`. Only the Integrator writes
`iteration/*` and `main`. No other role pushes to either.

```plantuml
@startuml
title Portal - Branch topology (workspace hierarchy)

package "Integration workspaces - written only by the Integrator" {
  [main\nprotected, always green] as MAIN
  [iteration/E n\nElaboration] as ITE
  [iteration/C n\nConstruction] as ITC
}

package "Work branches - one owner each" {
  [feature/I n - subject\nInception feasibility, rare] as FI
  [feature/E n - risk-id - mechanism\nElaboration architectural mechanism] as FE
  [feature/C n - uc-id - subject\nConstruction UC realization] as FC
  [hotfix/issue-id\nTransition] as HF
  [chore/subject\nCI and tooling maintenance] as CH
}

package "Baselines - tags on main only" {
  [baseline-elaboration-E n -v x] as TE
  [baseline-construction-C n -v x] as TC
  [baseline-transition-T n -v x] as TT
}

FI --> MAIN : PR, APPROVED
FE --> ITE : PR, APPROVED
FC --> ITC : PR, APPROVED
ITE --> MAIN : iteration-close PR, APPROVED
ITC --> MAIN : iteration-close PR, APPROVED
HF --> MAIN : express review
CH --> MAIN : PR, reviewed
MAIN --> TE
MAIN --> TC
MAIN --> TT

note bottom of MAIN
  Documentation and config-as-code (this file, README)
  commit direct to main. Source, CI workflow and
  tooling changes go through a PR.
end note
@enduml
```

### Naming conventions

| Branch | Pattern | Base | Merges into |
|---|---|---|---|
| Inception feasibility | `feature/I{n}-{subject}` | `main` | `main` via PR |
| Elaboration mechanism | `feature/E{n}-{risk-id}[-{mechanism}]` | `iteration/E{n}` | `iteration/E{n}` via PR |
| Construction feature | `feature/C{n}-{uc-id}-{subject}` | `iteration/C{n}` | `iteration/C{n}` via PR |
| Integration workspace | `iteration/E{n}` \| `iteration/C{n}` | `main` | `main` via iteration-close PR |
| Transition hotfix | `hotfix/{issue-id}` | `main` | `main`, express review |
| Maintenance | `chore/{subject}` | `main` | `main` via PR |

A branch that matches no pattern is surfaced as an SCM issue labelled `severity:minor` +
`nature:defect` + `naming-violation`. It is never renamed in place: renaming rewrites history that
other roles may already reference.

### Per-phase model

- **Inception — documentation only.** No implementation code. A feasibility mechanism, if genuinely
  required to reduce risk, is built evolutionarily in `src/` on `feature/I{n}-{subject}` — never as
  throwaway sample code. This iteration requires none: the declared risks are retired by testing
  against stand-ins (CON-031), not by a prototype.
- **Elaboration — evolutionary architectural mechanism.** The architectural prototype becomes the
  Construction baseline; it is not throwaway. A technical risk is retired either by analysis (the
  SoftwareArchitect reasons feasibility, no code) or by building the real mechanism in `src/` on
  `feature/E{n}-{risk-id}[-{mechanism}]` based on `iteration/E{n}`. The Architect records the choice
  as a process fact — `analysis-only`, `single-mechanism` or `candidates`. The Code Reviewer opens and
  reviews each mechanism PR as production code; the Integrator merges the APPROVED mechanism into
  `iteration/E{n}`. For competing candidates the Architect selects the winner and the Integrator
  closes the loser's PR. At LAM close the Integrator opens `iteration/E{n} → main`. There is no
  `samples/poc/` directory and no ephemeral `poc/*` branch.
- **Construction — feature branches.** UC realizations on `feature/C{n}-{uc-id}-{subject}` based on
  `iteration/C{n}`. The Code Reviewer reviews, the Integrator merges APPROVED into `iteration/C{n}`
  and opens `iteration/C{n} → main` at IOC.
- **Transition — hotfixes.** `hotfix/{issue-id}` from `main`, express review, merge to `main` with a
  patch baseline tag.

### Cross-phase invariants

1. Only the Integrator writes `iteration/*` and `main`.
2. `ready-for-review` is the Implementer → Code Reviewer handoff label. A branch carrying it and no
   pull request is waiting for one.
3. A baseline tag freezes only an APPROVED and CI-green commit.
4. Documentation and config-as-code commit direct to `main`; source, CI workflow and tooling changes
   go through a pull request.

## Baselines

One baseline per iteration close, never mid-iteration. A tag is defensible only when both gates pass.

### Baseline register

```plantuml
@startuml
title Portal - Baseline register: the tag series and what each one freezes

state "Inception - no tag" as INC {
  INC : documentation and config-as-code only
  INC : no iteration-close PR exists to gate on
  INC : the tag family has no Inception member
}

state "Elaboration iteration 1" as E1 {
  E1 : baseline-elaboration-E1-v1
  E1 : freezes the first evolutionary mechanism
}

state "Elaboration iteration n" as EN {
  EN : baseline-elaboration-En-v1
}

state "Construction iteration 1" as C1 {
  C1 : baseline-construction-C1-v1
  C1 : freezes the first UC realizations
}

state "Construction iteration n" as CN {
  CN : baseline-construction-Cn-v1
}

state "Transition release" as T1 {
  T1 : baseline-transition-T1-v1
  T1 : handover to Infrastructure (CON-032)
}

[*] --> INC
INC --> E1 : LAM close, both gates pass
E1 --> EN : next Elaboration iteration
EN --> C1 : LCA close, both gates pass
C1 --> CN : next Construction iteration
CN --> T1 : Project Acceptance
T1 --> [*]

note right of INC
  A patch version is written only after a
  rollback or a post-baseline critical fix.
  Routine work targets the NEXT tag.
end note

note bottom of T1
  Every tag in this series points to a commit
  whose iteration-close PR was APPROVED and
  whose post-merge main build was green.
end note
@enduml
```

| Tag | Written at | What it freezes |
|---|---|---|
| `baseline-elaboration-E{n}-v{x}` | Elaboration iteration close (LAM) | the evolutionary architectural mechanism merged into `iteration/E{n}` |
| `baseline-construction-C{n}-v{x}` | Construction iteration close (IOC) | the UC realizations merged into `iteration/C{n}` |
| `baseline-transition-T{n}-v{x}` | Transition release | the release handed to Infrastructure (CON-032) |

`x` starts at 1 and is incremented only after a rollback or a post-baseline critical fix applied to
the iteration branch. Routine iteration work targets the next iteration's tag, not a re-tag of the
previous one.

### Pre-tag gate

```plantuml
@startuml
title Portal - Baseline pedigree: the pre-tag gate

[*] --> IterationWork
state "Iteration work in progress" as IterationWork {
  IterationWork : feature branches merged into iteration/Cn
  IterationWork : no tag is written mid-iteration
}
IterationWork --> ClosePR : Integrator opens iteration/Cn to main
state "Iteration-close PR open" as ClosePR
ClosePR --> ReviewGate : scm_get_pull_request_review_state
state "Review gate" as ReviewGate <<choice>>
ReviewGate --> Blocked : CHANGES_REQUESTED or NONE
ReviewGate --> Merge : APPROVED
state "Blocked - no tag" as Blocked {
  Blocked : scm_create_issue severity:blocker nature:defect
  Blocked : HALT until the review is resolved
}
state "Integrator merges to main" as Merge
Merge --> CIGate : scm_get_build_status main
state "CI gate on main" as CIGate <<choice>>
CIGate --> Red : red or pending
CIGate --> Tag : green
state "Red - no tag" as Red {
  Red : scm_create_issue severity:blocker nature:defect
  Red : HALT until main is green
}
state "Write baseline tag" as Tag {
  Tag : scm_create_tag baseline-phase n -v x
  Tag : message carries PR number, head SHA,
  Tag : approval review id, CI run URL, findings
}
Tag --> [*]
Blocked --> [*]
Red --> [*]

note right of Tag
  A tag is defensible only when both gates
  passed. Re-tagging with a higher patch
  number requires a rollback or a
  post-baseline critical fix.
end note
@enduml
```

### Tag message contract

The tag message is the audit record. It carries the iteration-close PR number and head commit SHA,
the Architect approval review id, the `main` CI run URL at tag time, and any notable finding — a
naming violation, a deferred item, a re-tag justification. A tag message reading only the word
baseline is a defect: it claims a pedigree it does not evidence.

## Change control

### Change Control Board

```plantuml
@startuml
title Portal - Change Control Board: decision rights and the CM / CCM boundary

package "Change Control Board" {
  class "STK-001 Laura Gomez\nHR Director, project sponsor\nscope and acceptance authority" as CCB1
  class "SoftwareArchitect\narchitectural impact" as CCB2
  class "ProjectManager\nschedule and risk impact" as CCB3
  class "ChangeControlManager\nchair, records the decision" as CCB4
}

package "Decides - CCB only" {
  class "Change to declared scope\nadd, cut or defer a FR, NFR, CON, AC" as D1
  class "Change to a constraint\nCON-001 to CON-036" as D2
  class "Change to a tagged baseline\nre-tag, rollback, patch version" as D3
  class "New OPTIONAL artifact trigger" as D4
}

package "Does not decide - lightweight control" {
  class "A code change inside declared scope\npull request review" as L1
  class "A documentation or config-as-code change\ndirect commit to main" as L2
  class "A defect correction against an\nopen finding" as L3
}

package "ConfigurationManager" {
  class "Verifies both gates at iteration close" as CM1
  class "Writes the baseline tag" as CM2
  class "Files gate-failure and naming issues" as CM3
  class "Does NOT triage a CR\nDoes NOT vote on the CCB" as CM4
}

CCB1 --> D1
CCB1 --> D2
CCB2 --> D2
CCB3 --> D3
CCB4 --> D1
CCB4 --> D2
CCB4 --> D3
CCB4 --> D4
D1 --> CM2 : authorises the branch\nand the PR it produces
D3 --> CM2
L1 --> CM1
L2 --> CM1
L3 --> CM1
CM1 --> CM2
CM3 --> CCB4 : escalates a gate failure

note bottom of CM4
  The CM consumes CCB decisions through the
  branches and pull requests they authorise.
  Triaging a CR is the CCM's work; a CM that
  triages one has taken a decision it does
  not own.
end note

note bottom of L1
  A pull request is the lightweight change
  control for a code configuration item.
  The CCB is reserved for scope, constraints
  and already-tagged baselines.
end note
@enduml
```

| Decision | Authority | Record |
|---|---|---|
| Add, cut or defer a declared FR, NFR, CON, AC or BG | STK-001, on the ChangeControlManager's recommendation | the Change Request issue |
| Change a constraint (CON-001 to CON-036) | STK-001 with the SoftwareArchitect's impact assessment | the Change Request issue |
| Re-tag, roll back, or increment a baseline patch version | ChangeControlManager with the ProjectManager | the tag message |
| Fire an OPTIONAL artifact trigger | ChangeControlManager, recorded in the Development Case | the Development Case |
| Merge a code change inside declared scope | CodeReviewer, by pull request approval | the pull request |
| Commit a documentation or config-as-code change | the owning role, direct to `main` | the commit |

The board is convened only for the first four rows. The last two are lightweight control and do not
reach it.

### Lightweight control for code

```plantuml
@startuml
title Portal - Change control flow: lightweight control for code, CCB for scope

|ChangeControlManager|
start
:Issue raised as a Change Request;
:Triage and impact analysis;
:Convene the CCB where the change
:touches scope, a constraint or a tag;
:cr:new to cr:approved;
note right
  The CCM owns the CR state machine
  and chairs the CCB. The
  ConfigurationManager does not
  triage a CR and does not vote.
end note

|Implementer|
:Create branch per the naming convention;
:Commit work, label ready-for-review;

|CodeReviewer|
:Open and review the pull request;
:APPROVED or CHANGES_REQUESTED;

|Integrator|
if (review state APPROVED?) then (yes)
  :Merge into iteration/Cn;
else (no)
  :Return to Implementer;
  stop
endif

|ConfigurationManager|
:At iteration close, verify both gates;
:Write the baseline tag;
:CR reaches cr:complete;

|ChangeControlManager|
:Close the Change Request;
stop
@enduml
```

A pull request is the lightweight change control for a code configuration item. The CCB is reserved
for changes to declared scope, to a constraint, or to a baseline already tagged.

### CM / CCM boundary

The ChangeControlManager owns the Change Request state machine and chairs the CCB. The
ConfigurationManager consumes those decisions through the branches and pull requests they authorize,
and does not triage change requests, does not vote, and does not close a CR.

## Audit procedures

```plantuml
@startuml
title Portal - Configuration status accounting: the audits and what each reads

package "Audits run at every iteration close" {
  class "A1 Baseline pedigree\nDid every commit in this tag come\nfrom an APPROVED PR and a green build?" as A1
  class "A2 Naming conformance\nDoes every branch and tag match\nthe published patterns?" as A2
  class "A3 Configuration surface\nIs any real credential or host\nin the repository?" as A3
  class "A4 Stand-in fidelity\nDoes the test directory carry the\nempty job-title and extension entries?" as A4
  class "A5 Trace integrity\nDoes every element trace to a\ndeclared identifier?" as A5
  class "A6 Manifest integrity\nDoes Portal.slnx reference every\nproject under src/ and tests/?" as A6
}

package "Evidence each audit reads" {
  class "scm_get_pull_request_review_state\nscm_get_build_status" as E1
  class "scm_list_branches_with_label\nbranch and tag names" as E2
  class "CI-3 diff review" as E3
  class "CI-4 diff review against\nCON-031 and R001" as E4
  class "the trace graph" as E5
  class "the pipeline manifest guard" as E6
}

package "Output - Git-native, never a report artifact" {
  class "the baseline tag message" as O1
  class "a naming-violation issue\nseverity:minor nature:defect" as O2
  class "a blocker issue\nseverity:blocker nature:defect" as O3
  class "the dashboards that query the\nbranch, PR, tag and issue graph" as O4
}

A1 --> E1
A2 --> E2
A3 --> E3
A4 --> E4
A5 --> E5
A6 --> E6
A1 --> O1
A1 --> O3
A2 --> O2
A3 --> O3
A4 --> O3
A5 --> O3
A6 --> O3
O1 --> O4
O2 --> O4
O3 --> O4

note bottom of O4
  No status report artifact is produced.
  Progress, aging, distribution and trend
  are read from the graph by dashboards.
end note

note bottom of A1
  A1, A3 and A6 are the audits that can block
  a tag. A2, A4 and A5 raise issues; they do
  not stop the iteration from closing.
end note
@enduml
```

| Audit | Question it answers | Mechanism | Blocks a tag |
|---|---|---|---|
| A1 Baseline pedigree | Did every commit in this tag come from an APPROVED PR and a green build? | the two gates above, recorded in the tag message | Yes |
| A2 Naming conformance | Does every branch and tag match the conventions? | `scm_list_branches_with_label` sweep each iteration close; violations filed as `naming-violation` issues | No |
| A3 Configuration surface | Is any real credential or host in the repository? | review of CI-3 changes; a real value committed is a defect | Yes |
| A4 Stand-in fidelity | Does the test directory carry the empty job title and extension entries? | review of CI-4 changes against CON-031 and R001 | No |
| A5 Trace integrity | Does every element trace to a declared identifier? | artifact review; the trace graph is the record | No |
| A6 Manifest integrity | Does the solution manifest reference every project under `src/` and `tests/`? | the pipeline's manifest guard, on every run | Yes |

Status and measurement data — progress, aging, distribution, trends — is read from the branch, pull
request, tag and issue graph by dashboards. No status report artifact is produced.

## Tooling

| Capability | Tool | State |
|---|---|---|
| Version control | hosted SCM provider (CON-029) | available |
| Build and test CI | `.github/workflows/ci.yml` on the hosted provider | committed and green on `main`; build and test only, never deploys (CON-029) |
| Solution manifest and SDK pin | `Portal.slnx`, `global.json` (SDK 10.0.100, rollForward latestFeature) | committed; the pipeline fails if a project under `src/` or `tests/` is missing from the manifest |
| Build | .NET 10 SDK (CON-025) | available |
| Database | PostgreSQL 18 (CON-027) | available |
| Modeling | Markdown with embedded PlantUML in SCM | available; no modeling tool procured |
| Identity and directory stand-ins | team-built per CON-031 | not yet created — Elaboration |
| Test framework | not declared by the stakeholder | gap — TestManager selects it in Elaboration |
| `CONTRIBUTING.md` and lint configuration | not yet created | gap — Elaboration |

CI covers all branch families — `main`, `iteration/**`, `feature/**`, `chore/**`, `hotfix/**` — on
both push and pull request, runs build and test only, and never deploys (CON-029). Deployment is
Infrastructure's (CON-032).

## Inception status

No baseline tag is written in Inception. The architecture is not stable, no iteration-close pull
request exists to gate on, and the tag family itself has no Inception member — the first tag this
project writes is `baseline-elaboration-E1-v1`, at the Elaboration iteration close.

The pipeline is live. The build observed on `main` at the moment of writing is run `39940359296`,
success, 2026-10-23 10:36:57Z to 10:37:48Z. It builds one web project and one test project — a
skeleton — so a green result proves the pipeline runs and the manifest guard holds, not that the
product works. The CI gate becomes a real gate on a baseline when the first mechanism lands in
Elaboration.
