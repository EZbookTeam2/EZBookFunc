# Release Checklist

Use this checklist before cutting a release from `master`.

## 1. Update release notes

- Review `CHANGELOG.md`.
- Move relevant items from `Unreleased` into a dated release section.
- Keep notes short and grouped into `Added`, `Changed`, and `Fixed`.

## 2. Verify the build

- Run `.\scripts\Invoke-ReleaseCheck.ps1`.
- Confirm the solution builds in `Release`.

## 3. Confirm configuration safety

- Check that `Testing9/Web.config` does not contain production secrets committed to source control.
- Confirm SMTP values are environment-appropriate for the target deployment.
- Confirm the database connection string matches the intended environment.

## 4. Review dependency status

- Review `docs/DEPENDENCY_BACKLOG.md`.
- Decide whether pending package updates are part of the release or deferred.

## 5. Prepare the release

- Create a tag that matches the team’s chosen version or date format.
- Publish the release summary using the matching `CHANGELOG.md` section.
- Attach any deployment notes that are environment-specific.

## 6. Post-release follow-up

- Re-open `Unreleased` in `CHANGELOG.md` for the next cycle.
- Record any rollback notes or hotfix items immediately while they are fresh.
