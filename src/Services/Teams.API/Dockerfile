#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Teams.API/Teams.API.csproj", "Services/Teams.API/"]
COPY ["BuildingBlocks/Utilities/Utilities.csproj", "BuildingBlocks/Utilities/"]
RUN dotnet restore "Services/Teams.API/Teams.API.csproj"
COPY . .
WORKDIR "/src/Services/Teams.API"
RUN dotnet build "Teams.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Teams.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Teams.API.dll"]