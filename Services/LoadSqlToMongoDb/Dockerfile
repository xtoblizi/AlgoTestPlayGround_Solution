FROM mcr.microsoft.com/dotnet/core/runtime:2.2-stretch-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["LoadSqlToMongoDb/LoadSqlToMongoDb.csproj", "LoadSqlToMongoDb/"]
RUN dotnet restore "LoadSqlToMongoDb/LoadSqlToMongoDb.csproj"
COPY . .
WORKDIR "/src/LoadSqlToMongoDb"
RUN dotnet build "LoadSqlToMongoDb.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "LoadSqlToMongoDb.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "LoadSqlToMongoDb.dll"]