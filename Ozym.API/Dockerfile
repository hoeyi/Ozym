#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
RUN dotnet --version
WORKDIR /src

# Copy the project files to /src.
COPY ["Ozym.API/Ozym.API.csproj", "Ozym.API/"]
COPY ["Ozym.DAL/Ozym.DAL.csproj", "Ozym.DAL/"]
COPY ["Ozym.EntityModel/Ozym.EntityModel.csproj", "Ozym.EntityModel/"]

# Copy the local nuget package repository to /src so that packages may be
# restored if not deployed to the online package repistory.
COPY [".nuget-local/*.*nupkg", "nuget-local/"]

# Restore the projects using local nuget packages.
RUN dotnet restore "Ozym.API/Ozym.API.csproj" -s "nuget-local/" \
	-s "https://api.nuget.org/v3/index.json"
COPY . .
WORKDIR /src/Ozym.API

# Build the web api project.
ARG CONFIGURATION

# TODO: If release build, configure tests to run before publishing.

RUN dotnet publish "Ozym.API.csproj" -c $CONFIGURATION -o /app/publish /p:UseAppHost=false --property WarningLevel=1

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
# Copy the self-signed certificate to the container.
#COPY --from=build /root/.dotnet/corefx/cryptography/x509stores/my/* /root/.dotnet/corefx/cryptography/x509stores/my/
ENTRYPOINT ["dotnet", "Ozym.API.dll"]
