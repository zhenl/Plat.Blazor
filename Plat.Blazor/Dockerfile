#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Plat.Blazor/Plat.Blazor.csproj", "Plat.Blazor/"]
RUN dotnet restore "Plat.Blazor/Plat.Blazor.csproj"
COPY . .
WORKDIR "/src/Plat.Blazor"
RUN dotnet build "Plat.Blazor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Plat.Blazor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Plat.Blazor.dll"]