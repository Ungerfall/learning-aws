#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 5432

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/SimpleShoppingCart/SimpleShoppingCart.csproj", "src/SimpleShoppingCart/"]
RUN dotnet restore "src/SimpleShoppingCart/SimpleShoppingCart.csproj"
COPY . .
WORKDIR "/src/src/SimpleShoppingCart"
RUN dotnet build "SimpleShoppingCart.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleShoppingCart.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleShoppingCart.dll"]