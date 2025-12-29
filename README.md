# TEM.CI.PoC - CI/CD Pipeline Demonstration Project

This project demonstrates how to set up and utilize CI/CD pipelines for .NET Framework projects using GitHub Actions. It serves as a proof of concept and learning resource for implementing Continuous Integration and Continuous Deployment practices.

## Project Overview

This is a simple .NET Framework 4.8.1 console application with a Calculator class and corresponding unit tests. The project is configured with GitHub Actions workflows to demonstrate various CI/CD scenarios.

## Features

- **Calculator Application**: Simple console application with basic arithmetic operations
- **Unit Tests**: Comprehensive MSTest unit tests for the Calculator class
- **CI/CD Pipelines**: GitHub Actions workflows for automated builds and testing
- **Branch Protection**: Documentation for setting up branch protection rules
- **Branch Naming Conventions**: Enforced naming patterns for different branch types

## Project Structure

```
TEM.CI.PoC/
├── TEM.CI.PoC/              # Main console application
│   ├── Calculator.cs        # Calculator class implementation
│   ├── Program.cs           # Entry point
│   └── TEM.CI.PoC.csproj   # Project file
├── TEM.CI.PoC.Tests/        # Unit test project
│   ├── CalculatorTests.cs  # Calculator unit tests
│   └── TEM.CI.PoC.Tests.csproj
├── .github/
│   └── workflows/           # GitHub Actions workflows
│       ├── main-ci.yml      # Main branch CI workflow
│       └── release-ci.yml   # Release branch CI workflow
├── TEM.CI.PoC.sln          # Solution file
└── README.md               # This file
```

## Prerequisites

- Visual Studio 2019 or later (or Visual Studio Build Tools) - for building
- .NET Framework 4.8.1 SDK
- .NET SDK (for running tests with `dotnet test`)
- Git
- GitHub account

## Getting Started

### 1. Clone the Repository

```bash
git clone <repository-url>
cd TEM.CI.PoC
```

### 2. Restore NuGet Packages

```bash
nuget restore TEM.CI.PoC.sln
```

### 3. Build the Solution

```bash
msbuild TEM.CI.PoC.sln /p:Configuration=Release
```

### 4. Run the Application

```bash
.\TEM.CI.PoC\bin\Release\TEM.CI.PoC.exe
```

### 5. Run Unit Tests

**Option 1: Using dotnet test (Recommended)**
```powershell
# Build first (if not already built)
msbuild TEM.CI.PoC.sln /p:Configuration=Release

# Run tests using the built DLL
dotnet test TEM.CI.PoC.Tests/bin/Release/TEM.CI.PoC.Tests.dll
```

**Option 2: Using the provided PowerShell script**
```powershell
.\run-tests.ps1
```

**Option 3: Using Visual Studio**
- Open `TEM.CI.PoC.sln` in Visual Studio
- Build the solution (Ctrl+Shift+B)
- Open Test Explorer (Test → Test Explorer)
- Run all tests

**Note**: The CI/CD pipelines use `dotnet test` for running tests, which is the recommended approach as it works consistently across different environments.

## CI/CD Pipelines

### Main Branch CI (`main-ci.yml`)

**Triggers:**
- Pushes to `main` branch
- Pull requests targeting `main` branch
- Commits pushed to pull requests

**Actions:**
- Builds the solution in Release configuration
- Runs all unit tests
- Performs code analysis using built-in analyzers
- Publishes test results
- Uploads build artifacts

### Release Branch CI (`release-ci.yml`)

**Triggers:**
- Pushes to `release/**` branches
- Pull requests targeting `release/**` branches

**Actions:**
- Builds the solution in Release configuration
- Runs all unit tests
- Publishes test results

### Running CI Workflows Locally

You can test your CI workflows locally before pushing to GitHub:

**Option 1: Using the provided script (Recommended)**
```powershell
.\run-ci-locally.ps1
```

This script mimics the GitHub Actions workflow steps:
- Restores NuGet packages
- Builds the solution
- Runs unit tests
- Performs code analysis
- Provides a summary

**Option 2: Using act (Limited support for Windows)**
The `act` tool can run GitHub Actions locally, but it has limitations with Windows runners:
```powershell
# Install act (requires Docker)
choco install act-cli

# List workflows
act -l

# Run a workflow
act push
```

**Note**: Since this project uses `windows-latest` runners, `act` may not fully replicate the environment. The `run-ci-locally.ps1` script is recommended for Windows-based .NET Framework projects.

## Branch Naming Conventions

This project follows specific branch naming conventions. See [BRANCH_POLICY.md](BRANCH_POLICY.md) for detailed information.

**Branch Types:**
- `feature/*` - Feature development branches
- `bugfix/*` - Bug fix branches
- `hotfix/*` - Hotfix branches
- `release/*` - Release preparation branches

## Contributing

Please read [CONTRIBUTING.md](CONTRIBUTING.md) for details on our code of conduct and the process for submitting pull requests.

## Demonstration Scenarios

For step-by-step scenarios demonstrating the CI/CD pipeline, see [DEMO_SCENARIOS.md](DEMO_SCENARIOS.md).

## Setting Up Branch Protection

Branch protection rules must be configured manually in GitHub repository settings:

1. Go to **Settings** → **Branches**
2. Add a rule for the `main` branch
3. Enable the following:
   - Require pull request reviews before merging
   - Require status checks to pass before merging
   - Require branches to be up to date before merging
   - Include administrators

See [BRANCH_POLICY.md](BRANCH_POLICY.md) for complete setup instructions.

## License

This project is for demonstration purposes.

## Resources

- [GitHub Actions Documentation](https://docs.github.com/en/actions)
- [.NET Framework Documentation](https://docs.microsoft.com/en-us/dotnet/framework/)
- [MSTest Documentation](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-mstest)

