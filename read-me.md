## Install steps  (3 steps)

### I. DB
Here are the commands you can run in PowerShell from the solution root to create the initial EF migration and generate a SQL script.

- Ensure EF CLI is available (optional if already installed):
```powershell
dotnet tool update --global dotnet-ef
```

- Create the initial migration in the Database project:
```powershell
dotnet ef migrations add InitialCreate -p "CleanShop 11 Database" -s "CleanShop 71 RestApi" -o "Migrations"
```

- Generate an idempotent SQL script for the migration:
```powershell
dotnet ef migrations script --idempotent -p "CleanShop 11 Database" -s "CleanShop 71 RestApi" -o "CleanShop 11 Database\Migrations\InitialCreate.sql"
```

- Optional: apply the migration to your local database now:
```powershell
dotnet ef database update -p "CleanShop 11 Database" -s "CleanShop 71 RestApi"
```

- Added EF Core DbContext and configured relationships for `OrderLine` in `ShopDbContext`.
- Refactored repositories to use EF and wired up `AddDbContext`/DI.