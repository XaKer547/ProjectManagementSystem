FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY . .

RUN dotnet restore "./ProjectManagementSystem.API/ProjectManagementSystem.API.csproj"

COPY . .

FROM build AS publish
WORKDIR "ProjectManagementSystem.API"
RUN dotnet publish "./ProjectManagementSystem.API.csproj" --no-restore -c Release -o /app/publish /p:UseAppHost=true

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 7036
EXPOSE 5179

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjectManagementSystem.API.dll"]