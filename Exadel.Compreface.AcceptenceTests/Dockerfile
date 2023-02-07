FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine

WORKDIR /tests-app
COPY publish .

# need this to fetch timezone info https://pf-g.slack.com/archives/C02J25G5476/p1644249389596049?thread_ts=1644248635.665829&cid=C02J25G5476
RUN apk add --no-cache tzdata

ARG dotnet_cli_home_arg=/tmp/
ENV DOTNET_CLI_HOME=$dotnet_cli_home_arg 


ENTRYPOINT dotnet test "Exadel.Compreface.AcceptenceTests.dll" -l:"console;verbosity=detailed"