FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build-env
WORKDIR /add

#Copy everything
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Build runtime image
#FROM mcr.microsoft.com/dotnet/aspnet:7.0
#WORKDIR /app
#COPY --from=build-env /app/out .


#ARG dotnet_cli_home_arg=/tmp/
#ENV DOTNET_CLI_HOME=$dotnet_cli_home_arg

ENTRYPOINT ["dotnet", "Exadel.Compreface.AcceptenceTests.dll"]
#ENTRYPOINT dotnet test "Exadel.Compreface.AcceptenceTests.dll" -l:"console;verbosity=detailed" 