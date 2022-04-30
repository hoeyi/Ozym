REM Change working directory to the project direct where FinanceDbContext resides.
cd NjordFinance.DAL

REM Check for expected positional parameter and redirect as needed.
if "%1"=="" goto missingparameter

REM Define context migration event.
set migration=FinanceDbContext_%1

REM Add the migration. Reference the FinanceDbContext with fully-qualified namespace.
dotnet ef migrations add %migration% ^
	--context NjordFinance.Context.FinanceDbContext ^
	--startup-project ..\NjordFinance.Web\NjordFinance.Web.csproj

REM Update the database using the added migration.
dotnet ef database update %migration% ^
	--context NjordFinance.Context.FinanceDbContext ^
	--startup-project ..\NjordFinance.Web\NjordFinance.Web.csproj ^
	--configuration Debug

REM Remove the migration.
dotnet ef migrations remove ^
	--context NjordFinance.Context.FinanceDbContext ^
	--startup-project ..\NjordFinance.Web\NjordFinance.Web.csproj

goto scriptexit

REM Write error message to console describing missing parameter.
:missingparameter
echo Missing positional parameter 'event'

:scriptexit

REM Revert the working directory back to the parent.
cd ..\

