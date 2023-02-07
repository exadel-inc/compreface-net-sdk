FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build-env
WORKDIR /add

COPY bin/Debug/net7.0/publish .

ENTRYPOINT dotnet test "Exadel.Compreface.AcceptenceTests.dll" -l:"console;verbosity=detailed"
