# NjordinSight #
A web-application for recording and reporting spending and investing activity. Built using Blazor, ASP.NET Core, and Entity Framework Core.

* [Getting Started](#getting-started)
* [Commit Message Guidelines](CONTRIBUTING.md)

## Getting Started
This application may be downloaded in a pre-build Docker image, or compiled from source and/or used to generate a Docker container to host a sample version of the app. For 
* [Download Docker image](#download-docker-image): Likley the easiest and quickest. Requires [Docker Desktop](https://www.docker.com/products/docker-desktop/).
* [Compile from source](#compile-from-source): Possible, but requires downloading and compiling source for select dependent projects. Not recommended.
  * [Deploying to Docker container](#deploying-to-docker-container): If compiling from source, instructions for deploying build to a Docker container. Requires **Docker Desktop**.

<br/>

### **Download Docker image**
**Prerequisites**

You will need **Docker Desktop** and access to the CLI for the local machine.

For most users, running the pre-built Docker image will be the quickest way to spin-up the application. Run the following command to pull the deployed container image.
``` Bash
docker pull ghcr.io/hoeyi/njordinsight:latest
```

Once pulled, you may run the application using the command line:
``` Bash
$ docker container run -dp {HostPort}:{ContainerPort} -t 'ghcr.io/hoeyi/njordinsight:latest'
```

Or by using the **Docker Desktop** GUI.

<br/>

### **Compile from source** 

**Prerequisites**

You will need the .NET CLI to build the project from source, typically made available by installing the .NET SDK, which you may download [here](https://learn.microsoft.com/en-us/dotnet/core/install/windows?tabs=net70).

**Note: This process currently fails due to dependencies on packages not available via the Nuget API.**

**1. Clone the source repository**
``` Bash
$ git clone https://github.com/hoeyi/NjordinSight.git
```
**2. Restore package dependencies**
``` Bash
$ dotnet restore "NjordinSight.Web/NjordinSight.Web.csproj"
```

**3. Update the current launch profile**

There are a few different launch profiles. I recommend using `NjordinSight.Web.InMemory` as it is easy to reproduce. The primary data storage method intended for the application is SQL Server, which profile `NjordinSight.Web` is intended to support.

<br/>

### **Deploying to Docker container**
A Dockerfile is stored in the root fo the project directory for use with constructing an image that can be run as a container using the in-memory database provider. Docker Desktop is required for this process.

**Note: This process currently fails due to dependencies on packages not available via the Nuget API.**

From the projects root directory:

**1. Create the Docker image**
From the projects root directory, where the `Dockerfile` is saved, run the following command:
``` Bash
$ docker build --tag 'njordinsight.web' .
```
This will be build the project into a new Docker image with the tag **njordinsight.web**. 

**2. Run a Docker container from the created image**
```Bash
$ docker container run -dp {HostPort}:{ContainerPort} -t 'njordinsight.web'
```
<br/>

### **Migration Scripts**
The following scripts may be used for creating and applying migrations.

| Script | Usage |
|:--- |:--- |
| **AddNjordWorksMigration** | Adds a new migration using `EntityModel.Context.FinanceDbContext`. Requires a positional parameter 'tagging' the migration. |
**AddNjordIdentityMigration** | Adds a new migration using `Web.Data.IdentityDbContext`. Requires a positional parameter 'tagging' the migration. |
| **UpdateNjordWorksDatabase** | Updates the target database for `NjordinSight.EntityModel` to the most recent migration using `EntityModel.Context.FinanceDbContext`. |
| **UpdateNjordWorksDatabase** | Updates the target database for `NjordinSight.Web` to the most recent migration using `Web.Data.IdentityDbContext`. |
