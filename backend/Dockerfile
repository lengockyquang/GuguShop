FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy everything
COPY *.sln ./
COPY GuguShop/*.csproj GuguShop/
COPY GuguShop.Application/*.csproj GuguShop.Application/
COPY GuguShop.Domain/*.csproj GuguShop.Domain/
COPY GuguShop.GridFsApplication/*.csproj GuguShop.GridFsApplication/
COPY GuguShop.Infrastructure/*.csproj GuguShop.Infrastructure/
COPY GuguShop.Migrator/*.csproj GuguShop.Migrator/
# Restore as distinct layers
RUN dotnet restore
COPY . .
WORKDIR GuguShop
# Build and publish a release
RUN dotnet publish -c Release -o /app/out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "GuguShop.dll"]