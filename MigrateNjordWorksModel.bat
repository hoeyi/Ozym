REM Change working directory to the project direct where FinanceDbContext resides.
cd NjordinSight

REM Check for expected positional parameter and redirect as needed.
if "%1"=="" goto missingparameter

REM Define context migration event.
set migration=FinanceDbContext_%1

REM Add the migration. Reference the FinanceDbContext with fully-qualified namespace.
dotnet ef migrations add %migration% ^
	--context NjordinSight.EntityModel.FinanceDbContext ^
	--startup-project ..\NjordinSight.Web\NjordinSight.Web.csproj ^
	--project NjordinSight.EntityModel.csproj

REM Update the database using the added migration.
dotnet ef database update %migration% ^
	--context NjordinSight.EntityModel.Context.FinanceDbContext ^
	--startup-project ..\NjordinSight.Web\NjordinSight.Web.csproj ^
	--project NjordinSight.EntityModel.csproj ^
	--configuration Debug

goto scriptexit

REM Write error message to console describing missing parameter.
:missingparameter
echo Missing positional parameter 'event'

:scriptexit

REM Migration use is complete. Delete the migrations and model snapshot.
rmdir Migrations /s

REM Revert the working directory back to the parent.
cd ..\

