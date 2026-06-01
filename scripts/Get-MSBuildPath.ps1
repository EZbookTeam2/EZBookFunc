[CmdletBinding()]
param()

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

$candidatePaths = @(
    (Join-Path $env:ProgramFiles "Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe"),
    (Join-Path $env:ProgramFiles "Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\amd64\MSBuild.exe"),
    (Join-Path $env:ProgramFiles "Microsoft Visual Studio\18\Community\MSBuild\Current\Bin\MSBuild.exe"),
    (Join-Path $env:ProgramFiles "Microsoft Visual Studio\18\Community\MSBuild\Current\Bin\amd64\MSBuild.exe")
)

foreach ($candidatePath in $candidatePaths)
{
    if ([System.IO.File]::Exists($candidatePath))
    {
        Write-Output $candidatePath
        exit 0
    }
}

$vsWherePath = Join-Path ${env:ProgramFiles(x86)} "Microsoft Visual Studio\Installer\vswhere.exe"
if ([System.IO.File]::Exists($vsWherePath))
{
    $discoveredPath = & $vsWherePath -latest -requires Microsoft.Component.MSBuild -find "MSBuild\**\Bin\MSBuild.exe" | Select-Object -First 1
    if ($discoveredPath)
    {
        Write-Output $discoveredPath
        exit 0
    }
}

throw "MSBuild.exe could not be located. Install Visual Studio Build Tools or Visual Studio with MSBuild support."
