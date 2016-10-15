del packages/*
rm packages
 
dotnet restore
dotnet build **\project.json
dotnet test test\TvDbSharper.Tests 
dotnet pack -c release -o packages src/TvDbSharper/project.json

$packageName = (dir packages | where { $_.Name -match '^TvDbSharper\.\d+\.\d+\.\d+\.nupkg$' } | select -first 1).Name

nuget push -source https://api.nuget.org/v3/index.json packages/$packageName

pause