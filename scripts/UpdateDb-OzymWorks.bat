REM Change working directory to the project directory where FinanceDbContext resides.
cd ..\Ozym.EntityModel

REM Check for first position parameter denoting the migration to use.
REM Assume latest if undefined.
if "%1%"=="" (
	dotnet ef database update ^
		--context Ozym.EntityModel.Context.FinanceDbContext ^
		--startup-project ..\Ozym.Web\Ozym.Web.csproj ^
		--project ..\Ozym.EntityMigration\Ozym.EntityMigration.csproj
) ^
else (
	REM Define context migration event.
	set migration=%1

	dotnet ef database update %migration% ^
		--context Ozym.EntityModel.Context.FinanceDbContext ^
		--startup-project ..\Ozym.Web\Ozym.Web.csproj ^
		--project ..\Ozym.EntityMigration\Ozym.EntityMigration.csproj
)

cd ..\
