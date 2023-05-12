REM Change working directory to the project directory where FinanceDbContext resides.
cd NjordinSight.EntityModel

dotnet ef database update ^
	--context NjordinSight.EntityModel.Context.FinanceDbContext ^
	--startup-project ..\NjordinSight.Web\NjordinSight.Web.csproj ^
	--project ..\NjordinSight.EntityMigration\NjordinSight.EntityMigration.csproj

cd ..\