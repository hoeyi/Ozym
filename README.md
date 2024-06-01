# Ozym #
**Ozym** is a web-based financial and investment recording-keeping and reporting application for personal use. The app user interface is built with [Blazor](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor) backed by [ASP.NET Core](https://github.com/dotnet/aspnetcore) and Entity Framework and Microsoft SQL Server on Linux for the data persistence layer.

For information on contributing changes to this codebase, see [How to contribute](CONTRIBUTING.md).

## Getting Started
Docker is the recommended approach for exploring the app's features.

### Running Docker app
This approach uses the latest Docker images deployed to [Ozym/Packages](https://github.com/hoeyi?tab=packages&repo_name=Ozym). The Docker images are constructed into a multi-container app that includes:
* **ozymapi**: The RESTful API service component.
* **ozymdb**: The database component.
* **ozymweb**: The Blazor web-service component.

**Download Docker Desktop** <br/>
See [Docker Desktop](https://www.docker.com/products/docker-desktop/) for installation options.

**Download and run the installation script `install-docker-app.sh (coming soon)`.** 

---

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
