#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
RUN dotnet --version
ENV PATH="${PATH}:/root/.dotnet/tools"
RUN dotnet tool install --global dotnet-ef 

RUN dotnet ef --version

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
WORKDIR "/src/Ozym.Web"

# Build the web project.
RUN dotnet build "Ozym.Web.csproj" -c Release -o /app/build

RUN echo "Publishing build"
FROM build AS publish
RUN dotnet publish "Ozym.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

RUN echo "Creating sample data migrations program"
RUN dotnet ef migrations bundle \
	--configuration Release \
	--context Ozym.EntityModel.Context.FinanceDbContext \
	--startup-project Ozym.Web.csproj \
	--project ../Ozym.EntityMigration/Ozym.EntityMigration.csproj \
	--output /app/migration/ozymefbundle \
	-r linux-x64 \
	--self-contained \
	--no-build \
	--force

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=publish /app/migration .
ENTRYPOINT ["dotnet", "Ozym.Web.dll", "--environment=Development"]