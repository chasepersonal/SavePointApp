FROM microsoft/aspnetcore:2.0-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-nanoserver-1709 AS build
WORKDIR /src
COPY SavePointAPI/SavePointAPI.csproj SavePointAPI/
RUN dotnet restore SavePointAPI/SavePointAPI.csproj
COPY . .
WORKDIR /src/SavePointAPI
RUN dotnet build SavePointAPI.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish SavePointAPI.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SavePointAPI.dll"]
