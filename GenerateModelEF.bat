dotnet-ef dbcontext scaffold Name=ConnectionStrings:EulerFinancial Microsoft.EntityFrameworkCore.SqlServer ^
    --project EulerFinancial.Web\EulerFinancial.Web.csproj ^
    --output-dir ..\EulerFinancial.DAL\Model ^
    --context-dir ..\EulerFinancial.DAL\Context ^
    --context-namespace "EulerFinancial.Context" ^
    --namespace "EulerFinancial.Model" ^
    --data-annotations ^
    --force
   