REM Change working directory to the project direct where FinanceDbContext resides.
cd NjordFinance

REM Check for expected positional parameter and redirect as needed.
if "%1"=="" goto missingparameter

REM Define context migration event.
set migration=FinanceDbContext_%1

REM Add the migration. Reference the FinanceDbContext with fully-qualified namespace.
dotnet ef migrations add %migration% ^
	--context NjordFinance.EntityModel.Context.FinanceDbContext ^
	--startup-project ..\NjordFinance.Web\NjordFinance.Web.csproj ^
	--project NjordFinance.EntityModel.csproj

cd ..\