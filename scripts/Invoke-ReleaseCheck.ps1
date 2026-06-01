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
    (Join-Path $repoRoot "EZBook.Api\Web.config")
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

$blockedChecks = @(
    [pscustomobject]@{
        Description = "Hardcoded SMTP credentials"
        Pattern = 'NetworkCredential\s*\(\s*"[^"]+"\s*,\s*"[^"]+"'
    },
    [pscustomobject]@{
        Description = "Inline SQL credentials in code"
        Pattern = 'UseSqlServer\s*\(\s*"[^"]*(?:User ID|Uid)\s*=[^";]+;[^"]*(?:Password|Pwd)\s*=[^";]+;'
    },
    [pscustomobject]@{
        Description = "Committed SMTP configuration value"
        Pattern = '<add\s+key="Smtp\.(?:Username|Password|FromAddress)"\s+value="[^"]*\S[^"]*"'
    }
)

$scanRoots = @(
    (Join-Path $repoRoot "EZBook.Api"),
    (Join-Path $repoRoot "docs"),
    (Join-Path $repoRoot "README.md"),
    (Join-Path $repoRoot "CHANGELOG.md")
)

$violations = foreach ($scanRoot in $scanRoots)
{
    if (-not (Test-Path $scanRoot))
    {
        continue
    }

    $files = if ((Get-Item $scanRoot) -is [System.IO.DirectoryInfo])
    {
        Get-ChildItem $scanRoot -Recurse -File
    }
    else
    {
        Get-Item $scanRoot
    }

    foreach ($blockedCheck in $blockedChecks)
    {
        foreach ($match in ($files | Select-String -Pattern $blockedCheck.Pattern -ErrorAction SilentlyContinue))
        {
            [pscustomobject]@{
                Path = $match.Path
                LineNumber = $match.LineNumber
                Rule = $blockedCheck.Description
            }
        }
    }
}

if ($violations)
{
    $details = $violations |
        Sort-Object Path, LineNumber, Rule |
        ForEach-Object { "$($_.Path):$($_.LineNumber) [$($_.Rule)]" }

    throw "Blocked credential pattern found:`n$($details -join [Environment]::NewLine)"
}

& (Join-Path $scriptRoot "Invoke-Build.ps1") -Configuration $Configuration -Restore

Write-Host "Release check completed successfully."
