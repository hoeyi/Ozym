REM Change working directory to the project direct where IdentityDbContext resides.
cd NjordinSight.Web

REM Check for expected positional parameter and redirect as needed.
if "%1"=="" goto missingparameter

REM Define context migration event.
set migration=IdentityDbContext_%1

REM Add the migration. Reference the IdentityDbContext with fully-qualified namespace.
dotnet ef migrations add %migration% ^
	--startup-project NjordinSight.Web.csproj ^
	--context NjordinSight.Web.Data.IdentityDbContext ^
	--project NjordinSight.Web.csproj

REM Update the database using the added migration.
dotnet ef database update %migration% ^
	--context NjordinSight.Web.Data.IdentityDbContext ^
	--startup-project NjordinSight.Web.csproj ^
	--project NjordinSight.Web.csproj ^
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