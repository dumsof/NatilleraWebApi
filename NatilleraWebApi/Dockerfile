#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["NatilleraWebApi/NatilleraWebApi.csproj", "NatilleraWebApi/"]
COPY ["LoggerService/LoggerService.csproj", "LoggerService/"]
COPY ["Natillera.Aplication/Natillera.Aplication.csproj", "Natillera.Aplication/"]
COPY ["Natillera.DataAccessContract/Natillera.DataAccessContract.csproj", "Natillera.DataAccessContract/"]
COPY ["Natillera.Business/Natillera.Business.csproj", "Natillera.Business/"]
COPY ["Natillera.BusinessContract/Natillera.BusinessContract.csproj", "Natillera.BusinessContract/"]
COPY ["Natillera.CrossClothing/Natillera.CrossClothing.csproj", "Natillera.CrossClothing/"]
COPY ["Natillera.DataAccess/Natillera.DataAccess.csproj", "Natillera.DataAccess/"]
COPY ["Natillera.AplicationContract/Natillera.AplicationContract.csproj", "Natillera.AplicationContract/"]
RUN dotnet restore "NatilleraWebApi/NatilleraWebApi.csproj"
COPY . .
WORKDIR "/src/NatilleraWebApi"
RUN dotnet build "NatilleraWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NatilleraWebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NatilleraWebApi.dll"]