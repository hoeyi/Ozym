REM Change working directory to the project direct where FinanceDbContext resides.
cd NjordFinance.DAL

REM Define context migration event.
set context = FinanceDbContext_
set migration = %context% and %1

REM Add the migration. Reference the FinanceDbContext with fully-qualified namespace.
dotnet ef migrations add %migration% ^
	--context NjordFinance.Context.FinanceDbContext ^
	--startup-project ..\NjordFinance.Web\NjordFinance.Web.csproj

REM Update the database using the added migration.
dotnet ef database update %migration% ^
	--context NjordFinance.Context.FinanceDbContext ^
	--startup-project ..\NjordFinance.Web\NjordFinance.Web.csproj

REM Remove the migration.
dotnet ef migrations remove

REM Revert the working directory back to the parent.
cd ..\

