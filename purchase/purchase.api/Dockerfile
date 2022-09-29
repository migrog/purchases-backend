#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 55122
EXPOSE 44383

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["purchase.api/purchase.api.csproj", "purchase.api/"]
RUN dotnet restore "purchase.api/purchase.api.csproj"
COPY . .
WORKDIR "/src/purchase.api"
RUN dotnet build "purchase.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "purchase.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "purchase.api.dll"]