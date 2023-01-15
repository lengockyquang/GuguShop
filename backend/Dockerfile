FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy everything
COPY . /app
# Restore as distinct layers
RUN dotnet restore
WORKDIR GuguShop
# Build and publish a release
RUN dotnet publish -c Release -o /app/out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
RUN sed -i 's/TLSv1.2/TLSv1.0/g' /etc/ssl/openssl.cnf
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "GuguShop.dll"]

FROM mcr.microsoft.com/mssql/server:2022-latest

ARG SA_PASSWORD="Quangle@123"
ENV SA_PASSWORD=$SA_PASSWORD
ENV ACCEPT_EULA="Y"

EXPOSE 1433

RUN mkdir -p /usr/db-init
COPY ./GuguShop.Migrator/*.sql /usr/db-init/

WORKDIR /usr/db-init

RUN ( /opt/mssql/bin/sqlservr & ) \
    | grep -q "Service Broker manager has started" \
    && /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P $SA_PASSWORD -i init-script.sql \
    && pkill sqlservr