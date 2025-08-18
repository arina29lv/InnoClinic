FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY Contracts/Contracts.csproj Contracts/
COPY AppointmentControl/AppointmentControl.csproj AppointmentControl/

RUN dotnet restore AppointmentControl/AppointmentControl.csproj
COPY . .
RUN dotnet publish AppointmentControl/AppointmentControl.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "AppointmentControl.dll"]
