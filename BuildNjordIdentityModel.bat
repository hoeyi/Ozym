REM Change working directory to the project direct where IdentityContext resides.
cd EulerFinancial.Web

REM Add the migration then use it to update the database.
REM Migration should be saved, but retain for example of how to add.
REM dotnet ef migrations add IdentitySupport --context EulerFinancial.Web.Data.IdentityContext
dotnet ef database update --context NjordFinance.Web.Data.IdentityContext

REM revert the working directory back to the parent.
cd ..