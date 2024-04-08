FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5094

ENV ASPNETCORE_URLS=http://+:5094

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Docker.Container.NetCore.csproj", "./"]
RUN dotnet restore "Docker.Container.NetCore.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Docker.Container.NetCore.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Docker.Container.NetCore.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Docker.Container.NetCore.dll"]
