FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

COPY ./PayMart.Domain.Login/PayMart.Domain.Login.csproj ./PayMart.Domain.Login/
COPY ./PayMart.Infrastructure.Login/PayMart.Infrastructure.Login.csproj ./PayMart.Infrastructure.Login/
COPY ./PayMart.API.Login/PayMart.API.Login.csproj ./PayMart.API.Login/
RUN dotnet restore ./PayMart.API.Login/PayMart.API.Login.csproj

COPY ./PayMart.Domain.Login ./PayMart.Domain.Login/
COPY ./PayMart.Infrastructure.Login ./PayMart.Infrastructure.Login/
COPY ./PayMart.API.Login ./PayMart.API.Login/

WORKDIR /app/PayMart.API.Login
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/PayMart.API.Login/out .

EXPOSE 5000

ENTRYPOINT ["dotnet", "PayMart.API.Login.dll"]
