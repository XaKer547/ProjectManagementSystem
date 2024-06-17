FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 7036
EXPOSE 5179

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ProjectManagementSystem.API/ProjectManagementSystem.API.csproj", "ProjectManagementSystem.API/"]
COPY ["ProjectManagementSystem.Application/ProjectManagementSystem.Application.csproj", "ProjectManagementSystem.Application/"]
COPY ["ProjectManagementSystem.Domain/ProjectManagementSystem.Domain.csproj", "ProjectManagementSystem.Domain/"]
COPY ["SharedKernel/SharedKernel.csproj", "SharedKernel/"]
COPY ["ProjectManagementSystem.Infrastucture/ProjectManagementSystem.Infrastucture.csproj", "ProjectManagementSystem.Infrastucture/"]
COPY ["SmartCollege.RabbitMQ.Contracts/SmartCollege.RabbitMQ.Contracts.csproj", "SmartCollege.RabbitMQ.Contracts/"]
RUN dotnet restore "./ProjectManagementSystem.API/ProjectManagementSystem.API.csproj"
COPY . .
WORKDIR "/src/ProjectManagementSystem.API"
RUN dotnet build "./ProjectManagementSystem.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ProjectManagementSystem.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjectManagementSystem.API.dll"]