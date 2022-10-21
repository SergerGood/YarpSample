FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["YarpSample.Proxy/YarpSample.Proxy.csproj", "YarpSample.Proxy/"]
RUN dotnet restore "YarpSample.Proxy/YarpSample.Proxy.csproj"
COPY . .
WORKDIR "/src/YarpSample.Proxy"
RUN dotnet build "YarpSample.Proxy.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "YarpSample.Proxy.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YarpSample.Proxy.dll"]
