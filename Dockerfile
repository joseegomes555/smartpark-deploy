# ---- Build stage ----
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiar solução e csproj primeiro (melhor cache)
COPY ./src/SmartPark.ApiRest/SmartPark.ApiRest.csproj ./src/SmartPark.ApiRest/
COPY ./src/SmartPark.Data/SmartPark.Data.csproj ./src/SmartPark.Data/
COPY ./src/SmartPark.Contracts/SmartPark.Contracts.csproj ./src/SmartPark.Contracts/

# Restaurar dependências do projeto REST
RUN dotnet restore ./src/SmartPark.ApiRest/SmartPark.ApiRest.csproj

# Copiar o resto do código
COPY . .

# Publicar
RUN dotnet publish ./src/SmartPark.ApiRest/SmartPark.ApiRest.csproj -c Release -o /out

# ---- Runtime stage ----
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /out ./

# Render expõe a porta em $PORT
ENV ASPNETCORE_URLS=http://0.0.0.0:$PORT

ENTRYPOINT ["dotnet", "SmartPark.ApiRest.dll"]
