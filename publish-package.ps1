if([System.IO.Directory]::Exists("packages")) {

	Remove-Item -Recurse -Force packages
}
 
dotnet restore
dotnet build src\TvDbSharper\TvDbSharper.csproj
dotnet test test\TvDbSharper.Tests\TvDbSharper.Tests.csproj

dotnet pack src\TvDbSharper\TvDbSharper.csproj -c release -o ./../../packages --include-symbols --include-source

$packageName = (dir packages | where { $_.Name -match '^TvDbSharper\.\d+\.\d+\.\d+\.nupkg$' } | select -first 1).Name

nuget push -ApiKey $env:nuget_key -source https://api.nuget.org/v3/index.json packages/$packageName

pause