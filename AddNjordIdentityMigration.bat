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
	--project NjordinSight.Web.csproj ^
	--no-build

cd ..\