#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 42183
EXPOSE 44363

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["user.api/user.api.csproj", "user.api/"]
RUN dotnet restore "user.api/user.api.csproj"
COPY . .
WORKDIR "/src/user.api"
RUN dotnet build "user.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "user.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "user.api.dll"]