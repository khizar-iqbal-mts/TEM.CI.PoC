# PowerShell script to run MSTest unit tests using dotnet test
# Usage: .\run-tests.ps1

param(
    [string]$Configuration = "Release"
)

Write-Host "Running unit tests using dotnet test..." -ForegroundColor Cyan
Write-Host ""

# Check if dotnet CLI is available
$dotnetPath = Get-Command dotnet -ErrorAction SilentlyContinue
if ($null -eq $dotnetPath) {
    Write-Host "ERROR: dotnet CLI not found!" -ForegroundColor Red
    Write-Host ""
    Write-Host "Please install .NET SDK:" -ForegroundColor Yellow
    Write-Host "  https://dotnet.microsoft.com/download" -ForegroundColor Yellow
    Write-Host ""
    Write-Host "Alternatively, you can:" -ForegroundColor Yellow
    Write-Host "  1. Open the solution in Visual Studio and use Test Explorer" -ForegroundColor Yellow
    Write-Host "  2. Use vstest.console.exe directly (requires Visual Studio)" -ForegroundColor Yellow
    exit 1
}

# Always rebuild the solution
Write-Host "Building solution..." -ForegroundColor Yellow
Write-Host ""
msbuild TEM.CI.PoC.sln /p:Configuration=$Configuration /p:Platform="Any CPU" /t:Rebuild /v:minimal

if ($LASTEXITCODE -ne 0) {
    Write-Host ""
    Write-Host "Build failed!" -ForegroundColor Red
    exit $LASTEXITCODE
}

Write-Host ""
Write-Host "Running tests..." -ForegroundColor Cyan
Write-Host ""

dotnet test TEM.CI.PoC.Tests/bin/$Configuration/TEM.CI.PoC.Tests.dll --logger "console;verbosity=normal"

if ($LASTEXITCODE -ne 0) {
    Write-Host ""
    Write-Host "Some tests failed!" -ForegroundColor Red
    exit $LASTEXITCODE
}

Write-Host ""
Write-Host "All tests passed!" -ForegroundColor Green


