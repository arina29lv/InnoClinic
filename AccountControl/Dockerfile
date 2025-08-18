FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY Contracts/Contracts.csproj Contracts/
COPY AccountControl/AccountControl.csproj AccountControl/

RUN dotnet restore AccountControl/AccountControl.csproj
COPY . .
RUN dotnet publish AccountControl/AccountControl.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "AccountControl.dll"]
