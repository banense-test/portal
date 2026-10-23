## Document Control
- **Phase:** Inception
- **Status:** Draft — iteration 3, submitted for review
- **Milestone Target:** End of Inception (not yet achieved)
## Tailoring Overview
This document is a **delta over the IARI Development Case baseline**. The baseline supplies the
25-role roster, the 9 disciplines, the 16 CORE and 6 OPTIONAL artifacts, the ownership allowlist and
the canonical intensity matrix. None of that is restated or redefined here. What follows is only what
this project changes, and why.

**No structural plug-in is applied.** No role is added, merged or removed; no CORE artifact is
omitted; no primary ownership is reassigned. Five thin plug-ins are applied — they substitute content
and add project guidance without altering the process shape.

```plantuml
@startuml
title Portal — Process configuration architecture (thin plug-ins only)

package "RUP Library" {
  [Full discipline, role and artifact library] as LIB
}
package "IARI DC Baseline — inherited, never redefined" {
  [25 roles / 9 disciplines / 16 CORE + 6 OPTIONAL] as BASE
}
package "Thin plug-ins applied by this project" {
  [P1 Business Modeling INACTIVE] as P1
  [P2 OPTIONAL trigger decisions] as P2
  [P3 Project tool and guideline references] as P3
  [P4 Measurement policy] as P4
  [P5 Authoring checks C1 to C9] as P5
}
package "Portal Development Case — this artifact" {
  [Delta over the baseline] as DC
}

LIB --> BASE : subset selection
BASE --> P1
BASE --> P2
BASE --> P3
BASE --> P4
BASE --> P5
P1 --> DC
P2 --> DC
P3 --> DC
P4 --> DC
P5 --> DC

note bottom of DC
  No structural plug-in is applied: no role is merged,
  added or removed; no CORE artifact is omitted;
  no ownership is reassigned.
end note
@enduml
```
## Disciplines and Intensity
**All active disciplines: intensity per canonical matrix.** No deviation is proposed and none is
self-granted.

**Inactive discipline — Business Modeling.** Declared INACTIVE for this project. The portal automates
discrete administrative tasks that the stakeholder declared directly as system use cases FR-001 to
FR-015. There is no business process to model: no business actors, no business workers, no process
re-engineering, and no business use case anywhere in the declared scope. BusinessProcessAnalyst and
BusinessReviewer therefore receive no assignment this cycle. This is a thin plug-in — it removes no
role from the roster and changes no workflow structure.

**Environment.** One-time at project start, per the baseline. This document is its output. The
recurring part — the per-iteration readiness checkpoint — is described in Guidelines and Procedures.

**Real-time-system trigger: not fired.** NFR-004's one-second clocking response is a performance
target, not a hard deadline. FR-013's retry is a bounded client-side retry loop, not reactive
event-driven behaviour. CON-010's single-featured-item rule is a data invariant enforced in the
service layer. No capsule, no concurrent state machine, no timing invariant — CapsuleDesigner
receives no assignment.

**A discipline at Medium or Low intensity is active, not idle.** Inception runs Analysis and Design
at Medium and Test at Low. Neither is a rest state: the Software Architecture Document and the Test
Evaluation Summary are both CORE artifacts produced in Inception, and both were produced in iteration
1. Reading a Low or Medium intensity as "no work this phase" is what caused `Iteration Plan#F1`
(Reviewer), where two producing roles were marked idle and two produced artifacts had no work item.

**A plan is derived from the artifact set, not from the discipline sequence.** The workflow diagram
below orders the disciplines; it does not enumerate the work. An iteration plan is built by listing
the artifacts that iteration will produce, assigning each to its owning role, and placing each in the
critical chain — then checking the result against this diagram for ordering, never deriving the list
from it. The diagram answers "in what order"; only the artifact set answers "what".

```plantuml
@startuml
title Portal - Discipline workflow and artifact flow

|Environment|
start
:Assess organization and toolchain;
:Select process subset - this Development Case;
:Record DC classification, optional triggers, version policy;
if (Environment ready for the iteration?) then (yes)
  :Release iteration start;
else (no)
  :Fix toolchain or template gap;
  :Release iteration start;
endif

|Requirements|
:Vision;
:Use-Case Model - one UC per declared FR;
:Supplementary Specification - NFR and CON;

|Analysis and Design|
:Software Architecture Document - COMP;
:Design Model - CLS, INT, SEQ, tables inline;

|Implementation|
:Implementation Model;
:Code and tests against stand-ins (CON-031);

|Test|
:Test Case - TC;
:Test Evaluation Summary;

|Deployment|
:Release Notes;
:Handover to Infrastructure (CON-032);

|Project Management|
:Iteration Plan, Risk List, Iteration Assessment;

|Environment|
:Read Iteration Assessment;
:Revise Development Case where a finding demands it;
stop
@enduml
```

Disciplines are pipelined within an iteration, not run as a waterfall: Requirements, Analysis and
Design, Implementation and Test overlap, while Project Management and CM run alongside all of them.
The diagram shows ordering, not workload — see the two rules above.
## Artifacts and Templates
**All 16 CORE artifacts are produced. None is omitted, deferred or downgraded.** The table records
only the project-specific format note for each; ownership is in Roles and Ownership.

| CORE artifact | Project format note |
|---|---|
| Vision | Derived from the declared scope; carries FR, NFR, CON, BG, STK, AC and R identifiers as assigned |
| Use-Case Model | One UC per declared FR-001 to FR-015. Multi-actor on the same declared process is one UC with several scenarios. Authentication (NFR-001) is a Supplementary Specification mechanism with `<<include>>`, never a UC |
| Supplementary Specification | Carries the 5 NFRs and the 36 constraints. This is the constraint-conformance record — the densest artifact of the project |
| Software Architecture Document | Carries COMP identifiers and the deployment section (see Optional Artifact Triggers). Must place Keycloak inside the corporate network per CON-028 |
| Design Model | Carries ACL, CLS, INT, SEQ and the data tables inline (see Optional Artifact Triggers). Co-owned: Designer, UserInterfaceDesigner, DatabaseDesigner each write their own sections |
| Implementation Model | Reverse-engineered from the repository; records the stand-in configuration surface (CON-031) |
| Test Case | TC identifiers. Must cover the empty-attribute directory entries whose passing test retires R001, and the FR-013 retry path |
| Test Evaluation Summary | Per iteration |
| User Documentation | Employee-facing and HR-facing. Must not describe a self-service correction screen (CON-017) or an audit view screen (NFR-005) |
| Release Notes | Per release; handover-oriented for Infrastructure (CON-032) |
| Iteration Plan | Defines per-iteration testing scope, since no Test Plan exists |
| Iteration Assessment | Carries the measured token spend and the two-clock elapsed time |
| Risk List | R001 and R002 carried with their declared identifiers and magnitudes, never renumbered or reclassified. Team-identified risks are numbered R003 onwards in the order raised (CON-023) |
| Review Record | Concrete findings only, one per defect, with severity and verdict |
| Development Case | This document |
| Change Request | Per-iteration audit narrative from Construction onwards; SCM issues carry the live state |

**Templates.** No template files are procured. Each artifact's canonical section skeleton, as
published by the artifact service, is the template. This is a deliberate tailoring decision: a
separate template repository would be a second source of truth that drifts from the skeleton the
service actually enforces.

**Project tool and guideline references.** This document references, and does not author, the
following. Each is owned by the discipline role named:

| Reference | Owner | State |
|---|---|---|
| `CONTRIBUTING.md` | SoftwareArchitect with Implementer | Not yet created — Elaboration |
| Lint and format configuration | Implementer | Not yet created — Elaboration |
| `.github/workflows` (build and test CI) | ConfigurationManager with Implementer | Not yet created — Elaboration |
| `docs/inputs/employee-portal-design.html` | Stakeholder-declared, authoritative (CON-034) | Committed with the project inputs |
## Optional Artifact Triggers

**No OPTIONAL artifact trigger fires for this project.** All six are recorded NOT TRIGGERED, each
against its baseline condition. This set is re-evaluated every iteration — a Change Request may
newly fire one.

| OPTIONAL artifact | Verdict | Why the trigger does not hold |
|---|---|---|
| Glossary | NOT TRIGGERED | The domain is internal HR administration, not regulated, legal, medical or financial. Every specialist term the project uses is already defined by a constraint: worker category by CON-009 (closed four-value list), clocking pair by CON-011, EmployeeId by CON-004. Terminology is defined inline in the Supplementary Specification; a separate stakeholder-validated glossary would duplicate it |
| Architectural Proof-of-Concept | NOT TRIGGERED | The phase condition (Elaboration) is not met. Substantively, neither declared risk needs empirical validation: R001 is retired by testing against a stand-in directory that carries empty job title and extension entries (CON-031), and R002 is an adoption risk with no architectural mechanism. Validation against the real Keycloak and AD is human work by Infrastructure and HR, not a team PoC. Re-evaluated in Elaboration |
| Data Model | NOT TRIGGERED | Not a data-centric system, fewer than 10 entities, and CON-033 declares no data migration. The entities are clocking, clocking correction, news item, worker-category link and audit entry. CON-021 fixes the worker-category table at two columns. Data design lives inline in the Design Model |
| Deployment Model | NOT TRIGGERED | Single internal Windows Server estate, no cloud, no containers, no clustering or load balancing declared, no migration. Deployment is a section of the Software Architecture Document — which is where CON-028's requirement that Keycloak sit inside the corporate network is enforced |
| User-Interface Prototype | NOT TRIGGERED | The stakeholder has already supplied the authoritative UI design at `docs/inputs/employee-portal-design.html`, mandatory for the visual layer per CON-034. A prototype exists to obtain validation the project already holds; building a second one would create a competing source of truth |
| Test Plan | NOT TRIGGERED | No formal delivery, regulatory audit or contractual test reporting. NFR-005 states no external compliance regime applies and no retention period is mandated. Per-iteration testing scope is defined in the Iteration Plan |

## Roles and Ownership

**The 25-role roster is inherited unchanged. Primary ownership is per the service-side allowlist and
is not reassigned.** This section records only which roles are active this cycle and what each
contributes.

**Active roles (22).** All roles in Requirements, Analysis and Design, Implementation, Test,
Deployment, Configuration and Change Management, Project Management, Environment, and Review and
Documentation receive assignment.

**Idle roles (3) — trigger not fired, not removed from the roster:**

| Role | Why idle |
|---|---|
| BusinessProcessAnalyst | Business Modeling is inactive — no business process, business actor or business use case in the declared scope |
| BusinessReviewer | Same — there is no business model to review |
| CapsuleDesigner | No real-time capsule: no hard deadline, no concurrent state machine, no timing invariant |

**Project contribution notes.** Three contribution patterns are specific to this project and are
worth stating because they are where the process most often goes wrong:

- **The Software Architect owns the constraint-conformance argument.** With 36 constraints, the SAD
  is where each architectural constraint (CON-001, CON-002, CON-021, CON-025, CON-026, CON-027,
  CON-028, CON-034, CON-036) is shown to be satisfied. A constraint that appears in no SAD section is
  an unproven constraint.
- **The Database Designer owns the audit trail's physical shape.** NFR-005 requires that corrections
  never overwrite in place (CON-013) and that news is never deleted (CON-014). Those are schema
  decisions, not prose decisions.
- **The TechnicalWriter must not document what the scope excludes.** No self-service correction
  screen (CON-017), no audit view screen (NFR-005), no news archive screen, no permission
  administration screen (CON-008). User Documentation that describes an excluded screen is a defect.

```plantuml
@startuml
title Portal - Roles and the CORE artifacts they contribute to

package "Requirements" {
  class "SystemAnalyst" as SA
  class "RequirementsSpecifier" as RS
  class "Vision" as VIS <<artifact>>
  class "Use-Case Model" as UCM <<artifact>>
  class "Supplementary Specification" as SS <<artifact>>
}
package "Analysis and Design" {
  class "SoftwareArchitect" as SWA
  class "Designer" as DES
  class "UserInterfaceDesigner" as UID
  class "DatabaseDesigner" as DBD
  class "Software Architecture Document" as SAD <<artifact>>
  class "Design Model" as DM <<artifact>>
}
package "Implementation" {
  class "Implementer" as IMP
  class "Integrator" as INT
  class "Implementation Model" as IM <<artifact>>
}
package "Test" {
  class "TestManager" as TM
  class "TestAnalyst" as TA
  class "TestDesigner" as TD
  class "Tester" as TE
  class "Test Case" as TC <<artifact>>
  class "Test Evaluation Summary" as TES <<artifact>>
}
package "Deployment" {
  class "DeploymentManager" as DEP
  class "Release Notes" as RN <<artifact>>
}
package "Project Management" {
  class "ProjectManager" as PM
  class "Iteration Plan" as IP <<artifact>>
  class "Iteration Assessment" as IA <<artifact>>
  class "Risk List" as RL <<artifact>>
}
package "CM and Change Management" {
  class "ConfigurationManager" as CMG
  class "ChangeControlManager" as CCM
  class "Change Request" as CR <<artifact>>
}
package "Review and Documentation" {
  class "Reviewer" as REV
  class "ReviewCoordinator" as RC
  class "ManagementReviewer" as MR
  class "CodeReviewer" as CRV
  class "TechnicalWriter" as TW
  class "Review Record" as RR <<artifact>>
  class "User Documentation" as UD <<artifact>>
}
package "Environment" {
  class "ProcessEngineer" as PE
  class "Development Case" as DC <<artifact>>
}
package "Idle - trigger not fired" {
  class "BusinessProcessAnalyst" as BPA
  class "BusinessReviewer" as BRV
  class "CapsuleDesigner" as CAP
}

SA --> VIS
SA --> UCM
RS --> SS
SWA --> SAD
DES --> DM
UID --> DM
DBD --> DM
IMP --> IM
INT --> IM
TM --> TES
TA --> TC
TD --> TC
TE --> TC
DEP --> RN
PM --> IP
PM --> IA
PM --> RL
CMG --> IM
CCM --> CR
REV --> RR
RC --> RR
MR --> RR
CRV --> RR
TW --> UD
PE --> DC
@enduml
```

## Guidelines and Procedures
### Measurement policy

The baseline measures two quantities and only two: tokens consumed, and elapsed time split into agent
time and human queue time. This section states what **this project** does with them — the decision
each one enables and who reads it. A quantity with no named decision is not collected.

| Quantity | Decision it enables | Read by |
|---|---|---|
| Tokens consumed per iteration | Whether the live-artifact surface is growing faster than the work it enables. Cost in this process scales with artifact surface × times read, not with lines emitted. If spend rises across iterations while the milestone has not passed, that is the schedule-slip signal, and the response is to **replace** an artifact or section rather than re-read it — never to cut declared scope | ProcessEngineer, for the process-weight review; ProjectManager, for the Iteration Assessment |
| Agent time per iteration | Iteration length. Agent time is the working clock; it is not converted into a date | ProjectManager |
| Human queue time per iteration | Whether the CON-031 validation gate is holding the iteration. Queue time is waiting, not working, and is reported apart from agent time — the two clocks are never added | ProjectManager, for escalation; ReviewCoordinator, at the milestone gate |

**No token budget or cap exists for this project, and none is set by the team (CON-030).** Each
iteration's measured spend is recorded and used to forecast the next. Declared scope is never cut or
deferred to fit an estimate.

**The human validation gate is a risk, not an estimate.** CON-031 places validation against the real
Keycloak and the real AD in the hands of Infrastructure and HR, with feedback required before
Elaboration closes. That gate is bounded at a ceiling of 14 days of queue time. If it is exceeded the
process **suspends** — nothing is auto-filled, no date is projected, and the ProjectManager escalates.
The remedy for a delayed gate is another iteration, not a scope reduction (CON-023). Its actual
duration is measured and reported apart from agent time.

### Version policy

The enterprise version policy is recorded and governs over any registry "latest". The Software
Architect anchors it in the Software Architecture Document; the Process Engineer does not resolve or
verify versions against a registry.

| Ecosystem | Package | Pinned | Basis |
|---|---|---|---|
| framework | .NET | 10 | CON-025 — backend is .NET 10 with a REST API |
| framework | PostgreSQL | 18 | CON-027 — latest stable major at project start; major pinned, patch floats |

No package-level pins (NuGet, npm, PyPI) are declared by the stakeholder. The frontend is Razor Pages
(CON-026), so no client-side framework pin applies. A package-level pin is added only when the
stakeholder declares one — the team does not invent one.

### Working against stand-ins (CON-031)

This is the single most consequential procedure in the project, because it defines the team's entire
integration surface.

- The OIDC client and the LDAP connection are configured with **placeholder values** — issuer, client
  id, client secret, LDAP host, bind account, base DN — held in configuration and **never in code**.
  Infrastructure substitutes the real values at deployment.
- The team builds and tests against stand-ins it controls: a test OIDC issuer, and a test directory
  carrying the declared attributes **including entries whose job title or extension is empty**.
- Validation against the real Keycloak and the real AD is human work by Infrastructure with HR. It is
  not team work to plan, and the team does not schedule it.
- The team's definition of done is: every use case works correctly against the stand-ins.

**The stand-in is R001's mechanism, not its retirement.** R001 is that the directory shows gaps when
attributes are unfilled. A fixture that carries the gaps makes the risk *testable*; only a passing
directory search and a passing export against that fixture retires it. The two are different events
and the plan records them as different events. A stand-in without the empty-attribute entries leaves
R001 untested while appearing to have addressed it — which is the failure mode this paragraph exists
to prevent.

### Iteration preparation checkpoint

Process preparation is not a one-time Inception activity. Every iteration opens with an explicit
readiness checkpoint before development starts, and the Environment discipline owns it:

1. Re-evaluate the DC classification and the six OPTIONAL triggers — a Change Request may newly fire
   one.
2. Re-record the version policy — the stakeholder may revise it.
3. Verify the toolchain the iteration depends on actually works: build, CI, test framework, and the
   stand-ins. A broken build discovered on day one is a process failure, not a development one.
4. Confirm the templates and guideline references the iteration needs exist. `CONTRIBUTING.md`, the
   lint configuration and `.github/workflows` do not yet exist; they are R007 and must be closed
   before Implementation intensity rises in Construction. The test framework is the same shape of gap
   and closes in the first Elaboration iteration.
5. Apply the authoring checks (C1 to C9) to every artifact the iteration produces, before it is
   persisted. A check applied at review time is a finding; a check applied at authoring time is a
   correction that never becomes one.

### Process support during the iteration

Support is continuous, not an afterthought. During active construction the Process Engineer is the
process help desk: questions about how a guideline applies, ambiguous templates, and malfunctioning
tools are answered within the iteration. A blocking process question is escalated immediately rather
than carried to the next iteration.

### Guideline ownership — collaborative, not solo

Guideline content lives in `CONTRIBUTING.md` and the lint configuration, not in this document. Each
section is authored by the discipline expert who owns the practice; the Process Engineer integrates
and publishes, and does not invent technical guidance.

| Guideline area | Authoring role |
|---|---|
| Architecture and design conventions | SoftwareArchitect |
| Coding standards, formatting, lint rules | Implementer, with CodeReviewer |
| UI implementation against the authoritative design (CON-034) | UserInterfaceDesigner |
| Schema, audit-trail and immutability conventions (CON-013, CON-014) | DatabaseDesigner |
| Test conventions and stand-in fixtures | TestManager with TestDesigner |
| Branching, CI and release procedure | ConfigurationManager |

### Process improvement

After every iteration the Process Engineer reads the Iteration Assessment and the Review Record and
asks what went wrong and why — a process gap, a tool failure, an ambiguous template, or a missing
guideline. Each change to this document is traceable to a specific observed problem. Process
improvement without that evidence is guesswork and is not recorded here.

**Iteration 1 evidence and the changes it forced.** Ten findings were recorded across three lenses.
Five of them are defects of a *kind*, not of a single artifact — the same mistake made in different
documents — and a kind of defect is a process gap, which is this document's business.

```plantuml
@startuml
title Portal - Process improvement record: iteration 1 evidence to Development Case change

package "Observed in Inception iteration 1" {
  class "Iteration Plan#F1 (Reviewer)\nFine plan derived from the discipline\nsequence, not from the artifact set" as O1
  class "Iteration Plan#F1 (Management)\nFixture built treated as risk retired" as O2
  class "Iteration Plan#F2 (Management)\nPopulation measure assigned to an\niteration gate" as O3
  class "Test Evaluation Summary#F1\nStale CI run cited as observed" as O4
  class "Vision#F1 (both lenses)\nCriterion restates its requirement" as O5
}

package "Development Case change forced" {
  class "Disciplines and Intensity:\nplan derives from the artifact set" as C1
  class "Guidelines: risk retirement is a\npassing test, never a fixture" as C2
  class "Guidelines: a criterion must be\nable to fail" as C3
  class "Guidelines: observable SCM state\ncited only as observed" as C4
  class "Guidelines: process improvement\nrecord" as C5
}

O1 --> C1
O2 --> C2
O3 --> C3
O4 --> C4
O5 --> C3
C1 --> C5
C2 --> C5
C3 --> C5
C4 --> C5

note bottom of C5
  Each change is traceable to a named
  finding. A change with no observed
  problem behind it is not recorded.
end note
@enduml
```

| Observed problem | Root cause | Change to this document |
|---|---|---|
| `Iteration Plan#F1` (Reviewer) — the fine plan covered seven artifacts; the iteration produced nine, and the two it missed had their roles marked idle | The plan was derived from the discipline sequence this document describes, not from the artifact set the iteration was going to produce. Analysis and Design is Medium and Test is Low in Inception, and both were read as idle | Disciplines and Intensity now states that a plan is derived from the artifact set, and that a discipline at Medium or Low intensity is active, not idle |
| `Iteration Plan#F1` (Management Reviewer) — the plan claimed R001 retired in iteration 2 on the strength of the stand-in fixture being built | Building a risk's mechanism was treated as retiring the risk. The distinction is the one claim a risk-driven gate exists to test | Guidelines and Procedures, working against stand-ins: the stand-in is R001's mechanism, not its retirement; retirement is a passing test |
| `Iteration Plan#F2` (Management Reviewer) — AC-004, a population measure, was assigned to the iteration in which its own window opens | A measure that cannot close inside an iteration was gated on an iteration | Guidelines and Procedures, criteria: a criterion must be able to fail, and a measure whose window outlives the iteration is a post-acceptance measure with a named owner |
| `Vision#F1` (both lenses) — BG-001 presented as measurable with no declared baseline; FR-014 and FR-015 citing their own identifiers as success criteria | A criterion that restates its requirement cannot be distinguished from it, so it cannot be tested | Same guideline as above, applied at authoring time rather than at review time |
| `Test Evaluation Summary#F1` — a CI run identifier and two timestamps cited from an earlier read than the moment of writing | Observable SCM state was cited from memory | Guidelines and Procedures, observable state: a run identifier, a timestamp, a build status or a commit SHA is cited only as read at the moment of writing, or not cited at all |

**Iteration 2 evidence and the changes it forced.** Ten findings were closed and seven raised. The
seven are the evidence, and the verdict table above is the analysis: four checks covered four defect
classes, and the second generation arrived from three classes none of them touched.

| Observed problem | Root cause | Change to this document |
|---|---|---|
| `Use-Case Model#F1` and `#F2` (Business Reviewer) — CON-012 bound to UC-001 with no flow enforcing it; CON-015 bound to two of its three declared uses while the artifact denied the third | A rule was cited in a "business rules enforced" list and treated as enforced. No check asked which step of which flow makes the rule true | C5, a binding is a claim about behaviour: name the step that enforces the rule and confirm the flow cannot produce the state the rule forbids |
| `Supplementary Specification#F1` (Business Reviewer) — the register presented itself as complete and carried twelve of the thirteen declared `[BusinessRule]` constraints | A completeness claim was asserted rather than counted against the declared set | C6, a completeness claim is counted: every "the N below" and every "all are accounted for" is computed before it is written |
| `Supplementary Specification#F1` (Reviewer) — the constraint table and the constraint map disagreed on CON-005 and CON-031, and neither matched the declared category | One set of 36 constraints was hand-authored twice, in a table and in a diagram, with no single source | C7, one set, one source list: the second representation is generated from the first, never authored independently |
| `Use-Case Model#F2` (Reviewer) and `Software Architecture Document#F3` — ADR-010 changed the clocking shape and the Use-Case Model did not follow; the roadmap changed and the significance table did not follow | Corrections were made artifact by artifact against the finding that named them, with no pass asking which other artifacts the correction invalidated | C8 and the cross-artifact re-base sweep: name the decision, list its consumers, re-base them in the same iteration, record the sweep |
| `Iteration Plan#F3` (Management Reviewer) — C3 was written in iteration 2 to catch a plan derived from the finding ledger, and the iteration-2 plan still failed it | A check added in the iteration it must govern has not been exercised, so the process could not distinguish a check that works from one that was never run | C9, a check is in force only once applied: a check governs from the iteration after the one that adds it, and its first application is recorded |

**The pattern behind the second generation.** The iteration-1 pattern was a claim that *looks*
verified and is not. The iteration-2 pattern is narrower: a claim that is *true of the artifact that
makes it* and false of the artifacts that consume it. A rule is genuinely bound in the register and
genuinely unenforced in the flow; a decision is genuinely made in the architecture and genuinely not
carried to the use case. The check that catches it is C8, and C8 is a sweep across artifacts rather
than a reading of one.

**No change is made to the roster, the CORE catalog, the ownership allowlist or the intensity
matrix.** The iteration-2 defects were authoring and planning defects, not process-shape defects. The
process configuration held; what it lacked was coverage of three defect classes and a rule making a
check's application observable.

### Scope note for test tailoring

No accessibility conformance target is declared for this cycle, and scale is not a binding concern at
200 employees across 3 offices. Neither is designed for as a separate objective, and neither is a gap
in this document — both return to the stakeholder when this cycle closes.

One factual consequence follows from CON-034 and is recorded here so the UI Designer and Test roles
do not have to rediscover it: the authoritative design reference at
`docs/inputs/employee-portal-design.html` — committed to the repository with the project inputs per
CON-034 — states in its own design-system header that it targets AA contrast, visible focus, targets
of at least 40px, and keyboard-only operation. Because CON-034 makes that file mandatory and
authoritative for the visual layer, those values are inherited as **design conformance** — the UI is
built to the reference and tested against it. They are not a separately declared accessibility
target, no WCAG level is claimed, and no accessibility test suite is scoped from them. The
distinction matters: a defect is "the UI departs from the reference", not "the portal fails WCAG".

### Criteria that can fail

Three of the ten iteration-1 findings are one defect in three artifacts: a criterion that restates
the requirement it is meant to verify. BG-001 was presented as measurable with no declared baseline;
FR-014 and FR-015 cited their own identifiers as their success criterion; AC-004 was gated on the
iteration in which its own window opens.

The check, applied at authoring time and not left to review:

1. **Can this criterion fail?** If no observation could make it false, it is not a criterion.
2. **Is it distinguishable from the requirement?** If the criterion and the requirement are the same
   sentence, the criterion measures nothing.
3. **Does its window fit its gate?** A measure that elapses after the iteration closes — an adoption
   rate, a three-month trend — is a post-acceptance measure with a named owner, never an iteration
   gate. A gate that can never close is worse than no gate, because it reports as permanently in
   progress.

### Observable state

A run identifier, a build status, a timestamp, a commit SHA, a test count, a defect count — each is a
fact with a moment. Citing one from an earlier read than the moment of writing turns a stale value
into what reads downstream as a verified observation. `Test Evaluation Summary#F1` is exactly this
defect.

The rule: cite observable SCM state only as read at the moment of writing, or state the fact without
the identifier. Never reconstruct an identifier from memory, and never carry one forward from a prior
iteration's artifact. Where a figure is not measured, it carries `[ASSUMPTION — requires validation]`
and is not presented as an observation.

### Authoring checks — register and verdict

Nine checks are in force. Each is applied to an artifact **before** it is persisted, not left to
review. A check that is only described is not in force; C9 exists to make that distinction
enforceable.

```plantuml
@startuml
title Portal - Authoring check gate applied before an artifact is persisted

start
:Artifact drafted;
repeat
  :Run the next authoring check (C1 to C9);
  if (the check fails?) then (yes)
    :Correct the artifact;
    note right
      The correction is re-checked
      before the next check runs.
    end note
  else (no)
    :Check passes;
  endif
repeat while (checks remain?) is (yes)
->no;
:Persist the artifact;
stop
@enduml
```

| Check | What it asks | The defect it catches | Detail |
|---|---|---|---|
| C1 | Could any observation make this criterion false? | A criterion that restates the requirement it is meant to verify | Criteria that can fail |
| C2 | Was this identifier read at the moment of writing? | A run id, SHA, build status or count cited from an earlier read as if observed | Observable state |
| C3 | Is every artifact this iteration will produce a work item with an owner and an exit condition? | A plan derived from the finding ledger or the discipline sequence instead of the artifact set | Disciplines and Intensity |
| C4 | Is the retiring event a passing test, not a fixture? | A risk reported retired because its mechanism was built | Working against stand-ins |
| C5 | Which step of which flow enforces this rule? | A rule cited in a "business rules enforced" list whose flow does not enforce it | This section, below |
| C6 | How many of the declared set are present? | A register asserting its own completeness while omitting a member | This section, below |
| C7 | Do the table and the diagram derive from the same list? | Two representations of one set disagreeing with each other | This section, below |
| C8 | Which other artifacts consume the decision that just changed? | An artifact not re-based onto a decision another artifact changed | Cross-artifact re-base sweep |
| C9 | Has this check been applied to a persisted artifact? | A check written in the iteration it must govern, and therefore never exercised | This section, below |

**C5 — a binding is a claim about behaviour.** A row in a "business rules enforced" table is a
citation, not an enforcement. The check: for every rule bound to a use case, name the step of the
main flow or the alternative flow that makes the rule true, and confirm the flow cannot produce the
state the rule forbids. A rule bound without such a step is bound in name only.

**C6 — a completeness claim is counted.** Any sentence of the form "the N rules below", "all
constraints are accounted for", "every use case has a test level" is a count, and a count is computed
against the declared set before it is written. An asserted count is a claim the author has not
checked.

**C7 — one set, one source list.** When one set of elements is represented twice — a table and a
diagram, a register and a map — the second representation is generated from the first, never authored
independently. Two hand-authored representations of the same set will disagree, and the reader cannot
tell which is authoritative.

**C9 — a check is in force only once applied.** A check added in the same iteration it must govern has
not been exercised, so the process cannot claim it works. The check is in force from the iteration
after the one that adds it, and the first application is recorded.

#### Verdict: the nine checks against the seven open findings

R009 asks whether the authoring checks work. The Iteration Plan's W7 requires the question answered
finding by finding, not asserted. Each of the seven open findings is classified by the check that
should have caught it and by whether that check was in force when the artifact was persisted.

```plantuml
@startuml
title Portal - Authoring checks against the seven open findings: caught or not caught

package "Checks in force during iteration 2" {
  class "C1 Criterion can fail" as C1
  class "C2 Observable state read now" as C2
  class "C3 Plan derived from the artifact set" as C3
  class "C4 Stand-in is mechanism, not retirement" as C4
}

package "Checks added this iteration" {
  class "C5 A binding is a claim about behaviour" as C5
  class "C6 A completeness claim is counted" as C6
  class "C7 One set, one source list" as C7
  class "C8 Every consumer of a decision is re-based" as C8
  class "C9 A check is in force only once applied" as C9
}

package "Open findings at the LCO gate" {
  class "Use-Case Model#F2 (Reviewer)\npostcondition vs ADR-010" as F1
  class "Use-Case Model#F1 (Business)\nCON-012 bound, not enforced" as F2
  class "Use-Case Model#F2 (Business)\nCON-015 attachment vs the SAD" as F3
  class "Software Architecture Document#F3\nsignificance table not re-based" as F4
  class "Iteration Plan#F3\nDevelopment Case has no work item" as F5
  class "Supplementary Specification#F1 (Reviewer)\nconstraint grouping" as F6
  class "Supplementary Specification#F1 (Business)\nCON-008 absent from the register" as F7
}

C8 --> F1 : catches
C5 --> F2 : catches
C5 --> F3 : catches
C8 --> F4 : catches
C3 --> F5 : existed, not applied
C7 --> F6 : catches
C6 --> F7 : catches
C9 --> F5 : would have caught the non-application

note bottom of C9
  Six of the seven open findings were caught by
  no check in force. The seventh was caught by a
  check that existed and was not applied - which
  is why C9 exists.
end note
@enduml
```

| Finding | Defect class | Check that should catch it | In force when the artifact was persisted | Verdict |
|---|---|---|---|---|
| `Use-Case Model#F2` (Reviewer) | A decision another artifact changed, not carried through | C8 | No — C8 did not exist | Not caught |
| `Use-Case Model#F1` (Business) | A binding asserted without the behaviour that enforces it | C5 | No — C5 did not exist | Not caught |
| `Use-Case Model#F2` (Business) | A binding asserted without the behaviour that enforces it | C5 | No — C5 did not exist | Not caught |
| `Software Architecture Document#F3` | A decision another artifact changed, not carried through | C8 | No — C8 did not exist | Not caught |
| `Iteration Plan#F3` | A plan derived from the finding ledger, not the artifact set | C3 | **Yes** — added in iteration 2 | **Existed and was not applied** |
| `Supplementary Specification#F1` (Reviewer) | Two representations of one set disagreeing | C7 | No — C7 did not exist | Not caught |
| `Supplementary Specification#F1` (Business) | A completeness claim not counted | C6 | No — C6 did not exist | Not caught |

**The verdict is 0 of 7 caught, and the one that could have been caught was not.** This is the honest
reading and it is more useful than a claim that the checks failed. Six of the seven findings are of
classes no check addressed — the iteration-2 checks covered criteria, observable state, plan
derivation and risk retirement, and the second generation of findings came from three classes those
four do not touch: a binding without behaviour, a completeness claim without a count, and a decision
not carried to its consumers. The seventh, `Iteration Plan#F3`, is the one that matters: C3 was
written in iteration 2 to catch exactly that defect, and the plan that iteration produced still failed
it. A check written in the iteration it must govern has not been exercised, so it cannot be credited
with working — and the process cannot tell a check that works from a check that was never run.

**What this means for R009.** The risk is that the correction process does not converge. The evidence
does not support the reading that the checks are ineffective; it supports the narrower and more
actionable reading that four checks covered four classes and the defects arrived from three others.
C5, C6, C7 and C8 close those three classes, and C9 makes the "in force" claim checkable rather than
assumed. If iteration 3's review raises a third generation of a class C5 to C8 now cover, the checks
are ineffective and the process needs correction rather than a fourth pass — that is R009's escalation
path and it is unchanged.

**No change is made to the roster, the CORE catalog, the ownership allowlist or the intensity
matrix.** Every finding in both iterations is an authoring or planning defect, not a process-shape
defect. The configuration held; what it lacked was coverage of three defect classes and a rule making
a check's application observable.

### Cross-artifact re-base sweep

C8 is the check that addresses the defect class behind two of the five open Major findings, and the
class behind both generations of findings in this project. It is a procedure, not an intention.

When an artifact changes a **decision** — a data shape, a roadmap, a contract, an invariant, a
binding — the author of that change runs the sweep before persisting:

1. **Name the decision in one sentence.** "Clocking is an append-only event log, not a single record."
   "The roadmap is nine iterations, Elaboration at 4 and 5." A decision that cannot be stated in one
   sentence is not yet a decision and the sweep cannot run.
2. **List the artifacts that consume it.** Not the artifacts that mention it — the ones whose content
   becomes false if the decision is true. ADR-010's decision makes the Use-Case Model's postcondition
   false; the roadmap's change makes the significance table's "Design in" column false.
3. **Re-base each consumer in the same iteration.** A consumer left for the next iteration is a
   finding waiting to be raised, and the review will raise it.
4. **Record the sweep in the artifact that made the decision**, naming the consumers and their state.
   The record is what lets the next reviewer check the sweep rather than rediscover the class.

The sweep is cheap and its omission is not. Two artifacts were corrected onto an eight-iteration
numbering in the same iteration that invalidated it, and the cost of the sweep would have been one
pass over the artifacts that name an iteration number.

