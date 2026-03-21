# Stage 1 — Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY src/TaskApi/TaskApi.csproj TaskApi/
RUN dotnet restore TaskApi/TaskApi.csproj
COPY src/TaskApi/ TaskApi/
WORKDIR /src/TaskApi
RUN dotnet publish -c Release -o /app/publish

# Stage 2 — Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Fix: run as non-root user
RUN adduser --disabled-password --gecos "" appuser
USER appuser

EXPOSE 8080
ENTRYPOINT ["dotnet", "TaskApi.dll"]