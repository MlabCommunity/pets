
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

EXPOSE 5040
COPY Lapka.Pet.Api/Lapka.Pet.Api.csproj Lapka.Pet.Api/Lapka.Pet.Api.csproj
COPY Lapka.Pet.Application/Lapka.Pet.Application.csproj Lapka.Pet.Application/Lapka.Pet.Application.csproj
COPY Lapka.Pet.Core/Lapka.Pet.Core.csproj Lapka.Pet.Core/Lapka.Pet.Core.csproj
COPY Lapka.Pet.Infrastructure/Lapka.Pet.Infrastructure.csproj Lapka.Pet.Infrastructure/Lapka.Pet.Infrastructure.csproj
RUN dotnet restore Lapka.Pet.Api

COPY . .
RUN dotnet publish Lapka.Pet.Api -c release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/out .

ARG BUILD_VERSION
ENV BUILD_VERSION $BUILD_VERSION

ENTRYPOINT ["dotnet", "Lapka.Pet.Api.dll"]