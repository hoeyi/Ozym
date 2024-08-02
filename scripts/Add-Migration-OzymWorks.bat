REM Change working directory to the project directory where FinanceDbContext resides.
cd ..\Ozym.EntityModel

REM Check for expected positional parameter and redirect as needed.
if "%1"=="" goto missingparameter

REM Define context migration event.
set migration=%1

REM Add the migration. Reference the FinanceDbContext with fully-qualified namespace.
dotnet ef migrations add %migration% ^
	--context Ozym.EntityModel.Context.FinanceDbContext ^
	--startup-project ..\Ozym.Web\Ozym.Web.csproj ^
	--project ..\Ozym.EntityMigration\Ozym.EntityMigration.csproj ^
	--output-dir FinanceApp

goto :finally

:missingparameter
echo "Required 1st positional argument was not provided."

:finally
cd ..\
