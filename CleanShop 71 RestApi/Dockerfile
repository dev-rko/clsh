# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Packages.props", "."]
COPY ["Directory.Build.props", "."]
COPY ["CleanShop 71 RestApi/CleanShop 71 RestApi.csproj", "CleanShop 71 RestApi/"]
COPY ["CleanShop 00 Entities/CleanShop 00 Entities.csproj", "CleanShop 00 Entities/"]
COPY ["CleanShop 01 Common/CleanShop 01 Common.csproj", "CleanShop 01 Common/"]
COPY ["CleanShop 11 Database/CleanShop 11 Database.csproj", "CleanShop 11 Database/"]
COPY ["CleanShop 21 Busines/CleanShop 21 Business.csproj", "CleanShop 21 Busines/"]
COPY ["CleanShop 31 Services/CleanShop 31 Services.csproj", "CleanShop 31 Services/"]
RUN dotnet restore "./CleanShop 71 RestApi/CleanShop 71 RestApi.csproj"
COPY . .
WORKDIR "/src/CleanShop 71 RestApi"
RUN dotnet build "./CleanShop 71 RestApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CleanShop 71 RestApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CleanShop.RestApi.dll"]