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
- Update the connection string in the Blazor project's `appsettings.json` (or the server project's `appsettings.json`) to point to your SQL Server / LocalDB instance.

4. Apply Entity Framework migrations
- From the solution root or the project that contains the migrations, run:
- Or, using Visual Studio's Package Manager Console:
- If your solution separates the migrations and startup projects, use the `--project` and `--startup-project` options:

5. Run the application
- In Visual Studio 2026: open the solution, set the Blazor project as the startup project, then press F5.
- From the terminal, run from the Blazor project directory (the folder containing the `.csproj`):


- The app will typically be available at `https://localhost:5001` (or the configured launch profile).

## Troubleshooting
- "Cannot find dotnet-ef": install with `dotnet tool install --global dotnet-ef`.
- Migrations fail: ensure the correct connection string and run the migration command from the project that contains the EF migrations or specify `--project/--startup-project`.
- Database permission errors: confirm SQL Server is running and the configured user has permission to create/update the database.

## Notes
- This repository targets .NET 10 and contains a Blazor project — use the Blazor project folder for run/migration commands.
- If you want the README updated with the exact project name or recommended launch profile, tell me which `.csproj` should be used and I will update the instructions.

## License
See repository metadata for license information.
