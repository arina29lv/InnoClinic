FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY Contracts/Contracts.csproj Contracts/
COPY StaffControl/StaffControl.csproj StaffControl/

RUN dotnet restore StaffControl/StaffControl.csproj
COPY . .
RUN dotnet publish StaffControl/StaffControl.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "StaffControl.dll"]
