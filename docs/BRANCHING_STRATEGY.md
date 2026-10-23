# Branching and Baseline Strategy — Portal

**Owner:** ConfigurationManager. **Status:** Inception baseline, iteration 1.

This file is the configuration-management model of the project expressed as code. It defines what a
configuration item is, how branches and baselines are named, which gates a baseline must pass, and
where the boundary with change control sits. It is documentation: it is committed direct to `main`,
never opened as a pull request.

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
  [.github/workflows\nbuild and test only, never deploys\nCON-029] as CI
  [CONTRIBUTING.md and lint config] as LINT
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
LINT --> SRC : governs
DESIGN --> VIEWS : authoritative for the visual layer
ART --> UML : contains

note bottom of CFG_OIDC
  Real values are Infrastructure's to insert
  at deployment. A real secret committed to
  the repository is a defect, not a shortcut.
end note
@enduml
```

| CI class | Identification | Baseline unit |
|---|---|---|
| CI-1 Source code | file path + commit SHA | the commit the tag points to |
| CI-2 Process artifacts | canonical artifact name; every change is a commit | the commit the tag points to |
| CI-3 Configuration surface | key name in configuration; values are placeholders per CON-031 | the commit the tag points to |
| CI-4 Test fixtures | fixture path in the test tree | the commit the tag points to |
| CI-5 Build and CI definition | `.github/workflows/*`, `CONTRIBUTING.md`, lint config | the commit the tag points to |
| CI-6 Authoritative external input | `docs/inputs/employee-portal-design.html` | read-only; never edited, never re-baselined |

CI-3 and CI-4 are the pair that carries the project's integration risk. CON-031 makes the stand-ins
the team's entire integration surface, and the stand-in directory must carry entries whose job title
or extension is empty — those entries are what retire R001. A stand-in without them is a fixture
defect, not a test gap.

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

### Tag naming

`baseline-{phase}{n}-v{x}` — phase is `elaboration`, `construction` or `transition`; `n` is the
iteration or release number; `x` starts at 1.

| Tag | Written at |
|---|---|
| `baseline-elaboration-E{n}-v{x}` | Elaboration iteration close (LAM) |
| `baseline-construction-C{n}-v{x}` | Construction iteration close (IOC) |
| `baseline-transition-T{n}-v{x}` | Transition release |

`x` is incremented only after a rollback or a post-baseline critical fix applied to the iteration
branch. Routine iteration work targets the next iteration's tag, not a re-tag of the previous one.

### Tag message contract

The tag message is the audit record. It carries the iteration-close PR number and head commit SHA,
the Architect approval review id, the `main` CI run URL at tag time, and any notable finding — a
naming violation, a deferred item, a re-tag justification. A tag message reading only `baseline` is a
defect: it claims a pedigree it does not evidence.

## Change control

The ChangeControlManager owns the Change Request state machine and the CCB decisions. The
ConfigurationManager consumes those decisions through the branches and pull requests they authorize
and does not triage change requests.

```plantuml
@startuml
title Portal - Change control flow and the CM / CCM boundary

|ChangeControlManager|
start
:Issue raised as a Change Request;
:Triage, impact analysis, CCB decision;
:cr:new to cr:approved;
note right
  The CCM owns the CR state machine
  and the CCB decision. The
  ConfigurationManager does not
  triage CRs and does not decide.
end note

|Implementer|
:Create branch per the naming convention;
:Commit work, label ready-for-review;

|CodeReviewer|
:Open and review the PR;
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

## Audit procedures

| Audit | Question it answers | Mechanism |
|---|---|---|
| Baseline pedigree | Did every commit in this tag come from an APPROVED PR and a green build? | the two gates above, recorded in the tag message |
| Naming conformance | Does every branch and tag match the conventions? | `scm_list_branches_with_label` sweep each iteration close; violations filed as `naming-violation` issues |
| Configuration surface | Is any real credential or host in the repository? | review of CI-3 changes; a real value committed is a defect |
| Stand-in fidelity | Does the test directory carry the empty job title and extension entries? | review of CI-4 changes against CON-031 and R001 |
| Trace integrity | Does every element trace to a declared identifier? | artifact review; the trace graph is the record |

Status and measurement data — progress, aging, distribution, trends — is read from the branch, pull
request, tag and issue graph by dashboards. No status report artifact is produced.

## Tooling

| Capability | Tool | State |
|---|---|---|
| Version control | hosted SCM provider (CON-029) | available |
| Build and test CI | `.github/workflows` on the hosted provider | not yet created — Elaboration, owned by ConfigurationManager with Implementer |
| Build | .NET 10 SDK (CON-025) | available |
| Database | PostgreSQL 18 (CON-027) | available |
| Modeling | Markdown with embedded PlantUML in SCM | available; no modeling tool procured |
| Identity and directory stand-ins | team-built per CON-031 | not yet created — Elaboration |

CI covers all branch families, runs build and test only, and never deploys (CON-029). Deployment is
Infrastructure's (CON-032).

## Inception status

No baseline tag is written in Inception. The architecture is not stable, no CI workflow exists yet,
and there is no iteration-close pull request to gate on. The first tag this project writes is
`baseline-elaboration-E1-v1`, at the Elaboration iteration close, once both gates can actually be
evaluated.
