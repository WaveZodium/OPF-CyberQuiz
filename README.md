# OPF-CyberQuiz

Final assignment for the OPF course — a Blazor-based quiz application.

## Prerequisites
- .NET 10 SDK
- Microsoft Visual Studio Community 2026 (recommended) or the `dotnet` CLI
- SQL Server or LocalDB (for the application's database)
- (Optional) EF Core CLI tools: `dotnet-ef` (install with `dotnet tool install --global dotnet-ef`)

## Quick start
1. Clone the repository

2. Restore NuGet packages

3. Configure the database
- Update the connection string in the Blazor/server project's `appsettings.json` (or use user secrets / environment variables) to point to your SQL Server / LocalDB instance.

4. Apply Entity Framework migrations
- This repository already includes EF Core migration files. In Visual Studio you can apply them directly from the Package Manager Console:
  - Ensure the project that contains the `Migrations` folder is selected as the __Default project__ (PMC) and the correct startup project is selected as the solution __Startup Project__.
  - Run:

- CLI alternative (PowerShell):

````````

- Note for Blazor hosted solutions: run the migration command against the server/startup project (not the client) so the correct configuration and services are used.

5. Run the application
- In Visual Studio 2026: open the solution, set the Blazor/server project as the startup project, then press `F5`.
- From the terminal (project folder containing the `.csproj`):

````````

The app typically runs at `https://localhost:5001` (or the configured launch profile).

## Troubleshooting
- "Cannot find dotnet-ef": install with `dotnet tool install --global dotnet-ef`.
- `Update-Database` errors: ensure the correct connection string, the PMC __Default project__ points to the migrations project, and the solution __Startup Project__ is the server/startup project. Use `-Project`/`-StartupProject` flags when necessary.
- Database permission errors: confirm SQL Server is running and the configured user has permission to create/update the database.

## Notes
- This repository targets .NET 10 and contains a Blazor project — use the Blazor/server project folder for run and migration commands.
- Project requirement: do not use JWT authentication.
- If you want the README updated with the exact project `.csproj` names or a recommended launch profile, tell me which `.csproj` to target and I will update the instructions.

## License
See repository metadata for license information.
