# EZBookFunc

Legacy ASP.NET Web API project for room booking, booking approval, cancellation approval, room management, and user management.

## Stack

- .NET Framework 4.7.2
- ASP.NET Web API 2
- Entity Framework Core 3.1
- SQL Server / LocalDB

## Project Layout

- `EZBook.Api/Controllers`: API endpoints
- `EZBook.Api/Models`: EF entities, DbContext, and API DTOs
- `EZBook.Api/Infrastructure`: shared configuration and status helpers
- `EZBook.Api/App_Start`: Web API startup and route registration
- `EZBook.Api/Utils`: password hashing utilities

## Local Setup

1. Restore NuGet packages for `EZBook.Api.sln`.
2. Confirm the `ezbookdatabase` connection string in `EZBook.Api/Web.config`.
3. If email sending is required, fill the `Smtp.*` app settings with environment-specific values.
4. Build the solution with Visual Studio or the Visual Studio MSBuild host (`MSBuild.exe` from the Visual Studio installation).
5. For repeatable local checks, use `.\scripts\Invoke-Build.ps1 -Restore` and `.\scripts\Invoke-ReleaseCheck.ps1`.

## Configuration

The project now reads runtime settings from `Web.config` instead of hardcoding them in controllers:

- `connectionStrings/ezbookdatabase`
- `appSettings` entries under `Smtp.*`

Recommended practice:

- Keep local development values in `Web.config`.
- Override production email secrets with deployment transforms or server-level configuration.

## Release Tracking

- `CHANGELOG.md`: human-readable release history
- `docs/RELEASE_CHECKLIST.md`: repeatable release flow
- `docs/DEPENDENCY_BACKLOG.md`: dependency follow-up items that should be reviewed during release planning
- `.github/workflows/build.yml`: CI build and release check on push and pull request
- `.github/dependabot.yml`: weekly dependency maintenance automation

## Current API Areas

- `api/BookingApplication`
- `api/BookingList`
- `api/BookingListAdmin`
- `api/BookingID`
- `api/ApproveBooking`
- `api/CancelBooking`
- `api/Cancellationsubmit`
- `api/CancellationList`
- `api/ApproveCancel`
- `api/User`
- `api/RegisterUser`
- `api/DeleteUser`
- `api/createRoom`
- `api/Schedule`
- `api/Email`

## Maintenance Notes

- Booking and cancellation status strings are centralized in `EZBook.Api/Infrastructure/StatusValues.cs`.
- Shared API response/projection DTOs live in `EZBook.Api/Models/ApiModels.cs`.
- `ezbookdatabaseContext` now prefers the named connection string from `Web.config`.
- SMTP credentials are no longer embedded in `EmailController`.
