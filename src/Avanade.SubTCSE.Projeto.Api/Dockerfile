#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Avanade.SubTCSE.Projeto.Api/Avanade.SubTCSE.Projeto.Api.csproj", "Avanade.SubTCSE.Projeto.Api/"]
COPY ["Avanade.SubTCSE.Projeto.Infra.CrossCutting/Avanade.SubTCSE.Projeto.Infra.CrossCutting.csproj", "Avanade.SubTCSE.Projeto.Infra.CrossCutting/"]
COPY ["Avanade.SubTCSE.Projeto.Infra.Data/Avanade.SubTCSE.Projeto.Infra.Data.csproj", "Avanade.SubTCSE.Projeto.Infra.Data/"]
COPY ["Avanade.SubTCSE.Projeto.Domain/Avanade.SubTCSE.Projeto.Domain.csproj", "Avanade.SubTCSE.Projeto.Domain/"]
COPY ["Avanade.SubTCSE.Projeto.Application/Avanade.SubTCSE.Projeto.Application.csproj", "Avanade.SubTCSE.Projeto.Application/"]
RUN dotnet restore "Avanade.SubTCSE.Projeto.Api/Avanade.SubTCSE.Projeto.Api.csproj"
COPY . .
WORKDIR "/src/Avanade.SubTCSE.Projeto.Api"
RUN dotnet build "Avanade.SubTCSE.Projeto.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Avanade.SubTCSE.Projeto.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Avanade.SubTCSE.Projeto.Api.dll"]