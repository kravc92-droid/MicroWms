
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["MicroWms.Api/MicroWms.Api.csproj", "MicroWms.Api/"]
COPY ["MicroWms.Domain/MicroWms.Domain.csproj", "MicroWms.Domain/"]

RUN dotnet restore "MicroWms.Api/MicroWms.Api.csproj"

COPY . .

WORKDIR /src/MicroWms.Api
RUN dotnet publish "MicroWms.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "MicroWms.Api.dll"]
