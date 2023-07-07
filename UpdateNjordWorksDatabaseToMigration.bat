REM Change working directory to the project directory where FinanceDbContext resides.
cd NjordinSight.EntityModel

REM Check for expected positional parameter and redirect as needed.
if "%1"=="" goto missingparameter

REM Define context migration event.
set migration=%1

dotnet ef database update %migration% ^
	--context NjordinSight.EntityModel.Context.FinanceDbContext ^
	--startup-project ..\NjordinSight.Web\NjordinSight.Web.csproj ^
	--project ..\NjordinSight.EntityMigration\NjordinSight.EntityMigration.csproj

goto :finally

:missingparameter
echo "Required 1st positional argument was not provided."

:finally
cd ..\
