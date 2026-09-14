## Document Control

| Field | Value |
|---|---|
| Phase | Inception |
| Status | Draft (awaiting review) |
| Milestone Target | End-of-Inception (Lifecycle Objectives) |
| Project | Portal |
| Owner | ProcessEngineer |

## Tailoring Overview

This Development Case records the project-specific **deltas** over the IARI DC baseline. The baseline (24-role roster, 16 CORE artifacts, 6 OPTIONAL artifacts, canonical discipline-intensity matrix, fixed ownership) is authoritative and is NOT restated here. Only deviations are declared.

**Organization & tool assessment (S1 findings):**
- **Team:** 25 AI agent roles per the IARI baseline roster — no role additions, removals, or merges.
- **Process maturity:** AI-driven RUP; no prior artifacts exist (fresh project).
- **Tools:** SCM repository + CI pipeline + lint configuration are the tool surface. Guideline content (`CONTRIBUTING.md`, `.github/workflows`, lint config) is owned by the respective discipline experts and referenced — not authored — by this document.
- **Domain:** Internal web application replacing shared Excel sheets, mass emails, and an outdated PDF. The stakeholder has fully specified system use cases (FR-001..FR-012); no business process re-engineering is in scope.

**Tailoring rationale:** The project is a tool replacement with a fully-specified system use-case model. This drives two deltas: (1) Business Modeling is INACTIVE (not business-process-led), and (2) no OPTIONAL artifact trigger fires (see §Optional Artifact Triggers). All other disciplines follow the canonical baseline.

## Disciplines and Intensity

Intensity per discipline/phase is **per the canonical matrix** in the IARI DC baseline — confirmed, not reassigned.

**INACTIVE discipline (delta):**
- **Business Modeling — INACTIVE.** The project is not business-process-led (see §Tailoring Overview). No Business Use-Case Model or Business Object Model is produced. The BusinessProcessAnalyst and BusinessReviewer roles are dormant for this project.

All other disciplines (Requirements, Analysis & Design, Implementation, Test, Deployment, Configuration & Change Management, Project Management) are ACTIVE per the baseline. Environment is ONE-TIME at project start (this document).

## Artifacts and Templates

All 16 CORE artifacts are produced per the baseline — none omitted, none reassigned.

**Tool configuration references (project-specific):**
- `CONTRIBUTING.md` — coding/design/UI/test guidelines, authored by discipline experts during Elaboration.
- `.github/workflows/` — CI pipeline configuration.
- Lint configuration — per-language lint rules.

These files are REFERENCED by this Development Case; their content is owned by the respective discipline roles, not the Process Engineer.

## Optional Artifact Triggers

None of the 6 OPTIONAL artifacts have a fired trigger for this project:

| Optional Artifact | Verdict | Reason |
|---|---|---|
| Glossary | NOT TRIGGERED | No specialist vocabulary (internal HR/clocking/directory domain, plain language) |
| Architectural Proof-of-Concept | NOT TRIGGERED | Not in Elaboration phase; no technical risk yet requiring empirical validation |
| Data Model | NOT TRIGGERED | Not data-centric; portal stores only 2 columns (AD user id → worker category, CON-007); data lives inline in Design Model |
| Deployment Model | NOT TRIGGERED | Single internal Windows Server (CON-004); deployment is a section in the SAD |
| User-Interface Prototype | NOT TRIGGERED | Custom design already committed and authoritative (CON-008); no prototype needed |
| Test Plan | NOT TRIGGERED | No formal delivery / regulatory audit / contractual test reporting |

## Roles and Ownership

Primary ownership of all CORE artifacts is per the baseline — unchanged. No role is added, removed, or merged.

**Dormant roles (delta):** BusinessProcessAnalyst and BusinessReviewer are dormant because Business Modeling is INACTIVE.

## Guidelines and Procedures

**Measurement policy (project-specific):** This project measures exactly two quantities — tokens consumed, and elapsed time split into agent time and human queue time (IARI baseline). This project uses them for the following decisions:
- **Tokens consumed** → iteration cost-boxing: an iteration ends when exit criteria pass or the token budget is spent (scope bends to the box).
- **Human queue time** → gate risk tracking: any human gate is a RISK (ceiling 14 days, then the process SUSPENDS), bound in the Risk List, never forecast in the plan.

No other metric is tracked — a metric whose decision cannot be named is not measured.

**Version policy:** .NET 10 is the authoritative framework target (CON-001), recorded via `record_version_policy`. The Software Architect anchors it in the SAD and it governs over the registry "latest".

## Traceability

| Element | Traces From | Link Type | Traces To |
|---|---|---|---|
| Business Modeling INACTIVE | CON-006, CON-007, CON-010 (external systems consumed, not re-engineered) | DependsOn | — |
| .NET 10 framework pin | CON-001 | DependsOn | Software Architecture Document |
| No OPTIONAL triggers | CON-004, CON-007, CON-008, CON-016 | DependsOn | — |
| Measurement policy | BG-001, BG-002, BG-003 (business goals drive cost-boxing) | DependsOn | Iteration Plan, Risk List |
