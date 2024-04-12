#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Avanade.SubTCSE.Projeto.Api/Avanade.SubTCSE.Projeto.Api.csproj", "Avanade.SubTCSE.Projeto.Api/"]
COPY ["Avanade.SubTCSE.Projeto.Application/Avanade.SubTCSE.Projeto.Application.csproj", "Avanade.SubTCSE.Projeto.Application/"]
COPY ["Avanade.SubTCSE.Projeto.Domain/Avanade.SubTCSE.Projeto.Domain.csproj", "Avanade.SubTCSE.Projeto.Domain/"]
COPY ["Avanade.SubTCSE.Projeto.Infra.CrossCutting/Avanade.SubTCSE.Projeto.Infra.CrossCutting.csproj", "Avanade.SubTCSE.Projeto.Infra.CrossCutting/"]
COPY ["Avanade.SubTCSE.Projeto.Infra.Database/Avanade.SubTCSE.Projeto.Infra.Database.csproj", "Avanade.SubTCSE.Projeto.Infra.Database/"]
RUN dotnet restore "./Avanade.SubTCSE.Projeto.Api/Avanade.SubTCSE.Projeto.Api.csproj"
COPY . .
WORKDIR "/src/Avanade.SubTCSE.Projeto.Api"
RUN dotnet build "./Avanade.SubTCSE.Projeto.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Avanade.SubTCSE.Projeto.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Avanade.SubTCSE.Projeto.Api.dll"]