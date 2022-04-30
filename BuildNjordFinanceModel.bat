dotnet-ef dbcontext scaffold Name=ConnectionStrings:NjordFinance Microsoft.EntityFrameworkCore.SqlServer ^
    --project NjordFinance.Web\NjordFinance.Web.csproj ^
    --output-dir ..\NjordFinance.DAL\Model ^
    --context-dir ..\NjordFinance.DAL\Context ^
    --context-namespace "NjordFinance.Context" ^
    --namespace "NjordFinance.Model" ^
    --data-annotations ^
    --force
   