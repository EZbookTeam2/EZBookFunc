# Changelog

All notable changes to this repository should be recorded here.

This project follows a simple release log:

- Keep work-in-progress notes under `Unreleased`.
- Move completed items into a dated release section when a release is cut.
- Prefer short, user-visible summaries over low-level edit logs.

## [Unreleased]

### Changed

- Renamed the legacy `Testing9` solution, project, folder, assembly, and namespace identity to `EZBook.Api`.
- Updated local build scripts, release checks, and repository documentation to follow the new `EZBook.Api` naming consistently.

### Fixed

- Reworked the release credential scan to use generic hardcoded-secret checks instead of storing leaked literals in the repository.

## [2026-06-01]

### Added

- Added `.editorconfig`, a repository `README`, and shared infrastructure files for configuration and status handling.
- Added shared API DTOs to keep controller payload shaping in one place.

### Changed

- Standardized the main API controllers around scoped `DbContext` usage, input validation, and clearer response paths.
- Moved database and SMTP settings out of hardcoded controller code and into `Web.config`.

### Fixed

- Removed the hardcoded SMTP credential from the email endpoint.
- Replaced the embedded Entity Framework connection string with a named configuration entry.
