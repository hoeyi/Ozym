#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
RUN dotnet --version
RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"
WORKDIR /src

# Copy the project files to /src.
COPY ["Ozym.DAL/Ozym.DAL.csproj", "Ozym.DAL/"]
COPY ["Ozym.EntityModel/Ozym.EntityModel.csproj", "Ozym.EntityModel/"]
COPY ["Ozym.EntityMigration/Ozym.EntityMigration.csproj", "Ozym.EntityMigration/"]
COPY ["Ozym.Web/Ozym.Web.csproj", "Ozym.Web/"]

# Copy the local nuget package repository to /src so that packages may be
# restored if not deployed to the online package repistory.
COPY [".nuget-local/*.*nupkg", "nuget-local/"]

# Restore the projects using local nuget packages.
RUN dotnet restore "Ozym.Web/Ozym.Web.csproj" -s "nuget-local/" -s "https://api.nuget.org/v3/index.json"
COPY . .
WORKDIR /src/Ozym.Web

# Build the web project.
ARG CONFIGURATION
RUN dotnet build "Ozym.Web.csproj" -c $CONFIGURATION -o /app/build

FROM build AS publish
ARG CONFIGURATION
RUN dotnet publish "Ozym.Web.csproj" -c $CONFIGURATION -o /app/publish /p:UseAppHost=false --property WarningLevel=1

# Build data migration program from version 6.0. Version 7.0 SDK for dotnet-ef tool causes 
# conflict with 6.0 target framework for the projects.
RUN echo "Creating sample data migrations program"
RUN if [ "$CONFIGURATION" -eq "Release" ] ; then \
    dotnet ef migrations bundle \
        --configuration Release \
        --context Ozym.EntityModel.Context.FinanceDbContext \
        --startup-project Ozym.Web.csproj \
        --project ../Ozym.EntityMigration/Ozym.EntityMigration.csproj \
        --output /app/migration/ozymworksbundle \
        -r linux-x64 \
        --self-contained \
        --no-build \
        --force; \
    else \
        echo "Skippig migration bundle creation for non-Release configuration"; \
    fi

RUN echo "Creating identity data migrations program"
RUN if [ "$CONFIGURATION" -eq "Release" ] ; then \
    dotnet ef migrations bundle \
        --configuration Release \
        --context Ozym.Web.Data.IdentityDbContext \
        --startup-project Ozym.Web.csproj \
        --project Ozym.Web.csproj \
        --output /app/migration/ozymidentitybundle \
        -r linux-x64 \
        --self-contained \
        --no-build \
        --force; \
    else \
        echo "Skippig migration bundle creation for non-Release configuration"; \
    fi

FROM base AS final
COPY --from=publish /app/publish /app
COPY --from=publish /app/migration /app
ENTRYPOINT ["dotnet", "Ozym.Web.dll"]