FROM microsoft/aspnetcore-build

WORKDIR /home/SavePointApp

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish ./SavePointAPI.csproj -o /run/
WORKDIR /run/
ENTRYPOINT ["dotnet", "SavePointAPI.dll"]