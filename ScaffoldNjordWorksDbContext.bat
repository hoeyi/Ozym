dotnet-ef dbcontext scaffold Name=ConnectionStrings:NjordinSight Microsoft.EntityFrameworkCore.SqlServer ^
    --project NjordinSight.Web\NjordinSight.Web.csproj ^
    --output-dir ..\NjordinSight.EntityModel\Model ^
    --context-dir ..\NjordinSight.EntityModel\Context ^
    --context-namespace "NjordinSight.Context" ^
	--context "FinanceDbContext" ^
    --namespace "NjordinSight.EntityModel" ^
    --data-annotations ^
    --force
   