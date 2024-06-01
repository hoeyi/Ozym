# Ozym #
**Ozym** is a web-based financial and investment recording-keeping and reporting application for personal use. The app user interface is built with [Blazor](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor) and [ASP.NET Core](https://github.com/dotnet/aspnetcore).

For information on contributing changes to this codebase, see [How to contribute](CONTRIBUTING.md).

## Getting Started
Docker is the recommended approach for exploring the app's features. To use Docker, download the 

### Running Docker app
This approach uses the latest Docker images deployed to [Ozym/Packages](https://github.com/hoeyi?tab=packages&repo_name=Ozym).

1. Download [Docker Desktop](https://www.docker.com/products/docker-desktop/).
2. Download the installation script `install-docker-app.sh`.

### **Migration Scripts**
The following scripts may be used for creating and applying migrations. Parameters are listed in order of their position.

#### Add-Migration-OzymIdentity
Adds a new migration using `Web.Data.IdentityDbContext`.</br>
**Parameter(s):** (req) name of the migration to create.

#### Add-Migration-OzymWorks
Adds a new migration using `EntityModel.Context.FinanceDbContext`.</br>
**Parameter(s):** (req) name of the migration to create.

#### UpdateDb-OzymIdentity 
Updates the web identity database target using `Web.Data.IdentityDbContext`.
**Parameter(s)::** (opt) name of the migration to update to.

#### UpdateDb-OzymWorks 
Updates the finance app database target using `EntityModel.Context.FinanceDbContext`.
**Parameter(s)::** (opt) name of the migration to update to.
