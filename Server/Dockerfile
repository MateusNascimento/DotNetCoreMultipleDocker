FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine AS base
WORKDIR /app

FROM microsoft/dotnet:2.2-sdk-alpine AS build
WORKDIR /src
COPY ["Server.csproj", "./"]
RUN dotnet restore "./Server.csproj"
COPY . .
WORKDIR /src/.
RUN dotnet build "Server.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Server.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Server.dll"]
