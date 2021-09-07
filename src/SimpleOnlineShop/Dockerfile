#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 2000/udp
EXPOSE 2000/tcp

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/SimpleOnlineShop/SimpleOnlineShop.csproj", "src/"]
RUN dotnet restore "src/SimpleOnlineShop.csproj"
COPY . .
WORKDIR "/src/src"
RUN dotnet build "SimpleOnlineShop.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleOnlineShop.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleOnlineShop.dll"]