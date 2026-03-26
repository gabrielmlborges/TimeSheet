FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["TimeSheet.slnx", "./"]
COPY ["TimeSheet.API/TimeSheet.API.csproj", "TimeSheet.API/"]
COPY ["TimeSheet.Application/TimeSheet.Application.csproj", "TimeSheet.Application/"]
COPY ["TimeSheet.Domain/TimeSheet.Domain.csproj", "TimeSheet.Domain/"]
COPY ["TimeSheet.Infrastructure/TimeSheet.Infrastructure.csproj", "TimeSheet.Infrastructure/"]

RUN dotnet restore

COPY . .
WORKDIR "/src/TimeSheet.API"

RUN dotnet build "TimeSheet.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TimeSheet.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

COPY --from=publish /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "TimeSheet.API.dll"]
