
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY Lapka.Pet.Api/Lapka.Pet.Api.csproj Lapka.Pet.Api/Lapka.Pet.Api.csproj
COPY Lapka.Pet.Application/Lapka.Pet.Application.csproj Lapka.Pet.Application/Lapka.Pet.Application.csproj
COPY Lapka.Pet.Core/Lapka.Pet.Core.csproj Lapka.Pet.Core/Lapka.Pet.Core.csproj
COPY Lapka.Pet.Infrastructure/Lapka.Pet.Infrastructure.csproj Lapka.Pet.Infrastructure/Lapka.Pet.Infrastructure.csproj
COPY Lapka.Pet.Api/rsa-public-key.pem Lapka.Pet.Api/rsa-public-key.pem
RUN dotnet restore Lapka.Pet.Api

COPY . .
RUN dotnet publish Lapka.Pet.Api -c release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/out .

ARG BUILD_VERSION
ENV BUILD_VERSION $BUILD_VERSION

ENV ASPNETCORE_URLS=http://+:5040
ENV ASPNETCORE_URLS=http://+:5041

ENTRYPOINT ["dotnet", "Lapka.Pet.Api.dll"]