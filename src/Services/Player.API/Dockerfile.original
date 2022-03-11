#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Player.API/Player.API.csproj", "Services/Player.API/"]
RUN dotnet restore "Services/Player.API/Player.API.csproj"
COPY . .
WORKDIR "/src/Services/Player.API"
RUN dotnet build "Player.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Player.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Player.API.dll"]