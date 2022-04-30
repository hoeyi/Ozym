REM Change working directory to the project direct where IdentityDbContext resides.
cd NjordFinance.Web

REM Define context migration event.
set context = IdentityDbContext_
set migration = %context% and %1

REM Add the migration. Reference the IdentityDbContext with fully-qualified namespace.
dotnet ef migrations add %migration% ^
	--context NjordFinance.Web.Data.IdentityDbContext

REM Update the database using the added migration.
dotnet ef database update IdentityDbContext_Initialize ^
	--context NjordFinance.Web.Data.IdentityDbContext

REM Remove the migration.
dotnet ef migrations remove

REM Revert the working directory back to the parent.
cd ..\