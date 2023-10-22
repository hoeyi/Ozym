#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
RUN dotnet --version
WORKDIR /src

# Copy the project files /src child directories.
COPY ["Ozym.Web/Ozym.Web.csproj", "Ozym.Web/"]
COPY ["Ozym.DAL/Ozym.DAL.csproj", "Ozym.DAL/"]
COPY ["Ozym.EntityModel/Ozym.EntityModel.csproj", "Ozym.EntityModel/"]
COPY ["Ozym.EntityMigration/Ozym.EntityMigration.csproj", "Ozym.EntityMigration/"]

# Copy the local nuget package repository to /src so that packages may be
# restored if not deployed to the online package repistory.
COPY ".nuget_local/*.*nupkg" "nuget-local/"
RUN ls

# Restore the projects using local nuget packages.
RUN dotnet restore "Ozym.Web/Ozym.Web.csproj" -s "Ozym.Web/nuget_local/" -s "https://api.nuget.org/v3/index.json"
COPY . .
WORKDIR "/src/Ozym.Web"

# Build the web project.
RUN dotnet build "Ozym.Web.csproj" -c Development -o /app/build

# Build the entity migration application to seed the demo database.
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS migration
WORKDIR /src
COPY . .
RUN dotnet restore "Ozym.EntityMigration/Ozym.EntityMigration.csproj"
COPY . .
WORKDIR "/src/Ozym.EntityMigration"
RUN dotnet build "Ozym.EntityMigration.csproj" -c Development -o /app/migration


FROM build AS publish
RUN dotnet publish "Ozym.Web.csproj" -c Development -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /migration
COPY --from=migration /app/migration .

WORKDIR /app
COPY --from=publish /app/publish .
ENV DOTNET_EnableDiagnostics=0
ENTRYPOINT ["dotnet", "Ozym.Web.dll"]