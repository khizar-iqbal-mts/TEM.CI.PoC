# CI Pipeline Demonstration Project Setup

## Overview

Create a new .NET Framework console application project with comprehensive CI/CD setup to demonstrate GitHub Actions workflows, branch protection, and naming conventions.

## Project Structure

- Create a new .NET Framework 4.5.2 (or 4.8) Console Application
- Add a simple class library project for unit testing demonstration
- Include sample unit tests using MSTest or NUnit
- Add a README with setup instructions

## GitHub Actions Workflows

### 1. Main Branch Workflow (`main-ci.yml`)

- Triggers: pushes to `main`, PRs targeting `main`, commits to PRs
- Scope: Build + Run Unit Tests + Code Analysis + Publish Artifacts (full CI)
- Uses MSBuild to build the solution
- Runs unit tests
- Performs code analysis (optional: SonarCloud or built-in analyzers)
- Publishes build artifacts and test results

### 2. Release Branch Workflow (`release-ci.yml`)

- Triggers: pushes to `release/*` branches, PRs targeting `release/*`
- Scope: Build + Run Unit Tests (standard CI)
- Uses MSBuild to build the solution
- Runs unit tests
- Publishes test results (no artifacts for release branches)

### 3. Build-Only Workflow (`build-only.yml`)

- Triggers: `workflow_dispatch` (manual trigger) or specific branch pattern
- Scope: Build only
- Simple MSBuild execution
- No tests, no analysis, no artifacts

### 4. Build + Tests Workflow (`build-tests.yml`)

- Triggers: `workflow_dispatch` (manual trigger) or specific branch pattern
- Scope: Build + Run Unit Tests
- Builds solution and runs tests
- Publishes test results

### 5. Build + Tests + Analysis Workflow (`build-tests-analysis.yml`)

- Triggers: `workflow_dispatch` (manual trigger) or specific branch pattern
- Scope: Build + Tests + Code Analysis
- Full pipeline with code quality checks

### 6. Full CI Workflow (`full-ci.yml`)

- Triggers: `workflow_dispatch` (manual trigger) or specific branch pattern
- Scope: Build + Tests + Analysis + Publish Artifacts
- Complete CI/CD pipeline

**Note**: Workflows 3-6 can be triggered manually via `workflow_dispatch` to demonstrate different scopes. Alternatively, we can use branch-based triggers (e.g., `demo/build-only`, `demo/build-tests`, etc.)

## Branch Protection Rules

- Protect `main` branch:
- Require pull request reviews
- Require status checks to pass (CI workflows)
- Require branches to be up to date
- Enforce branch naming conventions

## Branch Naming Convention Rules

Create GitHub branch protection rules with pattern-based naming:

- Feature branches: `feature/JIRA-123-description` or `feature/description`
- Bugfix branches: `bugfix/JIRA-456-description` or `bugfix/description`
- Hotfix branches: `hotfix/JIRA-789-description` or `hotfix/description`
- Release branches: `release/v1.0.0` or `release/version`
- Demo branches: `demo/scope-name` (for testing different CI scopes)

## Project Files to Create

1. Console application project file (`.csproj`)
2. Solution file (`.sln`)
3. Sample code files (Program.cs, Calculator.cs, etc.)
4. Unit test project (`.csproj`)
5. Sample unit tests
6. `.github/workflows/` directory with all workflow files
7. `README.md` with setup and demonstration instructions
8. `.gitignore` for .NET Framework projects
9. `Directory.Build.props` (optional, for shared MSBuild properties)

## Testing Strategy for Different CI Scopes

- **Option A (Recommended)**: Use `workflow_dispatch` with inputs to select scope
- **Option B**: Use branch naming patterns (`demo/build-only`, `demo/build-tests`, etc.)
- **Option C**: Create separate workflow files that can be manually triggered

## Documentation

- README.md explaining:
- How to set up the repository
- How to trigger different CI scopes
- Branch naming conventions
- How to create PRs and test workflows
- Team collaboration workflow

## Implementation Steps

1. Create project structure (console app + test project)
2. Add sample code and unit tests
3. Create all GitHub Actions workflow files
4. Create README with instructions
5. Create .gitignore
6. Document branch naming rules and protection setup (manual GitHub steps)