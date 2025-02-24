FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
EXPOSE 5000
WORKDIR /app

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5000
ENV ASPNETCORE_ENVIRONMENT=Development
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "LemonadeStand.dll"]
