FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CourierLocations.Api/CourierLocations.Api.csproj", "CourierLocations.Api/"]
COPY ["CourierLocations.Infrastructure/CourierLocations.Infrastructure.csproj", "CourierLocations.Infrastructure/"]
COPY ["CourierLocations.Domain/CourierLocations.Domain.csproj", "CourierLocations.Domain/"]
RUN dotnet restore "CourierLocations.Api/CourierLocations.Api.csproj"
COPY . .
WORKDIR "/src/CourierLocations.Api"
RUN dotnet build "CourierLocations.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CourierLocations.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CourierLocations.Api.dll"]
