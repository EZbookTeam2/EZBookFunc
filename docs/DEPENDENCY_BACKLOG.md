# Dependency Backlog

Track dependency follow-up items here when they are not resolved in the current release.

## Current audit findings

These warnings were reproduced by `.\scripts\Invoke-ReleaseCheck.ps1` on 2026-06-01.

- `jQuery` `3.4.1`
  - Moderate: `GHSA-jpcq-cgw6-v4j6`
  - Moderate: `GHSA-gxr4-xjj5-5px2`
  - Follow-up: update the package and refresh the checked-in `Scripts/jquery-*` files together.

- `jQuery.Validation` `1.17.0`
  - High: `GHSA-jxwx-85vp-gvwm`
  - Follow-up: update the package and confirm client-side validation behavior still matches the current forms.

- `Microsoft.Data.SqlClient` `1.0.19269.1`
  - Moderate: `GHSA-8g2p-5pqh-5jmc`
  - High: `GHSA-98g6-xh36-x2p7`
  - Follow-up: upgrade carefully because the project is on .NET Framework 4.7.2 and uses an older EF Core stack.

- `Newtonsoft.Json` `12.0.2`
  - High: `GHSA-5crp-9r3c-p9vr`
  - Follow-up: update and rebuild to confirm binding redirects remain correct in `Web.config`.

## Process follow-up

- Dependabot is configured to open weekly NuGet PRs against `master`.
- Keep dependency upgrade commits separate from feature commits so releases remain easier to review.
