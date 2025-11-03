# Use official .NET 8 SDK (Linux-based) to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY ["Jobs.csproj", "./"]
RUN dotnet restore "./Jobs.csproj"

# Copy the rest of the code and build
COPY . .
RUN dotnet publish "./Jobs.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Use lightweight runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Expose ports (Render usually uses 8080)
EXPOSE 8080
EXPOSE 8081

ENTRYPOINT ["dotnet", "Jobs.dll"]
