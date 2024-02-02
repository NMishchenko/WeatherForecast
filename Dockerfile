FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WeatherForecast.PL/WeatherForecast.PL.csproj", "WeatherForecast.PL/"]
COPY ["WeatherForecast.BLL/WeatherForecast.BLL.csproj", "WeatherForecast.BLL/"]
COPY ["WeatherForecast.DAL/WeatherForecast.DAL.csproj", "WeatherForecast.DAL/"]
RUN dotnet restore "./WeatherForecast.PL/./WeatherForecast.PL.csproj"
COPY . .
WORKDIR "/src/WeatherForecast.PL"
RUN dotnet build "./WeatherForecast.PL.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WeatherForecast.PL.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeatherForecast.PL.dll"]