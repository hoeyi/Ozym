REM Update the database using the added migration.
dotnet ef database update %migration% ^
	--context NjordinSight.Web.Data.IdentityDbContext ^
	--startup-project NjordinSight.Web.csproj ^
	--project NjordinSight.Web.csproj ^
	--configuration Debug