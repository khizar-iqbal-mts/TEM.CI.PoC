# PowerShell script to run CI workflow steps locally
# This mimics the GitHub Actions workflow for local testing
# Usage: .\run-ci-locally.ps1

param(
    [string]$Configuration = "Release"
)

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Running CI Workflow Steps Locally" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

# Step 1: Restore NuGet packages
Write-Host "[1/6] Restoring NuGet packages..." -ForegroundColor Yellow
$restoreSuccess = $false

# Try nuget.exe first (if available)
$nugetCmd = Get-Command nuget -ErrorAction SilentlyContinue
if ($null -ne $nugetCmd) {
    Write-Host "Using nuget.exe..." -ForegroundColor Gray
    nuget restore TEM.CI.PoC.sln
    if ($LASTEXITCODE -eq 0) {
        $restoreSuccess = $true
    }
}

# Fallback to dotnet restore (works with .NET Framework projects)
if (-not $restoreSuccess) {
    Write-Host "nuget.exe not found, using dotnet restore..." -ForegroundColor Gray
    dotnet restore TEM.CI.PoC.sln
    if ($LASTEXITCODE -eq 0) {
        $restoreSuccess = $true
    }
}

# Final fallback: MSBuild restore
if (-not $restoreSuccess) {
    Write-Host "Trying MSBuild restore..." -ForegroundColor Gray
    msbuild TEM.CI.PoC.sln /t:Restore /v:minimal
    if ($LASTEXITCODE -eq 0) {
        $restoreSuccess = $true
    }
}

if (-not $restoreSuccess) {
    Write-Host "Failed to restore NuGet packages!" -ForegroundColor Red
    Write-Host "Please ensure one of the following is available:" -ForegroundColor Yellow
    Write-Host "  - nuget.exe in PATH" -ForegroundColor Yellow
    Write-Host "  - dotnet CLI (for 'dotnet restore')" -ForegroundColor Yellow
    Write-Host "  - MSBuild (for restore target)" -ForegroundColor Yellow
    exit 1
}

Write-Host "✓ NuGet packages restored" -ForegroundColor Green
Write-Host ""

# Step 2: Build solution
Write-Host "[2/6] Building solution..." -ForegroundColor Yellow
msbuild TEM.CI.PoC.sln /p:Configuration=$Configuration /p:Platform="Any CPU" /t:Build /v:minimal
if ($LASTEXITCODE -ne 0) {
    Write-Host "Build failed!" -ForegroundColor Red
    exit 1
}
Write-Host "✓ Solution built successfully" -ForegroundColor Green
Write-Host ""

# Step 3: Check .NET SDK
Write-Host "[3/6] Checking .NET SDK..." -ForegroundColor Yellow
$dotnetPath = Get-Command dotnet -ErrorAction SilentlyContinue
if ($null -eq $dotnetPath) {
    Write-Host "ERROR: dotnet CLI not found!" -ForegroundColor Red
    Write-Host "Please install .NET SDK: https://dotnet.microsoft.com/download" -ForegroundColor Yellow
    exit 1
}
$dotnetVersion = dotnet --version
Write-Host "✓ .NET SDK found: $dotnetVersion" -ForegroundColor Green
Write-Host ""

# Step 4: Run unit tests
Write-Host "[4/6] Running unit tests..." -ForegroundColor Yellow
$testDll = "TEM.CI.PoC.Tests/bin/$Configuration/TEM.CI.PoC.Tests.dll"
if (-not (Test-Path $testDll)) {
    Write-Host "Test DLL not found: $testDll" -ForegroundColor Red
    Write-Host "Please build the solution first." -ForegroundColor Yellow
    exit 1
}

dotnet test $testDll --logger "trx;LogFileName=TestResults.trx" --logger "console;verbosity=normal"
$testExitCode = $LASTEXITCODE
if ($testExitCode -eq 0) {
    Write-Host "✓ All tests passed" -ForegroundColor Green
} else {
    Write-Host "⚠ Some tests failed (exit code: $testExitCode)" -ForegroundColor Yellow
}
Write-Host ""

# Step 5: Code Analysis
Write-Host "[5/6] Running code analysis..." -ForegroundColor Yellow
Write-Host "Note: For .NET Framework, we'll use Roslyn analyzers. Installing analyzers..." -ForegroundColor Gray
Write-Host ""

# Install analyzers if not already present (using dotnet add package)
# Note: This requires the project to be SDK-style or we use a different approach
# For legacy .NET Framework, we'll show compiler warnings and use a simpler approach

Write-Host "Running build with detailed warnings to show code quality issues..." -ForegroundColor Gray
$analysisOutput = msbuild TEM.CI.PoC.sln /p:Configuration=$Configuration /p:Platform="Any CPU" /t:Rebuild /v:normal 2>&1

# Filter and display code analysis relevant warnings
# Match actual warnings/errors: path(line,col): warning/error CS####: message
# Exclude compiler command lines (long lines with /reference, /noconfig, etc.)
$warnings = $analysisOutput | Where-Object { 
    $_ -match "\(\d+,\d+\):\s*(warning|error)\s+CS\d+:" -and
    $_ -notmatch "^E:\\Program Files" -and
    $_ -notmatch "/noconfig" -and
    $_ -notmatch "/reference:" -and
    $_.Length -lt 500  # Exclude very long compiler command lines
}

$errorCount = 0
$warningCount = 0

if ($warnings) {
    Write-Host ""
    Write-Host "Code Analysis Results:" -ForegroundColor Cyan
    Write-Host "========================================" -ForegroundColor Cyan
    $warnings | ForEach-Object {
        if ($_ -match "\(\d+,\d+\):\s*error\s+CS\d+:") {
            Write-Host $_ -ForegroundColor Red
            $errorCount++
        } elseif ($_ -match "\(\d+,\d+\):\s*warning\s+CS\d+:") {
            Write-Host $_ -ForegroundColor Yellow
            $warningCount++
        }
    }
    Write-Host "========================================" -ForegroundColor Cyan
    Write-Host ""
    if ($errorCount -gt 0 -or $warningCount -gt 0) {
        Write-Host "Summary: $errorCount error(s), $warningCount warning(s)" -ForegroundColor Yellow
        Write-Host "✓ Code analysis completed - Found $($errorCount + $warningCount) issues" -ForegroundColor Green
    } else {
        Write-Host "✓ Code analysis completed - No issues found" -ForegroundColor Green
    }
} else {
    Write-Host "✓ Code analysis completed - No issues found" -ForegroundColor Green
}
Write-Host ""

# Step 6: Summary
Write-Host "[6/6] Summary" -ForegroundColor Yellow
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Build: ✓ Success" -ForegroundColor Green
if ($testExitCode -eq 0) {
    Write-Host "Tests: ✓ Passed" -ForegroundColor Green
} else {
    Write-Host "Tests: ✗ Failed" -ForegroundColor Red
}
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

if ($testExitCode -eq 0) {
    Write-Host "All CI steps completed successfully!" -ForegroundColor Green
    exit 0
} else {
    Write-Host "CI workflow completed with test failures." -ForegroundColor Yellow
    exit $testExitCode
}

