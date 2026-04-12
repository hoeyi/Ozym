FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
RUN dotnet --version
RUN dotnet tool install --global dotnet-ef --version 9.0.11
ENV PATH="${PATH}:/root/.dotnet/tools"
WORKDIR /src

# Copy the project files to /src.
COPY ["Ozym.DAL/Ozym.DAL.csproj", "Ozym.DAL/"]
COPY ["Ozym.EntityModel/Ozym.EntityModel.csproj", "Ozym.EntityModel/"]
COPY ["Ozym.EntityMigration/Ozym.EntityMigration.csproj", "Ozym.EntityMigration/"]
COPY ["Ozym.Api/Ozym.Api.csproj", "Ozym.Api/"]
#COPY ["Ozym.DAL.Test/Ozym.DAL.Test.csproj", "Ozym.DAL.Test/"]

# Copy the local nuget package repository to /src so that packages may be
# restored if not deployed to the online package repistory.
ARG NUGET_LOCAL
COPY ["$NUGET_LOCAL/*.*nupkg", "nuget-local/"]

# Restore the projects using local nuget packages.
RUN dotnet restore "Ozym.DAL.Test/Ozym.DAL.Test.csproj" -s "nuget-local/" -s "https://api.nuget.org/v3/index.json"

# Build data migration programs
ARG DOCKER_DATABASE_SERVICE
ENV DOCKER_DATABASE_SERVICE=$DOCKER_DATABASE_SERVICE
ARG DOCKER_API_SERVICE
ENV DOCKER_API_SERVICE=$DOCKER_API_SERVICE

RUN dotnet ef migrations bundle \
    --configuration Release \
    --context Ozym.EntityModel.Context.FinanceDbIntegrationTestContext \
    --startup-project Ozym.Api.csproj \
    --project ../Ozym.EntityMigration/Ozym.EntityMigration.csproj \
    --output /app/migration/ozymworksbundle \
    -r linux-x64 \
    --self-contained \
    --no-build \
    --force;

# test-entrypoint exposes tests as the default executable for the stage
FROM build AS test
ENTRYPOINT ["dotnet", "test", "--no-build", "--logger:trx"]

