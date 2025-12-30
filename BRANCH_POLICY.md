# Branch Policy and Naming Conventions

This document outlines the branch naming conventions and protection policies for this repository.

## Branch Naming Conventions

All branches must follow the naming patterns below:

### Feature Branches
**Pattern**: `feature/JIRA-123-description` or `feature/description`

**Purpose**: New features or enhancements

**Examples**:
- `feature/add-logging`
- `feature/PROJ-456-user-authentication`
- `feature/calculator-scientific-operations`

### Bugfix Branches
**Pattern**: `bugfix/JIRA-456-description` or `bugfix/description`

**Purpose**: Bug fixes and defect corrections

**Examples**:
- `bugfix/division-by-zero-error`
- `bugfix/PROJ-789-null-reference-exception`
- `bugfix/calculator-precision-issue`

### Hotfix Branches
**Pattern**: `hotfix/JIRA-789-description` or `hotfix/description`

**Purpose**: Critical fixes that need immediate deployment

**Examples**:
- `hotfix/security-patch`
- `hotfix/PROJ-101-critical-bug`
- `hotfix/memory-leak-fix`

### Release Branches
**Pattern**: `release/v1.0.0` or `release/version`

**Purpose**: Preparation for production releases

**Examples**:
- `release/v1.0.0`
- `release/v2.1.3`
- `release/2024.1`

### Demo Branches (Optional)
**Pattern**: `demo/scope-name`

**Purpose**: Testing different CI/CD pipeline scopes

**Examples**:
- `demo/build-only`
- `demo/build-tests`
- `demo/full-pipeline`

## Branch Protection Rules

### Main Branch Protection

The `main` branch is protected with the following rules:

#### Required Settings (Configure in GitHub)

1. **Navigate to Repository Settings**
   - Go to your GitHub repository
   - Click on **Settings** → **Branches**

2. **Add Branch Protection Rule**
   - Click **Add rule** or edit existing rule for `main`
   - Branch name pattern: `main`

3. **Configure Protection Settings**

   **Protect matching branches:**
   - ✅ Require a pull request before merging
     - Required number of approvals: `1` (or as per your team policy)
     - Dismiss stale pull request approvals when new commits are pushed
     - Require review from Code Owners (if CODEOWNERS file exists)
   
   - ✅ Require status checks to pass before merging
     - Require branches to be up to date before merging
     - Status checks that are required:
       - `Main Branch CI / build`
       - `Main Branch CI / Test Results` (if tests are configured)
   
   - ✅ Require conversation resolution before merging
   
   - ✅ Include administrators (optional, based on team preference)
   
   - ✅ Restrict who can push to matching branches
     - Only allow specific people or teams (optional)

4. **Branch Naming Rules** (if available in your GitHub plan)
   - Enable branch name restrictions
   - Add patterns:
     - `feature/*`
     - `bugfix/*`
     - `hotfix/*`
     - `release/*`
     - `demo/*`

### Release Branch Protection

Release branches (`release/**`) should have similar protection but may allow:
- Direct pushes for version updates
- Fewer required approvals (based on team policy)

## Workflow Integration

### CI Pipeline Triggers

- **Main Branch**: Triggers on pushes and PRs to `main`
- **Release Branches**: Triggers on pushes and PRs to `release/**`
- **Feature/Bugfix/Hotfix**: Can trigger workflows based on branch patterns

### Status Checks

The following status checks are enforced:
- Build must succeed
- All unit tests must pass
- Code analysis must pass (for main branch)

## Enforcement

### Automatic Enforcement

- GitHub Actions workflows can validate branch names
- Branch protection rules prevent direct pushes to protected branches
- PRs must pass all required status checks

### Manual Enforcement

- Code reviews should verify branch naming
- Team leads should monitor branch creation
- Regular cleanup of merged branches

## Branch Lifecycle

1. **Create**: Create branch following naming convention
2. **Develop**: Make commits and push changes
3. **Test**: CI pipeline runs automatically
4. **Review**: Create PR and get approvals
5. **Merge**: Merge to target branch after all checks pass
6. **Cleanup**: Delete branch after merge (optional, can be automated)

## Best Practices

1. **Keep branches short-lived**: Merge or delete within a reasonable timeframe
2. **Use descriptive names**: Make it clear what the branch is for
3. **One feature per branch**: Keep changes focused and reviewable
4. **Update frequently**: Rebase or merge from main regularly
5. **Clean up**: Delete merged branches to keep repository tidy

## Troubleshooting

### Branch Name Rejected

If your branch name is rejected:
- Check the naming patterns above
- Ensure you're using the correct prefix (`feature/`, `bugfix/`, etc.)
- Verify special characters are allowed (hyphens and underscores typically are)

### Cannot Push to Protected Branch

If you cannot push directly to `main`:
- This is expected behavior
- Create a feature branch instead
- Create a pull request to merge your changes

### CI Checks Failing

If CI checks are failing:
- Review the error messages in the Actions tab
- Fix any build errors or test failures
- Ensure your code follows project standards

## Questions?

For questions about branch policies:
- Review this document
- Check GitHub repository settings
- Contact repository administrators
- Refer to [CONTRIBUTING.md](CONTRIBUTING.md) for contribution guidelines

