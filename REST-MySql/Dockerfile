FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["REST-MySql/REST-MySql.csproj", "REST-MySql/"]
RUN dotnet restore "REST-MySql/REST-MySql.csproj"
COPY . .
WORKDIR "/src/REST-MySql"
RUN dotnet build "REST-MySql.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "REST-MySql.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "REST-MySql.dll"]