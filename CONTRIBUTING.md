# Contributing to TEM.CI.PoC

Thank you for your interest in contributing to this CI/CD demonstration project! This document provides guidelines and instructions for contributing.

## Code of Conduct

- Be respectful and considerate
- Focus on constructive feedback
- Help others learn and grow

## Development Workflow

### 1. Create a Branch

Follow the branch naming conventions:

- **Feature**: `feature/JIRA-123-description` or `feature/description`
- **Bugfix**: `bugfix/JIRA-456-description` or `bugfix/description`
- **Hotfix**: `hotfix/JIRA-789-description` or `hotfix/description`
- **Release**: `release/v1.0.0` or `release/version`

Example:
```bash
git checkout -b feature/add-multiplication
```

### 2. Make Your Changes

- Write clean, readable code
- Follow existing code style and conventions
- Add unit tests for new functionality
- Update documentation as needed

### 3. Commit Your Changes

Write clear, descriptive commit messages:

```bash
git commit -m "Add multiplication feature to Calculator"
```

### 4. Push Your Branch

```bash
git push origin feature/add-multiplication
```

### 5. Create a Pull Request

1. Go to the GitHub repository
2. Click "New Pull Request"
3. Select your branch and the target branch (usually `main`)
4. Fill in the PR description
5. Wait for CI checks to pass
6. Request reviews if required by branch protection rules

## Pull Request Guidelines

### PR Title
- Use clear, descriptive titles
- Reference issue numbers if applicable
- Example: `Feature: Add division operation to Calculator`

### PR Description
Include:
- What changes were made
- Why the changes were necessary
- How to test the changes
- Any breaking changes

### CI Checks
- All CI checks must pass before merging
- Fix any failing tests or build errors
- Address code analysis warnings if applicable

## Code Style

### C# Conventions
- Use PascalCase for public members
- Use camelCase for private fields and local variables
- Use meaningful names
- Add XML documentation comments for public APIs

### Example:
```csharp
/// <summary>
/// Adds two numbers
/// </summary>
public int Add(int a, int b)
{
    return a + b;
}
```

## Testing Requirements

- All new features must include unit tests
- Maintain or improve code coverage
- Tests should be clear and well-named
- Use Arrange-Act-Assert pattern

### Test Naming Convention
- Format: `MethodName_Scenario_ExpectedBehavior`
- Example: `Divide_WhenDivisorIsZero_ThrowsDivideByZeroException`

## Review Process

1. **Automated Checks**: CI pipeline runs automatically
2. **Code Review**: At least one approval required (if branch protection is enabled)
3. **Merge**: Once approved and all checks pass, merge the PR

## Questions?

If you have questions about contributing, please:
- Open an issue for discussion
- Contact the project maintainers
- Refer to the [README.md](README.md) for project overview

## Thank You!

Your contributions help make this a better learning resource for the team. We appreciate your time and effort!

