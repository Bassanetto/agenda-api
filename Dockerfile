FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["agenda-api.csproj", "./"]
RUN dotnet restore "agenda-api.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "agenda-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "agenda-api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "agenda-api.dll"]
