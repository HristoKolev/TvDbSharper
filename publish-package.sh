#!/usr/bin/env bash

set -exu

rm ./packages -rf
 
dotnet restore
dotnet build src/TvDbSharper/TvDbSharper.csproj
dotnet test test/TvDbSharper.Tests/TvDbSharper.Tests.csproj

dotnet pack src/TvDbSharper/TvDbSharper.csproj -c release -o ./packages --include-symbols --include-source

PACKAGE_PATH=`find "$PWD/packages" -type f | grep 'TvDbSharper\.[0-9]\+\.[0-9]\+\.[0-9]\+\.nupkg$'`

nuget push -ApiKey $NUGET_KEY -source https://api.nuget.org/v3/index.json $PACKAGE_PATH

