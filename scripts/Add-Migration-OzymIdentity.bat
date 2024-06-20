REM Change working directory to the project direct where IdentityDbContext resides.
cd ..\Ozym.Web

REM Check for expected positional parameter and redirect as needed.
if "%1"=="" goto missingparameter

REM Define context migration event.
set migration=%1

REM Add the migration. Reference the IdentityDbContext with fully-qualified namespace.
dotnet ef migrations add %migration% ^
	--startup-project Ozym.Web.csproj ^
	--context Ozym.Web.Data.IdentityDbContext ^
	--project Ozym.Web.csproj ^
	--output-dir Areas/Identity/Migrations

goto :finally

:missingparameter
echo "Required 1st positional argument was not provided."

:finally
cd ..\
