FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk-alpine AS build
WORKDIR /src
COPY ["Client.csproj", "./"]
RUN dotnet restore "./Client.csproj"
COPY . .
WORKDIR /src/.
RUN dotnet build "Client.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Client.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Client.dll"]
