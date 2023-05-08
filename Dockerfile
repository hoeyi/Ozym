#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NjordFinance.Web/NjordFinance.Web.csproj", "NjordFinance.Web/"]
COPY ["NjordFinance.DAL/NjordFinance.DAL.csproj", "NjordFinance.DAL/"]
COPY ["NjordFinance.EntityModel/NjordFinance.EntityModel.csproj", "NjordFinance.EntityModel/"]
RUN ls

# Copy the local nuget package repository to /src so that packages may be
# restored if not deployed to the online package repistory.
COPY "NjordFinance.Web/bin/nuget_local/*.*nupkg" "NjordFinance.Web/nuget_local/"

# Restore the projects using local nuget packages.
RUN dotnet restore "NjordFinance.Web/NjordFinance.Web.csproj" -s "NjordFinance.Web/nuget_local/" -s "https://api.nuget.org/v3/index.json"
COPY . .
WORKDIR "/src/NjordFinance.Web"

# Build the web project.
RUN dotnet build "NjordFinance.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NjordFinance.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false;PublishProfile=Docker

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV DOTNET_EnableDiagnostics=0
ENTRYPOINT ["dotnet", "NjordFinance.Web.dll"]