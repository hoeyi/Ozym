dotnet-ef dbcontext scaffold Name=ConnectionStrings:NjordFinance Microsoft.EntityFrameworkCore.SqlServer ^
    --project NjordFinance.Web\NjordFinance.Web.csproj ^
    --output-dir ..\NjordFinance.EntityModel\Model ^
    --context-dir ..\NjordFinance.EntityModel\Context ^
    --context-namespace "NjordFinance.Context" ^
	--context "FinanceDbContext" ^
    --namespace "NjordFinance.EntityModel" ^
    --data-annotations ^
    --force
   