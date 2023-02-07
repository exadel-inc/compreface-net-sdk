#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Exadel.Compreface.AcceptenceTests/Exadel.Compreface.AcceptenceTests.csproj", "Exadel.Compreface.AcceptenceTests/"]
COPY ["Exadel.Compreface/Exadel.Compreface.csproj", "Exadel.Compreface/"]
RUN dotnet restore "Exadel.Compreface.AcceptenceTests/Exadel.Compreface.AcceptenceTests.csproj"
COPY . .
WORKDIR "/src/Exadel.Compreface.AcceptenceTests"
RUN dotnet build "Exadel.Compreface.AcceptenceTests.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Exadel.Compreface.AcceptenceTests.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Exadel.Compreface.AcceptenceTests.dll"]