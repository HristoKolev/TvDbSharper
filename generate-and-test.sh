#!/usr/bin/env bash
TMP_SOURCE="${BASH_SOURCE[0]}"
while [ -h "$TMP_SOURCE" ]; do
  SCRIPT_PATH="$( cd -P "$( dirname "$TMP_SOURCE" )" >/dev/null 2>&1 && pwd )"
  TMP_SOURCE="$(readlink "$TMP_SOURCE")"
  [[ $TMP_SOURCE != /* ]] && TMP_SOURCE="$SCRIPT_PATH/$TMP_SOURCE"
done
SCRIPT_PATH="$( cd -P "$( dirname "$TMP_SOURCE" )" >/dev/null 2>&1 && pwd )"

HERE=`pwd`

set -eu

# build generator
cd $SCRIPT_PATH/test/GenerateDto && dotnet build

# run generator
cd $SCRIPT_PATH/test/GenerateDto/bin/Debug/net5.0/ && dotnet exec GenerateDto.dll

# build tests
cd $SCRIPT_PATH/test/ManualTests && dotnet build

# run tests
cd $SCRIPT_PATH/test/ManualTests/bin/Debug/net5.0/ && dotnet exec ManualTests.dll

cd $HERE
