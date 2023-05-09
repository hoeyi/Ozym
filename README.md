# NjordinSight #
A web-application for recording and reporting spending and investing activity. Built using Blazor, ASP.NET Core, and Entity Framework Core.

* [Getting Started](#getting-started)
* [Commit Message Guidelines](#commit-message-guidelines)

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
The following scripts may be used to update a target database.

| Script | Usage |
|:--- |:--- |
| **MigrateNjordWorksModel** | Updates the destintation database set in the startup project connection string using the `FinanceDbContext`.
| **MigrateNjordIdentityModel** | Updates the destination database set in the startup project connection string using the `IdentityDbContext`.

## Commit Message Guidelines ##

Commit message guidelines are meant to mirror the style prescribed in [Conventional Commits](https://www.conventionalcommits.org/en/v1.0.0/). Changes to
the types and scope have been made.

Commit messages should follow the format:
```
<type>[optional scope]: <description>
[optional body]
[optional footer]
```

### Type ###
Must be one of the following:

* **build**: Changes that affect the build system or external dependencies
* **design**: Changes to CSS rules or code changes to support UI behavior
* **docs**: Documentation only changes
* **feat**: A new feature
* **fix**: A bug fix
* **perf**: A code change that improves performance
* **refactor**: A code change that neither fixes a bug nor adds a feature
* **revert**: Reverts commit `<hash>`.
* **style**: Changes that do not affect the meaning of the code 
(white-space, formatting, missing semi-colons, etc)
* **test**: Adding missing tests or correcting existing tests

### Scope ###
The scope is the domain affected. Choose one of the following:
* **Blazor**: Blazor pages or components.
* **DAL**: Model repository services and data-transfer objects.
* **EntityModel**: Entity classes and/or ORM.
* **Logic**: Business logic.
* **API-{Name}**: API support where {Name} is the API project (e.g., NjordinSight, or a vendor).

Example: 
```
feat(DAL): add service for using market data API

fix(Blazor): fix unhandled null reference error
```

### Subject ###
The subject contains a succinct description of the change:

* Use the imperative, present tense
* Don't capitalize the first letter
* Don't include punctuation

### Body ###
The body contains the detail of why the change was made:
* Use the imperative, present tense
* Include the motivation for the change with contrast to prior behavior

### Footer ###
The footer contains information on breaking changes. Start with the phrase 
`BREAKING CHANGE:`. Also use this space to reference closing GitHub issues. 

Example:
```
BREAKING CHANGE: Ends support for [NAME] API

Resolves #42 (where #42 is the GitHub issue no.)
```
