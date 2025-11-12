# Etapa de build e publicação
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /app

COPY . .

RUN dotnet publish "SimpleWebApi/SimpleWebApi.csproj" -c Release -o /app/publish

# Etapa final com imagem de runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 80
ENTRYPOINT ["dotnet", "SimpleWebApi.dll"]
