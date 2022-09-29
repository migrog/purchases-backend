#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 5597
EXPOSE 44307

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["product.api/product.api.csproj", "product.api/"]
RUN dotnet restore "product.api/product.api.csproj"
COPY . .
WORKDIR "/src/product.api"
RUN dotnet build "product.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "product.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "product.api.dll"]