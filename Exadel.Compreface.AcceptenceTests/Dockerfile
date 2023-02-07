FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine

WORKDIR /tests-app
COPY /Exadel.Compreface.AcceptenceTests/bin/Debug/net7.0/publish .

ARG dotnet_cli_home_arg=/tmp/
ENV DOTNET_CLI_HOME=$dotnet_cli_home_arg

ENTRYPOINT dotnet test "Exadel.Compreface.AcceptenceTests.dll" -l:"console;verbosity=detailed" 