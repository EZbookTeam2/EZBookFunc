[CmdletBinding()]
param(
    [ValidateSet("Debug", "Release")]
    [string]$Configuration = "Release",
    [switch]$Restore
)

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

$scriptRoot = Split-Path -Parent $MyInvocation.MyCommand.Path
$repoRoot = Split-Path -Parent $scriptRoot
$solutionPath = Join-Path $repoRoot "Testing9.sln"

if (-not (Test-Path $solutionPath))
{
    throw "Solution not found at $solutionPath"
}

$msbuildPath = & (Join-Path $scriptRoot "Get-MSBuildPath.ps1")
$targets = if ($Restore) { "Restore;Build" } else { "Build" }

Write-Host "Using MSBuild: $msbuildPath"
Write-Host "Building solution: $solutionPath"

& $msbuildPath $solutionPath "/t:$targets" "/p:Configuration=$Configuration" "/p:RestorePackagesConfig=true"

if ($LASTEXITCODE -ne 0)
{
    throw "MSBuild failed with exit code $LASTEXITCODE"
}
