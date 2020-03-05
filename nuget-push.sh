#!/usr/bin/env bash

PACKAGE_DIR="./packages";

if [ -d "$PACKAGE_DIR" ]; then
    rm $PACKAGE_DIR -rf
fi

dotnet pack -c release -o $PACKAGE_DIR --include-symbols --include-source

dotnet nuget push $PACKAGE_DIR/**/*.nupkg -k $NUGET_KEY -s https://api.nuget.org/v3/index.json --skip-duplicate
