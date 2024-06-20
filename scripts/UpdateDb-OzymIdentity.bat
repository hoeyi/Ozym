REM Change working directory to the project direct where IdentityDbContext resides.
cd Ozym.Web

REM Check for first position parameter denoting the migration to use.
REM Assume latest if undefined.
if "%1%"=="" (
	dotnet ef database update ^
		--context Ozym.Web.Data.IdentityDbContext ^
		--startup-project Ozym.Web.csproj ^
		--project Ozym.Web.csproj
) ^
else (
	REM Define context migration event.
	set migration=%1

	dotnet ef database update %migration% ^
		--context Ozym.Web.Data.IdentityDbContext ^
		--startup-project Ozym.Web.csproj ^
		--project Ozym.Web.csproj
)

cd ..\
