[CmdletBinding()]
param(
    [ValidateSet("Debug", "Release")]
    [string]$Configuration = "Release"
)

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

$scriptRoot = Split-Path -Parent $MyInvocation.MyCommand.Path
$repoRoot = Split-Path -Parent $scriptRoot

$requiredPaths = @(
    (Join-Path $repoRoot "CHANGELOG.md"),
    (Join-Path $repoRoot "docs\RELEASE_CHECKLIST.md"),
    (Join-Path $repoRoot "Testing9\Web.config")
)

foreach ($requiredPath in $requiredPaths)
{
    if (-not (Test-Path $requiredPath))
    {
        throw "Required release file is missing: $requiredPath"
    }
}

$changelogContent = Get-Content (Join-Path $repoRoot "CHANGELOG.md") -Raw
if ($changelogContent -notmatch "## \[Unreleased\]")
{
    throw "CHANGELOG.md must contain an Unreleased section."
}

$blockedPatterns = @(
    "Abc123456_",
    "animeplaylist78@gmail.com"
)

$scanRoots = @(
    (Join-Path $repoRoot "Testing9"),
    (Join-Path $repoRoot "docs"),
    (Join-Path $repoRoot "README.md"),
    (Join-Path $repoRoot "CHANGELOG.md")
)

$violations = foreach ($scanRoot in $scanRoots)
{
    if (Test-Path $scanRoot)
    {
        if ((Get-Item $scanRoot) -is [System.IO.DirectoryInfo])
        {
            Get-ChildItem $scanRoot -Recurse -File |
                Select-String -Pattern $blockedPatterns -SimpleMatch -ErrorAction SilentlyContinue
        }
        else
        {
            Select-String -Path $scanRoot -Pattern $blockedPatterns -SimpleMatch -ErrorAction SilentlyContinue
        }
    }
}

if ($violations)
{
    $paths = $violations | Select-Object -ExpandProperty Path -Unique
    throw "Blocked credential pattern found in: $($paths -join ', ')"
}

& (Join-Path $scriptRoot "Invoke-Build.ps1") -Configuration $Configuration -Restore

Write-Host "Release check completed successfully."
