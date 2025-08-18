FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY Contracts/Contracts.csproj Contracts/
COPY LogControl/LogControl.csproj LogControl/

RUN dotnet restore LogControl/LogControl.csproj
COPY . .
RUN dotnet publish LogControl/LogControl.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "LogControl.dll"]
