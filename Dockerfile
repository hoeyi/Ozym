#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Ozym.Web/Ozym.Web.csproj", "Ozym.Web/"]
COPY ["Ozym.DAL/Ozym.DAL.csproj", "Ozym.DAL/"]
COPY ["Ozym.EntityModel/Ozym.EntityModel.csproj", "Ozym.EntityModel/"]
COPY ["Ozym.EntityMigration/Ozym.EntityMigration.csproj", "Ozym.EntityMigration/"]
RUN ls

# Copy the local nuget package repository to /src so that packages may be
# restored if not deployed to the online package repistory.
COPY "Ozym.Web/bin/nuget_local/*.*nupkg" "Ozym.Web/nuget_local/"

# Restore the projects using local nuget packages.
RUN dotnet restore "Ozym.Web/Ozym.Web.csproj" -s "Ozym.Web/nuget_local/" -s "https://api.nuget.org/v3/index.json"
COPY . .
WORKDIR "/src/Ozym.Web"

# Build the web project.
RUN dotnet build "Ozym.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ozym.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false;PublishProfile=Docker

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV DOTNET_EnableDiagnostics=0
ENTRYPOINT ["dotnet", "Ozym.Web.dll"]